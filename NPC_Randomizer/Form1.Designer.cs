namespace NPC_Randomizer
{
    partial class NPC
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Species = new ComboBox();
            NDisplay = new Label();
            TDisplay = new Label();
            GDisplay = new Label();
            DDisplay = new Label();
            Create = new Button();
            ADisplay = new Label();
            lbl7 = new Label();
            MDisplay = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 77);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 23);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 118);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 1;
            label2.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 160);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 2;
            label3.Text = "Gender:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 199);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 23);
            label4.TabIndex = 3;
            label4.Text = "Demeanor:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 9);
            label5.Name = "label5";
            label5.Size = new Size(67, 23);
            label5.TabIndex = 4;
            label5.Text = "Species";
            // 
            // Species
            // 
            Species.FormattingEnabled = true;
            Species.Items.AddRange(new object[] { "Beastfolk", "Human", "Elf", "Tiefling", "Pixie", "Dwarf" });
            Species.Location = new Point(202, 6);
            Species.Name = "Species";
            Species.Size = new Size(205, 31);
            Species.TabIndex = 5;
            Species.Text = "Beastfolk";
            // 
            // NDisplay
            // 
            NDisplay.AutoSize = true;
            NDisplay.Location = new Point(133, 77);
            NDisplay.Name = "NDisplay";
            NDisplay.Size = new Size(25, 23);
            NDisplay.TabIndex = 6;
            NDisplay.Text = "...";
            // 
            // TDisplay
            // 
            TDisplay.AutoSize = true;
            TDisplay.Location = new Point(133, 118);
            TDisplay.Name = "TDisplay";
            TDisplay.Size = new Size(25, 23);
            TDisplay.TabIndex = 7;
            TDisplay.Text = "...";
            // 
            // GDisplay
            // 
            GDisplay.AutoSize = true;
            GDisplay.Location = new Point(133, 160);
            GDisplay.Name = "GDisplay";
            GDisplay.Size = new Size(25, 23);
            GDisplay.TabIndex = 8;
            GDisplay.Text = "...";
            // 
            // DDisplay
            // 
            DDisplay.AutoSize = true;
            DDisplay.Location = new Point(133, 199);
            DDisplay.Name = "DDisplay";
            DDisplay.Size = new Size(25, 23);
            DDisplay.TabIndex = 9;
            DDisplay.Text = "...";
            // 
            // Create
            // 
            Create.Location = new Point(17, 339);
            Create.Name = "Create";
            Create.Size = new Size(446, 48);
            Create.TabIndex = 10;
            Create.Text = "Create NPC";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // ADisplay
            // 
            ADisplay.AutoSize = true;
            ADisplay.Location = new Point(133, 245);
            ADisplay.Name = "ADisplay";
            ADisplay.Size = new Size(25, 23);
            ADisplay.TabIndex = 12;
            ADisplay.Text = "...";
            // 
            // lbl7
            // 
            lbl7.AutoSize = true;
            lbl7.Location = new Point(17, 245);
            lbl7.Margin = new Padding(4, 0, 4, 0);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(67, 23);
            lbl7.TabIndex = 11;
            lbl7.Text = "Animal ";
            // 
            // MDisplay
            // 
            MDisplay.AutoSize = true;
            MDisplay.Location = new Point(133, 292);
            MDisplay.Name = "MDisplay";
            MDisplay.Size = new Size(25, 23);
            MDisplay.TabIndex = 14;
            MDisplay.Text = "...";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 292);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(99, 23);
            label7.TabIndex = 13;
            label7.Text = "Magic type:";
            // 
            // NPC
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 399);
            Controls.Add(MDisplay);
            Controls.Add(label7);
            Controls.Add(ADisplay);
            Controls.Add(lbl7);
            Controls.Add(Create);
            Controls.Add(DDisplay);
            Controls.Add(GDisplay);
            Controls.Add(TDisplay);
            Controls.Add(NDisplay);
            Controls.Add(Species);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 5, 4, 5);
            Name = "NPC";
            Text = "NPC Randomizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox Species;
        private Label NDisplay;
        private Label TDisplay;
        private Label GDisplay;
        private Label DDisplay;
        private Button Create;
        private Label ADisplay;
        private Label lbl7;
        private Label MDisplay;
        private Label label7;
    }
}
