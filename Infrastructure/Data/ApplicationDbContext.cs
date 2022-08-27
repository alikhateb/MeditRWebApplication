namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).HasMaxLength(50).IsRequired(true);
                c.Property(c => c.Address).HasMaxLength(150).IsRequired(true);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
                e.Property(e => e.Title).HasMaxLength(50).IsRequired(false);
                e.HasOne(e => e.Company).WithMany(c => c.Employees).HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
