using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CarteleriaDigital.DTO;
using CarteleriaDigital.Controladores;
using CarteleriaDigital.DAO;
using System.Threading;

namespace CarteleriaDigital.Pantallas
{
    public partial class PanOperativa : Form
    {   //Defino variables globales
        bool verCursor = false;
        ImageList imagenL = new ImageList();
        bool parar = false;
        Thread threadPasoImagenes;
        int tiempoRestante = 0;
        //Para el banner
        String textoString;

        int minutoInicio = 0;
        int segundosInicio = 0;
        int[] minutosDisp = new int[] { 00, 15, 30, 45 };
        private Thread threadDeslizar;

        public PanOperativa()
        {   //Se inicializan los controles.

            InitializeComponent();
            this.KeyDown += new KeyEventHandler(this.teclaPresionada);
            menuStrip1.Visible = false;
            //Defino los atajos de teclado

        }

        private void PanOperativa_Load(object sender, EventArgs e)
        {
            //textoString = ControladorBanners.ObtenerTextoActual();
            //threadDeslizar = new Thread(new ThreadStart(DeslizarTexto));
            //threadDeslizar.Start();
            //threadDeslizar.Priority = ThreadPriority.Normal;

            DateTime fechaActual = DateTime.Now;
            //Ciclo para saber cuanto falta para la proxima buscada de una campaña
            for (int i = 0; i < minutosDisp.Length; i++)
            {
                if (fechaActual.Minute == minutosDisp[i])
                {

                    segundosInicio = 59 - fechaActual.Second;
                    if (segundosInicio > 0)
                    {
                        minutoInicio = minutosDisp[i] + 14;
                    }
                    else
                    {
                        minutoInicio = minutosDisp[i] + 15;
                    }

                }
                else if (fechaActual.Minute > minutosDisp[i] &&
                    fechaActual.Minute <= minutosDisp[i] + 14)
                {
                    segundosInicio = 59 - fechaActual.Second;

                    if (segundosInicio > 0)
                    {
                        minutoInicio = (minutosDisp[i] + 14) - fechaActual.Minute;
                    }
                    else
                    {
                        minutoInicio = (minutosDisp[i] + 15) - fechaActual.Minute;
                    }
                }
            }

            tiempoRestante = ((minutoInicio * 60000) + (segundosInicio * 1000));

            
            threadPasoImagenes = new Thread(new ThreadStart(pasoImagenes));
            threadPasoImagenes.Start();
            threadPasoImagenes.Priority = ThreadPriority.Normal;

        }

        private void teclaPresionada(object sender, KeyEventArgs e)
        {   // Oculta/Muestra el cursor y la barrar de control adminstrativo al presionar la tecla F1.
            if (e.KeyCode == Keys.F1)
            {
                ocultarControles();
            }

            //Oculta la barra al presionar Escape.
            if ((e.KeyCode == Keys.Escape) && (menuStrip1.Visible))
            {
                Cursor.Hide(); verCursor = false;
                menuStrip1.Visible = false;
            }
        }
        private void ocultarControles()
        {
            if (verCursor)
            {
                Cursor.Hide(); verCursor = !verCursor;
            }
            else
            {
                Cursor.Show(); verCursor = !verCursor;
            }

            menuStrip1.Visible = !menuStrip1.Visible;
        }
        private void agregarCampañaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarCampaña camp1 = new AgregarCampaña();
            camp1.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaInicio abrir = new PantallaInicio();
            abrir.Show();
            this.Close();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            threadPasoImagenes.Abort();
            this.Close();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pantallas.AcercaDe abrir = new Pantallas.AcercaDe();
            abrir.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void pasoImagenes()
        {
            List<ImagenDTO> listIMG = new List<ImagenDTO>();
            CampañaDTO camp = new CampañaDTO();
            camp = ControladorCampañas.buscarCampañaActual();

            if (camp != null)
            {
                int tiempoAcumulado = 0;
                listIMG = ControladorCampañas.buscarImagenesCampaña(camp.IdCampaña);

                //Se itera sobre la lista de imagenes y se las va cargando periodicamente a un picturebox
                while (!parar)
                {
                    foreach (ImagenDTO img in listIMG)
                    {
                        Image imagen = Image.FromFile(img.RutaImagen);
                        pbImagenes.Image = imagen;
                        tiempoAcumulado += 1000 * img.Duracion;
                        if (tiempoAcumulado > tiempoRestante)
                        {
                            parar = true;
                            await Task.Delay((1000*img.Duracion) - (tiempoAcumulado - tiempoRestante));
                            break;
                        } else
                        {
                            await Task.Delay(1000 * img.Duracion);
                        }
                    }
                }
            }
            else
            {
                //Si no hay una lista de imagenes.
                pbImagenes.Image = Properties.Resources.LogoUTN;
                await Task.Delay(tiempoRestante);
            }
            parar = false;
            tiempoRestante = 900000;            
            pasoImagenes();
        }

        private async void DeslizarTexto()
        {
            CheckForIllegalCrossThreadCalls = false;
            if (textoString != null)
            {
                char[] texto = textoString.ToCharArray();
                for (int i = 0; i < texto.Length; i++)
                {
                    if (i < texto.Length - 1)
                    {
                        await Task.Delay(125);
                        //Probar

                        if (textoBanner.Text.Length == 81)
                        {
                            textoBanner.Text = textoBanner.Text.Remove(textoBanner.Text.Length - 1);
                            textoBanner.Text += texto[i];
                        }
                        else { textoBanner.Text += texto[i]; }
                    }
                    else
                    {
                        await Task.Delay(1000);
                        DeslizarTexto();
                    }
                }

            }
        }
    }
}
