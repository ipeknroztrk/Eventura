

using System;
using EntityLayer.Concrete;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=pg-35d0b49b-eventura.c.aivencloud.com;Port=25558;Database=event;Username=avnadmin;Password=AVNS_UHYggiYYAYpKfGAMhym;Ssl Mode=Require;");
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<City> Cities  { get; set; }

        public DbSet<SavedCard> SavedCards { get; set; }
        public DbSet<EventsTickets> EventsTickets { get; set; }
        public DbSet<EventEventsTickets> EventEventsTicket { get; set; }
        public IConfiguration Configuration { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<EventEventsTickets>()
                .HasKey(e => new { e.EventId, e.EventsTicketsEventsTicketId }); 

            
            modelBuilder.Entity<EventEventsTickets>()
                .HasOne(e => e.Event)
                .WithMany()  
                .HasForeignKey(e => e.EventId); 

            


            
            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserFavorites)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.Event)
                .WithMany(e => e.UserFavorites)
                .HasForeignKey(uf => uf.EventId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<EventEventsTickets>()
      .HasKey(e => new { e.EventId, e.EventsTicketsEventsTicketId });

            modelBuilder.Entity<Ticket>()
      .HasOne(t => t.EventsTicket)    
      .WithMany(et => et.Tickets)    
      .HasForeignKey(t => t.EventsTicketId); 

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)          
                .WithMany(e => e.Tickets)     
                .HasForeignKey(t => t.EventId);  




        }





    }
}
