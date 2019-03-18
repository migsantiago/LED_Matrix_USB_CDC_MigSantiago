/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

using System;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Shell;

namespace LED_Matrix_CDC
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblAbout.Text =
                "This is a Demo application for the\n"
                + "LED Matrix CDC board\n"
                + "from MigSantiago.com\n"
                + "Use this software AT YOUR OWN RISK.\n"
                + "Author: Santiago Villafuerte\n"
                + "Twitter: @migsantiagov";
        }
    }
}
