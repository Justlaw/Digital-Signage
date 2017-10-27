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
    public partial class ModificarBanner : Form
    {
        int idrango;
        int idbanner;
        public ModificarBanner(DataGridViewRow renglonBanner)
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

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            RangoDTO rngDTO = new RangoDTO();
            rngDTO.IdRango = idrango;
            rngDTO.HoraInicio = Int16.Parse(horaInicio.SelectedText);
            rngDTO.MinutoInicio = Int16.Parse(minutoInicio.SelectedText);
            rngDTO.HoraFin = Int16.Parse(horaFin.SelectedText);
            rngDTO.MinutoFin = Int16.Parse(minutoFin.SelectedText);

            if (rbBS.Checked)
            {
                BannerSimpleDTO bsDTO= new BannerSimpleDTO();
//                bsDTO

                //ControladorBanners.ModificarBannerSimple(bsDTO, rngDTO);
            }

            if (rbRSS.Checked)
            {

            }


           
        }
    }


}
