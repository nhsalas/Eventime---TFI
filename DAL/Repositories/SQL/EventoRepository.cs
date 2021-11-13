using DAL.Contracts;
using DAL.Tools;
using Dapper;
using Dominio;
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
    public class EventoRepository : IRepositoryEvento<Evento>
    {
        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[evento] "
                + "(FechaInicio, FechaFinalizacion, Nombre,Tipo, id_cliente) "
                + "VALUES (@FechaInicio, @FechaFinalizacion, @Nombre, @Tipo, @id_cliente)";
        }
        private static string UpdateStatement
        {
            get => "UPDATE [dbo].[evento] SET FechaInicio = @FechaInicio, FechaFinalizacion = @FechaFinalizacion, Nombre = @Nombre, Tipo = @Tipo, id_Cliente = @id_cliente " +
                "WHERE EventoId = @EventoId ";
        }

        private static string DeleteStatement
        {
            get => "DELETE FROM [dbo].[evento] WHERE EventoId = @EventoId ";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[evento] WHERE EventoId = @EventoId ";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[evento]";
        }
        #endregion

        public void Add(Evento evento)
        {
            // Cliente cliente = new Cliente();
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {
                        
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("FechaInicio", evento.FechaInicio);
                        cmd.Parameters.AddWithValue("FechaFinalizacion", evento.FechaFinalizacion);
                        cmd.Parameters.AddWithValue("Nombre", evento.Nombre);
                        cmd.Parameters.AddWithValue("Tipo", evento.Tipo);
                        cmd.Parameters.AddWithValue("id_cliente", evento.NroCliente);

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

        public IEnumerable<Evento> GetAll()
        {
            try
            {
                List<Evento> eventos = new List<Evento>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Evento evento = new Evento();

                        evento.EventoId = Convert.ToInt32(values[0]);
                        evento.FechaInicio = Convert.ToDateTime(values[1]);
                        evento.FechaFinalizacion = Convert.ToDateTime(values[2]);
                        evento.Nombre = values[3].ToString();
                        evento.Tipo = values[4].ToString();
                        evento.NroCliente = Convert.ToInt32(values[5]);

                        eventos.Add(evento);
                    }
                }

                foreach (var evento in eventos)
                {
                    //ClienteRepository cli = new ClienteRepository();
                    //evento.Cliente = cli.GetUno(evento.NroCliente);
                }

                return eventos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Evento> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Evento evento)
        {
            throw new NotImplementedException();
        }
    }
}
