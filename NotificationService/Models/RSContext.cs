using System;
using Microsoft.EntityFrameworkCore;

namespace NotificationService.Models
{
    public class RSContext : DbContext
    {
        public RSContext(DbContextOptions<RSContext> opt) : base(opt) { }

        public DbSet<Notification> notification { get; set; }
        public DbSet<NotificationLogs> notificationLogs { get; set; }

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
