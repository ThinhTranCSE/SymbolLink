namespace SymbolLink
{
    partial class CreatedSymbolLink
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            desToSrcButton = new Button();
            srcToDesButton = new Button();
            deleteButton = new Button();
            toggleSymbolButton = new Button();
            destinationTextbox = new TextBox();
            label1 = new Label();
            sourceTextbox = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(desToSrcButton);
            panel1.Controls.Add(srcToDesButton);
            panel1.Controls.Add(deleteButton);
            panel1.Controls.Add(toggleSymbolButton);
            panel1.Controls.Add(destinationTextbox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(sourceTextbox);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(527, 60);
            panel1.TabIndex = 0;
            // 
            // desToSrcButton
            // 
            desToSrcButton.Location = new Point(368, 32);
            desToSrcButton.Name = "desToSrcButton";
            desToSrcButton.Size = new Size(75, 23);
            desToSrcButton.TabIndex = 8;
            desToSrcButton.Text = "DesToSrc";
            desToSrcButton.UseVisualStyleBackColor = true;
            desToSrcButton.Click += DesToSrcButton_Click;
            // 
            // srcToDesButton
            // 
            srcToDesButton.Location = new Point(368, 6);
            srcToDesButton.Name = "srcToDesButton";
            srcToDesButton.Size = new Size(75, 23);
            srcToDesButton.TabIndex = 7;
            srcToDesButton.Text = "SrcToDes";
            srcToDesButton.UseVisualStyleBackColor = true;
            srcToDesButton.Click += SrcToDesButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(449, 32);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // toggleSymbolButton
            // 
            toggleSymbolButton.Location = new Point(449, 5);
            toggleSymbolButton.Name = "toggleSymbolButton";
            toggleSymbolButton.Size = new Size(75, 23);
            toggleSymbolButton.TabIndex = 3;
            toggleSymbolButton.Text = "Unsymbol";
            toggleSymbolButton.UseVisualStyleBackColor = true;
            toggleSymbolButton.Click += ToggleSymbolButton_Click;
            // 
            // destinationTextbox
            // 
            destinationTextbox.Enabled = false;
            destinationTextbox.Location = new Point(88, 32);
            destinationTextbox.Name = "destinationTextbox";
            destinationTextbox.Size = new Size(274, 23);
            destinationTextbox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 9);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Source";
            // 
            // sourceTextbox
            // 
            sourceTextbox.Enabled = false;
            sourceTextbox.Location = new Point(88, 6);
            sourceTextbox.Name = "sourceTextbox";
            sourceTextbox.Size = new Size(274, 23);
            sourceTextbox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 36);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Destination";
            // 
            // CreatedSymbolLink
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "CreatedSymbolLink";
            Size = new Size(532, 66);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        public Button toggleSymbolButton;
        private TextBox sourceTextbox;
        private TextBox destinationTextbox;
        private Button deleteButton;
        private Button desToSrcButton;
        public Button srcToDesButton;
    }
}
