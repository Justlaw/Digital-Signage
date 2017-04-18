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
    public partial class ListarBanner : Form
    {
        BannerDAO banner = new BannerDAO();
        public ListarBanner()
        {
            InitializeComponent();
        }

        private void ListarBanner_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //Carga el datasource con las campañas cuyas fechas se encuentren en el intervalo.
                List<BannerDTO> campañasFecha = new List<BannerDTO>();
                campañasFecha = banner.ListarPorFecha(dateTimePicker1.Value, dateTimePicker2.Value);



                dataGridView1.DataSource = campañasFecha;
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
    }
}
