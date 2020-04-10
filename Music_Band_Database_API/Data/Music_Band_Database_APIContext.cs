using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music_Band_Database_API.Models;

namespace Music_Band_Database_API.Data
{
    public class Music_Band_Database_APIContext : DbContext
    {
        public Music_Band_Database_APIContext (DbContextOptions<Music_Band_Database_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Music_Band_Database_API.Models.BandDetails> BandDetails { get; set; }
    }
}
