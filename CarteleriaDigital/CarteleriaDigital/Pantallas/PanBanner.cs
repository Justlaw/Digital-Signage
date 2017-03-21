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
            CrearBanner abrir = new CrearBanner();
            abrir.Show();
            this.SetVisibleCore(false);
        }
    }
}
