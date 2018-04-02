namespace Analyzing.Quality.Tools.UI.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProvaDeConceito : DbContext
    {
        public ProvaDeConceito()
            : base("name=ProvaDeConceito")
        {
        }

        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Intervalo> Intervalo { get; set; }
        public virtual DbSet<IntervalosDeTarefa> IntervalosDeTarefa { get; set; }
        public virtual DbSet<Ponto> Ponto { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.Situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.Ponto)
                .WithRequired(e => e.Funcionario)
                .HasForeignKey(e => e.IdFuncionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.Tarefa)
                .WithRequired(e => e.Funcionario)
                .HasForeignKey(e => e.IdFuncionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ponto>()
                .HasMany(e => e.Intervalo)
                .WithRequired(e => e.Ponto)
                .HasForeignKey(e => e.IdPonto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarefa>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Tarefa>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Tarefa>()
                .Property(e => e.Situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tarefa>()
                .HasMany(e => e.IntervalosDeTarefa)
                .WithRequired(e => e.Tarefa)
                .HasForeignKey(e => e.IdTarefa)
                .WillCascadeOnDelete(false);
        }
    }
}
