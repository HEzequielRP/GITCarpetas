using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CuerpoSano.Context;
using CuerpoSano.Models;
using CuerpoSano.Services;
using System.IO;

namespace CuerpoSano
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CuerpoSanoDbContext>();
            optionsBuilder.UseSqlite("Data Source=cuerposano.db");
            var context = new CuerpoSanoDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            SembrarDatosIniciales(context);

            var servicioMembresia = new GP_MembresiaService(context);
            var servicioMiembro = new GM_MiembroService(context);
            var servicioEntrenador = new GE_EntrenadorService(context);
            var servicioClase = new GC_ClaseService(context);
            var servicioCobranza = new GR_CobranzaService(context);

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA CUERPO SANO ===");
                Console.WriteLine("1. Membresias");
                Console.WriteLine("2. Miembros");
                Console.WriteLine("3. Entrenadores");
                Console.WriteLine("4. Clases");
                Console.WriteLine("5. Cobranzas");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opcion: ");

                int opcion = LeerEntero("", 0);

                switch (opcion)
                {
                    case 1:
                        MenuMembresias(servicioMembresia);
                        break;
                    case 2:
                        MenuMiembros(servicioMiembro, servicioMembresia, servicioClase);
                        break;
                    case 3:
                        MenuEntrenadores(servicioEntrenador);
                        break;
                    case 4:
                        MenuClases(servicioClase, servicioEntrenador, servicioMiembro);
                        break;
                    case 5:
                        MenuCobranzas(servicioCobranza, servicioMiembro);
                        break;
                    case 0:
                        salir = true;
                        break;
                    default:
                        MostrarError("Opcion invalida");
                        Pausar();
                        break;
                }
            }
        }

        private static void SembrarDatosIniciales(CuerpoSanoDbContext context)
        {
            if (!context.Membresias.Any())
            {
                context.Membresias.Add(new Membresia
                {
                    Nombre = "Basica",
                    Precio = 500m,
                    DuracionDias = 30,
                    Publico = "General"
                });
                context.Membresias.Add(new Membresia
                {
                    Nombre = "Premium",
                    Precio = 900m,
                    DuracionDias = 30,
                    Publico = "General"
                });
                context.Profesores.Add(new Profesor
                {
                    Nombre = "Carlos",
                    Apellido = "Lopez",
                    TipoDocumento = "DNI",
                    NumeroDocumento = 12345678,
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    TelCelular = 123456789,
                    Direccion = "Sin especificar",
                    Especialidad = "Musculacion",
                    CodigoProfesor = "P001"
                });
                context.SaveChanges();
            }
        }

        private static void MenuMembresias(GP_MembresiaService servicio)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== MENU MEMBRESIAS ===");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Listar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opcion: ");

                int opcion = LeerEntero("", 0);

                switch (opcion)
                {
                    case 1:
                        CrearMembresia(servicio);
                        break;
                    case 2:
                        EditarMembresia(servicio);
                        break;
                    case 3:
                        EliminarMembresia(servicio);
                        break;
                    case 4:
                        ListarMembresias(servicio);
                        break;
                    case 0:
                        volver = true;
                        break;
                    default:
                        MostrarError("Opcion invalida");
                        Pausar();
                        break;
                }
            }
        }

        private static void MenuMiembros(GM_MiembroService servicio, GP_MembresiaService servicioMembresia, GC_ClaseService servicioClase)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== MENU MIEMBROS ===");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Listar");
                Console.WriteLine("5. Asociar a una clase");
                Console.WriteLine("0. Volver");
                
                Console.Write("Seleccione una opcion: ");

                int opcion = LeerEntero("", 0);

                switch (opcion)
                {
                    case 1:
                        CrearMiembro(servicio, servicioMembresia);
                        break;
                    case 2:
                        EditarMiembro(servicio, servicioMembresia);
                        break;
                    case 3:
                        EliminarMiembro(servicio);
                        break;
                    case 4:
                        ListarMiembros(servicio);
                        break;
                    case 5:
                        InscribirAlumnoDesdeMenu(servicioClase, servicio);
                        break;
                    case 0:
                        volver = true;
                        break;
                    
                    default:
                        MostrarError("Opcion invalida");
                        Pausar();
                        break;
                }
            }
        }

        private static void MenuEntrenadores(GE_EntrenadorService servicio)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ENTRENADORES ===");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Listar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opcion: ");

                int opcion = LeerEntero("", 0);

                switch (opcion)
                {
                    case 1:
                        CrearEntrenador(servicio);
                        break;
                    case 2:
                        EditarEntrenador(servicio);
                        break;
                    case 3:
                        EliminarEntrenador(servicio);
                        break;
                    case 4:
                        ListarEntrenadores(servicio);
                        break;
                    case 0:
                        volver = true;
                        break;
                    default:
                        MostrarError("Opcion invalida");
                        Pausar();
                        break;
                }
            }
        }

        private static void MenuClases(GC_ClaseService servicio, GE_EntrenadorService servicioEntrenador, GM_MiembroService servicioMiembro)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== MENU CLASES ===");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Listar");
                Console.WriteLine("5. Inscribir Alumno");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opcion: ");

                int opcion = LeerEntero("", 0);

                switch (opcion)
                {
                    case 1:
                        CrearClase(servicio, servicioEntrenador);
                        break;
                    case 2:
                        EditarClase(servicio, servicioEntrenador);
                        break;
                    case 3:
                        EliminarClase(servicio);
                        break;
                    case 4:
                        ListarClases(servicio);
                        break;
                    case 5:
                        InscribirAlumnoDesdeMenu(servicio, servicioMiembro);
                        break;
                    case 0:
                        volver = true;
                        break;
                    default:
                        MostrarError("Opcion invalida");
                        Pausar();
                        break;
                }
            }
        }

        private static void MenuCobranzas(GR_CobranzaService servicio, GM_MiembroService servicioMiembro)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== MENU COBRANZAS ===");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Listar");
                Console.WriteLine("5. Imprimir Recibo");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opcion: ");

                int opcion = LeerEntero("", 0);

                switch (opcion)
                {
                    case 1:
                        CrearCobranza(servicio, servicioMiembro);
                        break;
                    case 2:
                        EditarCobranza(servicio, servicioMiembro);
                        break;
                    case 3:
                        EliminarCobranza(servicio);
                        break;
                    case 4:
                        ListarCobranzas(servicio);
                        break;
                    case 5:
                        ImprimirReciboCobranza(servicio);
                        break;
                    case 0:
                        volver = true;
                        break;
                    default:
                        MostrarError("Opcion invalida");
                        Pausar();
                        break;
                }
            }
        }

        #region Membresias

        private static void CrearMembresia(GP_MembresiaService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== CREAR MEMBRESIA ===");
            var membresia = new Membresia
            {
                Nombre = LeerCadena("Nombre: "),
                Precio = LeerDecimal("Precio: "),
                DuracionDias = LeerEntero("Duracion en dias: "),
                Publico = LeerCadena("Publico: ")
            };

            try
            {
                servicio.Crear(membresia);
                MostrarExito("Membresia creada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al crear membresia: " + ex.Message);
            }
            Pausar();
        }

        private static void EditarMembresia(GP_MembresiaService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR MEMBRESIA ===");
            ListarMembresias(servicio, false);
            int id = LeerEntero("Id de membresia a editar: ");
            var membresia = servicio.ObtenerPorId(id);
            if (membresia == null)
            {
                MostrarError("Membresia no encontrada");
                Pausar();
                return;
            }

            membresia.Nombre = LeerCadena("Nombre (" + membresia.Nombre + "): ", membresia.Nombre);
            membresia.Precio = LeerDecimal("Precio (" + membresia.Precio + "): ", membresia.Precio);
            membresia.DuracionDias = LeerEntero("Duracion en dias (" + membresia.DuracionDias + "): ", membresia.DuracionDias);
            membresia.Publico = LeerCadena("Publico (" + membresia.Publico + "): ", membresia.Publico);

            try
            {
                servicio.Actualizar(membresia);
                MostrarExito("Membresia actualizada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar membresia: " + ex.Message);
            }
            Pausar();
        }

        private static void EliminarMembresia(GP_MembresiaService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR MEMBRESIA ===");
            ListarMembresias(servicio, false);
            int id = LeerEntero("Id de membresia a eliminar: ");
            var membresia = servicio.ObtenerPorId(id);
            if (membresia == null)
            {
                MostrarError("Membresia no encontrada");
                Pausar();
                return;
            }

            Console.Write("Confirma eliminar la membresia '" + membresia.Nombre + "'? (s/n): ");
            if (LeerBooleano("", false))
            {
                try
                {
                    bool eliminado = servicio.Eliminar(id);
                    if (eliminado)
                        MostrarExito("Membresia eliminada correctamente");
                    else
                        MostrarError("No se pudo eliminar la membresia");
                }
                catch (Exception ex)
                {
                    MostrarError("Error al eliminar membresia: " + ex.Message);
                }
            }
            else
            {
                MostrarError("Eliminacion cancelada");
            }
            Pausar();
        }

        private static void ListarMembresias(GP_MembresiaService servicio, bool pausar = true)
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE MEMBRESIAS ===");
            var membresias = servicio.ObtenerTodos();
            if (membresias.Count == 0)
            {
                Console.WriteLine("No hay membresias registradas");
            }
            else
            {
                foreach (var m in membresias)
                {
                    Console.WriteLine($"Id: {m.Id}, Nombre: {m.Nombre}, Precio: {m.Precio}, Duracion: {m.DuracionDias} dias, Publico: {m.Publico}");
                }
            }
            if (pausar) Pausar();
        }

        #endregion

        #region Miembros

        private static void CrearMiembro(GM_MiembroService servicio, GP_MembresiaService servicioMembresia)
        {
            Console.Clear();
            Console.WriteLine("=== CREAR MIEMBRO ===");
            ListarMembresias(servicioMembresia, false);
            int membresiaId = LeerEntero("Membresia Id: ");

            var miembro = new Miembro
            {
                Nombre = LeerCadena("Nombre: "),
                Apellido = LeerCadena("Apellido: "),
                TipoDocumento = LeerCadena("Tipo de documento: "),
                NumeroDocumento = LeerEntero("Numero de documento: "),
                FechaNacimiento = LeerFecha("Fecha de nacimiento (dd/MM/yyyy): "),
                TelCelular = LeerEnteroLong("Tel celular: "),
                Direccion = LeerCadena("Direccion: "),
                Telefono = LeerCadena("Telefono (opcional): ", null),
                Email = LeerCadena("Email (opcional): ", null),
                CodigoAlumno = LeerCadena("Codigo de alumno: "),
                MembresiaId = membresiaId
            };

            try
            {
                servicio.CrearMiembro(miembro);
                MostrarExito("Miembro creado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al crear miembro: " + ex.Message);
            }
            Pausar();
        }

        private static void EditarMiembro(GM_MiembroService servicio, GP_MembresiaService servicioMembresia)
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR MIEMBRO ===");
            ListarMiembros(servicio, false);
            int id = LeerEntero("Id de miembro a editar: ");
            var miembro = servicio.ObtenerMiembroPorId(id);
            if (miembro == null)
            {
                MostrarError("Miembro no encontrado");
                Pausar();
                return;
            }

            ListarMembresias(servicioMembresia, false);
            miembro.MembresiaId = LeerEntero("Membresia Id (" + miembro.MembresiaId + "): ", miembro.MembresiaId);
            miembro.Nombre = LeerCadena("Nombre (" + miembro.Nombre + "): ", miembro.Nombre);
            miembro.Apellido = LeerCadena("Apellido (" + miembro.Apellido + "): ", miembro.Apellido);
            miembro.TipoDocumento = LeerCadena("Tipo de documento (" + miembro.TipoDocumento + "): ", miembro.TipoDocumento);
            miembro.NumeroDocumento = LeerEntero("Numero de documento (" + miembro.NumeroDocumento + "): ", miembro.NumeroDocumento);
            miembro.FechaNacimiento = LeerFecha("Fecha de nacimiento (" + miembro.FechaNacimiento.ToString("dd/MM/yyyy") + "): ", miembro.FechaNacimiento);
            miembro.TelCelular = LeerEnteroLong("Tel celular (" + miembro.TelCelular + "): ", miembro.TelCelular);
            miembro.Direccion = LeerCadena("Direccion (" + miembro.Direccion + "): ", miembro.Direccion);
            miembro.Telefono = LeerCadena("Telefono (" + miembro.Telefono + "): ", miembro.Telefono);
            miembro.Email = LeerCadena("Email (" + miembro.Email + "): ", miembro.Email);
            miembro.CodigoAlumno = LeerCadena("Codigo de alumno (" + miembro.CodigoAlumno + "): ", miembro.CodigoAlumno);

            try
            {
                servicio.ActualizarMiembro(miembro);
                MostrarExito("Miembro actualizado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar miembro: " + ex.Message);
            }
            Pausar();
        }

        private static void EliminarMiembro(GM_MiembroService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR MIEMBRO ===");
            ListarMiembros(servicio, false);
            int id = LeerEntero("Id de miembro a eliminar: ");
            var miembro = servicio.ObtenerMiembroPorId(id);
            if (miembro == null)
            {
                MostrarError("Miembro no encontrado");
                Pausar();
                return;
            }

            Console.Write("Confirma eliminar al miembro '" + miembro.Nombre + " " + miembro.Apellido + "'? (s/n): ");
            if (LeerBooleano("", false))
            {
                try
                {
                    bool eliminado = servicio.EliminarMiembro(id);
                    if (eliminado)
                        MostrarExito("Miembro eliminado correctamente");
                    else
                        MostrarError("No se pudo eliminar el miembro");
                }
                catch (Exception ex)
                {
                    MostrarError("Error al eliminar miembro: " + ex.Message);
                }
            }
            else
            {
                MostrarError("Eliminacion cancelada");
            }
            Pausar();
        }

    private static void ListarMiembros(GM_MiembroService servicio, bool pausar = true)
    {
        Console.Clear();
        Console.WriteLine("=== LISTADO DE MIEMBROS ===");
        var miembros = servicio.ObtenerMiembros();

        if (miembros.Count == 0)
        {
            Console.WriteLine("No hay miembros registrados.");
        }
        else
        {
            foreach (var m in miembros)
            {
                string clasesInfo = m.ListaClases != null && m.ListaClases.Any() 
                    ? string.Join(", ", m.ListaClases.Select(c => c.Nombre)) 
                    : "Sin clases";

                Console.WriteLine($"ID: {m.Id} | Socio: {m.Nombre} {m.Apellido} | Membresía: {m.Membresia?.Nombre ?? "N/A"}");
                Console.WriteLine($"   > Clases: {clasesInfo}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
        if (pausar) Pausar();
    }

        #endregion

        #region Entrenadores

    private static void CrearEntrenador(GE_EntrenadorService servicio)
    {
        Console.Clear();
        Console.WriteLine("=== CREAR ENTRENADOR ===");
    
        var profesor = new Profesor
        {
            Nombre = LeerCadena("Nombre: "),
            Apellido = LeerCadena("Apellido: "),
            TipoDocumento = LeerCadena("Tipo de documento: "),
            NumeroDocumento = LeerEntero("Numero de documento: "),
            FechaNacimiento = LeerFecha("Fecha de nacimiento (dd/MM/yyyy): "),
            TelCelular = LeerEnteroLong("Tel celular: "),
            Direccion = LeerCadena("Direccion: "),
            Email = LeerCadena("Email (opcional): ", null),
            Especialidad = LeerCadena("Especialidad: "),
            CodigoProfesor = LeerCadena("Codigo de profesor: "),
            Certificado = LeerArchivoPDF("Ingrese la ruta del PDF del certificado (o Enter para omitir): ")
        };

        try
        {
            servicio.Crear(profesor);
            MostrarExito("Entrenador creado correctamente con su certificado.");
        }
        catch (Exception ex)
        {
            MostrarError("Error al crear entrenador: " + ex.Message);
        }
        Pausar();
    }

        private static void EditarEntrenador(GE_EntrenadorService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR ENTRENADOR ===");
            ListarEntrenadores(servicio, false);
            int id = LeerEntero("Id de entrenador a editar: ");
            var profesor = servicio.ObtenerPorId(id);
            if (profesor == null)
            {
                MostrarError("Entrenador no encontrado");
                Pausar();
                return;
            }

            profesor.Nombre = LeerCadena("Nombre (" + profesor.Nombre + "): ", profesor.Nombre);
            profesor.Apellido = LeerCadena("Apellido (" + profesor.Apellido + "): ", profesor.Apellido);
            profesor.TipoDocumento = LeerCadena("Tipo de documento (" + profesor.TipoDocumento + "): ", profesor.TipoDocumento);
            profesor.NumeroDocumento = LeerEntero("Numero de documento (" + profesor.NumeroDocumento + "): ", profesor.NumeroDocumento);
            profesor.FechaNacimiento = LeerFecha("Fecha de nacimiento (" + profesor.FechaNacimiento.ToString("dd/MM/yyyy") + "): ", profesor.FechaNacimiento);
            profesor.TelCelular = LeerEnteroLong("Tel celular (" + profesor.TelCelular + "): ", profesor.TelCelular);
            profesor.Direccion = LeerCadena("Direccion (" + profesor.Direccion + "): ", profesor.Direccion);
            profesor.Email = LeerCadena("Email (" + profesor.Email + "): ", profesor.Email);
            profesor.Especialidad = LeerCadena("Especialidad (" + profesor.Especialidad + "): ", profesor.Especialidad);
            profesor.CodigoProfesor = LeerCadena("Codigo de profesor (" + profesor.CodigoProfesor + "): ", profesor.CodigoProfesor);
            profesor.Certificado = LeerArchivoPDF("Ingrese la ruta del PDF del certificado (o Enter para omitir): ");
            try
            {
                servicio.Actualizar(profesor);
                MostrarExito("Entrenador actualizado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar entrenador: " + ex.Message);
            }
            Pausar();
        }

        private static void EliminarEntrenador(GE_EntrenadorService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR ENTRENADOR ===");
            ListarEntrenadores(servicio, false);
            int id = LeerEntero("Id de entrenador a eliminar: ");
            var profesor = servicio.ObtenerPorId(id);
            if (profesor == null)
            {
                MostrarError("Entrenador no encontrado");
                Pausar();
                return;
            }

            Console.Write("Confirma eliminar al entrenador '" + profesor.Nombre + " " + profesor.Apellido + "'? (s/n): ");
            if (LeerBooleano("", false))
            {
                try
                {
                    bool eliminado = servicio.Eliminar(id);
                    if (eliminado)
                        MostrarExito("Entrenador eliminado correctamente");
                    else
                        MostrarError("No se pudo eliminar al entrenador");
                }
                catch (Exception ex)
                {
                    MostrarError("Error al eliminar entrenador: " + ex.Message);
                }
            }
            else
            {
                MostrarError("Eliminacion cancelada");
            }
            Pausar();
        }
        private static void ListarEntrenadores(GE_EntrenadorService servicio, bool pausar = true)
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE ENTRENADORES ===");
            var profesores = servicio.ObtenerTodos();

            if (profesores.Count == 0)
            {
                Console.WriteLine("No hay entrenadores registrados.");
            }
            else
            {
                foreach (var p in profesores)
                {
                    string estadoCertificado = (p.Certificado != null && p.Certificado.Length > 0) 
                        ? "[CON CERTIFICADO]" 
                        : "[SIN CERTIFICADO]";

                    Console.WriteLine($"Id: {p.Id} | {p.Nombre} {p.Apellido} | Especialidad: {p.Especialidad} | {estadoCertificado}");
                }
            }
            if (pausar) Pausar();
        }

        #endregion

        #region Clases

        private static void CrearClase(GC_ClaseService servicio, GE_EntrenadorService servicioEntrenador)
        {
            Console.Clear();
            Console.WriteLine("=== CREAR CLASE ===");
            ListarEntrenadores(servicioEntrenador, false);
            int profesorId = LeerEntero("Profesor Id: ");

            var clase = new Clase
            {
                Nombre = LeerCadena("Nombre: "),
                Descripcion = LeerCadena("Descripcion: "),
                Horario = LeerCadena("Horario: "),
                CupoMaximo = LeerEntero("Cupo maximo: "),
                ProfesorId = profesorId
            };

            try
            {
                servicio.Crear(clase);
                MostrarExito("Clase creada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al crear clase: " + ex.Message);
            }
            Pausar();
        }

        private static void EditarClase(GC_ClaseService servicio, GE_EntrenadorService servicioEntrenador)
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR CLASE ===");
            ListarClases(servicio, false);
            int id = LeerEntero("Id de clase a editar: ");
            var clase = servicio.ObtenerPorId(id);
            if (clase == null)
            {
                MostrarError("Clase no encontrada");
                Pausar();
                return;
            }

            ListarEntrenadores(servicioEntrenador, false);
            clase.ProfesorId = LeerEntero("Profesor Id (" + clase.ProfesorId + "): ", clase.ProfesorId);
            clase.Nombre = LeerCadena("Nombre (" + clase.Nombre + "): ", clase.Nombre);
            clase.Descripcion = LeerCadena("Descripcion (" + clase.Descripcion + "): ", clase.Descripcion);
            clase.Horario = LeerCadena("Horario (" + clase.Horario + "): ", clase.Horario);
            clase.CupoMaximo = LeerEntero("Cupo maximo (" + clase.CupoMaximo + "): ", clase.CupoMaximo);

            try
            {
                servicio.Actualizar(clase);
                MostrarExito("Clase actualizada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar clase: " + ex.Message);
            }
            Pausar();
        }

        private static void EliminarClase(GC_ClaseService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR CLASE ===");
            ListarClases(servicio, false);
            int id = LeerEntero("Id de clase a eliminar: ");
            var clase = servicio.ObtenerPorId(id);
            if (clase == null)
            {
                MostrarError("Clase no encontrada");
                Pausar();
                return;
            }

            Console.Write("Confirma eliminar la clase '" + clase.Nombre + "'? (s/n): ");
            if (LeerBooleano("", false))
            {
                try
                {
                    bool eliminado = servicio.Eliminar(id);
                    if (eliminado)
                        MostrarExito("Clase eliminada correctamente");
                    else
                        MostrarError("No se pudo eliminar la clase");
                }
                catch (Exception ex)
                {
                    MostrarError("Error al eliminar clase: " + ex.Message);
                }
            }
            else
            {
                MostrarError("Eliminacion cancelada");
            }
            Pausar();
        }

    private static void ListarClases(GC_ClaseService servicio, bool pausar = true)
    {
        Console.Clear();
        Console.WriteLine("=== LISTADO DE CLASES ===");
        var clases = servicio.ObtenerClases();

        if (clases.Count == 0)
        {
            Console.WriteLine("No hay clases registradas.");
        }
        else
        {
            foreach (var c in clases)
            {
                string listaAlumnos = c.Miembros.Any() 
                    ? string.Join(", ", c.Miembros.Select(m => m.Nombre + " " + m.Apellido)) 
                    : "Sin alumnos";

                Console.WriteLine($"ID: {c.Id} | Clase: {c.Nombre} | Horario: {c.Horario}");
                Console.WriteLine($"   Profesor: {(c.Profesor != null ? c.Profesor.Nombre : "No asignado")}");
                Console.WriteLine($"   Cupo: {c.Miembros.Count}/{c.CupoMaximo} | Alumnos: {listaAlumnos}");
                Console.WriteLine(new string('-', 50));
            }
        }
        if (pausar) Pausar();
    }

        #endregion

        #region Cobranzas

        private static void CrearCobranza(GR_CobranzaService servicio, GM_MiembroService servicioMiembro)
        {
            Console.Clear();
            Console.WriteLine("=== CREAR COBRANZA ===");
            ListarMiembros(servicioMiembro, false);
            int miembroId = LeerEntero("Miembro Id: ");

            var cobranza = new Cobranzas
            {
                Fecha = LeerFecha("Fecha (dd/MM/yyyy): "),
                MiembroId = miembroId,
                Monto = LeerDecimal("Monto: "),
                Pagado = LeerBooleano("Pagado (s/n): ", false),
                FormaPago = LeerCadena("Forma de pago: ")
            };

            try
            {
                servicio.Crear(cobranza);
                MostrarExito("Cobranza creada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al crear cobranza: " + ex.Message);
            }
            Pausar();
        }

        private static void EditarCobranza(GR_CobranzaService servicio, GM_MiembroService servicioMiembro)
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR COBRANZA ===");
            ListarCobranzas(servicio, false);
            int id = LeerEntero("Id de cobranza a editar: ");
            var cobranza = servicio.ObtenerPorId(id);
            if (cobranza == null)
            {
                MostrarError("Cobranza no encontrada");
                Pausar();
                return;
            }

            ListarMiembros(servicioMiembro, false);
            cobranza.MiembroId = LeerEntero("Miembro Id (" + cobranza.MiembroId + "): ", cobranza.MiembroId);
            cobranza.Fecha = LeerFecha("Fecha (" + cobranza.Fecha.ToString("dd/MM/yyyy") + "): ", cobranza.Fecha);
            cobranza.Monto = LeerDecimal("Monto (" + cobranza.Monto + "): ", cobranza.Monto);
            cobranza.Pagado = LeerBooleano("Pagado (" + (cobranza.Pagado ? "s" : "n") + "): ", cobranza.Pagado);
            cobranza.FormaPago = LeerCadena("Forma de pago (" + cobranza.FormaPago + "): ", cobranza.FormaPago);

            try
            {
                servicio.Actualizar(cobranza);
                MostrarExito("Cobranza actualizada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar cobranza: " + ex.Message);
            }
            Pausar();
        }

        private static void EliminarCobranza(GR_CobranzaService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR COBRANZA ===");
            ListarCobranzas(servicio, false);
            int id = LeerEntero("Id de cobranza a eliminar: ");
            var cobranza = servicio.ObtenerPorId(id);
            if (cobranza == null)
            {
                MostrarError("Cobranza no encontrada");
                Pausar();
                return;
            }

            Console.Write("Confirma eliminar la cobranza de Id '" + cobranza.Id + "'? (s/n): ");
            if (LeerBooleano("", false))
            {
                try
                {
                    bool eliminado = servicio.Eliminar(id);
                    if (eliminado)
                        MostrarExito("Cobranza eliminada correctamente");
                    else
                        MostrarError("No se pudo eliminar la cobranza");
                }
                catch (Exception ex)
                {
                    MostrarError("Error al eliminar cobranza: " + ex.Message);
                }
            }
            else
            {
                MostrarError("Eliminacion cancelada");
            }
            Pausar();
        }

        private static void ListarCobranzas(GR_CobranzaService servicio, bool pausar = true)
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE COBRANZAS ===");
            var cobranzas = servicio.ObtenerTodos();
            if (cobranzas.Count == 0)
            {
                Console.WriteLine("No hay cobranzas registradas");
            }
            else
            {
                foreach (var c in cobranzas)
                {
                    Console.WriteLine($"Id: {c.Id}, Fecha: {c.Fecha.ToString("dd/MM/yyyy")}, MiembroId: {c.MiembroId}, Monto: {c.Monto}, Pagado: {c.Pagado}, FormaPago: {c.FormaPago}");
                }
            }
            if (pausar) Pausar();
        }

        private static void ImprimirReciboCobranza(GR_CobranzaService servicio)
        {
            Console.Clear();
            Console.WriteLine("=== IMPRIMIR RECIBO ===");
            
            ListarCobranzas(servicio, false);
            
            int id = LeerEntero("Ingrese el Id de la cobranza para ver el recibo: ");
            var cobranza = servicio.ObtenerPorId(id);
            
            if (cobranza == null)
            {
                MostrarError("Cobranza no encontrada.");
            }
            else
            {
                cobranza.ImpresionRecibo();
            }
            
            Pausar();
        }

        #endregion

        #region Helpers

        private static int LeerEntero(string mensaje, int valorDefault = 0)
        {
            if (!string.IsNullOrEmpty(mensaje))
                Console.Write(mensaje);

            while (true)
            {
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                    return valorDefault;

                if (int.TryParse(entrada, out int resultado))
                    return resultado;

                MostrarError("Valor invalido. Ingrese un numero entero: ");
            }
        }

        private static long LeerEnteroLong(string mensaje, long valorDefault = 0)
        {
            if (!string.IsNullOrEmpty(mensaje))
                Console.Write(mensaje);

            while (true)
            {
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                    return valorDefault;

                if (long.TryParse(entrada, out long resultado))
                    return resultado;

                MostrarError("Valor invalido. Ingrese un numero: ");
            }
        }

        private static decimal LeerDecimal(string mensaje, decimal valorDefault = 0)
        {
            if (!string.IsNullOrEmpty(mensaje))
                Console.Write(mensaje);

            while (true)
            {
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                    return valorDefault;

                if (decimal.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultado))
                    return resultado;

                MostrarError("Valor invalido. Ingrese un numero decimal: ");
            }
        }

        private static DateTime LeerFecha(string mensaje, DateTime? valorDefault = null)
        {
            if (!string.IsNullOrEmpty(mensaje))
                Console.Write(mensaje);

            while (true)
            {
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada) && valorDefault.HasValue)
                    return valorDefault.Value;

                if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultado))
                    return resultado;

                MostrarError("Fecha invalida. Use formato dd/MM/yyyy: ");
            }
        }

        private static string LeerCadena(string mensaje, string valorDefault = "")
        {
            if (!string.IsNullOrEmpty(mensaje))
                Console.Write(mensaje);

            string entrada = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entrada))
                return valorDefault;

            return entrada;
        }

        private static bool LeerBooleano(string mensaje, bool? valorDefault = null)
        {
            if (!string.IsNullOrEmpty(mensaje))
                Console.Write(mensaje);

            while (true)
            {
                string entrada = Console.ReadLine()?.Trim().ToLowerInvariant();
                if (string.IsNullOrEmpty(entrada) && valorDefault.HasValue)
                    return valorDefault.Value;

                if (entrada == "s" || entrada == "si" || entrada == "true" || entrada == "1")
                    return true;
                if (entrada == "n" || entrada == "no" || entrada == "false" || entrada == "0")
                    return false;

                MostrarError("Valor invalido. Ingrese s/n: ");
            }
        }

        private static void MostrarError(string mensaje)
        {
            ConsoleColor anterior = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = anterior;
        }

        private static void MostrarExito(string mensaje)
        {
            ConsoleColor anterior = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = anterior;
        }

        private static void Pausar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
private static byte[] LeerArchivoPDF(string mensaje)
    {
        Console.Write(mensaje);
        string ruta = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(ruta) || !System.IO.File.Exists(ruta))
        {
            return null;
        }
        try
        {
            return System.IO.File.ReadAllBytes(ruta);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo: " + ex.Message);
            return null;
        }
    }
        private static void InscribirAlumnoDesdeMenu(GC_ClaseService sClase, GM_MiembroService sMiembro)
        {
            Console.Clear();
            Console.WriteLine("=== INSCRIPCIÓN A CLASE ===");
            int idM = LeerEntero("ID del Miembro: ");
            int idC = LeerEntero("ID de la Clase: ");
            string msg = sClase.InscribirMiembro(idC, idM);
            Console.WriteLine(msg);
            Pausar();
        }
        #endregion
    }
    
}


