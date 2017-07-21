namespace CarteleriaDigital.Pantallas
{
    partial class ListarBanner
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
            this.gb_BuscarPor = new System.Windows.Forms.GroupBox();
            this.rbFechas = new System.Windows.Forms.RadioButton();
            this.rbPorNombre = new System.Windows.Forms.RadioButton();
            this.gpFechas = new System.Windows.Forms.GroupBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.gpPorNombre = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.gpTipo = new System.Windows.Forms.GroupBox();
            this.rbTipo = new System.Windows.Forms.RadioButton();
            this.gb_BuscarPor.SuspendLayout();
            this.gpFechas.SuspendLayout();
            this.gpPorNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_BuscarPor
            // 
            this.gb_BuscarPor.Controls.Add(this.rbTipo);
            this.gb_BuscarPor.Controls.Add(this.gpTipo);
            this.gb_BuscarPor.Controls.Add(this.rbFechas);
            this.gb_BuscarPor.Controls.Add(this.rbPorNombre);
            this.gb_BuscarPor.Controls.Add(this.gpFechas);
            this.gb_BuscarPor.Controls.Add(this.gpPorNombre);
            this.gb_BuscarPor.Controls.Add(this.btnFiltrar);
            this.gb_BuscarPor.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gb_BuscarPor.Location = new System.Drawing.Point(12, 12);
            this.gb_BuscarPor.Name = "gb_BuscarPor";
            this.gb_BuscarPor.Size = new System.Drawing.Size(251, 282);
            this.gb_BuscarPor.TabIndex = 0;
            this.gb_BuscarPor.TabStop = false;
            this.gb_BuscarPor.Text = "Buscar por...";
            // 
            // rbFechas
            // 
            this.rbFechas.AutoSize = true;
            this.rbFechas.Location = new System.Drawing.Point(18, 192);
            this.rbFechas.Name = "rbFechas";
            this.rbFechas.Size = new System.Drawing.Size(14, 13);
            this.rbFechas.TabIndex = 12;
            this.rbFechas.TabStop = true;
            this.rbFechas.UseVisualStyleBackColor = true;
            this.rbFechas.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbPorNombre
            // 
            this.rbPorNombre.AutoSize = true;
            this.rbPorNombre.Location = new System.Drawing.Point(18, 51);
            this.rbPorNombre.Name = "rbPorNombre";
            this.rbPorNombre.Size = new System.Drawing.Size(14, 13);
            this.rbPorNombre.TabIndex = 11;
            this.rbPorNombre.TabStop = true;
            this.rbPorNombre.UseVisualStyleBackColor = true;
            this.rbPorNombre.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // gpFechas
            // 
            this.gpFechas.Controls.Add(this.dtpFechaInicio);
            this.gpFechas.Controls.Add(this.label2);
            this.gpFechas.Controls.Add(this.label3);
            this.gpFechas.Controls.Add(this.dtpFechaFin);
            this.gpFechas.Location = new System.Drawing.Point(36, 157);
            this.gpFechas.Name = "gpFechas";
            this.gpFechas.Size = new System.Drawing.Size(209, 84);
            this.gpFechas.TabIndex = 10;
            this.gpFechas.TabStop = false;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(73, 15);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde:";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Todos",
            "Simple",
            "RSS"});
            this.cbTipo.Location = new System.Drawing.Point(73, 18);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hasta:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(73, 53);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaFin.TabIndex = 5;
            // 
            // gpPorNombre
            // 
            this.gpPorNombre.Controls.Add(this.label1);
            this.gpPorNombre.Controls.Add(this.txtNombre);
            this.gpPorNombre.Location = new System.Drawing.Point(36, 28);
            this.gpPorNombre.Name = "gpPorNombre";
            this.gpPorNombre.Size = new System.Drawing.Size(209, 55);
            this.gpPorNombre.TabIndex = 9;
            this.gpPorNombre.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(73, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.ForeColor = System.Drawing.Color.Teal;
            this.btnFiltrar.Location = new System.Drawing.Point(100, 247);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Location = new System.Drawing.Point(112, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Location = new System.Drawing.Point(154, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(269, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(519, 311);
            this.dataGridView1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Teal;
            this.button4.Location = new System.Drawing.Point(687, 372);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Atrás";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // gpTipo
            // 
            this.gpTipo.Controls.Add(this.cbTipo);
            this.gpTipo.Controls.Add(this.label4);
            this.gpTipo.Location = new System.Drawing.Point(36, 96);
            this.gpTipo.Name = "gpTipo";
            this.gpTipo.Size = new System.Drawing.Size(209, 55);
            this.gpTipo.TabIndex = 10;
            this.gpTipo.TabStop = false;
            // 
            // rbTipo
            // 
            this.rbTipo.AutoSize = true;
            this.rbTipo.Location = new System.Drawing.Point(18, 120);
            this.rbTipo.Name = "rbTipo";
            this.rbTipo.Size = new System.Drawing.Size(14, 13);
            this.rbTipo.TabIndex = 13;
            this.rbTipo.TabStop = true;
            this.rbTipo.UseVisualStyleBackColor = true;
            this.rbTipo.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            // 
            // ListarBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gb_BuscarPor);
            this.Name = "ListarBanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListarBanner";
            this.gb_BuscarPor.ResumeLayout(false);
            this.gb_BuscarPor.PerformLayout();
            this.gpFechas.ResumeLayout(false);
            this.gpFechas.PerformLayout();
            this.gpPorNombre.ResumeLayout(false);
            this.gpPorNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpTipo.ResumeLayout(false);
            this.gpTipo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_BuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbFechas;
        private System.Windows.Forms.RadioButton rbPorNombre;
        private System.Windows.Forms.GroupBox gpFechas;
        private System.Windows.Forms.GroupBox gpPorNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.RadioButton rbTipo;
        private System.Windows.Forms.GroupBox gpTipo;
    }
}