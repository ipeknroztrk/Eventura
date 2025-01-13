using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PaymentManager : IGenericService<Payment>, IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public Task<bool> BuyTicketAsync(int eventId, int userId, int eventTicketId)
        {
            return _paymentDal.BuyTicketAsync(eventId, userId, eventTicketId);
        }


        public decimal GetEventTicketPrice(int eventId)
        {
            
            return _paymentDal.GetEventTicketPrice(eventId);
        }

        public void TAdd(Payment payment)
        {
            _paymentDal.Insert(payment);
        }

        public void TDelete(Payment payment)
        {
            _paymentDal.Delete(payment);
        }

        public Payment TGetByID(int id)
        {
            return _paymentDal.GetByID(id);
        }

        public List<Payment> TGetList()
        {
            return _paymentDal.GetList();
        }

        public void TUpdate(Payment payment)
        {
            _paymentDal.Update(payment);
        }
    }
}