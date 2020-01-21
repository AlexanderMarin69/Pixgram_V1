using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.DB
{
    public class PixgramDbContext : DbContext
    {
        public PixgramDbContext(DbContextOptions<PixgramDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
        public DbSet<Pixgram_V1.Models.Category> Categories { get; set; }
        public DbSet<Pixgram_V1.Models.Image> Images { get; set; }
        public DbSet<Pixgram_V1.Models.FileUpload> FileUploads { get; set; }
       
    }
}

