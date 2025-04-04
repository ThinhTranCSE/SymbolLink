namespace SymbolLink
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hostTextbox.Text) || string.IsNullOrEmpty(letterComboBox.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string host = hostTextbox.Text;
            string letter = letterComboBox.Text;
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;

            if (Utilities.Instance.ConnectNetworkDrive(letter, host, username, password))
            {
                MessageBox.Show("Connected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to connect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshLetterComboBox();
        }

        private void RefreshLetterComboBox()
        {
            var availableLetters = DriveUtilities.GetAvailableDriveLetters();

            letterComboBox.Items.Clear();

            letterComboBox.Items.AddRange(availableLetters);

            if (availableLetters.Length > 0)
            {
                letterComboBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No available drive letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshLetterComboBox();
        }

        private void FixButton_Click(object sender, EventArgs e)
        {
            DriveUtilities.AllowInsecureGuestLogin();
        }
    }
}
