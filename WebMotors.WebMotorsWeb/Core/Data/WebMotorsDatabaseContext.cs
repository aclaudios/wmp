using Microsoft.EntityFrameworkCore;
using WebMotors.Core.Entities;
using WebMotors.WebMotorsWeb.Models;

namespace WebMotors.Core.Data
{
    public class WebMotorsDatabaseContext : DbContext
    {
        public WebMotorsDatabaseContext(DbContextOptions<WebMotorsDatabaseContext> options)
           : base(options)
        {

        }

        public DbSet<Anuncio> Anuncio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>().HasData(new Anuncio() { Id = 1, Ano = 2020, Marca = "Tesla", Modelo = "Cybertruck", Versao = "1.0", Quilometragem = 0, Observacao = "Tesla Cybertruck 2020 v1.0" });
            modelBuilder.Entity<Anuncio>().HasData(new Anuncio() { Id = 2, Ano = 2019, Marca = "Tesla", Modelo = "Roaster", Versao = "1.0", Quilometragem = 0, Observacao = "Tesla Roaster 2019 v1.0" });
            modelBuilder.Entity<Anuncio>().HasData(new Anuncio() { Id = 3, Ano = 2020, Marca = "Fiat", Modelo = "Argo", Versao = "1.0", Quilometragem = 0, Observacao = "Fiat Argo" });
            modelBuilder.Entity<Anuncio>().HasData(new Anuncio() { Id = 4, Ano = 2020, Marca = "Ferrari", Modelo = "Spider", Versao = "1.0", Quilometragem = 0, Observacao = "Ferrari Spider v1.0 2020" });
            modelBuilder.Entity<Anuncio>().HasData(new Anuncio() { Id = 5, Ano = 2018, Marca = "Rolls-Royce", Modelo = "Phanton", Versao = "III", Quilometragem = 0, Observacao = "Rolls-Royce Phanton VIII 2018" });
            modelBuilder.Entity<Anuncio>().HasData(new Anuncio() { Id = 6, Ano = 2018, Marca = "Lamborghini", Modelo = "Aventador", Versao = "1.0", Quilometragem = 0, Observacao = "Lamborghini aVentador 2020" });            
            base.OnModelCreating(modelBuilder);
        }
    }
}