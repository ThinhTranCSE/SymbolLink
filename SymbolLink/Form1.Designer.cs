namespace SymbolLink
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
            sourceTextbox = new TextBox();
            destinationTextbox = new TextBox();
            soureLabel = new Label();
            panel1 = new Panel();
            resetButton = new Button();
            addSymbolLinkButton = new Button();
            panel3 = new Panel();
            sourceBrowseButton = new Button();
            panel2 = new Panel();
            destinationLabel = new Label();
            destinationBrowseButton = new Button();
            linkPanel = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // sourceTextbox
            // 
            sourceTextbox.Location = new Point(73, 12);
            sourceTextbox.Name = "sourceTextbox";
            sourceTextbox.Size = new Size(345, 23);
            sourceTextbox.TabIndex = 0;
            // 
            // destinationTextbox
            // 
            destinationTextbox.Location = new Point(73, 14);
            destinationTextbox.Name = "destinationTextbox";
            destinationTextbox.Size = new Size(345, 23);
            destinationTextbox.TabIndex = 1;
            // 
            // soureLabel
            // 
            soureLabel.AutoSize = true;
            soureLabel.Location = new Point(21, 15);
            soureLabel.Name = "soureLabel";
            soureLabel.Size = new Size(37, 15);
            soureLabel.TabIndex = 2;
            soureLabel.Text = "Soure";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(resetButton);
            panel1.Controls.Add(addSymbolLinkButton);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 187);
            panel1.TabIndex = 3;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(355, 149);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(75, 23);
            resetButton.TabIndex = 9;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += ResetButton_Click;
            // 
            // addSymbolLinkButton
            // 
            addSymbolLinkButton.Location = new Point(436, 149);
            addSymbolLinkButton.Name = "addSymbolLinkButton";
            addSymbolLinkButton.Size = new Size(75, 23);
            addSymbolLinkButton.TabIndex = 8;
            addSymbolLinkButton.Text = "Add";
            addSymbolLinkButton.UseVisualStyleBackColor = true;
            addSymbolLinkButton.Click += AddSymbolLinkButton_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(soureLabel);
            panel3.Controls.Add(sourceTextbox);
            panel3.Controls.Add(sourceBrowseButton);
            panel3.Location = new Point(12, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(508, 46);
            panel3.TabIndex = 7;
            // 
            // sourceBrowseButton
            // 
            sourceBrowseButton.Location = new Point(424, 12);
            sourceBrowseButton.Name = "sourceBrowseButton";
            sourceBrowseButton.Size = new Size(75, 23);
            sourceBrowseButton.TabIndex = 4;
            sourceBrowseButton.Text = "Browse";
            sourceBrowseButton.UseVisualStyleBackColor = true;
            sourceBrowseButton.Click += BrowseSourceButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(destinationLabel);
            panel2.Controls.Add(destinationBrowseButton);
            panel2.Controls.Add(destinationTextbox);
            panel2.Location = new Point(12, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(508, 50);
            panel2.TabIndex = 6;
            // 
            // destinationLabel
            // 
            destinationLabel.AutoSize = true;
            destinationLabel.Location = new Point(3, 17);
            destinationLabel.Name = "destinationLabel";
            destinationLabel.Size = new Size(67, 15);
            destinationLabel.TabIndex = 3;
            destinationLabel.Text = "Destination";
            // 
            // destinationBrowseButton
            // 
            destinationBrowseButton.Location = new Point(424, 14);
            destinationBrowseButton.Name = "destinationBrowseButton";
            destinationBrowseButton.Size = new Size(75, 23);
            destinationBrowseButton.TabIndex = 5;
            destinationBrowseButton.Text = "Browse";
            destinationBrowseButton.UseVisualStyleBackColor = true;
            destinationBrowseButton.Click += DestinationBrowseButton_Click;
            // 
            // linkPanel
            // 
            linkPanel.AutoScroll = true;
            linkPanel.BorderStyle = BorderStyle.FixedSingle;
            linkPanel.Dock = DockStyle.Bottom;
            linkPanel.Location = new Point(0, 193);
            linkPanel.Name = "linkPanel";
            linkPanel.Size = new Size(538, 294);
            linkPanel.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 487);
            Controls.Add(linkPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "SuperMegaVipproTool";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox sourceTextbox;
        private TextBox destinationTextbox;
        private Label soureLabel;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label destinationLabel;
        private Button destinationBrowseButton;
        private Button sourceBrowseButton;
        private Button resetButton;
        private Button addSymbolLinkButton;
        private Panel linkPanel;
    }
}
