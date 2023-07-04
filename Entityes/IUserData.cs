using SQLiteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWork.Entityes
{
    public interface IUserData
    {
       IEnumerable<User> GetTable();
    }
}
