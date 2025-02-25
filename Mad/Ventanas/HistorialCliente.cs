﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace Mad.Ventanas
{
    public partial class HistorialCliente : Form
    {
        bool sidebarExpand;

        string cliente;
        
        public HistorialCliente()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //AQUI EMPIEZA EL SIDE MENU

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SideBarTimer.Start();
        }

        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {       //MINIMIZA
                sidebarContainer.Width -= 10;
                if (sidebarContainer.Width == sidebarContainer.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SideBarTimer.Stop();
                }

            }
            else
            {
                sidebarContainer.Width += 10;
                if (sidebarContainer.Width == sidebarContainer.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SideBarTimer.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.correoRU f_registro = new Ventanas.correoRU();
            f_registro.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.Cliente f_cliente = new Ventanas.Cliente();
            f_cliente.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.Form1 f_hotel = new Ventanas.Form1();
            f_hotel.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.Estatus_habitacion f_estatus = new Ventanas.Estatus_habitacion();
            f_estatus.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.HistorialCliente f_historial = new Ventanas.HistorialCliente();
            f_historial.Show();
        }
        //PORQUE NO FUNCIONA EL LOGIN AAAAAAAAAAAAAAAAAAAAAAAAAAA
        private void button15_Click(object sender, EventArgs e)
        {

            //Ventanas.login f_login = new Ventanas.login();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.RepOcupacionHoteñ f_repHotel = new Ventanas.RepOcupacionHoteñ();
            f_repHotel.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.Cancelacion f_cancel = new Ventanas.Cancelacion();
            f_cancel.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.Reservación f_reserv = new Ventanas.Reservación();
            f_reserv.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.RepVentas f_ventas = new Ventanas.RepVentas();
            f_ventas.Show();
        }

        private void IN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.CHECKIN f_checkin = new Ventanas.CHECKIN();
            f_checkin.Show();
        }

        private void OUT_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventanas.CHECKOUT f_checkout = new Ventanas.CHECKOUT();
            f_checkout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            int opcionBusqueda = 0;

            // Verificar el RadioButton seleccionado y asignar la opción correspondiente
            if (radioButton1.Checked)
            {
                opcionBusqueda = 1;
            }
            else if (radioButton2.Checked)
            {
                opcionBusqueda = 2;
            }
            else if (radioButton3.Checked)
            {
                opcionBusqueda = 3;
            }


            // Llamar al procedimiento almacenado para buscar clientes
            var obj = new EnlaceDB();
            var tablita = new DataTable();
            tablita = obj.BuscarClientes(busqueda, opcionBusqueda);

            // Mostrar los resultados en un DataGridView u otro control adecuado
            dataGridView2.DataSource = tablita;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cliente = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                var obj = new EnlaceDB();
                var tablita = new DataTable();
                tablita = obj.HistorialCliente(cliente, null);


                // Mostrar los resultados en un DataGridView u otro control adecuado
                dataGridView1.DataSource = tablita;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var obj = new EnlaceDB();
                var tablita = new DataTable();
                tablita = obj.HistorialCliente(null, dateTimePicker1.Text);


                // Mostrar los resultados en un DataGridView u otro control adecuado
                dataGridView1.DataSource = tablita;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //AQUI TERMINA  EL SIDE MENU
    }
}
