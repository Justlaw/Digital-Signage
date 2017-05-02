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
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            rbPorNombre.Checked = true;
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
            if (rbPorNombre.Checked)
            {
                int tam = dataGridView1.Rows.Count -1;
                for (int i = tam; i >= 0; i--)
                {
                    if (dataGridView1.Rows[i].Cells["Nombre"].Value.ToString() != txtNombre.Text)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }

            if (rbTipo.Checked)
            {
                int tam = dataGridView1.Rows.Count - 1;
                for (int i = tam; i >= 0; i--)
                {
                    if (dataGridView1.Rows[i].Cells[""].Value.ToString() != txtNombre.Text)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }


            if (rbFechas.Checked)
            {
                
                   
            }
        }

    }
    }

