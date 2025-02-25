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
using static Mad.Funciones;
using static Mad.Listas;
namespace Mad.Ventanas
{
    public partial class Cliente : Form
    {
        Mad.Funciones funciones = new Mad.Funciones();
        bool sidebarExpand;
        public Cliente()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string firstLetter = textBox.Text.Substring(0, 1).ToUpper();
                string remainingText = textBox.Text.Substring(1).ToLower();
                textBox.Text = firstLetter + remainingText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void patRC_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string firstLetter = textBox.Text.Substring(0, 1).ToUpper();
                string remainingText = textBox.Text.Substring(1).ToLower();
                textBox.Text = firstLetter + remainingText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void matRC_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string firstLetter = textBox.Text.Substring(0, 1).ToUpper();
                string remainingText = textBox.Text.Substring(1).ToLower();
                textBox.Text = firstLetter + remainingText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void calleRC_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string firstLetter = textBox.Text.Substring(0, 1).ToUpper();
                string remainingText = textBox.Text.Substring(1).ToLower();
                textBox.Text = firstLetter + remainingText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void correoRC_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (funciones.AreControlsNotEmpty(this))
            {
                bool validar = false;
                DateTime fechaNacimiento = fechaNacRc.Value;
                DateTime fechaActual = fechaNacRc.Value;

                string fechaNacimiento_ = fechaNacRc.Text;
                
                string emailAddress = correoRC.Text;

                string apellidos = patRC.Text + " " + matRC.Text;
                string nombre= nonRC.Text;
                string domicilioCompleto = calleRC.Text + " " + numExtRC.Text + " " + colRC.Text;
                string rfc = rfcRC.Text;
                string correoElectronico = correoRC.Text;
                string telefonoCasa = telCasaRC.Text;
                string telefonoCelular = telCelRC.Text;
                string referenciaHotel = comoRC.Text;
                //  string fechaNacimiento = fechaNacRc.Text;
                string estadoCivil = estadoCivRC.Text;
                
                DateTime fecha = DateTime.Now.Date; // Fecha actual
                                                    // DateTime hora = DateTime.Now.TimeOfDay; // Hora actual
              //  string usuarioOperativo = Environment.UserName; // Usuario operativo del sistema

                if (fechaNacimiento > fechaActual)
                {
                    validar = true;
                    MessageBox.Show("La fecha de nacimiento no puede ser posterior a la fecha actual.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                bool isValidEmail = funciones.IsValidEmail(emailAddress);


                if (isValidEmail == false)
                {
                    validar = true;
                    MessageBox.Show("El correo electrónico no  es válido.");

                }


             

                if (validar == false)
                {
                    MessageBox.Show("Todos los datos son correctos.");

                    var dB = new EnlaceDB();
                    bool insertarCliente = dB.InsertarCliente(apellidos, nombre, domicilioCompleto, rfc, emailAddress, estadoCivil, referenciaHotel, fechaNacimiento_,  telefonoCasa, telefonoCelular);
                    if (insertarCliente == true)
                    {

                        MessageBox.Show("Se registro Correctamente");
                        nonRC.Text = string.Empty;
                        patRC.Text = string.Empty;
                        matRC.Text = string.Empty;
                        calleRC.Text = string.Empty;
                        numExtRC.Text = string.Empty;
                        colRC.Text = string.Empty;
                        rfcRC.Text = string.Empty;
                        correoRC.Text = string.Empty;
                        telCasaRC.Text = string.Empty;
                        telCelRC.Text = string.Empty;
                        comoRC.Text = string.Empty;
                        estadoCivRC.Text = string.Empty;
                       DateTime fechaNacRc = DateTime.Now.Date;


                    }
                    else {
                        MessageBox.Show("El registro salio mal");


                    }

                    //  string estado = "Activo"; // Estado predeterminado

                    // Cierra la conexión cuando hayas terminado de usarla

                    //funciones.LimpiarControles(this);

                }

            }
            else
            {

                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }

        private void colRC_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string firstLetter = textBox.Text.Substring(0, 1).ToUpper();
                string remainingText = textBox.Text.Substring(1).ToLower();
                textBox.Text = firstLetter + remainingText;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
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

        private void comoRC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fechaNacRc_ValueChanged(object sender, EventArgs e)
        {

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



        //AQUI TERMINA  EL SIDE MENU
    }
}
