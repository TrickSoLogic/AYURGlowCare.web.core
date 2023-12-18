using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AYURGlowCare.web.core.Models;

namespace AYURGlowCare.web.core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AYURGlowCare.web.core.Models.Product>? Product { get; set; }
        public DbSet<AYURGlowCare.web.core.Models.order>? order { get; set; }
    }
} 