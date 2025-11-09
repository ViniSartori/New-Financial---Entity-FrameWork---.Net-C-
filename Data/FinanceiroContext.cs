using Financeiro.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq.Expressions;

namespace Financeiro.Data
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> options) : base(options)
        {
        }

        public DbSet<Banco> Bancos { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                string dbPath = @"C:\Users\Vinicius de Oliveira\source\repos\Financeiro\Financeiro.db";

               
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
    }
}
