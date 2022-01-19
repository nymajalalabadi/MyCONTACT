using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCONTACT.REPOSITORY;

namespace MyCONTACT.Servies
{
    class EFContactRepository : IContactRepository
    {
        contact_DBEntities db = new contact_DBEntities();
        public bool Delete(int contactId)
        {
            try
            {
               //var  db.MyContacts.Remove(contactId);
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        public bool Insert(string name, string family, string email, string address, int age, string mobile)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string parameter)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectRow(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int contactId, string name, string family, string email, string address, int age, string mobile)
        {
            throw new NotImplementedException();
        }
    }
}
