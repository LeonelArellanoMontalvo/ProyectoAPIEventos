using GestionEventosAcademicos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEventosAcademicos.NewApi.Data
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
            // Configurar claves primarias explícitamente
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.Idevento);
                entity.Property(e => e.Costo)
                      .HasPrecision(18, 2); // Precisión para SQL Server y PostgreSQL

                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.Fecha);
                entity.Property(e => e.Lugar).IsRequired();
                entity.Property(e => e.Tipo).IsRequired();
            });

            modelBuilder.Entity<Actividad>()
                .HasKey(a => a.Idactividad);

            modelBuilder.Entity<Asistencia>()
                .HasKey(a => a.Idasistencia);

            modelBuilder.Entity<Certificado>()
                .HasKey(c => c.Idcertificado);

            modelBuilder.Entity<Eventoponente>()
                .HasKey(ep => new { ep.Idevento, ep.Idponente });

            modelBuilder.Entity<Inscripcion>()
                .HasKey(i => i.Idinscripcion);

            modelBuilder.Entity<Participante>()
                .HasKey(p => p.Idparticipante);

            modelBuilder.Entity<Ponente>()
                .HasKey(p => p.Idponente);

            // Relaciones
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Evento)
                .WithMany(e => e.Actividades)
                .HasForeignKey(a => a.Idevento);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Evento)
                .WithMany(e => e.Inscripciones)
                .HasForeignKey(i => i.Idevento);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Participante)
                .WithMany(p => p.Inscripciones)
                .HasForeignKey(i => i.Idparticipante);

            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Inscripcion)
                .WithMany(i => i.Asistencias)
                .HasForeignKey(a => a.Idinscripcion);

            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Actividad)
                .WithMany(ac => ac.Asistencias)
                .HasForeignKey(a => a.Idactividad);

            // Relación Inscripcion - Certificado (1:1)
            modelBuilder.Entity<Certificado>()
                .HasOne(c => c.Inscripcion)
                .WithOne(i => i.Certificado)
                .HasForeignKey<Certificado>(c => c.Idinscripcion);

            modelBuilder.Entity<Eventoponente>()
                .HasOne(ep => ep.Evento)
                .WithMany(e => e.Eventoponentes)
                .HasForeignKey(ep => ep.Idevento);

            modelBuilder.Entity<Eventoponente>()
                .HasOne(ep => ep.Ponente)
                .WithMany(p => p.Eventoponentes)
                .HasForeignKey(ep => ep.Idponente);

            // Índices únicos para correos
            modelBuilder.Entity<Participante>()
                .HasIndex(p => p.Correo)
                .IsUnique();

            modelBuilder.Entity<Ponente>()
                .HasIndex(p => p.Correo)
                .IsUnique();
        }
    }
}
