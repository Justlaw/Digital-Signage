using CarteleriaDigital.Controladores;
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
    public partial class ListarBanner : Form
    {
        public ListarBanner()
        {
            InitializeComponent();

            DAO.BannerDAO bd = new DAO.BannerDAO();
            DataTable dt = bd.SelectBannersConRango();

            formatearTabla(dt);
        }


        private void formatearTabla(DataTable dt)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            rbPorNombre.Checked = true;

            //Formateando ancho de las columnas
            //Columna ID banner
            dataGridView1.Columns[1].Width = 30;
            //Columna de Activo
            dataGridView1.Columns[4].Width = 45;
            // Columnas de las horas de inicio y fin
            dataGridView1.Columns[7].Width = 25;
            dataGridView1.Columns[8].Width = 25;
            dataGridView1.Columns[9].Width = 25;
            dataGridView1.Columns[10].Width = 25;

            int filas = dataGridView1.Rows.Count;

            for (int i = 0; i <= filas - 1; i++)
            {
                dataGridView1[5, i].Value = dataGridView1[5, i].Value.ToString().Remove(11);
                dataGridView1[6, i].Value = dataGridView1[6, i].Value.ToString().Remove(11);
                if (dataGridView1[4, i].Value.ToString() == "False")
                {
                    dataGridView1[4, i].Value = "No";
                }
                else
                {
                    dataGridView1[4, i].Value = "Sí";
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListarBanner cerrar = new ListarBanner();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanBanner abrir = new PanBanner();
            abrir.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gpFechas.Enabled = false;
            gpPorNombre.Enabled = true;
            gpTipo.Enabled = false;
        }


        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            gpPorNombre.Enabled = false;
            gpTipo.Enabled = true;
            gpFechas.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gpPorNombre.Enabled = false;
            gpTipo.Enabled = false;
            gpFechas.Enabled = true;
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int tam = dataGridView1.Rows.Count - 1;

            if (rbPorNombre.Checked)
            {
                for (int i = tam; i >= 0; i--)
                {
                    if (dataGridView1.Rows[i].Cells["Nombre"].Value.ToString().ToLower() != txtNombre.Text.ToLower())
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }

            if (rbTipo.Checked)
            {
                for (int i = tam; i >= 0; i--)
                {
                    if (dataGridView1.Rows[i].Cells["Tipo"].Value.ToString() != cbTipo.Text)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }


            if (rbFechas.Checked)
            {

                for (int i = tam; i >= 0; i--)
                {
                    DateTime inicio, fin;
                    inicio = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value.ToString()).Date;
                    fin = Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value.ToString()).Date;

                    //rangoI = Int16.Parse(dtpFechaInicio.Value.ToString());
                    //rangoF = Int16.Parse(dtpFechaFin.Value.ToString());

                    if (inicio > dtpFechaFin.Value|| fin < dtpFechaInicio.Value)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el renglón completo haciendo click en la flechita a la izquierda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                DataGridViewRow renglon = dataGridView1.CurrentRow;

                PanModificarBanner mb = new PanModificarBanner(renglon);
                mb.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el renglón completo haciendo click en la flechita a la izquierda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataGridViewRow renglon = dataGridView1.CurrentRow;
                if (MessageBox.Show("Está completamente seguro que desea eliminar el banner: " + renglon.Cells["Nombre"].Value.ToString(), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ControladorBanners.EliminarBanner(Int16.Parse(renglon.Cells["IdBanner"].Value.ToString()));
                }
            }
        }
    }
    }

