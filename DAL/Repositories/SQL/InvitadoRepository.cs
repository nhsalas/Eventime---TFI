using DAL.Contracts;
using DAL.Tools;
using DOMINIO;
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
    public class InvitadoRepository : IRepositoryInvitado<Invitado>
    {
        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;

        private static string cnnSomee = ApplicationSettings.Current.ConexionSomee;

        private static string cnnAzure = ApplicationSettings.Current.ConexionAzure;

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[invitado] "
                + "(DNI, nombre, apellido, email, id_evento) "
                + "VALUES (@DNI, @nombre, @apellido, @email, @id_evento)";
        }
        private static string UpdateStatement
        {
            get => "UPDATE [dbo].[invitado] SET DNI = @DNI, nombre = @nombre, apellido = @apellido, email = @email, id_evento = @id_evento" +
                "WHERE id = @id ";
        }

        private static string DeleteStatement
        {
            get => "DELETE FROM [dbo].[invitado] WHERE id = @id ";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[invitado] WHERE id = @id ";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[invitado]";
        }
        #endregion
        public void Add(Invitado invitado)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnAzure))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("DNI", invitado.DNI);
                        cmd.Parameters.AddWithValue("nombre", invitado.nombre);
                        cmd.Parameters.AddWithValue("apellido", invitado.apellido);
                        cmd.Parameters.AddWithValue("email", invitado.email);
                        cmd.Parameters.AddWithValue("id_evento", invitado.id_evento);

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

        public IEnumerable<Invitado> GetAll()
        {
            try
            {
                List<Invitado> invitados = new List<Invitado>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Invitado invitado = new Invitado();

                        invitado.DNI = Convert.ToInt32(values[1]);
                        invitado.nombre = values[2].ToString();
                        invitado.apellido = values[3].ToString();
                        invitado.email = values[4].ToString();
                        invitado.id_evento = Convert.ToInt32(values[5]);

                        invitados.Add(invitado);
                    }
                }

                return invitados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Invitado> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Invitado invitado)
        {
            throw new NotImplementedException();
        }
    }
}
