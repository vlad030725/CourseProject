using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ComputerStore.DAL
{
    public partial class CompContext : DbContext
    {
        public CompContext()
            : base("name=CompContext")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Custom> Custom { get; set; }
        public virtual DbSet<CustomRow> CustomRow { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Custom>()
                .HasMany(e => e.CustomRow)
                .WithOptional(e => e.Custom)
                .HasForeignKey(e => e.IdCustom);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CustomRow)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct);
        }
    }
}
