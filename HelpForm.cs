using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBP
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) this.Close(); };
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
