using GestionEventosAcademicos.APIConsumer;
using GestionEventosAcademicos.Models;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Configurar los endpoints de la API
            Crud<Evento>.EndPoint = "https://localhost:7193/api/Eventos";
            Crud<Participante>.EndPoint = "https://localhost:7193/api/Participantes";
            Crud<Ponente>.EndPoint = "https://localhost:7193/api/Ponentes";

            /*

            // === Crear Registros ===
            Console.WriteLine("=== Creando Registros ===");

            // Crear 2 Participantes
            var participante1 = new Participante
            {
                Nombre = "María",
                Apellido = "Gómez",
                Correo = "maria.gomez@example.com",
                Telefono = "0987654321",
                Cedula = "1005277628"
            };
            var createdParticipante1 = await Crud<Participante>.Create(participante1);
            Console.WriteLine($"Participante 1 creado con ID: {createdParticipante1?.Idparticipante}");

            var participante2 = new Participante
            {
                Nombre = "Carlos",
                Apellido = "López",
                Correo = "carlos.lopez@example.com",
                Telefono = "0976543210",
                Cedula = "1005277629"
            };
            var createdParticipante2 = await Crud<Participante>.Create(participante2);
            Console.WriteLine($"Participante 2 creado con ID: {createdParticipante2?.Idparticipante}");

            // Crear 2 Ponentes
            var ponente1 = new Ponente
            {
                Nombre = "Ana",
                Apellido = "Martínez",
                Correo = "ana.martinez@example.com",
                Telefono = "0965432109"
            };
            var createdPonente1 = await Crud<Ponente>.Create(ponente1);
            Console.WriteLine($"Ponente 1 creado con ID: {createdPonente1?.Idponente}");

            var ponente2 = new Ponente
            {
                Nombre = "Pedro",
                Apellido = "Rodríguez",
                Correo = "pedro.rodriguez@example.com",
                Telefono = "0954321098"
            };
            var createdPonente2 = await Crud<Ponente>.Create(ponente2);
            Console.WriteLine($"Ponente 2 creado con ID: {createdPonente2?.Idponente}");

            // Crear 2 Eventos
            var evento1 = new Evento
            {
                Nombre = "Seminario de Innovación 2025",
                Fecha = DateTime.Now.AddDays(10),
                Lugar = "Universidad Central",
                Tipo = "Seminarios",
                Estado = "Activo",
                Costo = 30,
                Actividades = new List<Actividad> { new Actividad { Nombre = "Taller 1", Fechainicio = DateTime.Now.AddDays(11), Fechafin = DateTime.Now.AddDays(11).AddHours(2), Sala = "Aula 1" } },
                Inscripciones = new List<Inscripcion> { new Inscripcion { Fechainscripcion = DateTime.Now, EstadoInscripcion = "Confirmada", Fechapago = DateTime.Now, Mediopago = "Tarjeta", EstadoPago = "Pagado", Idparticipante = createdParticipante1?.Idparticipante ?? 0 } },
                Eventoponentes = new List<Eventoponente> { new Eventoponente { Idponente = createdPonente1?.Idponente ?? 0 } }
            };
            var createdEvento1 = await Crud<Evento>.Create(evento1);
            Console.WriteLine($"Evento 1 creado con ID: {createdEvento1?.Idevento}");

            var evento2 = new Evento
            {
                Nombre = "Congreso de Tecnología 2025",
                Fecha = DateTime.Now.AddDays(20),
                Lugar = "Politécnico Nacional",
                Tipo = "Congresos",
                Estado = "Activo",
                Costo = 50,
                Actividades = new List<Actividad> { new Actividad { Nombre = "Charla 1", Fechainicio = DateTime.Now.AddDays(21), Fechafin = DateTime.Now.AddDays(21).AddHours(2), Sala = "Aula 2" } },
                Inscripciones = new List<Inscripcion> { new Inscripcion { Fechainscripcion = DateTime.Now, EstadoInscripcion = "Confirmada", Fechapago = DateTime.Now, Mediopago = "Transferencia", EstadoPago = "Pagado", Idparticipante = createdParticipante2?.Idparticipante ?? 0 } },
                Eventoponentes = new List<Eventoponente> { new Eventoponente { Idponente = createdPonente2?.Idponente ?? 0 } }
            };
            var createdEvento2 = await Crud<Evento>.Create(evento2);
            Console.WriteLine($"Evento 2 creado con ID: {createdEvento2?.Idevento}");

            
            */
           
            // Mostrar todos los eventos
            Console.WriteLine("\n=== Lista de Eventos ===");
            var eventosList = await Crud<Evento>.GetAll();
            if (eventosList == null || !eventosList.Any())
            {
                Console.WriteLine("No se encontraron eventos.");
            }
            else
            {
                foreach (var evento in eventosList)
                {
                    Console.WriteLine("\nEvento:");
                    Console.WriteLine($"Evento ID: {evento.Idevento}");
                    Console.WriteLine($"Nombre: {evento.Nombre}");
                    Console.WriteLine($"Fecha: {evento.Fecha}");
                    Console.WriteLine($"Lugar: {evento.Lugar}");
                    Console.WriteLine($"Tipo: {evento.Tipo}");
                    Console.WriteLine($"Estado: {evento.Estado}");
                    Console.WriteLine($"Costo: ${evento.Costo}");

                    // Mostrar actividades
                    Console.WriteLine("  Actividades:");
                    if (evento.Actividades != null && evento.Actividades.Any())
                    {
                        foreach (var actividad in evento.Actividades)
                        {
                            Console.WriteLine($"    - Actividad ID: {actividad.Idactividad}");
                            Console.WriteLine($"      Nombre: {actividad.Nombre}");
                            Console.WriteLine($"      Fecha de Inicio: {actividad.Fechainicio}");
                            Console.WriteLine($"      Fecha de Fin: {actividad.Fechafin}");
                            Console.WriteLine($"      Sala: {actividad.Sala}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    No hay actividades asociadas.");
                    }

                    // Mostrar inscripciones
                    Console.WriteLine("  Inscripciones:");
                    if (evento.Inscripciones != null && evento.Inscripciones.Any())
                    {
                        foreach (var inscripcion in evento.Inscripciones)
                        {
                            Console.WriteLine($"    - Inscripción ID: {inscripcion.Idinscripcion}");
                            Console.WriteLine($"      Fecha de Inscripción: {inscripcion.Fechainscripcion}");
                            Console.WriteLine($"      Estado de Inscripción: {inscripcion.EstadoInscripcion}");
                            Console.WriteLine($"      Fecha de Pago: {inscripcion.Fechapago}");
                            Console.WriteLine($"      Medio de Pago: {inscripcion.Mediopago}");
                            Console.WriteLine($"      Estado de Pago: {inscripcion.EstadoPago}");

                            // Mostrar participante
                            if (inscripcion.Participante != null)
                            {
                                Console.WriteLine($"      Participante: {inscripcion.Participante.Nombre} {inscripcion.Participante.Apellido}");
                                Console.WriteLine($"      Correo: {inscripcion.Participante.Correo}");
                                Console.WriteLine($"      Teléfono: {inscripcion.Participante.Telefono}");
                                Console.WriteLine($"      Cédula: {inscripcion.Participante.Cedula}");
                            }

                            // Mostrar certificado
                            if (inscripcion.Certificado != null)
                            {
                                Console.WriteLine($"      Certificado ID: {inscripcion.Certificado.Idcertificado}");
                                Console.WriteLine($"      Fecha de Emisión: {inscripcion.Certificado.FechaEmision}");
                                Console.WriteLine($"      Estado: {(inscripcion.Certificado.EstadoCertificado ? "Activo" : "Inactivo")}");
                            }
                            else
                            {
                                Console.WriteLine("      No se ha emitido un certificado para esta inscripción.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("    No hay inscripciones asociadas.");
                    }

                    // Mostrar ponentes
                    Console.WriteLine("  Ponentes:");
                    if (evento.Eventoponentes != null && evento.Eventoponentes.Any())
                    {
                        foreach (var eventoponente in evento.Eventoponentes)
                        {
                            if (eventoponente.Ponente != null)
                            {
                                Console.WriteLine($"    - Ponente ID: {eventoponente.Idponente}");
                                Console.WriteLine($"      Nombre: {eventoponente.Ponente.Nombre} {eventoponente.Ponente.Apellido}");
                                Console.WriteLine($"      Correo: {eventoponente.Ponente.Correo}");
                                Console.WriteLine($"      Teléfono: {eventoponente.Ponente.Telefono}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("    No hay ponentes asociados.");
                    }
                }
            }

            // Mostrar todos los participantes
            Console.WriteLine("\n=== Lista de Participantes ===");
            var participantesList = await Crud<Participante>.GetAll();
            if (participantesList == null || !participantesList.Any())
            {
                Console.WriteLine("No se encontraron participantes.");
            }
            else
            {
                foreach (var participante in participantesList)
                {
                    Console.WriteLine($"Participante ID: {participante.Idparticipante}");
                    Console.WriteLine($"Nombre: {participante.Nombre} {participante.Apellido}");
                    Console.WriteLine($"Correo: {participante.Correo}");
                    Console.WriteLine($"Teléfono: {participante.Telefono}");
                    Console.WriteLine($"Cédula: {participante.Cedula}");

                    // Mostrar inscripciones del participante
                    Console.WriteLine("  Inscripciones:");
                    if (participante.Inscripciones != null && participante.Inscripciones.Any())
                    {
                        foreach (var inscripcion in participante.Inscripciones)
                        {
                            Console.WriteLine($"    - Inscripción ID: {inscripcion.Idinscripcion}");
                            Console.WriteLine($"      Fecha de Inscripción: {inscripcion.Fechainscripcion}");
                            Console.WriteLine($"      Estado de Inscripción: {inscripcion.EstadoInscripcion}");
                            Console.WriteLine($"      Fecha de Pago: {inscripcion.Fechapago}");
                            Console.WriteLine($"      Medio de Pago: {inscripcion.Mediopago}");
                            Console.WriteLine($"      Estado de Pago: {inscripcion.EstadoPago}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    No hay inscripciones asociadas.");
                    }
                    Console.WriteLine();
                }
            }

            // Mostrar todos los ponentes
            Console.WriteLine("\n=== Lista de Ponentes ===");
            var ponentesList = await Crud<Ponente>.GetAll();
            if (ponentesList == null || !ponentesList.Any())
            {
                Console.WriteLine("No se encontraron ponentes.");
            }
            else
            {
                foreach (var ponente in ponentesList)
                {
                    Console.WriteLine($"Ponente ID: {ponente.Idponente}");
                    Console.WriteLine($"Nombre: {ponente.Nombre} {ponente.Apellido}");
                    Console.WriteLine($"Correo: {ponente.Correo}");
                    Console.WriteLine($"Teléfono: {ponente.Telefono}");
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}