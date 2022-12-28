using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VirtualCard.Models;

namespace BusinessCardApp.Models
{

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Contributor> contributors { get; set; }

    }

}