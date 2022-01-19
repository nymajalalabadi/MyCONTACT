using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyCONTACT.REPOSITORY
{
    interface IContactRepository
    {
        bool Insert(string name, string family, string email ,string address, int age, string mobile);
        bool Update( int  contactId ,string name, string family, string email ,string address, int age, string mobile);
        bool Delete(int contactId);

        DataTable SelectAll();

        DataTable Search(string parameter);

        DataTable SelectRow(int contactId);
    }
}
