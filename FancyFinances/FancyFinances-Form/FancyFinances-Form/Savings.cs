using FancyFinances_Form;
using FancyFinances_Form.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using static FancyFinances_Form.frmFinance;

namespace FancyFinances_Form
{
    public partial class frmSavings : Form
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly Users _currentUser;
        private readonly BudgetHelper _helper;
        private readonly frmFinance _mainForm;
        public const string SavingsView = "Total Savings: {0:N2}";
        public const string IncomeView = "Total Income: {0:N2}";

        public frmSavings(IDbContextFactory<AppDbContext> contextFactory, Users user, frmFinance mainForm)
        {
            InitializeComponent();
            _contextFactory = contextFactory;
            _currentUser = user;
            _helper = new BudgetHelper(_contextFactory, _currentUser);
            _mainForm = mainForm;
        }

        private void frmSavings_Load(object sender, EventArgs e)
        {
            using var ctx = _contextFactory.CreateDbContext();

            lblSavings.Text = string.Format(SavingsView, _helper.BudgetDisplay("Savings"));
            lblIncome.Text = string.Format(IncomeView, _helper.BudgetDisplay("Income"));
            foreach (var goal in ctx.Goals.Where(g => g.UserID == _currentUser.UserID))
            {
                var goalInfo = $"Goal: {goal.GoalDescription} | Target Amount: R{goal.TargetAmount:N2} | Current Savings: R{goal.AllocatedAmount:N2}";
                rtbGoalView.AppendText(goalInfo + Environment.NewLine);
            }
          

        }

        private void frmSavings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            using var ctx = _contextFactory.CreateDbContext();
            var time = DateTime.Now;
            var amount = (int)(Interaction
                .InputBox("Enter amount to add to income:", "Add Income", "0").Trim() is string input && decimal
                .TryParse(input, out decimal inpAmount) && inpAmount > 0 ? inpAmount : 0);
            var desc = Interaction
                .InputBox("Enter a description for this transaction:", "Transaction Description", "No description").Trim();

            var msg = _helper.AddInOrOut("Income", amount, desc, time);
            lblIncome.Text = string.Format(IncomeView, _helper.BudgetDisplay("Income"));
            _mainForm.AddRecentTransaction(msg);
            _mainForm.SetIncomeButtonText(_helper.BudgetDisplay("Income"));

            _mainForm.LoadTransactionsFromFile();
            _mainForm.UpdateView(ViewMode.Hourly);
            _mainForm.UpdateView(ViewMode.Daily);
            _mainForm.UpdateView(ViewMode.Monthly);
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            using var ctx = _contextFactory.CreateDbContext();
            var time = DateTime.Now;
            var amount = (int)(Interaction
                .InputBox("Enter amount to add to expenses:", "Add an Expense", "0").Trim() is string input && decimal
                .TryParse(input, out decimal inpAmount) && inpAmount > 0 ? inpAmount : 0);
            var desc = Interaction
                .InputBox("Enter a description for this transaction:", "Transaction Description", "No description").Trim();

            var msg = _helper.AddInOrOut("Expenses", amount, desc, time);
            _mainForm.AddRecentTransaction(msg);
            _mainForm.SetExpensesButtonText(_helper.BudgetDisplay("Expenses"));

            _mainForm.LoadTransactionsFromFile();
            _mainForm.UpdateView(ViewMode.Hourly);
            _mainForm.UpdateView(ViewMode.Daily);
            _mainForm.UpdateView(ViewMode.Monthly);
        }

        private void btnAddSavings_Click(object sender, EventArgs e)
        {
            using var ctx = _contextFactory.CreateDbContext();
            var time = DateTime.Now;
            var amount = Interaction.InputBox("Enter amount to add to savings:", "Add Savings", " ").Trim() is string input && decimal.TryParse(input, out decimal inpAmount) && inpAmount > 0 ? inpAmount : 0;
            var Income = ctx.Budgets
                .Where(b => b.BudgetID == _currentUser.UserID)
                .Select(b => b.Income ?? 0m)
                .FirstOrDefault();

            if (amount <= Income && Income > 0)
            {
                var desc = Interaction.InputBox("Enter the description for this savings transaction:", "Description", "No description").Trim();
                var msg = _helper.AddInOrOut("Savings", (int)amount, desc, time);
                _mainForm.AddRecentTransaction(msg);

                Income -= amount;
                lblIncome.Text = string.Format(IncomeView, Income);
                lblSavings.Text = string.Format(SavingsView, _helper.BudgetDisplay("Savings"));

                _mainForm.SetIncomeButtonText(Income);
                _mainForm.SetSavingsButtonText(_helper.BudgetDisplay("Savings"));

                string transfer = $"{time:HH:mm:ss} Transferred R{amount:N2} from Income to Savings\n";
                _mainForm.AddRecentTransaction(transfer);

            }
            else
            {
                MessageBox.Show("You cannot save more than your total income. Please enter a valid amount.");
            }
            ctx.Budgets.FirstOrDefault(b => b.BudgetID == _currentUser.UserID).Income = Income;
            ctx.SaveChanges();

            _mainForm.LoadTransactionsFromFile();
            _mainForm.UpdateView(ViewMode.Hourly);
            _mainForm.UpdateView(ViewMode.Daily);
            _mainForm.UpdateView(ViewMode.Monthly);
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            using var ctx = _contextFactory.CreateDbContext();
            var time = DateTime.Now;
            var goals = ctx.Goals.Where(g => g.UserID == _currentUser.UserID).ToList();
            var Savings = ctx.Budgets
                .Where(b => b.BudgetID == _currentUser.UserID)
                .Select(b => b.Savings ?? 0m)
                .FirstOrDefault();

            var choice = Interaction.InputBox("What Goal would you like to allocate to? Please enter the Goal Description exactly as it appears in the list.", "Allocate Savings", " ").Trim();

            var selectedGoal = goals.FirstOrDefault(g => g.GoalDescription.Equals(choice, StringComparison.OrdinalIgnoreCase));
            if (selectedGoal != null)
            {
                var amount = Interaction.InputBox($"Enter the amount to allocate to {selectedGoal.GoalDescription}:", "Allocate Amount", " ").Trim() is string input && decimal.TryParse(input, out decimal inpAmount) && inpAmount > 0 ? inpAmount : 0;
                if (amount <= Savings)
                {
                    selectedGoal.AllocatedAmount += amount;
                    Savings -= amount;

                    lblSavings.Text = string.Format(SavingsView, Savings);
                    _mainForm.SetSavingsButtonText(Savings);

                    rtbGoalView.Clear();

                    string transfer = $"{time:HH:mm:ss} Transfered R{amount} to the progress of {selectedGoal.GoalDescription}\n ";
                    _mainForm.AddRecentTransaction(transfer);

                    MessageBox.Show($"Successfully allocated R{amount:N2} to {selectedGoal.GoalDescription}. Current allocation: R{selectedGoal.AllocatedAmount:N2}");
                    
                }
                else
                {
                    MessageBox.Show("You cannot allocate more than your total savings. Please enter a valid amount.");
                }
            }
            ctx.Budgets.FirstOrDefault(b => b.BudgetID == _currentUser.UserID).Savings = Savings;
            ctx.SaveChanges();
            frmSavings_Load(sender, e);
        }
        
    }
}
