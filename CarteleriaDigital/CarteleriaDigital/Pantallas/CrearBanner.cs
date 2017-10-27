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
            radioButton1.Checked = true;
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

            if (horaInicio.Text == "" || horaFin.Text == "" | minInicio.Text == "" || minFin.Text == "")
            {
                MessageBox.Show("Debe hacer click en los horarios que elija", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                rngDTO.HoraInicio = Int16.Parse(horaInicio.Text);
                rngDTO.MinutoInicio = Int16.Parse(minInicio.Text);
                rngDTO.HoraFin = Int16.Parse(horaFin.Text);
                rngDTO.MinutoFin = Int16.Parse(minFin.Text);

                bool resultado = false;
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
                    else
                    {
                        MessageBox.Show("Agregado con éxito!");
                    }

                }

                else
                {
                    BannerRSSDTO brssDTO = new BannerRSSDTO();
                    brssDTO.Nombre = txtNombre.Text;
                    brssDTO.FuenteRSS = txtURL.Text;
                    bool result = ControladorBanners.CrearBannerRSS(brssDTO, rngDTO);
                }
            }
        }

    }
}
