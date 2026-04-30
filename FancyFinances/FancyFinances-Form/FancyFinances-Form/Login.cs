using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using FancyFinances_Form;
using Microsoft.VisualBasic;
using FancyFinances_Form.Models;

namespace FancyFinances_Form
{
    public partial class frmLogin : Form
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public frmLogin(IDbContextFactory<AppDbContext> contextFactory)
        {
            InitializeComponent();
            _contextFactory = contextFactory;
        }

        private async void llbForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Fetches the favourite animal
            string favouriteAnimal = Interaction.InputBox("To reset password, enter your favourite animal:", "Password Recovery", "");

            //makes sure it has a value
            if (string.IsNullOrWhiteSpace(favouriteAnimal)) return;

            try
            {
                //Creates a new context 
                using var ctx = _contextFactory.CreateDbContext();

                //Checks if the username and favourite animal match
                var match = await ctx.Users.FirstOrDefaultAsync(u =>
                    u.Username.Trim() == txtUsername.Text.Trim() &&
                    u.FavouriteAnimal.Trim() == favouriteAnimal.Trim());

                if (match == null)
                {
                    MessageBox.Show("No matching account found.");
                    return;

                }
                //Gets the new password
                var newPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter your new password:", "Reset Password", "");
                if (string.IsNullOrWhiteSpace(newPassword)) return;

                match.Password = newPassword.Trim();
                await ctx.SaveChangesAsync();

                MessageBox.Show("Password reset successful!");
            }
            catch (Exception ex)
            {
                // Show full exception (message + stack) to help diagnose casting issues
                MessageBox.Show($"An Error occured: {ex}\n\nFull exception:\n{ex.ToString()}");
                throw;
            }
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                using var ctx = _contextFactory.CreateDbContext();
                var canConnect = await ctx.Database.CanConnectAsync();
                MessageBox.Show(canConnect ? "Connected!" : "Failed!");
            }
            catch (Exception ex)
            {
                // Show full details to help identify where the invalid cast originates
                MessageBox.Show($"Error connecting to database: {ex}\n\nFull exception:\n{ex.ToString()}");
                throw;
            }

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using var ctx = _contextFactory.CreateDbContext();

            var user = ctx.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show("Login successful!");

                // Open the main finance form
                frmFinance financeFrm = new frmFinance(_contextFactory, user);
                financeFrm.Show();

                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            using var ctx = _contextFactory.CreateDbContext();
            frmCreateAcc createAccFrm = new frmCreateAcc(_contextFactory, this);
            createAccFrm.Show();
            this.Hide();   

        }
    }
}
