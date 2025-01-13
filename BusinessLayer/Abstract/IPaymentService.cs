using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPaymentService : IGenericService<Payment>
    {

        decimal GetEventTicketPrice(int eventId);

      
        Task<bool> BuyTicketAsync(int eventId, int userId, int eventsTicketId);
    }
}