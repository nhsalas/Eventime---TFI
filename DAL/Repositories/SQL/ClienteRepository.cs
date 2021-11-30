using DAL.Contracts;
using DAL.Tools;
using Dominio;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SQL
{
    internal class ClienteRepository : IRepositoryCliente<Cliente>
    {
        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;

        private static string cnnSomee = ApplicationSettings.Current.ConexionSomee;

        private static string cnnAzure = ApplicationSettings.Current.ConexionAzure;

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[cliente] "
                + "(CUIT, RazonSocial, Saldo,nombre, apellido) "
                + "VALUES (@CUIT, @RazonSocial, @Saldo, @nombre, @apellido)";
        }
        private static string UpdateStatement
        {
            get => "UPDATE [dbo].[cliente] SET RazonSocial = @RazonSocial, Saldo = @Saldo, nombre = @nombre, apellido = @apellido " +
                "WHERE NroCliente = @NroCliente ";
        }

        private static string DeleteStatement
        {
            get => "DELETE FROM [dbo].[cliente] WHERE NroCliente = @NroCliente ";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[cliente] WHERE NroCliente = ";
        }

        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[cliente]";
        }
        #endregion

        public void Add(Cliente cliente)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnAzure))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("CUIT", cliente.CUIT);
                        cmd.Parameters.AddWithValue("RazonSocial", cliente.RazonSocial);
                        cmd.Parameters.AddWithValue("Saldo", cliente.Saldo);
                        cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                        cmd.Parameters.AddWithValue("apellido", cliente.apellido);

                        cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Cliente cliente = new Cliente();

                        cliente.CUIT = Convert.ToInt32(values[0]);
                        cliente.NroCliente = Convert.ToInt32(values[1]);
                        cliente.RazonSocial = values[2].ToString();
                        cliente.Saldo = Convert.ToDecimal(values[3]);
                        cliente.nombre = values[4].ToString();
                        cliente.apellido = values[5].ToString();

                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Cliente> GetOne(int id)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();

                using (var dr = SqlHelper.ExecuteReader(SelectOne + id, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);
                        
                        Cliente cliente = new Cliente();

                        cliente.CUIT = Convert.ToInt32(values[0]);
                        cliente.NroCliente = Convert.ToInt32(values[1]);
                        cliente.RazonSocial = values[2].ToString();
                        cliente.Saldo = Convert.ToDecimal(values[3]);
                        cliente.nombre = values[4].ToString();
                        cliente.apellido = values[5].ToString();

                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

    }
}
