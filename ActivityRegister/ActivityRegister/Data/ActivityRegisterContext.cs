using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActivityRegister.Models;

namespace ActivityRegister.Data
{
    public class ActivityRegisterContext : DbContext
    {
        public ActivityRegisterContext (DbContextOptions<ActivityRegisterContext> options)
            : base(options)
        {
        }

        public DbSet<ActivityRegister.Models.Registration> Registration { get; set; } = default!;
    }
}
