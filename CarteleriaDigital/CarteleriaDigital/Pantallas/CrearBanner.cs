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
    public partial class CrearBanner : Form
    {
        public CrearBanner()
        {
            InitializeComponent();
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
            RangoDTO rngDTO = new RangoDTO();
            rngDTO.FechaInicio = dtpFechaInicio.Value;
            rngDTO.FechaFin = dtpFechaFin.Value;
            rngDTO.HoraInicio = dtpHoraInicio.Value;
            rngDTO.HoraFin = dtpHoraFin.Value;
            
            if (radioButton1.Checked)
            {
                BannerSimpleDTO bsDTO = new BannerSimpleDTO();
                bsDTO.Nombre = txtNombre.Text;
                bsDTO.Texto = txtTexto.Text;
                bool result = ControladorBanners.CrearBannerSimple(bsDTO, rngDTO);
                if (!result)
                {
                    MessageBox.Show("No se pudo guardar el nuevo banner");
                }
            }

            if (radioButton2.Checked)
            {
                BannerRSSDTO brssDTO = new BannerRSSDTO();
                brssDTO.Nombre = txtNombre.Text;
                brssDTO.FuenteRSS = txtURL.Text;
                ControladorBanners.CrearBannerRSS(brssDTO, rngDTO);
            }

        }
    }
}
