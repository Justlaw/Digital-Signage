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
                List<CampañaDTO> campañasFecha = new List<CampañaDTO>();
                campañasFecha = camp.ListarPorFecha(dateTimePicker1.Value, dateTimePicker2.Value);
                


                dataGridView1.DataSource = campañasFecha;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
