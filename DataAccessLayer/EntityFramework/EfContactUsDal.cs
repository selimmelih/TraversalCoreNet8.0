﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        private readonly Context _context;

        public EfContactUsDal(Context context) : base(context)
        {
            _context = context;
        }

        public void ContactUsStatusChangeToFalse(int id)
        {
            var contact = _context.ContactUses.FirstOrDefault(x => x.ContactUsID == id);
            if (contact != null)
            {
                contact.MessageStatus = false;
                _context.SaveChanges();
            }
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            return _context.ContactUses.Where(x => x.MessageStatus == false).ToList();
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            return _context.ContactUses.Where(x => x.MessageStatus == true).ToList();
        }
    }
}


