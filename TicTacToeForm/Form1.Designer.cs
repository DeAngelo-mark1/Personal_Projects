namespace TicTacToeForm
{
    partial class TTT1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl1 = new Label();
            lbl2 = new Label();
            pnl1 = new Panel();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            lbl3 = new Label();
            pnl1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(12, 9);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(235, 29);
            lbl1.TabIndex = 10;
            lbl1.Text = "Welcome to the Game";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(12, 51);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(90, 19);
            lbl2.TabIndex = 11;
            lbl2.Text = "Player turn:";
            // 
            // pnl1
            // 
            pnl1.BorderStyle = BorderStyle.FixedSingle;
            pnl1.Controls.Add(btn9);
            pnl1.Controls.Add(btn8);
            pnl1.Controls.Add(btn7);
            pnl1.Controls.Add(btn6);
            pnl1.Controls.Add(btn5);
            pnl1.Controls.Add(btn4);
            pnl1.Controls.Add(btn3);
            pnl1.Controls.Add(btn2);
            pnl1.Controls.Add(btn1);
            pnl1.Font = new Font("Calibri", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnl1.Location = new Point(11, 92);
            pnl1.Name = "pnl1";
            pnl1.Size = new Size(350, 350);
            pnl1.TabIndex = 12;
            // 
            // btn9
            // 
            btn9.Location = new Point(232, 231);
            btn9.Name = "btn9";
            btn9.Size = new Size(100, 100);
            btn9.TabIndex = 17;
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(126, 231);
            btn8.Name = "btn8";
            btn8.Size = new Size(100, 100);
            btn8.TabIndex = 16;
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(20, 231);
            btn7.Name = "btn7";
            btn7.Size = new Size(100, 100);
            btn7.TabIndex = 15;
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(232, 125);
            btn6.Name = "btn6";
            btn6.Size = new Size(100, 100);
            btn6.TabIndex = 14;
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(126, 125);
            btn5.Name = "btn5";
            btn5.Size = new Size(100, 100);
            btn5.TabIndex = 13;
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(20, 125);
            btn4.Name = "btn4";
            btn4.Size = new Size(100, 100);
            btn4.TabIndex = 12;
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(232, 19);
            btn3.Name = "btn3";
            btn3.Size = new Size(100, 100);
            btn3.TabIndex = 11;
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(126, 19);
            btn2.Name = "btn2";
            btn2.Size = new Size(100, 100);
            btn2.TabIndex = 10;
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(20, 19);
            btn1.Name = "btn1";
            btn1.Size = new Size(100, 100);
            btn1.TabIndex = 9;
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn_Click;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(119, 51);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(21, 19);
            lbl3.TabIndex = 13;
            lbl3.Text = "...";
            // 
            // TTT1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 456);
            Controls.Add(lbl3);
            Controls.Add(pnl1);
            Controls.Add(lbl2);
            Controls.Add(lbl1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TTT1";
            Text = "Tic-Tac-Toe";
            pnl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl1;
        private Label lbl2;
        private Panel pnl1;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn3;
        private Button btn2;
        private Button btn1;
        private Label lbl3;
    }
}
