using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;

namespace pryTPFinal.Clases
{
    internal class verduleros
    {
        OleDbCommand comando;
        OleDbDataReader reader;
        OleDbConnection conexionBD;
        OleDbDataAdapter adapter;
        string cadenaconexion = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=C:\\Users\\Nico\\Downloads\\VERDULEROS.mdb";
        public string estadoconexion = "";


        public void Conectar()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaconexion;
                conexionBD.Open();
                estadoconexion = "conectado";
            }
            catch (Exception ex)
            {
                estadoconexion = "Error " + ex.ToString();

            }

        }
        public void mostrar(DataGridView TablaProductos)
        {
            var cadena = ConfigurationManager.ConnectionStrings["dbacces"].ConnectionString;
            try
            {
                using (OleDbConnection conector = new OleDbConnection(cadena))
                {
                    conector.Open();
                    string query = @"select * from PRODUCTOS";
                    DataTable DT = new DataTable();
                    comando = new OleDbCommand(query, conector);
                    adapter = new OleDbDataAdapter(comando);
                    adapter.SelectCommand = comando;
                    adapter.Fill(DT);
                    TablaProductos.DataSource = DT;


                }

            }
            catch (Exception ex)
            {
                estadoconexion = "Error " + ex;
            }

        }
        public void insertar(TextBox IdProducto, TextBox NomProducto, TextBox IdGrupo, TextBox Precio)
        {
            var cadena = ConfigurationManager.ConnectionStrings["dbacces"].ConnectionString;
            try
            {
                using (OleDbConnection conector = new OleDbConnection(cadena))
                {
                    conector.Open();
                    string query = @"insert into TablaPRODUCTOS(IdProducto,	NomProducto, IdGrupo, Precio )values(@IdP,@Nom,@IdG,@Precio);";
                    comando = new OleDbCommand(query, conector);
                    comando.Parameters.AddWithValue("@IdP", IdProducto.Text);
                    comando.Parameters.AddWithValue("@Nom", NomProducto.Text);
                    comando.Parameters.AddWithValue("@IdG", IdGrupo.Text);
                    comando.Parameters.AddWithValue("@Precio", Precio.Text);
                    if (comando.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Se guardo el producto ");
                    }
                }




            }
            catch (Exception ex)
            {
                estadoconexion = "Error " + ex;
            }

        }
        public void Buscar(TextBox palabra, DataGridView data)
        {
            var cadena = ConfigurationManager.ConnectionStrings["dbacces"].ConnectionString;
            try
            {
                using (OleDbConnection conector = new OleDbConnection(cadena))
                {
                    conector.Open();
                    string query = @"select * from PRODUCTOS where NomProducto=@Nom";
                    DataTable DT = new DataTable();
                    comando = new OleDbCommand(query, conector);
                    comando.Parameters.AddWithValue("@Nom", palabra.Text);
                    adapter = new OleDbDataAdapter(comando);
                    adapter.SelectCommand = comando;
                    adapter.Fill(DT);
                    data.DataSource = DT;

                }

            }
            catch (Exception ex)
            {
                estadoconexion = "Error " + ex;
            }

        }
        public void modificar(TextBox NomACambiar, TextBox NomProducto)
        {
            var cadena = ConfigurationManager.ConnectionStrings["dbacces"].ConnectionString;
            try
            {
                using (OleDbConnection conector = new OleDbConnection(cadena))
                {
                    conector.Open();
                    string query = @"update PRODUCTOS set NomProducto=@NomACambiar where NomProducto =@NomProducto";
                    comando = new OleDbCommand(query, conector);
                    comando.Parameters.AddWithValue("@NomProducto", NomProducto.Text);
                    comando.Parameters.AddWithValue("@NomACambiar", NomACambiar.Text);
                    if (comando.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Actualizado");
                    }
                }

            }
            catch (Exception ex)
            {
                estadoconexion = "Error " + ex.ToString();
            }
        }

    }
}
