using FancyFinances_Form.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using static FancyFinances_Form.BudgetHelper;

namespace FancyFinances_Form
{
    public partial class frmFinance : Form
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly Users _currentUser;
        private readonly BudgetHelper _helper;
        private int _goalCount = 1;
        private const int MaxLines = 10;
        private List<FileTransaction> transaction = new List<FileTransaction>();

        public enum ViewMode { Hourly, Daily, Monthly }

        public frmFinance(IDbContextFactory<AppDbContext> contextFactory, Users user)
        {
            InitializeComponent();
            _contextFactory = contextFactory;
            _currentUser = user;
            _helper = new BudgetHelper(_contextFactory, _currentUser);
        }

        //////////////////////////////////Background Logic///////////////////////////////

        private async void frmFinance_Load(object sender, EventArgs e)
        {
            lblWelcome.Text =
                $"Welcome, {_currentUser.Name?.Trim()} " +
                $"{(string.IsNullOrEmpty(_currentUser.Surname) ? "" : " " + _currentUser.Surname.Trim())}!";

            SetIncomeButtonText(_helper.BudgetDisplay("Income"));
            SetExpensesButtonText(_helper.BudgetDisplay("Expenses"));
            SetSavingsButtonText(_helper.BudgetDisplay("Savings"));

            LoadGoals();
            LoadRecentTransactions();

            // FIX: load from the JSONL file that BudgetHelper actually writes to
            LoadTransactionsFromFile();

            timer1.Interval = 1000;
            timer1.Start();

            // Chart axis labels
            frpDaily.Plot.XLabel("Hour of Day");
            frpDaily.Plot.YLabel("Amount (R)");

            frpWeekly.Plot.XLabel("Day");
            frpWeekly.Plot.YLabel("Amount (R)");
            frpWeekly.Plot.Axes.DateTimeTicksBottom();

            frpMonthly.Plot.XLabel("Month");
            frpMonthly.Plot.YLabel("Amount (R)");
            frpMonthly.Plot.Axes.DateTimeTicksBottom();

            UpdateView(ViewMode.Hourly);
            UpdateView(ViewMode.Daily);
            UpdateView(ViewMode.Monthly);
        }

        // ── Chart data helpers ──────────────────────────────────────────────────────

        private (double[] xs, double[] ys) GetHourlyData(List<FileTransaction> transactions)
        {
            var hourly = transactions
                .GroupBy(t => t.Time.Hour)
                .Select(g => new { Hour = g.Key, Amount = g.Sum(t => t.Amount) })
                .OrderBy(x => x.Hour)
                .ToList();

            return (
                hourly.Select(x => (double)x.Hour).ToArray(),
                hourly.Select(x => (double)x.Amount).ToArray()
            );
        }

        private (double[] xs, double[] ys) GetDailyData(List<FileTransaction> transactions)
        {
            var daily = transactions
                .GroupBy(t => t.Time.Date)
                .Select(g => new { Day = g.Key, Amount = g.Sum(t => t.Amount) })
                .OrderBy(x => x.Day)
                .ToList();

            return (
                daily.Select(x => x.Day.ToOADate()).ToArray(),
                daily.Select(x => (double)x.Amount).ToArray()
            );
        }

        private (double[] xs, double[] ys) GetMonthlyData(List<FileTransaction> transactions)
        {
            var monthly = transactions
                .GroupBy(t => new { t.Time.Year, t.Time.Month })
                .Select(g => new { Month = new DateTime(g.Key.Year, g.Key.Month, 1), Amount = g.Sum(t => t.Amount) })
                .OrderBy(x => x.Month)
                .ToList();

            return (
                monthly.Select(x => x.Month.ToOADate()).ToArray(),
                monthly.Select(x => (double)x.Amount).ToArray()
            );
        }

        public void UpdateView(ViewMode mode)
        {
            if (mode == ViewMode.Hourly)
            {
                var (xs, ys) = GetHourlyData(transaction);
                frpDaily.Plot.Clear();
                if (xs.Length > 0)
                {
                    frpDaily.Plot.Add.Scatter(xs, ys);
                    // FIX: set sensible axis limits so hours 0-23 always show correctly
                    frpDaily.Plot.Axes.SetLimitsX(0, 23);
                    frpDaily.Plot.Axes.AutoScaleY();
                }
                frpDaily.Refresh();
            }
            else if (mode == ViewMode.Daily)
            {
                var (xs, ys) = GetDailyData(transaction);
                frpWeekly.Plot.Clear();
                if (xs.Length > 0)
                {
                    frpWeekly.Plot.Add.Scatter(xs, ys);
                    frpWeekly.Plot.Axes.AutoScale();
                }
                frpWeekly.Refresh();
            }
            else
            {
                var (xs, ys) = GetMonthlyData(transaction);
                frpMonthly.Plot.Clear();
                if (xs.Length > 0)
                {
                    frpMonthly.Plot.Add.Scatter(xs, ys);
                    frpMonthly.Plot.Axes.AutoScale();
                }
                frpMonthly.Refresh();
            }
        }

