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
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListarBanner cerrar = new ListarBanner();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanBanner abrir = new PanBanner();
            abrir.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {   //Se ocultan/muestran controles segun el caso.
                case "TODOS":
                    {
                        
                        comboTipo.Hide();
                        fecha1.Hide();
                        fecha2.Hide();
                        //lblInicio.Hide();
                        //lblFin.Hide();
                        btnFiltrar.Enabled = false;
                        break;
                    }
                case "Fechas":
                    {
                        fecha1.Show();
                        fecha2.Show();
                        comboTipo.Hide();
                        fecha1.Format = DateTimePickerFormat.Short;
                        fecha2.Format = DateTimePickerFormat.Short;
                        //lblInicio.Show();
                        //lblFin.Show();
                        btnFiltrar.Enabled = true;
                        break;
                    }
                case "Horas":
                    {
                        comboTipo.Hide();
                        fecha1.Show();
                        fecha2.Show();
                        //lblInicio.Show();
                        //lblFin.Show();
                        fecha1.Format = DateTimePickerFormat.Time;
                        fecha1.ShowUpDown = true;
                        fecha1.CustomFormat = "hh:mm";
                        fecha2.Format = DateTimePickerFormat.Time;
                        fecha2.ShowUpDown = true;
                        fecha2.CustomFormat = "hh:mm";
                        btnFiltrar.Enabled = true;
                        break;
                    }
                case "Tipo de banner":
                    {
                        fecha1.Hide();
                        fecha2.Hide();
                        //lblInicio.Hide();
                        //lblFin.Hide();
                        comboTipo.Show();
                        fecha1.Hide();
                        fecha2.Hide();
                        btnFiltrar.Enabled = true;
                        break;
                    }
            }
        }
    }
    }

