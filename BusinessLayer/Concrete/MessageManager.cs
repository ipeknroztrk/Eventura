using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IGenericDal<Message> _MessageDal;

        public MessageManager(IGenericDal<Message> MessageDal)
        {
            _MessageDal = MessageDal;
        }

        public void TAdd(Message Message)
        {
            
            _MessageDal.Insert(Message);
        }

        public Message TGetByID(int id)
        {
            
            return _MessageDal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            
            return _MessageDal.GetList();
        }

        public void TUpdate(Message Message)
        {
            
            _MessageDal.Update(Message);
        }

        public void TDelete(Message Message)
        {
            
            _MessageDal.Delete(Message);
        }
    }
}
