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
    public class ServicioRepository : IRepositoryServicio<Servicio>
    {
        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[servicio] "
                + "(descripcion, nombre, precio, id_evento) "
                + "VALUES (@descripcion, @nombre, @precio, @id_evento)";
        }
        private static string UpdateStatement
        {
            get => "UPDATE [dbo].[servicio] SET descripcion = @descripcion, nombre = @nombre, precio = @precio, id_evento = @id_evento" +
                "WHERE id = @id ";
        }

        private static string DeleteStatement
        {
            get => "DELETE FROM [dbo].[servicio] WHERE id = @id ";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[servicio] WHERE id = @id ";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[servicio]";
        }
        #endregion
        public void Add(Servicio servicio)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("descripcion", servicio.descripcion);
                        cmd.Parameters.AddWithValue("nombre", servicio.nombre);
                        cmd.Parameters.AddWithValue("precio", servicio.precio);
                        cmd.Parameters.AddWithValue("id_evento", servicio.id_evento);

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

        public IEnumerable<Servicio> GetAll()
        {
            try
            {
                List<Servicio> servicios = new List<Servicio>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Servicio servicio = new Servicio();

                        servicio.descripcion = values[1].ToString();
                        servicio.nombre = values[2].ToString();
                        servicio.precio = Convert.ToDecimal(values[3]);
                        servicio.id_evento = Convert.ToInt32(values[5]);

                        servicios.Add(servicio);
                    }
                }

                return servicios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Servicio> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Servicio servicio)
        {
            throw new NotImplementedException();
        }
    }
}
