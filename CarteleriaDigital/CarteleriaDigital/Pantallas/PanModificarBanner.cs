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
                idrango = bsDTO.IdRango;
            }
            else
            {
                rbRSS.Checked = true;
                txtTexto.Enabled = false;
                BannerRSSDTO brssDTO = ControladorBanners.BuscarBannerRSS(idbanner);
                txtURL.Text = brssDTO.FuenteRSS;
                idrango = brssDTO.IdRango;
            }

            RangoDTO rngDTO = ControladorBanners.BuscarRangoPorId(idrango);
            dtpFechaInicio.Value = rngDTO.FechaInicio;
            dtpFechaFin.Value = rngDTO.FechaFin;
            cbHoraInicio.SelectedIndex = cbHoraInicio.FindString(rngDTO.HoraInicio.ToString());
            cbHoraFin.SelectedIndex = cbHoraFin.FindString(rngDTO.HoraFin.ToString());
            cbMinutoInicio.SelectedIndex = cbMinutoInicio.FindString(rngDTO.MinutoInicio.ToString());
            cbMinutoFin.SelectedIndex = cbMinutoFin.FindString(rngDTO.MinutoFin.ToString());
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

            if (VerificarRango(rngDTO))
            {
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
            

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Está seguro que desea cancelar la modificación?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private bool VerificarRango(RangoDTO rng)
        {
            bool resultado = false;
            if (rng.FechaInicio <= rng.FechaFin)
            {
                if (rng.HoraInicio < rng.HoraFin)
                {
                    resultado = true;
                }
                else if (rng.HoraInicio == rng.HoraFin)
                {
                    if (rng.MinutoInicio < rng.MinutoFin)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
    }
}
