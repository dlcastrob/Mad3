﻿/*
Autor: Alejandro Villarreal

LMAD

PARA EL PROYECTO ES OBLIGATORIO EL USO DE ESTA CLASE, 
EN EL SENTIDO DE QUE LOS DATOS DE CONEXION AL SERVIDOR ESTAN DEFINIDOS EN EL App.Config
Y NO TENER ESOS DATOS EN CODIGO DURO DEL PROYECTO.

LOS MÉTODOS QUE SE DEFINEN EN ESTA CLASE SON EJEMPLOS, PARA QUE SE BASEN Y USTEDES HAGAN LOS SUYOS PROPIOS
Y DEFINAN Y PROGRAMEN TODOS LOS MÉTODOS QUE SEAN NECESARIOS PARA SU PROYECTO.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


/*
Se tiene que cambiar el namespace para el que usen en su proyecto
*/
namespace WindowsFormsApplication1
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();

        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

        private static void conectar()
        {
            /*
			Para que funcione el ConfigurationManager
			en la sección de "Referencias" de su proyecto, en el "Solution Explorer"
			dar clic al botón derecho del mouse y dar clic a "Add Reference"
			Luego elegir la opción System.Configuration
			
			tal como lo vimos en clase.
			*/
            string cnn = ConfigurationManager.ConnectionStrings["Grupo03"].ToString();
            // Cambiar Grupo01 por el que ustedes hayan definido en el App.Confif
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }
        private static void desconectar()
        {
            _conexion.Close();
        }

        public bool Autentificar(string us, string ps)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "SP_ValidaUser";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                var parametro1 = _comandosql.Parameters.Add("@u", SqlDbType.Char, 20);
                parametro1.Value = us;
                var parametro2 = _comandosql.Parameters.Add("@p", SqlDbType.Char, 20);
                parametro2.Value = ps;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if (_tabla.Rows.Count > 0)
                {
                    isValid = true;
                }

            }
            catch (SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        }

        public DataTable BuscarClientes(string busqueda, int opcionBusqueda)
        {
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "spBuscarCliente";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Busqueda", SqlDbType.VarChar, 255);
                parametro1.Value = busqueda;

                var parametro2 = _comandosql.Parameters.Add("@OpcionBusqueda", SqlDbType.Int);
                parametro2.Value = opcionBusqueda;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }


            catch (SqlException e)
            {
                string msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


        public DataTable BuscarCiudadHotel()
        {
            DataTable dataTable = new DataTable();
            try
            {
                conectar();
                string qry = "spMostrarCiudades";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                // Crear un adaptador de datos y un DataTable para almacenar los resultados
                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);

                adapter.Fill(dataTable);


            }


            catch (SqlException e)
            {
                string msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }

        public string BuscarIDhotel(string NombreHotel)
        {
            string hotelID = string.Empty;

            try
            {
                conectar();
                string qry = "spObtenerHotelIDPorNombre";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                var parametro1 = _comandosql.Parameters.Add("@NombreHotel", SqlDbType.VarChar, 255);
                parametro1.Value = NombreHotel;

                conectar();

                hotelID = _comandosql.ExecuteScalar()?.ToString();
            }
            catch (SqlException e)
            {
                string msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return hotelID;
        }

        public DataTable ObtenerNombresHoteles()
        {
            DataTable dataTable = new DataTable();
            try
            {
                conectar();
                string qry = "spMostrarHoteles";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                // Crear un adaptador de datos y un DataTable para almacenar los resultados
                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);

                adapter.Fill(dataTable);


            }


            catch (SqlException e)
            {
                string msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }
        public DataTable BuscarHotelesenCiudad(string Ciudad)
        {

            DataTable dataTable = new DataTable();
            try
            {
                conectar();
                string qry = "sp_BuscarHotelesPorCiudad";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 255);
                parametro1.Value = Ciudad;
                // Crear un adaptador de datos y un DataTable para almacenar los resultados
                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);

                adapter.Fill(dataTable);


            }


            catch (SqlException e)
            {
                string msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }

        public DataTable BuscarhabReserv(string fechaentrada, string fechaSalida)
        {

            DataTable dataTable = new DataTable();
            try
            {
                conectar();
                string qry = "spReservacion";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                SqlParameter parametroFecha = new SqlParameter("@FechaEntrada", SqlDbType.Date);
                parametroFecha.Value = fechaentrada; // Obtener la fecha sin la parte de la hora
                _comandosql.Parameters.Add(parametroFecha);


                SqlParameter parametroFecha2 = new SqlParameter("@FechaSalida", SqlDbType.Date);
                parametroFecha2.Value = fechaSalida; // Obtener la fecha sin la parte de la hora
                _comandosql.Parameters.Add(parametroFecha2);


                // Crear un adaptador de datos y un DataTable para almacenar los resultados
                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);

                adapter.Fill(dataTable);


            }


            catch (SqlException e)
            {
                string msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return dataTable;

        }

        /*
        public bool InsertUsuario(string tipoUs, string CorreoElectronico, int Contrasena, string NombreCompleto, string NumeroNomina, string FechaNacimiento, string Domicilio, string TelefonoCasa, string TelefonoCel, string UsuarioID)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "spGestionUsuarios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var paramOpcion = _comandosql.Parameters.Add("@tipoUs", SqlDbType.Char, 1);
                paramOpcion.Value = "I";
                var paramCorreo = _comandosql.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 30);
                paramCorreo.Value = CorreoElectronico;
                var paramNombre = _comandosql.Parameters.Add("@Contrasena", SqlDbType.VarChar, 50);
                paramNombre.Value = Contrasena;
                var numNomina = _comandosql.Parameters.Add("@NombreCompleto", SqlDbType.Int);
                numNomina.Value = NombreCompleto;
                var paramFechaNac = _comandosql.Parameters.Add("@NumeroNomina", SqlDbType.Date);
                paramFechaNac.Value = NumeroNomina;
                var paramDomicilio = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar, 50);
                paramDomicilio.Value = FechaNacimiento;
                var paramPassword = _comandosql.Parameters.Add("@Domicilio", SqlDbType.VarChar, 30);
                paramPassword.Value = Domicilio;
                var paramTipoUsuario = _comandosql.Parameters.Add("@TelefonoCasa", SqlDbType.Int);
                paramTipoUsuario.Value = TelefonoCasa;
                var paramTelefono = _comandosql.Parameters.Add("@TelefonoCelular", SqlDbType.Int);
                paramTelefono.Value = TelefonoCasa;
                var paramUsuarioRegistro = _comandosql.Parameters.Add("@UsuarioID", SqlDbType.Int);
                paramUsuarioRegistro.Value = UsuarioID;

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                add = false;
                msg = "ERROR" + e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }

        */
        public bool InsertarCliente(string apellidos, string Nombre, string DomicilioC, string rfc, string correoElectronico, string estadoCivil, string referenciaHotel, string fechaNacimiento, string telefonoCasa, string telefonoCelular)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "spGestionarCliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var paramOpcion = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                paramOpcion.Value = "C";
                var paramApellidos = _comandosql.Parameters.Add("@apellidos", SqlDbType.VarChar, 100);
                paramApellidos.Value = apellidos;
                var paramNombre = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
                paramNombre.Value = Nombre;

                var paramDomicilio = _comandosql.Parameters.Add("@domicilioCompleto", SqlDbType.VarChar, 200);
                paramDomicilio.Value = DomicilioC;
                var paramRFC = _comandosql.Parameters.Add("@rfc", SqlDbType.VarChar, 13);
                paramRFC.Value = rfc;
                var paramCorreo = _comandosql.Parameters.Add("@correoElectronico", SqlDbType.VarChar, 100);
                paramCorreo.Value = correoElectronico;
                var paramTelefono = _comandosql.Parameters.Add("@telefonoCasa", SqlDbType.VarChar, 20);
                paramTelefono.Value = telefonoCasa;
                var paramCelular = _comandosql.Parameters.Add("@telefonoCelular", SqlDbType.VarChar, 20);
                paramCelular.Value = telefonoCelular;
                var paramReferencia = _comandosql.Parameters.Add("@referenciaHotel", SqlDbType.VarChar, 200);
                paramReferencia.Value = referenciaHotel;
                var paramFechaNacCliente = _comandosql.Parameters.Add("@fechaNacimiento", SqlDbType.Date);
                paramFechaNacCliente.Value = fechaNacimiento;

                var paramEstadoCivil = _comandosql.Parameters.Add("@estadoCivil", SqlDbType.VarChar, 20);
                paramEstadoCivil.Value = estadoCivil;

           

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }

        public bool InsertarHotel(string nombreHotel, string ciudad, string estado, string pais, string domicilio, int numeroPisos, string FechaInicioOperaciones)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "spGestionarHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var paramAccion = _comandosql.Parameters.Add("@accion", SqlDbType.Char, 1);
                paramAccion.Value = "C";
                var paramNombreHotel = _comandosql.Parameters.Add("@nombreHotel", SqlDbType.VarChar, 255);
                paramNombreHotel.Value = nombreHotel;
                var paramCiudad = _comandosql.Parameters.Add("@ciudad", SqlDbType.VarChar, 255);
                paramCiudad.Value = ciudad;
                var paramEstado = _comandosql.Parameters.Add("@estado", SqlDbType.VarChar, 255);
                paramEstado.Value = estado;
                var paramPais = _comandosql.Parameters.Add("@pais", SqlDbType.VarChar, 255);
                paramPais.Value = pais;
                var paramDomicilio = _comandosql.Parameters.Add("@domicilio", SqlDbType.VarChar, 255);
                paramDomicilio.Value = domicilio;
                var paramNumeroPisos = _comandosql.Parameters.Add("@numeroPisos", SqlDbType.Int);
                paramNumeroPisos.Value = numeroPisos;
                var paramFechaInicioOperaciones = _comandosql.Parameters.Add("@FechaInicioOperaciones", SqlDbType.Date);
                paramFechaInicioOperaciones.Value = FechaInicioOperaciones;

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }

        public bool InsertarServicioAdicional(int hotelID, string nombreServicio, decimal precioServicio)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "spRegistrarServicioAdicional";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var paramHotelID = _comandosql.Parameters.Add("@hotelID", SqlDbType.Int);
                paramHotelID.Value = hotelID;
                var paramNombreServicio = _comandosql.Parameters.Add("@nombreServicio", SqlDbType.VarChar, 255);
                paramNombreServicio.Value = nombreServicio;
                var paramPrecioServicio = _comandosql.Parameters.Add("@precioServicio", SqlDbType.Decimal);
                paramPrecioServicio.Value = precioServicio;

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }

        public bool InsertarTipoHabitacion(string tipoHabitacionID, int hotelID, decimal precioNochePersona, int capacidadMaxima, int numeroCamas, string tiposCama, int nivelHabitacion,  int cantidadHabitaciones)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "spGestionarTipoHabitacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                // Agregar los parámetros necesarios para el Stored Procedure
                _comandosql.Parameters.AddWithValue("@tipoHabitacionID", tipoHabitacionID);
                _comandosql.Parameters.AddWithValue("@hotelID", hotelID);
                _comandosql.Parameters.AddWithValue("@precioNochePersona", precioNochePersona);
                _comandosql.Parameters.AddWithValue("@capacidadMaxima", capacidadMaxima);
                _comandosql.Parameters.AddWithValue("@numeroCamas", numeroCamas);
                _comandosql.Parameters.AddWithValue("@tiposCama", tiposCama);
                _comandosql.Parameters.AddWithValue("@nivelHabitacion", nivelHabitacion);
                _comandosql.Parameters.AddWithValue("@cantidadHabitaciones", cantidadHabitaciones);
                _comandosql.Parameters.AddWithValue("@accion", "C");

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }

      

        


        public bool InsertarReservacion(string reservacionID,  int clienteID, int hotelID, int habitacionID, DateTime fechaEntrada, DateTime fechaSalida, decimal anticipo, int cantidadHabitaciones, int cantidadPersonasHabitacion, string estado)
        {
            var msg = "";
            var add = true;
            try
            {
                conectar();
                string qry = "spGestionarReservacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                // Agregar los parámetros necesarios para el Stored Procedure
                _comandosql.Parameters.AddWithValue("@ReservacionID", reservacionID);
                _comandosql.Parameters.AddWithValue("@ClienteID", clienteID);
                _comandosql.Parameters.AddWithValue("@HotelID", hotelID);
                _comandosql.Parameters.AddWithValue("@HabitacionID", habitacionID);
                _comandosql.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                _comandosql.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                _comandosql.Parameters.AddWithValue("@Anticipo", anticipo);
                _comandosql.Parameters.AddWithValue("@CantidadHabitaciones", cantidadHabitaciones);
                _comandosql.Parameters.AddWithValue("@CantidadPersonasHabitacion", cantidadPersonasHabitacion);
                _comandosql.Parameters.AddWithValue("@Estado", estado);
                _comandosql.Parameters.AddWithValue("@Accion", "C"); // Acción para crear una nueva reservación

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return add;
        }


    }
}

