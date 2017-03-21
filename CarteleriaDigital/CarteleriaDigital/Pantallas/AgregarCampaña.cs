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

namespace CarteleriaDigital.Pantallas
{
    public partial class AgregarCampaña : Form
    {
        List<ImagenDTO> ListIMG = new List<ImagenDTO>();

        public AgregarCampaña()
        {
            InitializeComponent();         
            
        }
                
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();

                PanCampaña abrir = new PanCampaña();
                abrir.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == ""))
            {
                MessageBox.Show("Falta ingresar el nombre de la campaña", "Advertencia");

            }

          else
            {
                
          /*     //para guardar UN pictureBox en disco
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // pictureBox1.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                   int  Numimagen = 1;
                        if (pictureBox1.Image != null) { pictureBox1.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox2.Image != null) { pictureBox2.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox3.Image != null) { pictureBox3.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox4.Image != null) { pictureBox4.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox5.Image != null) { pictureBox5.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox6.Image != null) { pictureBox6.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox7.Image != null) { pictureBox7.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox8.Image != null) { pictureBox8.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox9.Image != null) { pictureBox9.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
                        if (pictureBox10.Image != null) { pictureBox10.Image.Save(saveFileDialog1.FileName + Numimagen.ToString() + ".jpg", ImageFormat.Jpeg); Numimagen++; }
 
                MessageBox.Show("La campaña ha sido agregada exitosamente", "Atención", MessageBoxButtons.OK);
                } */

                MessageBox.Show("La campaña ha sido agregada exitosamente", "Atención", MessageBoxButtons.OK);

                this.Close();
                PanCampaña abrir = new PanCampaña();
                abrir.Show();

              /*  saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "C:/Imágenes";
                saveFileDialog1.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
                                      
            */

            }

            
            
        }
                   
        

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
       
     /*   private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:/Imágenes";
            openFileDialog.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image == null) { pictureBox1.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox2.Image == null) { pictureBox2.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox3.Image == null) { pictureBox3.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox4.Image == null) { pictureBox4.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox5.Image == null) { pictureBox5.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox6.Image == null) { pictureBox6.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox7.Image == null) { pictureBox7.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox8.Image == null) { pictureBox8.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox9.Image == null) { pictureBox9.ImageLocation = openFileDialog.FileName; }
                else if (pictureBox10.Image == null) { pictureBox10.ImageLocation = openFileDialog.FileName; }

            } 
        }        */

        
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
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:/Imágenes";
            openFileDialog.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName; 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Incorpora una nueva Imagen a la lista de imagenes con su correspondiente duración.                     
            if (!openFileDialog1.FileName.Equals(""))
            {
                try
                {
                   if (Convert.ToInt16(textBox2.Text) > 0)
                    {
                        this.listView1.Items.Clear();
                      
                        //Carga la imagen desde la ruta y de la un formato, luego la agrega la lista de img.
                        Image fotoEntrante = Image.FromFile(openFileDialog1.FileName);
                        imageList1.Images.Add(fotoEntrante);
                        imageList1.ImageSize = new Size(256, 256);
                        this.listView1.View = View.LargeIcon;
                      
                        //Arma los indices del listview.
                        for (int counter = 0; counter < imageList1.Images.Count; counter++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = counter;
                            this.listView1.Items.Add(item);
                        }
                      
                        //Carga la lista de imagenes al listview
                        imageList1.ColorDepth = ColorDepth.Depth16Bit;
                        this.listView1.LargeImageList = imageList1;
                     
                        //Carga el objeto de tipo imagen con los datos del usuario.
                        ImagenDTO imagen1 = new ImagenDTO();                  
                        imagen1.Duracion = Convert.ToInt16(textBox2.Text);
                        imagen1.RutaImagen = openFileDialog1.FileName;
                        openFileDialog1.FileName = "";
                      
                        //Lo agrega a la lista de imagenes de la campaña y vacia el picturebox.
                        ListIMG.Add(imagen1);
                        pictureBox1.Image = null;
                        pictureBox1.Update();
                        button4.Enabled = false;
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
    }
}