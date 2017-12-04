using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;

namespace CarteleriaDigital.Pantallas
{
    public partial class ListarCampaña : Form
    {      

        public ListarCampaña()
        {
            InitializeComponent();

            DAO.CampañaDAO bd = new DAO.CampañaDAO();
            DataTable dt = bd.SelectCampaña();

            formatearTablaC(dt);

        }

        private void formatearTablaC(DataTable dt)
        {
            dgvVista.DataSource = dt;
            dgvVista.Columns[0].Visible = false;
            dgvVista.Columns[1].Visible = false;
            rbNombre.Checked = true;
            //Formateando ancho de las columnas
            //Columna ID Campaña
            dgvVista.Columns[0].Width = 75;
            //Columna de Activo
            dgvVista.Columns[3].Width = 50;
            // Columnas de las horas de inicio y fin
            dgvVista.Columns[6].Width = 30;
            dgvVista.Columns[7].Width = 30;
            dgvVista.Columns[8].Width = 30;
            dgvVista.Columns[9].Width = 30;

            int filas = dgvVista.Rows.Count;

            for (int i = 0; i <= filas - 1; i++)
            {

                dgvVista[4, i].Value = dgvVista[4, i].Value.ToString().Remove(11);
                dgvVista[5, i].Value = dgvVista[5, i].Value.ToString().Remove(11);
                if (dgvVista[3, i].Value.ToString() == "False")
                {
                    dgvVista[3, i].Value = "No";
                }
                else
                {
                    dgvVista[3, i].Value = "Sí";
                }
            }
        }

        // button4 es el bAtrás
        private void button4_Click(object sender, EventArgs e)
        {
            ListarCampaña cerrar = new ListarCampaña();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanCampaña abrir = new PanCampaña();
            abrir.Show();
        }


        //button1 es el bFiltrar
        private void button1_Click(object sender, EventArgs e)
        {
            int tam = dgvVista.Rows.Count - 1;

            if (rbNombre.Checked)
            {
                for (int i = tam; i >= 0; i--)
                {
                    if (dgvVista.Rows[i].Cells["Nombre"].Value.ToString().ToLower() != cbNombre.Text.ToLower())
                    {
                        dgvVista.Rows.RemoveAt(i);
                    }
                }
            }

            if (rbFecha.Checked)
            {
                for (int i = tam; i >= 0; i--)
                {
                    DateTime inicio, fin;
                    inicio = Convert.ToDateTime(dgvVista.Rows[i].Cells[4].Value.ToString()).Date;
                    fin = Convert.ToDateTime(dgvVista.Rows[i].Cells[5].Value.ToString()).Date;

                    if (inicio > dtHasta.Value || fin < dtDesde.Value)
                    {
                        dgvVista.Rows.RemoveAt(i);
                    }
                }
            }
        }
        //btDesde
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /// Crear una lista y levantar los datos
        }

        private void groupBox1_Enter(object sender, EventArgs e)

        {

        }

        //bModificar
        private void button3_Click(object sender, EventArgs e)
        {
            Pantallas.ModificarCampaña abrir = new Pantallas.ModificarCampaña();
            abrir.Show();
            this.SetVisibleCore(false);
        }
        //bEliminar
        private void Button2_Click(object sender, EventArgs e) {

        }

        private void ListarCampaña_Load(object sender, EventArgs e)

        {

        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            gpFecha.Enabled = false;
            gpNombre.Enabled = true;
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            gpFecha.Enabled = true;
            gpNombre.Enabled = false;
        }
    }
}
