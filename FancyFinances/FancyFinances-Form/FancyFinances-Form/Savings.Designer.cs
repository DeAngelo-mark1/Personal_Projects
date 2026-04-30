namespace FancyFinances_Form
{
    partial class frmSavings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblIncome = new Label();
            label3 = new Label();
            label5 = new Label();
            lblSavings = new Label();
            panel2 = new Panel();
            btnViewGoals = new Button();
            rtbGoalView = new RichTextBox();
            label2 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            btnAddSavings = new Button();
            btnAddIncome = new Button();
            btnAddExpense = new Button();
            btnAllocate = new Button();
            label1 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblIncome);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblSavings);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 128);
            panel1.TabIndex = 0;
            // 
            // lblIncome
            // 
            lblIncome.AutoSize = true;
            lblIncome.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncome.Location = new Point(4, 88);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(123, 25);
            lblIncome.TabIndex = 3;
            lblIncome.Text = "Total Income:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 13);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(153, 25);
            label3.TabIndex = 0;
            label3.Text = "Savings Balance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-16, 26);
            label5.Name = "label5";
            label5.Size = new Size(486, 21);
            label5.TabIndex = 2;
            label5.Text = "____________________________________________________________________";
            // 
            // lblSavings
            // 
            lblSavings.AutoSize = true;
            lblSavings.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSavings.Location = new Point(4, 57);
            lblSavings.Name = "lblSavings";
            lblSavings.Size = new Size(125, 25);
            lblSavings.TabIndex = 1;
            lblSavings.Text = "Total Savings:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnViewGoals);
            panel2.Controls.Add(rtbGoalView);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 136);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 324);
            panel2.TabIndex = 0;
            // 
            // btnViewGoals
            // 
            btnViewGoals.Location = new Point(4, 321);
            btnViewGoals.Name = "btnViewGoals";
            btnViewGoals.Size = new Size(244, 30);
            btnViewGoals.TabIndex = 5;
            btnViewGoals.Text = "View Goals";
            btnViewGoals.UseVisualStyleBackColor = true;
            // 
            // rtbGoalView
            // 
            rtbGoalView.Location = new Point(0, 51);
            rtbGoalView.Name = "rtbGoalView";
            rtbGoalView.Size = new Size(253, 262);
            rtbGoalView.TabIndex = 4;
            rtbGoalView.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(4, 13);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 25);
            label2.TabIndex = 0;
            label2.Text = "Goals";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-69, 27);
            label6.Name = "label6";
            label6.Size = new Size(486, 21);
            label6.TabIndex = 3;
            label6.Text = "____________________________________________________________________";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnAddSavings);
            panel3.Controls.Add(btnAddIncome);
            panel3.Controls.Add(btnAddExpense);
            panel3.Controls.Add(btnAllocate);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(283, 156);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(136, 304);
            panel3.TabIndex = 0;
            // 
            // btnAddSavings
            // 
            btnAddSavings.Location = new Point(4, 234);
            btnAddSavings.Name = "btnAddSavings";
            btnAddSavings.Size = new Size(124, 55);
            btnAddSavings.TabIndex = 7;
            btnAddSavings.Text = "Add Savings";
            btnAddSavings.UseVisualStyleBackColor = true;
            btnAddSavings.Click += btnAddSavings_Click;
            // 
            // btnAddIncome
            // 
            btnAddIncome.Location = new Point(4, 112);
            btnAddIncome.Name = "btnAddIncome";
            btnAddIncome.Size = new Size(124, 55);
            btnAddIncome.TabIndex = 6;
            btnAddIncome.Text = "Add an Income";
            btnAddIncome.UseVisualStyleBackColor = true;
            btnAddIncome.Click += btnAddIncome_Click;
            // 
            // btnAddExpense
            // 
            btnAddExpense.Location = new Point(3, 173);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(123, 55);
            btnAddExpense.TabIndex = 5;
            btnAddExpense.Text = "Add an Expense";
            btnAddExpense.UseVisualStyleBackColor = true;
            btnAddExpense.Click += btnAddExpense_Click;
            // 
            // btnAllocate
            // 
            btnAllocate.Location = new Point(3, 51);
            btnAllocate.Name = "btnAllocate";
            btnAllocate.Size = new Size(124, 55);
            btnAllocate.TabIndex = 4;
            btnAllocate.Text = "Allocate Savings";
            btnAllocate.UseVisualStyleBackColor = true;
            btnAllocate.Click += btnAllocate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "Actions";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(-189, 27);
            label7.Name = "label7";
            label7.Size = new Size(486, 21);
            label7.TabIndex = 3;
            label7.Text = "____________________________________________________________________";
            // 
            // frmSavings
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(424, 461);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmSavings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Savings";
            Load += frmSavings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Label label1;
        private Label label5;
        private Label lblSavings;
        private Label label6;
        private Label label7;
        private Button btnAddIncome;
        private Button btnAddExpense;
        private Button btnAllocate;
        private Button btnViewGoals;
        private RichTextBox rtbGoalView;
        private Button btnAddSavings;
        private Label lblIncome;
    }
}