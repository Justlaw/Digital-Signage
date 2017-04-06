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
    public partial class ModificarCampaña : Form
    {
        public ModificarCampaña()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Al seleccionar una imagen se activa el boton Borrar.
            if (listView1.SelectedIndices.Count != 0)
            { button5.Enabled = true; }
            else { button5.Enabled = false; }
        }
    }
}
