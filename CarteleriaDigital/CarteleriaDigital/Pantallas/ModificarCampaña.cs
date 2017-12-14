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
    public partial class ModificarCampaña : Form
    {
        List<ImagenDTO> ListIMG = new List<ImagenDTO>();
        OpenFileDialog Img = new OpenFileDialog();
        CampañaDTO camp = new CampañaDTO();
        ImageList imageL = new ImageList();
        RangoDTO rngDTO = new RangoDTO();

        private int idCampaña;
        private int idRango;

        public ModificarCampaña(DataGridViewRow renglonCampaña)
        {
            //Se inicializa la pantalla con los datos elegidos en la pantalla listarCampaña
            InitializeComponent();
            idCampaña = Int16.Parse(renglonCampaña.Cells["idCampaña"].Value.ToString());
            tbNombre.Text = renglonCampaña.Cells["Nombre"].Value.ToString();
            idRango = Int16.Parse(renglonCampaña.Cells["idRango"].Value.ToString());

            
            rngDTO = ControladorCampañas.buscarRangoPorID(idRango);
            
            dtpFechaInicio.Value = rngDTO.FechaInicio;
            dtpFechaFin.Value = rngDTO.FechaFin;

            cbHoraInicio.SelectedIndex = cbHoraInicio.FindString(rngDTO.HoraInicio.ToString());
            cbHoraFin.SelectedIndex = cbHoraFin.FindString(rngDTO.HoraFin.ToString());
            cbMinutoInicio.SelectedIndex = cbMinutoInicio.FindString(rngDTO.MinutoInicio.ToString());
            cbMinutoFin.SelectedIndex = cbMinutoFin.FindString(rngDTO.MinutoFin.ToString());

            ListIMG = ControladorCampañas.buscarImagenesCampaña(idCampaña);

            this.vistaImagenes.Items.Clear();

            foreach (ImagenDTO i in ListIMG)
            {
                //Carga la imagen desde la ruta y de la un formato, luego la agrega la lista de img.
                Image fotoEntra = Image.FromFile(i.RutaImagen);
                imageL.Images.Add(fotoEntra);
                imageL.ImageSize = new Size(60, 60);
                this.vistaImagenes.View = View.LargeIcon;
            }
                //Arma los indices del listview.
            for (int counter = 0; counter < imageL.Images.Count; counter++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = counter;
                    this.vistaImagenes.Items.Add(item);
                }

            //Carga la lista de imagenes al listview
            imageL.ColorDepth = ColorDepth.Depth16Bit;
            this.vistaImagenes.LargeImageList = imageL;

            btnBorrarImg.Enabled = false;
        }

        //Acción del boton "Buscar".
        private void button1_Click(object sender, EventArgs e)
        {
            Img.InitialDirectory = "C:/Imágenes";
            Img.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            Img.FilterIndex = 1;
            Img.Multiselect = true;

            if (Img.ShowDialog() == DialogResult.OK)
            {
                pbMiniImg.ImageLocation = Img.FileName;
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
                }
                else
                {
                    btnAgregar.Enabled = false;
                }
            }
        }

        private void tbDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("El valor ingresado debe ser un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Al seleccionar una imagen se activa el boton Borrar.
            if (vistaImagenes.SelectedIndices.Count != 0)
            { btnBorrarImg.Enabled = true; }
            else { btnBorrarImg.Enabled = false; }
        }

        //Hace refencia al boton cancelar de la pantalla
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Cierra la ventana al presionar el boton Cancelar y abre la ventana anterior.
                this.Close();

                ListarCampaña abrir = new ListarCampaña();
                abrir.Show();
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            
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
                    imageL.Images.Add(fotoEntra);
                    imageL.ImageSize = new Size(60, 60);
                    this.vistaImagenes.View = View.LargeIcon;

                    //Arma los indices del listview.
                    for (int counter = 0; counter < imageL.Images.Count; counter++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = counter;
                        this.vistaImagenes.Items.Add(item);
                    }

                    //Carga la lista de imagenes al listview
                    imageL.ColorDepth = ColorDepth.Depth16Bit;
                    this.vistaImagenes.LargeImageList = imageL;

                    //Carga el objeto de tipo imagen con los datos del usuario.
                    ImagenDTO imagen1 = new ImagenDTO();
                    imagen1.Duracion = Convert.ToInt16(tbDuracion.Text);
                    imagen1.RutaImagen = Img.FileName;
                    Img.FileName = "";

                    //Lo agrega a la lista de imagenes de la campaña y vacia el picturebox.
                    ListIMG.Add(imagen1);
                    pbMiniImg.Image = null;
                    pbMiniImg.Update();
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

        private void btnBorrarImg_Click(object sender, EventArgs e)
        {
            if (vistaImagenes.Items.Count > 0)
            {
                if (vistaImagenes.SelectedIndices != null)
                {
                    //Se obtiene la posicion del elemento seleccionado.
                    Int32 pos = vistaImagenes.SelectedIndices[0];
                    //Se establece el índice de la imágen.
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = pos;
                    //Se elimina la imágen de la posicion.
                    imageL.Images.RemoveAt(pos);
                    ListIMG.RemoveAt(pos);
                    vistaImagenes.Clear();
                    //Actualizo los indices.
                    for (int counter = 0; counter < imageL.Images.Count; counter++)
                    {
                        ListViewItem item1 = new ListViewItem();
                        item1.ImageIndex = counter;
                        this.vistaImagenes.Items.Add(item1);
                    }
                    this.vistaImagenes.LargeImageList = imageL;
                    btnBorrarImg.Enabled = false;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

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
            }
            if (ListIMG.Count == 0)
            {
                MessageBox.Show("La campaña debe poseer al menos una imagen", "Advertencia");
            }
            else
            {
                rngDTO.FechaInicio = dtpFechaInicio.Value;
                rngDTO.FechaFin = dtpFechaFin.Value;
                rngDTO.HoraInicio = Int16.Parse(cbHoraInicio.Text);
                rngDTO.HoraFin = Int16.Parse(cbHoraFin.Text);
                rngDTO.MinutoInicio = Int16.Parse(cbMinutoInicio.Text);
                rngDTO.MinutoFin = Int16.Parse(cbMinutoFin.Text);
                camp.Nombre = tbNombre.Text;

                ControladorCampañas.ModificarCampaña(camp, rngDTO, ListIMG);

                MessageBox.Show("La campaña ha sido agregada exitosamente", "Atención", MessageBoxButtons.OK);

                this.Close();
                PanCampaña abrir = new PanCampaña();
                abrir.Show();
            }
        }

        private void tbDuracion_TextChanged(object sender, EventArgs e)
        {
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
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }
    }
}