namespace CarteleriaDigital.Pantallas
{
    partial class AgregarCampaña
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarCampaña));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gbFechaHora = new System.Windows.Forms.GroupBox();
            this.cbMinutoFin = new System.Windows.Forms.ComboBox();
            this.cbHoraFin = new System.Windows.Forms.ComboBox();
            this.cbMinutoInicio = new System.Windows.Forms.ComboBox();
            this.cbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lHoraFin = new System.Windows.Forms.Label();
            this.lHoraInicio = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lFechaInicio = new System.Windows.Forms.Label();
            this.gbImagenes = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.vistaImagenes = new System.Windows.Forms.ListView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tbDuracion = new System.Windows.Forms.TextBox();
            this.lDuracion = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pbMiniImg = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gbDetalles.SuspendLayout();
            this.gbFechaHora.SuspendLayout();
            this.gbImagenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMiniImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(120, 37);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(557, 22);
            this.tbNombre.TabIndex = 1;
            this.tbNombre.TextChanged += new System.EventHandler(this.tbNombre_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.Teal;
            this.btnAceptar.Location = new System.Drawing.Point(595, 660);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 41);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(427, 660);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 41);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk_1);
            // 
            // gbDetalles
            // 
            this.gbDetalles.Controls.Add(this.tbNombre);
            this.gbDetalles.Controls.Add(this.label1);
            this.gbDetalles.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbDetalles.Location = new System.Drawing.Point(21, 15);
            this.gbDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetalles.Size = new System.Drawing.Size(717, 85);
            this.gbDetalles.TabIndex = 12;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "Detalles";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "jpg";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // gbFechaHora
            // 
            this.gbFechaHora.Controls.Add(this.cbMinutoFin);
            this.gbFechaHora.Controls.Add(this.cbHoraFin);
            this.gbFechaHora.Controls.Add(this.cbMinutoInicio);
            this.gbFechaHora.Controls.Add(this.cbHoraInicio);
            this.gbFechaHora.Controls.Add(this.lHoraFin);
            this.gbFechaHora.Controls.Add(this.lHoraInicio);
            this.gbFechaHora.Controls.Add(this.dtpFechaFin);
            this.gbFechaHora.Controls.Add(this.lFechaFin);
            this.gbFechaHora.Controls.Add(this.dtpFechaInicio);
            this.gbFechaHora.Controls.Add(this.lFechaInicio);
            this.gbFechaHora.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbFechaHora.Location = new System.Drawing.Point(21, 107);
            this.gbFechaHora.Margin = new System.Windows.Forms.Padding(4);
            this.gbFechaHora.Name = "gbFechaHora";
            this.gbFechaHora.Padding = new System.Windows.Forms.Padding(4);
            this.gbFechaHora.Size = new System.Drawing.Size(717, 134);
            this.gbFechaHora.TabIndex = 13;
            this.gbFechaHora.TabStop = false;
            // 
            // cbMinutoFin
            // 
            this.cbMinutoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinutoFin.FormattingEnabled = true;
            this.cbMinutoFin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbMinutoFin.Location = new System.Drawing.Point(604, 87);
            this.cbMinutoFin.Margin = new System.Windows.Forms.Padding(4);
            this.cbMinutoFin.Name = "cbMinutoFin";
            this.cbMinutoFin.Size = new System.Drawing.Size(61, 24);
            this.cbMinutoFin.TabIndex = 28;
            // 
            // cbHoraFin
            // 
            this.cbHoraFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoraFin.FormattingEnabled = true;
            this.cbHoraFin.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbHoraFin.Location = new System.Drawing.Point(539, 87);
            this.cbHoraFin.Margin = new System.Windows.Forms.Padding(4);
            this.cbHoraFin.Name = "cbHoraFin";
            this.cbHoraFin.Size = new System.Drawing.Size(56, 24);
            this.cbHoraFin.TabIndex = 27;
            // 
            // cbMinutoInicio
            // 
            this.cbMinutoInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinutoInicio.FormattingEnabled = true;
            this.cbMinutoInicio.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cbMinutoInicio.Location = new System.Drawing.Point(604, 36);
            this.cbMinutoInicio.Margin = new System.Windows.Forms.Padding(4);
            this.cbMinutoInicio.Name = "cbMinutoInicio";
            this.cbMinutoInicio.Size = new System.Drawing.Size(61, 24);
            this.cbMinutoInicio.TabIndex = 26;
            // 
            // cbHoraInicio
            // 
            this.cbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoraInicio.FormattingEnabled = true;
            this.cbHoraInicio.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbHoraInicio.Location = new System.Drawing.Point(539, 36);
            this.cbHoraInicio.Margin = new System.Windows.Forms.Padding(4);
            this.cbHoraInicio.Name = "cbHoraInicio";
            this.cbHoraInicio.Size = new System.Drawing.Size(56, 24);
            this.cbHoraInicio.TabIndex = 25;
            // 
            // lHoraFin
            // 
            this.lHoraFin.AutoSize = true;
            this.lHoraFin.Location = new System.Drawing.Point(432, 90);
            this.lHoraFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lHoraFin.Name = "lHoraFin";
            this.lHoraFin.Size = new System.Drawing.Size(82, 17);
            this.lHoraFin.TabIndex = 5;
            this.lHoraFin.Text = "Hora de fin:";
            // 
            // lHoraInicio
            // 
            this.lHoraInicio.AutoSize = true;
            this.lHoraInicio.Location = new System.Drawing.Point(432, 39);
            this.lHoraInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lHoraInicio.Name = "lHoraInicio";
            this.lHoraInicio.Size = new System.Drawing.Size(99, 17);
            this.lHoraInicio.TabIndex = 4;
            this.lHoraInicio.Text = "Hora de inicio:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(120, 84);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lFechaFin
            // 
            this.lFechaFin.AutoSize = true;
            this.lFechaFin.Location = new System.Drawing.Point(8, 84);
            this.lFechaFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFechaFin.Name = "lFechaFin";
            this.lFechaFin.Size = new System.Drawing.Size(90, 17);
            this.lFechaFin.TabIndex = 2;
            this.lFechaFin.Text = "Fecha de fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(120, 32);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.AutoSize = true;
            this.lFechaInicio.Location = new System.Drawing.Point(8, 39);
            this.lFechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Size = new System.Drawing.Size(107, 17);
            this.lFechaInicio.TabIndex = 0;
            this.lFechaInicio.Text = "Fecha de inicio:";
            // 
            // gbImagenes
            // 
            this.gbImagenes.Controls.Add(this.label2);
            this.gbImagenes.Controls.Add(this.btnLimpiar);
            this.gbImagenes.Controls.Add(this.btnBorrar);
            this.gbImagenes.Controls.Add(this.vistaImagenes);
            this.gbImagenes.Controls.Add(this.btnAgregar);
            this.gbImagenes.Controls.Add(this.tbDuracion);
            this.gbImagenes.Controls.Add(this.lDuracion);
            this.gbImagenes.Controls.Add(this.btnBuscar);
            this.gbImagenes.Controls.Add(this.pbMiniImg);
            this.gbImagenes.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbImagenes.Location = new System.Drawing.Point(21, 265);
            this.gbImagenes.Margin = new System.Windows.Forms.Padding(4);
            this.gbImagenes.Name = "gbImagenes";
            this.gbImagenes.Padding = new System.Windows.Forms.Padding(4);
            this.gbImagenes.Size = new System.Drawing.Size(717, 368);
            this.gbImagenes.TabIndex = 14;
            this.gbImagenes.TabStop = false;
            this.gbImagenes.Text = "Imágenes";
            this.gbImagenes.Enter += new System.EventHandler(this.gbImagenes_Enter);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.Teal;
            this.btnLimpiar.Location = new System.Drawing.Point(28, 314);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(116, 33);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.ForeColor = System.Drawing.Color.Teal;
            this.btnBorrar.Location = new System.Drawing.Point(175, 314);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(116, 33);
            this.btnBorrar.TabIndex = 6;
            this.btnBorrar.Text = "Borrar imágen";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // vistaImagenes
            // 
            this.vistaImagenes.Location = new System.Drawing.Point(319, 23);
            this.vistaImagenes.Margin = new System.Windows.Forms.Padding(4);
            this.vistaImagenes.Name = "vistaImagenes";
            this.vistaImagenes.Size = new System.Drawing.Size(359, 324);
            this.vistaImagenes.TabIndex = 5;
            this.vistaImagenes.UseCompatibleStateImageBehavior = false;
            this.vistaImagenes.SelectedIndexChanged += new System.EventHandler(this.vistaImagenes_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ForeColor = System.Drawing.Color.Teal;
            this.btnAgregar.Location = new System.Drawing.Point(175, 103);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(116, 33);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbDuracion
            // 
            this.tbDuracion.Location = new System.Drawing.Point(87, 169);
            this.tbDuracion.Margin = new System.Windows.Forms.Padding(4);
            this.tbDuracion.Name = "tbDuracion";
            this.tbDuracion.Size = new System.Drawing.Size(57, 22);
            this.tbDuracion.TabIndex = 3;
            this.tbDuracion.TextChanged += new System.EventHandler(this.tbDuracion_TextChanged);
            this.tbDuracion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDuracion_KeyPress);
            // 
            // lDuracion
            // 
            this.lDuracion.AutoSize = true;
            this.lDuracion.Location = new System.Drawing.Point(8, 172);
            this.lDuracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDuracion.Name = "lDuracion";
            this.lDuracion.Size = new System.Drawing.Size(69, 17);
            this.lDuracion.TabIndex = 2;
            this.lDuracion.Text = "Duración:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.Teal;
            this.btnBuscar.Location = new System.Drawing.Point(175, 38);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 33);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pbMiniImg
            // 
            this.pbMiniImg.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbMiniImg.Location = new System.Drawing.Point(12, 38);
            this.pbMiniImg.Margin = new System.Windows.Forms.Padding(4);
            this.pbMiniImg.Name = "pbMiniImg";
            this.pbMiniImg.Size = new System.Drawing.Size(133, 98);
            this.pbMiniImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMiniImg.TabIndex = 0;
            this.pbMiniImg.TabStop = false;
            this.pbMiniImg.Click += new System.EventHandler(this.pbMiniImg_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "seg";
            // 
            // AgregarCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 715);
            this.Controls.Add(this.gbImagenes);
            this.Controls.Add(this.gbFechaHora);
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AgregarCampaña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarCampaña";
            this.Load += new System.EventHandler(this.AgregarCampaña_Load);
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            this.gbFechaHora.ResumeLayout(false);
            this.gbFechaHora.PerformLayout();
            this.gbImagenes.ResumeLayout(false);
            this.gbImagenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMiniImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox gbFechaHora;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lFechaFin;
        private System.Windows.Forms.Label lHoraFin;
        private System.Windows.Forms.Label lHoraInicio;
        private System.Windows.Forms.GroupBox gbImagenes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox pbMiniImg;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.ListView vistaImagenes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tbDuracion;
        private System.Windows.Forms.Label lDuracion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cbMinutoInicio;
        private System.Windows.Forms.ComboBox cbHoraInicio;
        private System.Windows.Forms.ComboBox cbMinutoFin;
        private System.Windows.Forms.ComboBox cbHoraFin;
        private System.Windows.Forms.Label label2;
    }
}