using System.Windows.Forms;

namespace DataGridSimple.Classes
{
    public static class CommonDialogs
    {
        public static bool Question(string pText) => (MessageBox.Show(pText, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        public static bool Question(string pText, string pTitle) => (MessageBox.Show(pText, pTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
    }
}
