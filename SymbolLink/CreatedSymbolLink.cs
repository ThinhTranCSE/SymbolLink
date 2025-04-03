namespace SymbolLink
{
    public partial class CreatedSymbolLink : UserControl
    {
        private readonly SymbolicLink _symbolicLink;

        public CreatedSymbolLink(SymbolicLink symbolicLink)
        {
            InitializeComponent();
            _symbolicLink = symbolicLink;

            sourceTextbox.Text = symbolicLink.Source;
            destinationTextbox.Text = symbolicLink.Destination;

            toggleSymbolButton.Text = symbolicLink.IsUnsymbol ? "Symbol" : "Unsymbol";
        }

        private void ToggleSymbolButton_Click(object sender, EventArgs e)
        {
            if (_symbolicLink.IsUnsymbol)
            {
                Utilities.Instance.CreateSymbolicLink(_symbolicLink.Source, _symbolicLink.Destination);
            }
            else
            {
                Utilities.Instance.UnsymbolLink(_symbolicLink.Source);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Utilities.Instance.DeleteSymbolLink(_symbolicLink.Source);
        }

        private void SrcToDesButton_Click(object sender, EventArgs e)
        {

            if (Utilities.Instance.CopyFiles(_symbolicLink.Source, _symbolicLink.Destination))
            {
                MessageBox.Show("Copy successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Copy failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesToSrcButton_Click(object sender, EventArgs e)
        {
            if (Utilities.Instance.CopyFiles(_symbolicLink.Destination, _symbolicLink.Source))
            {
                MessageBox.Show("Copy successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Copy failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
