using DAL.Contracts;
using Dapper;
using DOMINIO;
using Microsoft.Extensions.Configuration;
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
    public class DayEventRepository : IRepositoryDayEvent
    {
        DayEvent _oDayEvent = new DayEvent();
        List<DayEvent> _oDayEvents = new List<DayEvent>();

        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;

        public IConfiguration Configuration { get; set; }

        public DayEventRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Delete(int id)
        {
            string message = "";
            try
            {
                _oDayEvent = new DayEvent()
                {
                    DayEventId = id
                };

                using (IDbConnection con = new SqlConnection(cnnApp))
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    var oDayEvents = con.Query<DayEvent>("SP_DayEvent", this.SetParameters(_oDayEvent, (int)OperationType.Delete), commandType: CommandType.StoredProcedure);

                    message = "Evento eliminado correctamente";
                }
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            return message;
        }

        public DayEvent GetEvent(DateTime eventDate)
        {
            _oDayEvent = new DayEvent();
            using (IDbConnection con = new SqlConnection(cnnApp))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql = string.Format(@"SELECT * FROM DayEvent WHERE EventDate = '{0}'", eventDate.ToString("MM-dd-yyyy"));

                var oDayEvents = con.Query<DayEvent>(sql).ToList();

                if (_oDayEvents != null & _oDayEvents.Count() > 0)
                {
                    _oDayEvent = oDayEvents.SingleOrDefault();
                }
                else
                {
                    _oDayEvent.EventDate = eventDate;
                    _oDayEvent.FromDate = eventDate;
                    _oDayEvent.ToDate = eventDate;
                }
            };
            return _oDayEvent;
        }

        public List<DayEvent> GetEvents(DateTime fromDate, DateTime toDate)
        {
            _oDayEvents = new List<DayEvent>();

            using (IDbConnection con = new SqlConnection(cnnApp))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql = string.Format(@"SELECT * FROM DayEvent WHERE EventDate BETWEEN '{0}' AND '{1}'",fromDate.ToString("MM-dd-yyyy"),toDate.ToString("MM-dd-yyyy"));

                var oDayEvents = con.Query<DayEvent>(sql).ToList();

                if (_oDayEvents != null & _oDayEvents.Count() > 0)
                {
                    _oDayEvents = oDayEvents;
                }
            };

            return _oDayEvents;
        }

        public DayEvent SaveOrUpdate(DayEvent oDayEvent)
        {
            _oDayEvent = new DayEvent();
            try
            {
                int operationType = Convert.ToInt32(oDayEvent.DayEventId == 0 ? OperationType.Insert : OperationType.Update);

                using (IDbConnection con = new SqlConnection(cnnApp))
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    var oDayEvents = con.Query<DayEvent>("SP_DayEvent", this.SetParameters(oDayEvent, operationType), commandType: CommandType.StoredProcedure);

                    if(_oDayEvents != null & _oDayEvents.Count()>0)
                    {
                        _oDayEvent = oDayEvents.FirstOrDefault();
                    }
                };
            }
            catch (Exception ex)
            {

                _oDayEvent.Message = ex.Message;
            }
            return _oDayEvent;
        }
        private DynamicParameters SetParameters(DayEvent oDayEvent, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@DayEventId", oDayEvent.DayEventId);
            parameters.Add("@Note", oDayEvent.Note);
            parameters.Add("@EventDate", oDayEvent.EventDate);
            parameters.Add("@OperationType", operationType);

            return parameters;

        }
    }
}
