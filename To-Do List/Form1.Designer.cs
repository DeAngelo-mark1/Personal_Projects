namespace To_Do_List
{
    partial class Form1
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
            btnAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            cblOutput = new CheckedListBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 554);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(342, 45);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Task";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(125, 31);
            label1.Name = "label1";
            label1.Size = new Size(97, 37);
            label1.TabIndex = 1;
            label1.Text = "To-Do ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-10, 52);
            label2.Name = "label2";
            label2.Size = new Size(507, 20);
            label2.TabIndex = 2;
            label2.Text = "___________________________________________________________________________________";
            // 
            // cblOutput
            // 
            cblOutput.FormattingEnabled = true;
            cblOutput.Location = new Point(12, 93);
            cblOutput.Name = "cblOutput";
            cblOutput.Size = new Size(342, 378);
            cblOutput.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(12, 505);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(342, 42);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear List";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 600);
            Controls.Add(btnClear);
            Controls.Add(cblOutput);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label label1;
        private Label label2;
        private CheckedListBox cblOutput;
        private Button btnClear;
    }
}
