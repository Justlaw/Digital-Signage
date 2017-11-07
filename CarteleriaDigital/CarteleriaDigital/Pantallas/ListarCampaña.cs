﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;

namespace CarteleriaDigital.Pantallas
{
    public partial class ListarCampaña : Form
    {
        CampañaDAO camp = new CampañaDAO();
        

        public ListarCampaña()
        {
            InitializeComponent();

            DAO.CampañaDAO bd = new DAO.CampañaDAO();
            DataSet ds = bd.filtrarCampañaPorFecha(dtDesde.Value,dtHasta.Value);
            dgvVista.DataSource = ds.Tables[0];
            
        }

        private void formatearTabla(DataTable dt)
        {
            dgvVista.DataSource = dt;
            dgvVista.Columns[0].Visible = false;
            dgvVista.Columns[1].Visible = false;
            dgvVista.Columns[3].Visible = false;
            rbNombre.Checked = true;

            //Formateando ancho de las columnas
            //Columna ID banner
            dgvVista.Columns[1].Width = 30;
            //Columna de Activo
            dgvVista.Columns[4].Width = 45;
            // Columnas de las horas de inicio y fin
            dgvVista.Columns[7].Width = 25;
            dgvVista.Columns[8].Width = 25;
            dgvVista.Columns[9].Width = 25;
            dgvVista.Columns[10].Width = 25;

            int filas = dgvVista.Rows.Count;

            for (int i = 0; i <= filas - 1; i++)
            {
                dgvVista[5, i].Value = dgvVista[5, i].Value.ToString().Remove(11);
                dgvVista[6, i].Value = dgvVista[6, i].Value.ToString().Remove(11);
                if (dgvVista[4, i].Value.ToString() == "False")
                {
                    dgvVista[4, i].Value = "No";
                }
                else
                {
                    dgvVista[4, i].Value = "Sí";
                }

            }

        }

        // button4 es el bAtrás
        private void button4_Click(object sender, EventArgs e)
        {
            ListarCampaña cerrar = new ListarCampaña();
            cerrar.Hide();
            this.SetVisibleCore(false);

            PanCampaña abrir = new PanCampaña();
            abrir.Show();
        }


        //button1 es el bFiltrar
        private void button1_Click(object sender, EventArgs e)
        {
            if (rbNombre.Checked)
            {
                DAO.CampañaDAO bd = new DAO.CampañaDAO();
                DataSet ds = bd.filtrarCampañaPorNombre(cbNombre.Text);
                dgvVista.DataSource = ds.Tables[0];
            }

            if (rbFecha.Checked)
            {
                DAO.CampañaDAO bd = new DAO.CampañaDAO();
                DataSet ds = bd.filtrarCampañaPorFecha(dtDesde.Value, dtHasta.Value);
                dgvVista.DataSource = ds.Tables[0];
            }
        }
        //btDesde
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /// Crear una lista y levantar los datos
        }

        private void groupBox1_Enter(object sender, EventArgs e)

        {

        }

        //bModificar
        private void button3_Click(object sender, EventArgs e)
        {
            Pantallas.ModificarCampaña abrir = new Pantallas.ModificarCampaña();
            abrir.Show();
            this.SetVisibleCore(false);
        }
        //bEliminar
        private void Button2_Click(object sender, EventArgs e) {

        }

        private void ListarCampaña_Load(object sender, EventArgs e)

        {

        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            gpFecha.Enabled = false;
            gpNombre.Enabled = true;
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            gpFecha.Enabled = true;
            gpNombre.Enabled = false;
        }
    }
}
