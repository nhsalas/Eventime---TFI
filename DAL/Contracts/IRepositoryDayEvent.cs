using DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepositoryDayEvent
    {
        DayEvent SaveOrUpdate(DayEvent oDayEvent);
        DayEvent GetEvent(DateTime eventDate);
        List<DayEvent> GetEvents(DateTime fromDate, DateTime toDate);
        string Delete(int id);
    }
}
