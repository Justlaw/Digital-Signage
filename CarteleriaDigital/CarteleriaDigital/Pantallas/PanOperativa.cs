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
using System.Threading;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;



namespace CarteleriaDigital.Pantallas
{
    public partial class PanOperativa : Form
    {   //Defino variables globales
        bool verCursor = false;
        CampañaDAO camp = new CampañaDAO();
        bool detener = false;
        Thread thread1;
        Thread thread2;

        public PanOperativa()
        {   //Se inicializan los controles.

            InitializeComponent();
            this.KeyDown += new KeyEventHandler(this.teclaPresionada);
            menuStrip1.Visible = false;
            //Defino los atajos de teclado

        }



        private void PanOperativa_Load(object sender, EventArgs e)
        {
            //Se inician 2 hilos correspondientes a las campañas y banners
            thread1 = new Thread(new ThreadStart(SliderCampaña));
            //thread2 = new Thread(new ThreadStart(SliderBanners));
            thread1.Start();
            thread1.Priority = ThreadPriority.Normal;
            //thread2.Start();
            //thread2.Priority = ThreadPriority.Normal;

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

        private void administrarCampañaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Metodo asincrono correspondiente a la visualizacion de Campañas.
        private async void SliderCampaña() //(CampañaDTO campDTO, RangoDTO rangoDTO, List<ImagenDTO> listDTO)


        {
            List<CampañaDTO> campList = camp.CampañasDelDía(DateTime.Now, DateTime.Today.TimeOfDay);
            ImagenDAO img_DAO = new ImagenDAO();
            List <ImagenDTO> listDTO = new List<ImagenDTO>();
            List<ImagenDTO> listImg_DTO = new List<ImagenDTO>();
            foreach (CampañaDTO campaña in campList) {
                listImg_DTO = img_DAO.ListarPorCampaña(campaña.IdCampaña);
                foreach (ImagenDTO img_DTO in listImg_DTO) {
                    listDTO.Add(img_DTO);
                }               
            }
            
            //Se le solicitan todas las campañas a la clase Controlador
            
            //Se itera sobre la lista de imagenes y se las va cargando periodicamente a un picturebox
            while (detener != true)
            {
                if (listDTO != null)
                {
                    foreach (ImagenDTO img in listDTO)
                    {
                        try
                        {
                            Image imagen = Image.FromFile(img.RutaImagen);
                            pictureBox1.Image = imagen;
                        }
                        catch
                        {
                            //Si no puede acceder a la imagen de la ubicacion, carga una imagen de error.
                            //pictureBox1.Image = Properties.Resources.noImagen;

                        }
                        await Task.Delay(1000 * img.Duracion);
                    }
                }
                //Al finalizar la lista, vuelve a cargarla con nuevas imágenes correspondientes a la fecha y hora actual.
                //IMGcampañas = Controlador.obtenerImagenesCampañas();
            }
        }

        //Metodo correspondiente a la visualizacion de Banners.
       /* private void SliderBanners()
        {
            BannerSimple pruebaBanner = new BannerSimple();
            pruebaBanner.Text = "Hola mundo";
            List<BannerSimple> pruebaBS = new List<BannerSimple>();
            pruebaBS.Add(pruebaBanner);
            pruebaBanner.Text = "Gano el rojo!!!";
            pruebaBS.Add(pruebaBanner);

            string caracterTemporal = string.Empty;
            string textoTemporal = string.Empty;
            while (!detener)
            {
                string elTexto = pruebaBanner.Text; //Controlador.obtenerBanner();
                textoTemporal = "                                                                                                                                         " + elTexto;
                //Se le solicita a la clase controlador el banner actual y se lo va recortando para dar el efecto deslizante
                for (int i = 0; i < textoTemporal.Length; i++)
                {
                    try {
                        caracterTemporal = textoTemporal.Substring(0, 1);
                        textoTemporal = textoTemporal.Remove(0, 1) + caracterTemporal;
                        textoBanner.Invoke(new ScrollEnTxtBox(this.ActualizarTextBox), new object[] { textoTemporal });
                        Thread.Sleep(100);
                    }
                    catch { }
                    
                }
                elTexto = pruebaBS.ToString(); //Controlador.obtenerBanner();
            }
        }

        public delegate void ScrollEnTxtBox(string t);
        string elTexto = obtenerTexto(); //Controlador.obtenerBanner();

        private static string obtenerTexto()
        {
        BannerSimple pruebaBanner = new BannerSimple();
        pruebaBanner.Text = "Hola mundo";
            List<BannerSimple> pruebaBS = new List<BannerSimple>();
        pruebaBS.Add(pruebaBanner);
            pruebaBanner.Text = "Gano el rojo!!!";
            pruebaBS.Add(pruebaBanner);

            return pruebaBanner.Text;
        }

        //Actualiza el string del banner.
        private void ActualizarTextBox(string m_text)
        {
            textoBanner.Text = m_text;
        }*/


        private void nuevaCampañaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
