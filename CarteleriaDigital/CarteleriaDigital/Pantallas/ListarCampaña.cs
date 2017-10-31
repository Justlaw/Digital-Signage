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
        CampañaDAO camp = new CampañaDAO();

        public ListarCampaña()
        {
            List<CampañaDTO> Campañas = new List<CampañaDTO>();
            InitializeComponent();
        }
              

        private void button4_Click(object sender, EventArgs e)
        {
            ListarCampaña cerrar = new ListarCampaña();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanCampaña abrir = new PanCampaña();
            abrir.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {            
            {   
                //Carga el datasource con las campañas cuyas fechas se encuentren en el intervalo.
                InitializeComponent();

                CampañaDAO bd = new CampañaDAO();
                DataTable dt = bd.filtrarCampañaPorFecha(dtDesde.Value, dtHasta.Value);

                //corregir error en esta parte.
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)

        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Pantallas.ModificarCampaña abrir = new Pantallas.ModificarCampaña();
            abrir.Show();
            this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e) {

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
