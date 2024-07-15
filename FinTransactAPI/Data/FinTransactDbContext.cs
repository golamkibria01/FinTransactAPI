using FinTransactAPI.Model;
using Microsoft.EntityFrameworkCore;
 
namespace FinTransactAPI.Data
{
    public class FinTransactDbContext : DbContext
    {
        public FinTransactDbContext(DbContextOptions options) : base(options)
        {
             
        }
        public DbSet<AccountInformation> AccountInformation { get; set; }
        public DbSet<UserAuthentication> UserAuthentication { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInformation>()
                .HasKey(a => a.AccountInformationId);

            modelBuilder.Entity<TransactionType>()
                .HasKey(t => t.TransactionTypeId);

            modelBuilder.Entity<UserAuthentication>()
                .HasKey(t => t.UserId);

            modelBuilder.Entity<Transaction>()
                .HasKey(tr => tr.TransactionId);

            modelBuilder.Entity<Transaction>()
            .Property(tr => tr.TransactionAmount)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
            .Property(tr => tr.TransactionDate)
            .HasColumnType("datetime");

            modelBuilder.Entity<Transaction>()
                .HasOne(tr => tr.AccountInformation)
                .WithMany(a => a.Transaction)
                .HasForeignKey(tr => tr.AccountInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(tr => tr.TransactionType)
                .WithMany(t => t.Transaction)
                .HasForeignKey(tr => tr.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(tr => tr.UserAuthentication)
                .WithMany(t => t.Transaction)
                .HasForeignKey(tr => tr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
  