using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CarteleriaDigital.Pantallas
{
    public partial class PanOperativa : Form
    {   //Defino variables globales
        bool verCursor = false; 


        public PanOperativa()
        {   //Se inicializan los controles.
            
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(this.teclaPresionada);
            menuStrip1.Visible = false;
            //Defino los atajos de teclado
            
        }



        private void PanOperativa_Load(object sender, EventArgs e)
        {

        }

        private void teclaPresionada(object sender, KeyEventArgs e)
        {   // Oculta/Muestra el cursor y la barrar de control adminstrativo al presionar la tecla F1.
            if (e.KeyCode == Keys.F1)
            {
                ocultarControles();
            }

            //Oculta la barra al presionar Escape.
            if ((e.KeyCode == Keys.Escape) && (menuStrip1.Visible))
            {
                Cursor.Hide(); verCursor = false;
                menuStrip1.Visible = false;
            }
        }
        private void ocultarControles()
        {
            if (verCursor)
            {
                Cursor.Hide(); verCursor = !verCursor;
            }
            else
            {
                Cursor.Show(); verCursor = !verCursor;
            }

            menuStrip1.Visible = !menuStrip1.Visible;
        }
        private void agregarCampañaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarCampaña camp1 = new AgregarCampaña();
            camp1.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaInicio abrir = new PantallaInicio();
            abrir.Show();
            this.Close();
        }

        private void administrarCampañaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaCampañaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pantallas.AcercaDe abrir = new Pantallas.AcercaDe();
            abrir.Show();
        }
    }
}
