using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPaymentDal : IGenericDal<Payment>
    {
        decimal GetEventTicketPrice(int eventId);

        Task<bool> BuyTicketAsync(int eventId, int userId, int eventTicketId);
    }
}