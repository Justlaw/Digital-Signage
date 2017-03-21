using CarteleriaDigital.Pantallas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteleriaDigital
{
    public partial class PanCampaña : Form
    {
        public PanCampaña()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Pantallas.AgregarCampaña abrir = new Pantallas.AgregarCampaña();
            abrir.Show();
            this.SetVisibleCore(false);
          
        }

        private void Campaña_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Pantallas.Eliminar abrir = new Pantallas.Eliminar();
            abrir.Show();
            this.SetVisibleCore(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}