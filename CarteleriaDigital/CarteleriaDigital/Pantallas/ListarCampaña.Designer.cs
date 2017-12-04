namespace CarteleriaDigital.Pantallas
{
    partial class ListarCampaña
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpNombre = new System.Windows.Forms.GroupBox();
            this.cbNombre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpFecha = new System.Windows.Forms.GroupBox();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bModificar = new System.Windows.Forms.Button();
            this.dgvVista = new System.Windows.Forms.DataGridView();
            this.bAtras = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.groupBox1.SuspendLayout();
            this.gpNombre.SuspendLayout();
            this.gpFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVista)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gpNombre);
            this.groupBox1.Controls.Add(this.gpFecha);
            this.groupBox1.Controls.Add(this.rbFecha);
            this.groupBox1.Controls.Add(this.rbNombre);
            this.groupBox1.Controls.Add(this.bFiltrar);
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(16, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(333, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda por...";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // gpNombre
            // 
            this.gpNombre.Controls.Add(this.cbNombre);
            this.gpNombre.Controls.Add(this.label1);
            this.gpNombre.Location = new System.Drawing.Point(67, 39);
            this.gpNombre.Name = "gpNombre";
            this.gpNombre.Size = new System.Drawing.Size(259, 40);
            this.gpNombre.TabIndex = 11;
            this.gpNombre.TabStop = false;
            // 
            // cbNombre
            // 
            this.cbNombre.FormattingEnabled = true;
            this.cbNombre.Location = new System.Drawing.Point(76, 11);
            this.cbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(159, 24);
            this.cbNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // gpFecha
            // 
            this.gpFecha.Controls.Add(this.dtDesde);
            this.gpFecha.Controls.Add(this.dtHasta);
            this.gpFecha.Controls.Add(this.label2);
            this.gpFecha.Controls.Add(this.label3);
            this.gpFecha.Location = new System.Drawing.Point(67, 85);
            this.gpFecha.Name = "gpFecha";
            this.gpFecha.Size = new System.Drawing.Size(259, 103);
            this.gpFecha.TabIndex = 9;
            this.gpFecha.TabStop = false;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(76, 22);
            this.dtDesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(159, 22);
            this.dtDesde.TabIndex = 3;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(76, 67);
            this.dtHasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(159, 22);
            this.dtHasta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hasta:";
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(44, 132);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(17, 16);
            this.rbFecha.TabIndex = 8;
            this.rbFecha.TabStop = true;
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Location = new System.Drawing.Point(44, 53);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(17, 16);
            this.rbNombre.TabIndex = 7;
            this.rbNombre.TabStop = true;
            this.rbNombre.UseVisualStyleBackColor = true;
            this.rbNombre.CheckedChanged += new System.EventHandler(this.rbNombre_CheckedChanged);
            // 
            // bFiltrar
            // 
            this.bFiltrar.ForeColor = System.Drawing.Color.Teal;
            this.bFiltrar.Location = new System.Drawing.Point(123, 220);
            this.bFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(100, 28);
            this.bFiltrar.TabIndex = 6;
            this.bFiltrar.Text = "Filtrar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // bEliminar
            // 
            this.bEliminar.ForeColor = System.Drawing.Color.Teal;
            this.bEliminar.Location = new System.Drawing.Point(207, 303);
            this.bEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(100, 28);
            this.bEliminar.TabIndex = 7;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // bModificar
            // 
            this.bModificar.ForeColor = System.Drawing.Color.Teal;
            this.bModificar.Location = new System.Drawing.Point(60, 303);
            this.bModificar.Margin = new System.Windows.Forms.Padding(4);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(100, 28);
            this.bModificar.TabIndex = 8;
            this.bModificar.Text = "Modificar...";
            this.bModificar.UseVisualStyleBackColor = true;
            this.bModificar.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvVista
            // 
            this.dgvVista.AllowUserToAddRows = false;
            this.dgvVista.AllowUserToDeleteRows = false;
            this.dgvVista.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVista.Location = new System.Drawing.Point(357, 26);
            this.dgvVista.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVista.Name = "dgvVista";
            this.dgvVista.ReadOnly = true;
            this.dgvVista.Size = new System.Drawing.Size(704, 324);
            this.dgvVista.TabIndex = 9;
            this.dgvVista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // bAtras
            // 
            this.bAtras.ForeColor = System.Drawing.Color.Teal;
            this.bAtras.Location = new System.Drawing.Point(953, 374);
            this.bAtras.Margin = new System.Windows.Forms.Padding(4);
            this.bAtras.Name = "bAtras";
            this.bAtras.Size = new System.Drawing.Size(108, 41);
            this.bAtras.TabIndex = 10;
            this.bAtras.Text = "Atrás";
            this.bAtras.UseVisualStyleBackColor = true;
            this.bAtras.Click += new System.EventHandler(this.button4_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // ListarCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 432);
            this.Controls.Add(this.bAtras);
            this.Controls.Add(this.dgvVista);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bModificar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListarCampaña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListarCampaña";
            this.Load += new System.EventHandler(this.ListarCampaña_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpNombre.ResumeLayout(false);
            this.gpNombre.PerformLayout();
            this.gpFecha.ResumeLayout(false);
            this.gpFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.DataGridView dgvVista;
        private System.Windows.Forms.Button bAtras;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.GroupBox gpFecha;
        private System.Windows.Forms.GroupBox gpNombre;
    }
}