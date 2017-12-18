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

                PanBanner panBanner = new PanBanner();
                panBanner.Show();
            }                                        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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

            if (!this.VerificarRango(rngDTO))      
            {
                MessageBox.Show("Verifique la correctitud de las fechas y horas", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtNombre.Text == "" | (txtTexto.Text == "" & txtURL.Text == ""))
            {
                MessageBox.Show("Complete todos los campos");
            }else
            {
                bool resultado = false;
                if (rbBannerSimple.Checked)
                {
                    BannerSimpleDTO bsDTO = new BannerSimpleDTO
                    {
                        Nombre = txtNombre.Text,
                        Tipo = "simple",
                        Texto = txtTexto.Text
                    };
                    resultado = ControladorBanners.CrearBannerSimple(bsDTO, rngDTO);
                }
                else
                {
                    BannerRSSDTO brssDTO = new BannerRSSDTO
                    {
                        Nombre = txtNombre.Text,
                        Tipo = "rss",
                        FuenteRSS = txtURL.Text
                    };
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

                this.Close();
                PantallaInicio pantallaInicio = new PantallaInicio();
                pantallaInicio.Show();
            }
            
        }

        private bool VerificarRango(RangoDTO rng)
        {
            bool resultado = false;
            if (VerificarCorrectitudRango(rng))
            {
                if (rng.FechaInicio >= DateTime.Today)
                {
                    if (rng.HoraInicio > DateTime.Now.Hour)
                    {
                        resultado = true;
                    }
                    if (rng.HoraInicio == DateTime.Now.Hour)
                    {
                        if (rng.MinutoInicio >= DateTime.Now.Minute)
                        {
                            resultado = true;
                        } 
                    }
                }
                
            }
            return resultado;
        }

        private bool VerificarCorrectitudRango(RangoDTO rng)
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

