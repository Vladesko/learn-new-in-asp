using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SQLiteWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWork.Entityes
{
    public class DemoContext : IdentityDbContext<Person>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }
    }
}
