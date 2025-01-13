using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SavedCard
    {
        public int SavedCardId { get; set; }
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string CVV {  get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
