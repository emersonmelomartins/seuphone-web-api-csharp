using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seuphone.Api.Models;

namespace Seuphone.Api.Data
{
    public class SeuphoneApiContext : DbContext
    {
        public SeuphoneApiContext (DbContextOptions<SeuphoneApiContext> options)
            : base(options)
        {
        }

        public DbSet<Seuphone.Api.Models.User> User { get; set; }

        public DbSet<Seuphone.Api.Models.Provider> Provider { get; set; }

        public DbSet<Seuphone.Api.Models.Product> Product { get; set; }

        public DbSet<Seuphone.Api.Models.Order> Order { get; set; }

        public DbSet<Seuphone.Api.Models.OrderItems> OrderItems { get; set; }
    }
}
