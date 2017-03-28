using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteleriaDigital.Pantallas
{
    public partial class ListarCampaña : Form
    {
        public ListarCampaña()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListarCampaña cerrar = new ListarCampaña();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanCampaña abrir = new PanCampaña ();
            abrir.Show();
        }
    }
}
