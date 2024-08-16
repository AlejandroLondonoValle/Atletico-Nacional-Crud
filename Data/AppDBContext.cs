using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtleticoNacionalCRUD.Models;

namespace AtleticoNacionalCRUD.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Jugador> Jugadores { get; set; }

        //Sobre escritura de el metodo Unmodel creating (Nos permite definir las caracteristicas de nuestra tabla)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Jugador>(tb => {
                tb.HasKey(col => col.Id);

                tb.Property(col => col.Id).UseMySqlIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Imagen).HasMaxLength(255);
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Apellido).HasMaxLength(50);
                tb.Property(col => col.Posicion).HasMaxLength(50);
                tb.Property(col => col.FechaNacimiento).HasColumnType("DATE");
                tb.Property(col => col.PieHabil).HasMaxLength(50);
                tb.Property(col => col.Nacionalidad).HasMaxLength(50);
                //tb.ToTable("Jugadores"); //Cambiamos el nombre de la tabla a Jugadores en lugar de Jugador

            });

            modelBuilder.Entity<Jugador>().ToTable("Jugador");
               
        }
    }
}