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
        public ModificarBanner(DataGridViewRow renglonBanner)
        {
            InitializeComponent();
            int id = 0;

            txtNombre.Text = renglonBanner.Cells["Nombre"].Value.ToString();
            if (renglonBanner.Cells["Tipo"].Value.ToString() == "simple")
            {
                rbBS.Checked = true;
                txtURL.Enabled = false;
                BannerSimpleDTO bsDTO = ControladorBanners.BuscarBannerSimple(Int16.Parse(renglonBanner.Cells["idbanner"].Value.ToString()));
                txtTexto.Text = bsDTO.Texto;
                id = bsDTO.IdRango.Value;

            }
            else
            {
                rbRSS.Checked = true;
                txtTexto.Enabled = false;
                BannerRSSDTO brssDTO = ControladorBanners.BuscarBannerRSS(Int16.Parse(renglonBanner.Cells["idbanner"].Value.ToString()));
                txtURL.Text = brssDTO.FuenteRSS;
                id = brssDTO.IdRango.Value;
            }

            RangoDTO rngDTO = ControladorBanners.BuscarRangoPorId(id);
            dtpFechaInicio.Value = rngDTO.FechaInicio;
            dtpFechaFin.Value = rngDTO.FechaFin;

        }
    }


}
