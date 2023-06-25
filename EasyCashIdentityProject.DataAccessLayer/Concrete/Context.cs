using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context: IdentityDbContext<AppUser,AppRole,int> //IdentityDbContext Özünde DbContext ten miras alıyor //Approle Ve AppUser sınıflarını değiştirdiğimizi belirttik
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-V3J8H32; initial catalog = EasyCashDb; integrated Security=true");

        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; } //db deki  tablo isimleri
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.SenderCustomer)
                .WithMany(x => x.CustomerSender)
                .HasForeignKey(x => x.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.ReceiverCustomer)
                .WithMany(x => x.CustomerReceiver)
                .HasForeignKey(x => x.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            base.OnModelCreating(builder);
        }

    }
}
