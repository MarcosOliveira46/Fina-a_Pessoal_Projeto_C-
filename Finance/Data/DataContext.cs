using Finance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Finance.Data
{
    public class DataContext : DbContext
    {
        public DataContext()  : base("FinanceConn")
        {

        }
        public DbSet<Receita> Receitas { get; set; }
        
        public DbSet<TipoDespesa> TipoDespesas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>()
                .HasKey(r => r.ReceitaId);


            modelBuilder.Entity<Despesa>()
                .HasKey(d => d.Despesa_Id)
                .HasOptional(d => d.TipoDespesas)
                .WithRequired(d => d.Despesas);

        }
    }
}