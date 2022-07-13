using System;
using ASPNET_CRUD_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_CRUD_MVC.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ContactModel> Contact { get; set; }
    }
}

