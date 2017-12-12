using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarteleriaDigital.Controladores;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.Pantallas
{
    public partial class PanModificarBanner : Form
    {
        int idrango;
        int idbanner;
        public PanModificarBanner(DataGridViewRow renglonBanner)
        {
            InitializeComponent();
            idbanner = Int16.Parse(renglonBanner.Cells["idbanner"].Value.ToString());
 

            txtNombre.Text = renglonBanner.Cells["Nombre"].Value.ToString();
            if (renglonBanner.Cells["Tipo"].Value.ToString() == "simple")
            {
                rbBS.Checked = true;
                txtURL.Enabled = false;
                BannerSimpleDTO bsDTO = ControladorBanners.BuscarBannerSimple(idbanner);
                txtTexto.Text = bsDTO.Texto;
                idrango = bsDTO.IdRango.Value;
            }
            else
            {
                rbRSS.Checked = true;
                txtTexto.Enabled = false;
                BannerRSSDTO brssDTO = ControladorBanners.BuscarBannerRSS(idbanner);
                txtURL.Text = brssDTO.FuenteRSS;
                idrango = brssDTO.IdRango.Value;
            }

            RangoDTO rngDTO = ControladorBanners.BuscarRangoPorId(idrango);
            dtpFechaInicio.Value = rngDTO.FechaInicio;
            dtpFechaFin.Value = rngDTO.FechaFin;
            cbHoraInicio.Text = rngDTO.HoraInicio.ToString();
            cbMinutoInicio.Text = rngDTO.MinutoInicio.ToString();
            cbHoraFin.Text = rngDTO.HoraFin.ToString();
            cbMinutoFin.Text = rngDTO.MinutoFin.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            RangoDTO rngDTO = new RangoDTO
            {
                IdRango = idrango,
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value,
                HoraInicio = Int16.Parse(cbHoraInicio.Text),
                MinutoInicio = Int16.Parse(cbMinutoInicio.Text),
                HoraFin = Int16.Parse(cbHoraFin.Text),
                MinutoFin = Int16.Parse(cbMinutoFin.Text)
            };

            if (rbBS.Checked)
            {
                BannerSimpleDTO bsDTO = new BannerSimpleDTO
                {
                    IdBanner = idbanner,
                    Nombre = txtNombre.Text,
                    Texto = txtTexto.Text
                };

                ControladorBanners.ModificarBannerSimple(bsDTO, rngDTO);
            }

            if (rbRSS.Checked)
            {
                BannerRSSDTO brssDTO = new BannerRSSDTO
                {
                    IdBanner = idbanner,
                    Nombre = txtNombre.Text,
                    FuenteRSS = txtURL.Text
                };

                ControladorBanners.ModificarBannerRSS(brssDTO, rngDTO);
            }

            MessageBox.Show("El banner ha sido modificado satisfactoriamente", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
    }


}
