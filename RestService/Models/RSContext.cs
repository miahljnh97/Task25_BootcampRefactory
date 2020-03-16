using System;
using Microsoft.EntityFrameworkCore;

namespace RestService.Models
{
    public class RSContext : DbContext
    {
        public RSContext(DbContextOptions<RSContext> opt) : base(opt) { }

        public DbSet<Notification> notifs { get; set; }
        public DbSet<NotificationLogs> notifLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<NotificationLogs>()
                .HasOne(x => x.notif)
                .WithMany()
                .HasForeignKey(x => x.Notification_id);
        }
    }
}
