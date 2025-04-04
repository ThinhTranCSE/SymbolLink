namespace SymbolLink
{
    partial class Form2
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
            connectButton = new Button();
            panel1 = new Panel();
            refreshButton = new Button();
            label4 = new Label();
            hostTextbox = new TextBox();
            letterComboBox = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            passwordTextbox = new TextBox();
            usernameTextbox = new TextBox();
            fixButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Location = new Point(362, 147);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 0;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += ConnectButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(fixButton);
            panel1.Controls.Add(refreshButton);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(hostTextbox);
            panel1.Controls.Add(letterComboBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(passwordTextbox);
            panel1.Controls.Add(connectButton);
            panel1.Controls.Add(usernameTextbox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 196);
            panel1.TabIndex = 1;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(19, 147);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 10;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 18);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 9;
            label4.Text = "Host";
            // 
            // hostTextbox
            // 
            hostTextbox.Location = new Point(109, 18);
            hostTextbox.Name = "hostTextbox";
            hostTextbox.Size = new Size(328, 23);
            hostTextbox.TabIndex = 8;
            // 
            // letterComboBox
            // 
            letterComboBox.FormattingEnabled = true;
            letterComboBox.Location = new Point(109, 105);
            letterComboBox.Name = "letterComboBox";
            letterComboBox.Size = new Size(328, 23);
            letterComboBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 105);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 6;
            label3.Text = "Letter";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 76);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 47);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(109, 76);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.Size = new Size(328, 23);
            passwordTextbox.TabIndex = 3;
            passwordTextbox.UseSystemPasswordChar = true;
            // 
            // usernameTextbox
            // 
            usernameTextbox.Location = new Point(109, 47);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(328, 23);
            usernameTextbox.TabIndex = 2;
            // 
            // fixButton
            // 
            fixButton.Location = new Point(100, 147);
            fixButton.Name = "fixButton";
            fixButton.Size = new Size(75, 23);
            fixButton.TabIndex = 11;
            fixButton.Text = "Fix";
            fixButton.UseVisualStyleBackColor = true;
            fixButton.Click += FixButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 196);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form2";
            Text = "NetworkDrive";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button connectButton;
        private Panel panel1;
        private TextBox usernameTextbox;
        private TextBox passwordTextbox;
        private ComboBox letterComboBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox hostTextbox;
        private Button refreshButton;
        private Button fixButton;
    }
}