        // ── Transaction file I/O ────────────────────────────────────────────────────

        public void LoadTransactionsFromFile()
        {
            // FIX: use _helper.GetTransactionsFilePath() — same path BudgetHelper writes to
            var path = _helper.GetTransactionsFilePath();
            if (!File.Exists(path)) return;

            var list = new List<FileTransaction>();
            foreach (var raw in File.ReadLines(path))
            {
                var line = raw?.Trim();
                if (string.IsNullOrEmpty(line)) continue;
                try
                {
                    var ft = System.Text.Json.JsonSerializer.Deserialize<FileTransaction>(line);
                    if (ft != null) list.Add(ft);
                }
                catch (System.Text.Json.JsonException) { }   // skip malformed lines silently
            }

            transaction = list;
        }

        /// Path for the human-readable recent-transactions display (separate from JSONL chart data)
        private string GetRecentTransactionsFilePath()
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FancyFinances");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"recent_{_currentUser.UserID}.txt");
        }

        private void LoadRecentTransactions()
        {
            try
            {
                var path = GetRecentTransactionsFilePath();
                if (File.Exists(path))
                {
                    var lines = File.ReadAllLines(path);
                    rtbRecentTransactions.Lines = lines;
                    rtbTransactions.Lines = lines;
                }
            }
            catch { }
        }

        private void SaveRecentTransactions()
        {
            try
            {
                var path = GetRecentTransactionsFilePath();
                // FIX: was writing twice, second call overwrote the first.
                // The two boxes should stay in sync; just write once from rtbRecentTransactions.
                File.WriteAllLines(path, rtbRecentTransactions.Lines ?? Array.Empty<string>());
            }
            catch { }
        }

        public void AddRecentTransaction(string message)
        {
            try
            {
                if (InvokeRequired) { Invoke(() => AddRecentTransaction(message)); return; }
                rtbRecentTransactions.AppendText(message);
                rtbTransactions.AppendText(message);
                SaveRecentTransactions();
            }
            catch { }
        }

        // ── Timer ───────────────────────────────────────────────────────────────────

        private void timer1_Tick(object sender, EventArgs e)
        {
            var now = $"Today is {DateTime.Now:dddd, MMMM dd, yyyy, HH:mm:ss}";
            lblToday1.Text = now;
            lblToday2.Text = now;
            lblToday3.Text = now;
            lblToday4.Text = now;
        }

        // ── RichTextBox overflow guards ─────────────────────────────────────────────-

        private void rtbRecentTransactions_TextChanged(object sender, EventArgs e)
        {
            if (rtbRecentTransactions.Lines.Length > MaxLines)
            {
                var lines = rtbRecentTransactions.Lines.ToList();
                lines.RemoveAt(0);
                rtbRecentTransactions.Lines = lines.ToArray();
            }
        }

        private void rtbTransactions_TextChanged(object sender, EventArgs e)
        {
            if (rtbTransactions.Lines.Length > MaxLines)
            {
                var lines = rtbTransactions.Lines.ToList();
                lines.RemoveAt(0);
                rtbTransactions.Lines = lines.ToArray();
            }
        }

        // ── Goals ────────────────────────────────────────────────────────────────────

        private void LoadGoals()
        {
            try
            {
                using var ctx = _contextFactory.CreateDbContext();
                var goals = ctx.Goals.Where(g => g.UserID == _currentUser.UserID).ToList();
                foreach (var goal in goals)
                    CreateGoalPanelFromGoal(goal);
            }
            catch { }
        }

        private void CreateGoalPanelFromGoal(Models.Goals goal)
        {
            var goalPanel = new Panel
            {
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(796, 67),
                Margin = new Padding(3)
            };

            var lbl = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Location = new Point(6, 9),
                Text = $"{goal.GoalDescription} - R{goal.AllocatedAmount:N2} / R{goal.TargetAmount:N2}",
                Name = $"lblGoal_{_goalCount}"
            };

            var pgb = new ProgressBar
            {
                Location = new Point(6, 37),
                Size = new Size(782, 23),
                Name = $"pgbGoal_{_goalCount}",
                Maximum = 100,
                Value = 0,
                Tag = goal
            };

            var addBtn = new Button
            {
                Location = new Point(694, 5),
                Size = new Size(94, 30),
                Text = "Add Money",
                Name = $"btnAdd_{_goalCount}"
            };

            addBtn.Click += btnAddMoney_Click;

            int percent = goal.TargetAmount > 0
                ? (int)Math.Min(100, Math.Round((double)(goal.AllocatedAmount / goal.TargetAmount) * 100))
                : 0;
            pgb.Value = Math.Max(0, Math.Min(100, percent));

            goalPanel.Controls.Add(lbl);
            goalPanel.Controls.Add(pgb);
            goalPanel.Controls.Add(addBtn);
            flpGoals.Controls.Add(goalPanel);
            _goalCount++;
        }

        // ── Button Click Handlers ────────────────────────────────────────────────────

        private void btnSavings_Click(object sender, EventArgs e)
        {
            var savingsFrm = new frmSavings(_contextFactory, _currentUser, this);
            savingsFrm.Show();
        }

        private void btnAddGoal_Click(object sender, EventArgs e)
        {
            string goalName = Interaction.InputBox("Enter goal name:", "Add Goal", "New Goal");
            if (string.IsNullOrWhiteSpace(goalName)) return;

            string targetStr = Interaction.InputBox("Enter target amount (e.g. 1000.00):", "Add Goal", "0");
            if (!decimal.TryParse(targetStr, out decimal target) || target <= 0)
            {
                MessageBox.Show("Invalid target amount.");
                return;
            }

            using var ctx = _contextFactory.CreateDbContext();
            var goalEntity = new Goals
            {
                GoalDescription = goalName,
                TargetAmount = target,
                AllocatedAmount = 0m,
                UserID = _currentUser.UserID
            };
            ctx.Goals.Add(goalEntity);
            ctx.SaveChanges();
            CreateGoalPanelFromGoal(goalEntity);
        }

        private void btnAddMoney_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Parent is not Panel parent) return;

            var pgb = parent.Controls.OfType<System.Windows.Forms.ProgressBar>().FirstOrDefault();
            var lbl = parent.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault();
            if (pgb == null || lbl == null || pgb.Tag is not Goals data) return;

            string amountStr = Interaction.InputBox("Enter amount to add:", "Add Money", "0");
            if (!decimal.TryParse(amountStr, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            data.AllocatedAmount += amount;

            int percent = data.TargetAmount > 0
                ? (int)Math.Min(100, Math.Round((double)(data.AllocatedAmount / data.TargetAmount) * 100))
                : 0;
            pgb.Value = Math.Max(0, Math.Min(100, percent));
            lbl.Text = $"{data.GoalDescription} - R{data.AllocatedAmount:N2} / R{data.TargetAmount:N2}";

            try
            {
                using var ctx = _contextFactory.CreateDbContext();
                var goalToUpdate = ctx.Goals.Find(data.GoalID);
                if (goalToUpdate != null)
                {
                    
                    goalToUpdate.AllocatedAmount = data.AllocatedAmount;
                    ctx.SaveChanges();
                }
            }
            catch { }

           
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now;

            // FIX: keep as decimal, not cast to int
            string input = Interaction.InputBox("Enter amount to add to expenses:", "Add an Expense", "0").Trim();
            if (!decimal.TryParse(input, out decimal amount) || amount <= 0) return;

            string desc = Interaction.InputBox("Enter a description:", "Transaction Description", "No description").Trim();

            var msg = _helper.AddInOrOut("Expenses", amount, desc, time);
            AddRecentTransaction(msg);
            SetExpensesButtonText(_helper.BudgetDisplay("Expenses"));

            LoadTransactionsFromFile();
            UpdateView(ViewMode.Hourly);
            UpdateView(ViewMode.Daily);
            UpdateView(ViewMode.Monthly);
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now;

            // FIX: keep as decimal, not cast to int
            string input = Interaction.InputBox("Enter amount to add to income:", "Add Income", "0").Trim();
            if (!decimal.TryParse(input, out decimal amount) || amount <= 0) return;

            string desc = Interaction.InputBox("Enter a description:", "Transaction Description", "No description").Trim();

            var msg = _helper.AddInOrOut("Income", amount, desc, time);
            AddRecentTransaction(msg);
            SetIncomeButtonText(_helper.BudgetDisplay("Income"));

            LoadTransactionsFromFile();
            UpdateView(ViewMode.Hourly);
            UpdateView(ViewMode.Daily);
            UpdateView(ViewMode.Monthly);
        }

        ///////////////////////////Button Setters//////////////////////////////////////

        public void SetIncomeButtonText(decimal amount) => btnIncome.Text = $"Income: R{amount:N2}";
        public void SetExpensesButtonText(decimal amount) => btnExpenses.Text = $"Expenses: R{amount:N2}";
        public void SetSavingsButtonText(decimal amount) => btnSavings.Text = $"Savings: R{amount:N2}";
    }
}
