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
    public partial class PanBanner : Form
    {
        public PanBanner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
               // if (MessageBox.Show("¿Está seguro que desea salir?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.SetVisibleCore(false);

                    PanCampaña cerrar = new PanCampaña();
                    cerrar.Hide();
                    this.SetVisibleCore(false);

                    Campaña_OR_Banner abrir = new Campaña_OR_Banner();
                    abrir.Show();
                }
           
        }

        private void PanBannerSimple_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanCrearBanner abrir = new PanCrearBanner();
            abrir.Show();
            this.SetVisibleCore(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PanBanner cerrar = new PanBanner();
            cerrar.Hide();
            this.SetVisibleCore(false);

            ListarBanner abrir = new ListarBanner();
            abrir.Show();
        }
    }
}
