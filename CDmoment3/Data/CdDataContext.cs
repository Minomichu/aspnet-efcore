using System;
using CDmoment3.Models;
using Microsoft.EntityFrameworkCore;

namespace CDmoment3.Data
{
    public class CdDataContext : DbContext
    {
        public CdDataContext(DbContextOptions<CdDataContext> options) : base(options)
        {
        }

        public DbSet<CdData> CdData { get; set; }
        public DbSet<ArtistData> ArtistData { get; set; }
    }
}



