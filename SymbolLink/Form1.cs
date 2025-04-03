namespace SymbolLink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Utilities.Instance.OnSymbolicLinksChanged += DrawLinkPanel;
            DrawLinkPanel(Utilities.Instance.SymbolLinks.Values);
        }

        private void BrowseSourceButton_Click(object sender, EventArgs e)
        {
            sourceTextbox.Text = Utilities.Instance.BrowseFolder();
        }

        private void DestinationBrowseButton_Click(object sender, EventArgs e)
        {
            destinationTextbox.Text = Utilities.Instance.BrowseFolder();
        }

        private void AddSymbolLinkButton_Click(object sender, EventArgs e)
        {
            string source = sourceTextbox.Text;
            string destination = destinationTextbox.Text;

            if (Utilities.Instance.AddSymbolLinkToList(source, destination))
            {
                MessageBox.Show("Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            sourceTextbox.Text = string.Empty;
            destinationTextbox.Text = string.Empty;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Utilities.Instance.SaveSymbolLinks();
        }

        private void DrawLinkPanel(IEnumerable<SymbolicLink> symbolicLinks)
        {
            linkPanel.Controls.Clear();

            int startY = 0;

            foreach (var link in symbolicLinks)
            {
                var createdSymbolLink = new CreatedSymbolLink(link);
                createdSymbolLink.toggleSymbolButton.Text = link.IsUnsymbol ? "Symbol" : "Unsymbol";
                linkPanel.Controls.Add(createdSymbolLink);

                createdSymbolLink.Location = new Point(0, startY);
                startY += createdSymbolLink.Height;

            }
        }
    }
}
