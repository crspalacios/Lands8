using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lands8.Backend.Models
{
    using Domain;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Lands8.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<Lands8.Domain.UserType> UserTypes { get; set; }
    }
}