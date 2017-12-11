using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarteleriaDigital.DTO;
using CarteleriaDigital.Controladores;

namespace CarteleriaDigital.Pantallas
{
    public partial class AgregarCampaña : Form
    {
        List<ImagenDTO> ListIMG = new List<ImagenDTO>();
        OpenFileDialog Img = new OpenFileDialog();
        private DateTime fInicio;
        private DateTime fFin;
        private DateTime hIni;
        private DateTime hFin;
        private String n_Camp;

        public AgregarCampaña()
        {
            InitializeComponent();         
            
        }
                
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Cierra la ventana al presionar el boton Cancelar y abre la ventana anterior.
                this.Close();
                                
                PanCampaña abrir = new PanCampaña();
                abrir.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((tbNombre.Text == "" || cbHoraInicio.Text == "" || cbHoraFin.Text == "" || cbMinutoInicio.Text == "" || cbMinutoFin.Text == ""))
            {
                MessageBox.Show("Falta ingresar el nombre, fecha o horarios de la campaña", "Advertencia");
            }

            else
            {
                CampañaDTO camp = new CampañaDTO();
                RangoDTO rng = new RangoDTO();
                rng.FechaInicio = dtpFechaInicio.Value;
                rng.FechaFin = dtpFechaFin.Value;
                rng.HoraInicio = Int16.Parse(cbHoraInicio.Text);
                rng.HoraFin = Int16.Parse(cbHoraFin.Text);
                rng.MinutoInicio = Int16.Parse(cbMinutoInicio.Text);
                rng.MinutoFin = Int16.Parse(cbMinutoFin.Text);
                camp.Activo = true;
                camp.Nombre = tbNombre.Text;
               
                ControladorCampañas.CrearCampaña(camp,rng,ListIMG);

                MessageBox.Show("La campaña ha sido agregada exitosamente", "Atención", MessageBoxButtons.OK);

                this.Close();
                PanCampaña abrir = new PanCampaña();
                abrir.Show();              
            }            
        }                 
        

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
       
            
        private void groupBox1_Enter(object sender, EventArgs e)
        {
                  
                        
        }

        private void AgregarCampaña_Load(object sender, EventArgs e)
        {                      
            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e) 
        {
            
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Img.InitialDirectory = "C:/Imágenes";
            Img.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            Img.FilterIndex = 1;
            Img.Multiselect = true;

            if (Img.ShowDialog() == DialogResult.OK)
            {
                pbMiniImg.ImageLocation = Img.FileName; 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Incorpora una nueva Imagen a la lista de imagenes con su correspondiente duración.                     
            if (!Img.FileName.Equals(""))
            {
                try
                {
                   if (Convert.ToInt16(tbDuracion.Text) > 0)
                    {
                        this.vistaImagenes.Items.Clear();
                      
                        //Carga la imagen desde la ruta y de la un formato, luego la agrega la lista de img.
                        Image fotoEntra = Image.FromFile(Img.FileName);
                        imageList1.Images.Add(fotoEntra);
                        imageList1.ImageSize = new Size(156, 156);
                        this.vistaImagenes.View = View.LargeIcon;
                      
                        //Arma los indices del listview.
                        for (int counter = 0; counter < imageList1.Images.Count; counter++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = counter;
                            this.vistaImagenes.Items.Add(item);
                        }
                      
                        //Carga la lista de imagenes al listview
                        imageList1.ColorDepth = ColorDepth.Depth16Bit;
                        this.vistaImagenes.LargeImageList = imageList1;
                     
                        //Carga el objeto de tipo imagen con los datos del usuario.
                        ImagenDTO imagen1 = new ImagenDTO();                  
                        imagen1.Duracion = Convert.ToInt16(tbDuracion.Text);
                        imagen1.RutaImagen = Img.FileName;
                        openFileDialog1.FileName = "";
                      
                        //Lo agrega a la lista de imagenes de la campaña y vacia el picturebox.
                        ListIMG.Add(imagen1);
                        pbMiniImg.Image = null;
                        pbMiniImg.Update();
                        btnAgregar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El campo duración debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("El campo duración tiene un valor inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("El campo de la imagen no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)

        {
            if (vistaImagenes.Items.Count > 0)
            {
                {

                    {   //Se obtiene la posicion del elemento seleccionado.
                        Int32 pos = vistaImagenes.SelectedIndices[0];
                        //Se establece el índice de la imágen.
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = pos;
                        //Se elimina la imágen de la posicion.
                        imageList1.Images.RemoveAt(pos);
                        ListIMG.RemoveAt(pos);
                        vistaImagenes.Clear();
                        //Actualizo los indices.
                        for (int counter = 0; counter < imageList1.Images.Count; counter++)
                        {
                            ListViewItem item1 = new ListViewItem();
                            item1.ImageIndex = counter;
                            this.vistaImagenes.Items.Add(item1);
                        }
                        this.vistaImagenes.LargeImageList = imageList1;
                    }
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            {   //Al seleccionar una imagen se activa el boton Borrar.
                if (vistaImagenes.SelectedIndices.Count != 0)
                { btnBorrar.Enabled = true; }
                else { btnBorrar.Enabled = false; }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Quita todas las imagenes del ListView.
            imageList1.Dispose();
            ListIMG.Clear();
            vistaImagenes.LargeImageList = null;
            vistaImagenes.Clear();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}