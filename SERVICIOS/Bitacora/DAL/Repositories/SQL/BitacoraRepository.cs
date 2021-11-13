using SERVICIOS.Bitacora.DAL.Contracts;
using SERVICIOS.Bitacora.DAL.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Bitacora.DAL.Repositories.SQL
{
    internal class BitacoraRepository : IRepositoryBitacora<Dominio.Bitacora>
    {
        // private static string cnnApp = ApplicationSettings.Current.connAplicacion;
        // private static string cnnApp = "Data Source=DESKTOP-EDJTHOR;Initial Catalog=TFI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // HARDCODEADO, CAMBIAR DESPUES

        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[bitacora] "
                + "(FechaHora, Descripcion, Severidad, Usuario) "
                + "VALUES (@FechaHora, @Descripcion, @Severidad, @Usuario)";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[bitacora]";
        }
        public void Add(Dominio.Bitacora bitacora)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("FechaHora", bitacora.FechaHora);
                        cmd.Parameters.AddWithValue("Descripcion", bitacora.Descripcion);
                        cmd.Parameters.AddWithValue("Severidad", bitacora.Severidad);
                        cmd.Parameters.AddWithValue("Usuario", bitacora.Usuario);

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

        public IEnumerable<Dominio.Bitacora> GetAll()
        {
            try
            {
                List<Dominio.Bitacora> movimientos = new List<Dominio.Bitacora>();

                using (var dr = SqlHelperServicios.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Dominio.Bitacora bitacora = new Dominio.Bitacora();

                        bitacora.FechaHora = Convert.ToDateTime(values[1]);
                        bitacora.Descripcion = values[2].ToString();
                        bitacora.Severidad = values[3].ToString();
                        bitacora.Usuario = values[4].ToString();

                        movimientos.Add(bitacora);
                    }
                }
                return movimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Dominio.Bitacora> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Dominio.Bitacora bitacora)
        {
            throw new NotImplementedException();
        }
    }
}
