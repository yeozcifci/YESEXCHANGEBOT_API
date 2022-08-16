using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-3BJ5GK9;Database=DemoDb;Integrated Security=true;");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Yunusemre.68;Database=YESEXCHANGE;SearchPath=test");
            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tradehistory>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<StrategyTransaction> StrategyTransactions { get; set; }
        public DbSet<PairBuySellStrategy> PairBuySellStrategies { get; set; }
        public DbSet<tradehistory> TradeHistories { get; set; }
        public DbSet<transactionorder> transactionorders { get; set; }
        public DbSet<transaction> transactions { get; set; }
        public DbSet<buysellstrategy> buysellstrategies { get; set; }
    }
}
