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
    public partial class Campaña_OR_Banner : Form
    {
        public Campaña_OR_Banner()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Campaña_OR_Banner cerrar = new Campaña_OR_Banner();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PantallaInicio abrir = new PantallaInicio();
            abrir.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Campaña_OR_Banner cerrar = new Campaña_OR_Banner();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanCampaña abrir = new PanCampaña();
            abrir.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Campaña_OR_Banner cerrar = new Campaña_OR_Banner();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanBanner abrir = new PanBanner();
            abrir.Show();
        }
    }
}
