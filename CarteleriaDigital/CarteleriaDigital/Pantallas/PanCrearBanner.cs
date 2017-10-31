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
using CarteleriaDigital.Controladores;
using CarteleriaDigital.DAO;

namespace CarteleriaDigital.Pantallas
{
    public partial class PanCrearBanner : Form
    {
        public PanCrearBanner()
        {
            InitializeComponent();
            rbBannerSimple.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtURL.ReadOnly = true;
            txtTexto.ReadOnly = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtTexto.ReadOnly = true;
            txtURL.ReadOnly = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();

                PanBanner abrir = new PanBanner();
                abrir.Show();
            }                                        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((dtpFechaInicio.Value < DateTime.Today | dtpFechaFin.Value < dtpFechaInicio.Value) | 
                (cbHoraFin.Text == cbHoraInicio.Text && cbMinutoInicio.Text == cbMinutoInicio.Text))      
            {
                MessageBox.Show("Verifique la correctitud de las fechas y horas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                RangoDTO rngDTO = new RangoDTO
                {
                    FechaInicio = dtpFechaInicio.Value,
                    FechaFin = dtpFechaFin.Value,
                    HoraInicio = Int16.Parse(cbHoraInicio.Text),
                    MinutoInicio = Int16.Parse(cbMinutoInicio.Text),
                    HoraFin = Int16.Parse(cbHoraFin.Text),
                    MinutoFin = Int16.Parse(cbMinutoFin.Text)
                };

                bool resultado = false;
                if (rbBannerSimple.Checked)
                {
                    BannerSimpleDTO bsDTO = new BannerSimpleDTO
                    {
                        Nombre = txtNombre.Text,
                        Texto = txtTexto.Text
                    };
                    resultado = ControladorBanners.CrearBannerSimple(bsDTO, rngDTO);
                }

                else
                {
                    BannerRSSDTO brssDTO = new BannerRSSDTO();
                    brssDTO.Nombre = txtNombre.Text;
                    brssDTO.FuenteRSS = txtURL.Text;
                    resultado = ControladorBanners.CrearBannerRSS(brssDTO, rngDTO);
                }

                if (!resultado)
                {
                    MessageBox.Show("No se pudo guardar el nuevo banner");
                }
                else
                {
                    MessageBox.Show("Agregado con éxito!");
                }
            }
            
        }
        }

    }
}
