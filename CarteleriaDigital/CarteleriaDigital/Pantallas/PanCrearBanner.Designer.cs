namespace CarteleriaDigital.Pantallas
{
    partial class PanCrearBanner
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.rbBannerSimple = new System.Windows.Forms.RadioButton();
            this.rbBannerRSS = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbMinutoInicio = new System.Windows.Forms.ComboBox();
            this.cbHoraInicio = new System.Windows.Forms.ComboBox();
            this.cbMinutoFin = new System.Windows.Forms.ComboBox();
            this.cbHoraFin = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(84, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Nombre:";
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(84, 88);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(453, 20);
            this.txtTexto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(31, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Texto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(31, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(84, 125);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(453, 20);
            this.txtURL.TabIndex = 5;
            // 
            // rbBannerSimple
            // 
            this.rbBannerSimple.AutoSize = true;
            this.rbBannerSimple.Location = new System.Drawing.Point(84, 65);
            this.rbBannerSimple.Name = "rbBannerSimple";
            this.rbBannerSimple.Size = new System.Drawing.Size(93, 17);
            this.rbBannerSimple.TabIndex = 1;
            this.rbBannerSimple.TabStop = true;
            this.rbBannerSimple.Text = "Banner Simple";
            this.rbBannerSimple.UseVisualStyleBackColor = true;
            this.rbBannerSimple.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbBannerRSS
            // 
            this.rbBannerRSS.AutoSize = true;
            this.rbBannerRSS.Location = new System.Drawing.Point(175, 65);
            this.rbBannerRSS.Name = "rbBannerRSS";
            this.rbBannerRSS.Size = new System.Drawing.Size(84, 17);
            this.rbBannerRSS.TabIndex = 2;
            this.rbBannerRSS.TabStop = true;
            this.rbBannerRSS.Text = "Banner RSS";
            this.rbBannerRSS.UseVisualStyleBackColor = true;
            this.rbBannerRSS.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "Fecha de Inicio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Fecha de Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFechaInicio.Location = new System.Drawing.Point(133, 28);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFechaFin.Location = new System.Drawing.Point(357, 28);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaFin.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(34, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 72);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rango de Fechas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbMinutoFin);
            this.groupBox2.Controls.Add(this.cbHoraFin);
            this.groupBox2.Controls.Add(this.cbMinutoInicio);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbHoraInicio);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Location = new System.Drawing.Point(34, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 74);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango Horario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Hora de Fin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Hora de Inicio:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.Teal;
            this.btnAceptar.Location = new System.Drawing.Point(462, 346);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 38);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.Teal;
            this.btnCancelar.Location = new System.Drawing.Point(359, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 38);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.cbMinutoInicio.Location = new System.Drawing.Point(182, 39);
            this.cbMinutoInicio.Name = "cbMinutoInicio";
            this.cbMinutoInicio.Size = new System.Drawing.Size(47, 21);
            this.cbMinutoInicio.TabIndex = 101;
            // 
            // cbHoraInicio
            // 
            this.cbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoraInicio.FormattingEnabled = true;
            this.cbHoraInicio.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
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
            this.cbHoraInicio.Location = new System.Drawing.Point(133, 39);
            this.cbHoraInicio.Name = "cbHoraInicio";
            this.cbHoraInicio.Size = new System.Drawing.Size(43, 21);
            this.cbHoraInicio.TabIndex = 100;
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
            this.cbMinutoFin.Location = new System.Drawing.Point(406, 39);
            this.cbMinutoFin.Name = "cbMinutoFin";
            this.cbMinutoFin.Size = new System.Drawing.Size(47, 21);
            this.cbMinutoFin.TabIndex = 103;
            // 
            // cbHoraFin
            // 
            this.cbHoraFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoraFin.FormattingEnabled = true;
            this.cbHoraFin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
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
            this.cbHoraFin.Location = new System.Drawing.Point(357, 39);
            this.cbHoraFin.Name = "cbHoraFin";
            this.cbHoraFin.Size = new System.Drawing.Size(43, 21);
            this.cbHoraFin.TabIndex = 102;
            // 
            // PanCrearBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 396);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbBannerRSS);
            this.Controls.Add(this.rbBannerSimple);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Name = "PanCrearBanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearBanner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.RadioButton rbBannerSimple;
        private System.Windows.Forms.RadioButton rbBannerRSS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMinutoFin;
        private System.Windows.Forms.ComboBox cbHoraFin;
        private System.Windows.Forms.ComboBox cbMinutoInicio;
        private System.Windows.Forms.ComboBox cbHoraInicio;
    }
}