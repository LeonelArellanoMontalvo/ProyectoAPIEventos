using GestionEventosAcademicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionEventosAcademicos.Api.Data
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Eventoponente> Eventoponentes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Ponente> Ponentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la clave compuesta para Eventoponente
            modelBuilder.Entity<Eventoponente>()
                .HasKey(ep => new { ep.Idevento, ep.Idponente });

            // Configuración de la relación 1:1 entre Certificado e Inscripcion
            modelBuilder.Entity<Certificado>()
                .HasKey(c => c.Idinscripcion);

            // Relación Evento - Actividades (1:N)
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Evento)
                .WithMany(e => e.Actividades)
                .HasForeignKey(a => a.Idevento);

            // Relación Evento - Inscripciones (1:N)
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Evento)
                .WithMany(e => e.Inscripciones)
                .HasForeignKey(i => i.Idevento);

            // Relación Participante - Inscripciones (1:N)
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Participante)
                .WithMany(p => p.Inscripciones)
                .HasForeignKey(i => i.Idparticipante);

            // Relación Inscripcion - Asistencias (1:N)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Inscripcion)
                .WithMany(i => i.Asistencias)
                .HasForeignKey(a => a.Idinscripcion);

            // Relación Actividad - Asistencias (1:N)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Actividad)
                .WithMany(ac => ac.Asistencias)
                .HasForeignKey(a => a.Idactividad);

            // Relación Inscripcion - Certificado (1:1)
            modelBuilder.Entity<Certificado>()
                .HasOne(c => c.Inscripcion)
                .WithOne(i => i.Certificado)
                .HasForeignKey<Certificado>(c => c.Idinscripcion);

            // Relación Evento - Eventoponente (1:N)
            modelBuilder.Entity<Eventoponente>()
                .HasOne(ep => ep.Evento)
                .WithMany(e => e.Eventoponentes)
                .HasForeignKey(ep => ep.Idevento);

            // Relación Ponente - Eventoponente (1:N)
            modelBuilder.Entity<Eventoponente>()
                .HasOne(ep => ep.Ponente)
                .WithMany(p => p.Eventoponentes)
                .HasForeignKey(ep => ep.Idponente);

            // Índices únicos para correos (opcional, según el esquema)
            modelBuilder.Entity<Participante>()
                .HasIndex(p => p.Correo)
                .IsUnique();

            modelBuilder.Entity<Ponente>()
                .HasIndex(p => p.Correo)
                .IsUnique();
        }
    }

}