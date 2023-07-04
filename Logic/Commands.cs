using SQLiteWork.Entityes;
using SQLiteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWork.Logic
{
    public class Commands : IUserData
    {
        private DemoContext context;
        public Commands(DemoContext context)
        {
            this.context = context;
        }
        public async Task Add(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
        public IEnumerable<User> GetTable()
        {
            IEnumerable<User> users = context.Users.ToList(); 
            return users;
        }
    }
}
