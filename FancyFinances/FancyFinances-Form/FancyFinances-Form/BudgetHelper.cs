using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FancyFinances_Form.Models;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FancyFinances_Form
{
    public class BudgetHelper
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly Users _currentUser;

        public BudgetHelper(IDbContextFactory<AppDbContext> contextFactory, Users user)
        {
            _contextFactory = contextFactory;
            _currentUser = user;
        }

        // ── File paths ──────────────────────────────────────────────────────────────

        /// <summary>
        /// The canonical JSONL file that stores every transaction for graphing.
        /// All code that writes OR reads chart data must use this path.
        /// </summary>
        public string GetTransactionsFilePath()
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FancyFinances");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, $"transactions_{_currentUser.UserID}.jsonl");
        }

        private void AppendTransactionFile(FileTransaction txn)
        {
            try
            {
                var path = GetTransactionsFilePath();
                var line = System.Text.Json.JsonSerializer.Serialize(txn);
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch
            {
                // ignore IO issues
            }
        }

        public List<FileTransaction> ReadFileTransactions(DateTime start, DateTime end)
        {
            try
            {
                var path = GetTransactionsFilePath();
                if (!File.Exists(path)) return new List<FileTransaction>();

                var txns = new List<FileTransaction>();
                foreach (var l in File.ReadAllLines(path))
                {
                    try
                    {
                        var t = System.Text.Json.JsonSerializer.Deserialize<FileTransaction>(l);
                        if (t != null && t.Time >= start && t.Time < end)
                            txns.Add(t);
                    }
                    catch { }
                }
                return txns;
            }
            catch
            {
                return new List<FileTransaction>();
            }
        }

        // ── Budget DB helpers ────────────────────────────────────────────────────────

        public decimal BudgetDisplay(string type)
        {
            using var ctx = _contextFactory.CreateDbContext();

            return type switch
            {
                "Income" => ctx.Budgets
                    .Where(b => b.BudgetID == _currentUser.UserID)
                    .Select(b => b.Income ?? 0m)
                    .Sum(),

                "Expenses" => ctx.Budgets
                    .Where(b => b.BudgetID == _currentUser.UserID)
                    .Select(b => b.Expenses ?? 0m)
                    .Sum(),

                "Savings" => ctx.Budgets
                    .Where(b => b.BudgetID == _currentUser.UserID)
                    .Select(b => b.Savings ?? 0m)
                    .Sum(),

                _ => throw new ArgumentException($"Unknown budget type: {type}")
            };
        }

        private void UpdateBudget(string type, decimal amount)   // FIX: was int, now decimal; FIX: using added
        {
            using var ctx = _contextFactory.CreateDbContext();    // FIX: was missing 'using' – leaked DbContext
            ctx.Budgets
               .Where(b => b.BudgetID == _currentUser.UserID)
               .ToList()
               .ForEach(b =>
               {
                   if (type == "Expenses") b.Expenses = (b.Expenses ?? 0) + amount;
                   else if (type == "Income") b.Income = (b.Income ?? 0) + amount;
                   else if (type == "Savings") b.Savings = (b.Savings ?? 0) + amount;
               });
            ctx.SaveChanges();
        }

        public string AddInOrOut(string type, decimal amount, string description, DateTime time)
        {
            if (type != "Expenses" && type != "Income" && type != "Savings")
                throw new ArgumentException($"Invalid type: {type}");

            UpdateBudget(type, amount);    // FIX: pass decimal, not int

            var newTotal = BudgetDisplay(type);

            AppendTransactionFile(new FileTransaction
            {
                UserID = _currentUser.UserID,
                Time = time,
                Type = type,
                Amount = amount,
                Description = description
            });

            return $" {time:HH:mm:ss} {type} Added: R{amount:N2} - {description}, New total: R{newTotal:N2}\n";
        }
    }
}
