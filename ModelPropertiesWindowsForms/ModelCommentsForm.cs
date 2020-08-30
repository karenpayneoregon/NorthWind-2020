using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelPropertiesWindowsForms
{
    public partial class ModelCommentsForm : Form
    {
        private List<string> _commentList;
        public ModelCommentsForm(List<string> commentList, string modelName)
        {
            InitializeComponent();

            _commentList = commentList;

            Text = $"Comments for: {modelName}";
            Shown += ModelCommentsForm_Shown;
        }

        private void ModelCommentsForm_Shown(object sender, EventArgs e)
        {
            listBox1.DataSource = _commentList;
        }
    }
}
