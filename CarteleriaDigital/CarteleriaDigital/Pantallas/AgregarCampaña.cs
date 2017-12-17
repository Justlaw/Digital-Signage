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

        public AgregarCampaña()
        {
            InitializeComponent();
            btnAgregar.Enabled = false;
            btnBorrar.Enabled = false;
        }
        //Accion del boton "Cancelar".        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Cierra la ventana al presionar el boton Cancelar y abre la ventana anterior.
                this.Close();
                                
                PanCampaña abrir = new PanCampaña();
                abrir.Show();

            }
        }

        //Acción del boton "Aceptar".
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Comprobaciones para que se ingresen valores válidos y no se dejen campos en blanco
            if ((tbNombre.Text == "" || cbHoraInicio.Text == "" || cbHoraFin.Text == "" || cbMinutoInicio.Text == "" || cbMinutoFin.Text == ""))
            {
                MessageBox.Show("Falta ingresar el nombre, fecha o horarios de la campaña", "Advertencia");
            }

            else if (dtpFechaInicio.Value.Date < DateTime.Today || dtpFechaFin.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La campaña debe estar entre fechas válidas", "Advertencia");
            }
            else if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin de la campaña", "Advertencia");
            }
            else if (dtpFechaInicio.Value.Date == dtpFechaFin.Value.Date)
            {
                if (Int16.Parse(cbHoraInicio.Text) > Int16.Parse(cbHoraFin.Text))
                {
                    MessageBox.Show("La hora de inicio no puede ser mayor a la Hora de fin para una misma fecha", "Advertencia");
                }
                else if (Int16.Parse(cbHoraInicio.Text) == Int16.Parse(cbHoraFin.Text))
                {
                    if (Int16.Parse(cbMinutoInicio.Text) >= Int16.Parse(cbMinutoFin.Text))
                    {
                        MessageBox.Show("Los minutos de inicio no puede ser mayor a los de fin para la misma hora en un mismo día", "Advertencia");
                    }
                }
            } if (ListIMG.Count == 0)
            {
                MessageBox.Show("La campaña debe poseer al menos una imagen", "Advertencia");
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

                ControladorCampañas.CrearCampaña(camp, rng, ListIMG);

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

        //Acción del boton "Buscar".
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            Img.InitialDirectory = "C:/Imágenes";
            Img.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            Img.FilterIndex = 1;
            Img.Multiselect = true;

            if (Img.ShowDialog() == DialogResult.OK)
            {
                pbMiniImg.ImageLocation = Img.FileName;
                //Se comprueba que haya una duración establecida para que el boton Agregar esté disponible.
                if (tbDuracion.Text != "")
                {
                    if (Convert.ToInt16(tbDuracion.Text) > 0 && Convert.ToInt16(tbDuracion.Text) <= 60)
                    {
                        if (pbMiniImg.Image != null)
                        {
                            btnAgregar.Enabled = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("La duracion debe estar entre 1 segundo y 60 segundos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                } else
                {
                    btnAgregar.Enabled = false;
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Incorpora una nueva Imagen a la lista de imagenes con su correspondiente duración.                     
            if (!Img.FileName.Equals(""))
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
                    tbDuracion.Text = "";
                    btnAgregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El campo duración debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo de la imagen no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo que saber si el valor ingresado es un entero y se utilizara como evento en "Duración"
        private void tbDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("El valor ingresado debe ser un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        
        private void tbDuracion_TextChanged(object sender, EventArgs e)
        {
            if (tbDuracion.Text != "")
            {
                if (Convert.ToInt16(tbDuracion.Text) > 0 && Convert.ToInt16(tbDuracion.Text) <= 60)
                {
                    //Si hay una imagen cargada y la duración es correcta se habilita el boton
                    if (pbMiniImg.Image != null)
                    {
                        btnAgregar.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("La duracion debe estar entre 1 segundo y 60 segundos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                btnAgregar.Enabled = false;
            }
        }

        private void pbMiniImg_Click(object sender, EventArgs e)
        {

        }

       
        private void btnBorrar_Click(object sender, EventArgs e)

        {
            if (vistaImagenes.Items.Count > 0)
            {
                if (vistaImagenes.SelectedIndices != null)
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
                        btnBorrar.Enabled = false;
                    }
                }
            }
        }

        //Hace que cuando se seleccione una imagen, se active el boton "Borrar imagen".
        private void vistaImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {           
            {   //Al seleccionar una imagen se activa el boton Borrar.
                if (vistaImagenes.SelectedIndices.Count != 0)
                { btnBorrar.Enabled = true; }
                else { btnBorrar.Enabled = false; }
            }
        }

        
        private void btnLimpiar_Click(object sender, EventArgs e)
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

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gbImagenes_Enter(object sender, EventArgs e)
        {

        }
    }
}