using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CuerpoSano.Models;
using CuerpoSano.Context;
using CuerpoSano.Services;

namespace CuerpoSano
{
    class Program
    {
        static List<Membresia> membresias = new List<Membresia>();
        static List<Miembro> miembros = new List<Miembro>();
        static List<Entrenador> entrenadores = new List<Entrenador>();
        static List<Clase> clases = new List<Clase>();
        static List<Cobranza> cobranzas = new List<Cobranza>();
        static int siguienteId = 1;

        static void Main(string[] args)
        {
            CargarDatosIniciales();
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA CUERPO SANO ===");
                Console.WriteLine("1. Membresias");
                Console.WriteLine("2. Miembros");
                Console.WriteLine("3. Entrenadores");
                Console.WriteLine("4. Clases");
                Console.WriteLine("5. Cobranzas");
                Console.WriteLine("0. Salir");
                int opcion = LeerEntero("Seleccione opcion: ");
                switch (opcion)
                {
                    case 1: MenuCRUD("Membresias", CrearMembresia, EditarMembresia, EliminarMembresia, ListarMembresias); break;
                    case 2: MenuCRUD("Miembros", CrearMiembro, EditarMiembro, EliminarMiembro, ListarMiembros); break;
                    case 3: MenuCRUD("Entrenadores", CrearEntrenador, EditarEntrenador, EliminarEntrenador, ListarEntrenadores); break;
                    case 4: MenuCRUD("Clases", CrearClase, EditarClase, EliminarClase, ListarClases); break;
                    case 5: MenuCRUD("Cobranzas", CrearCobranza, EditarCobranza, EliminarCobranza, ListarCobranzas); break;
                    case 0: ejecutando = false; break;
                    default: MostrarError("Opcion invalida"); break;
                }
            }
        }

        static void MenuCRUD(string nombre, Action crear, Action editar, Action eliminar, Action listar)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine($"=== MENU {nombre.ToUpper()} ===");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Editar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Listar");
                Console.WriteLine("0. Volver");
                int opcion = LeerEntero("Seleccione opcion: ");
                switch (opcion)
                {
                    case 1: crear(); break;
                    case 2: editar(); break;
                    case 3: eliminar(); break;
                    case 4: listar(); break;
                    case 0: volver = true; break;
                    default: MostrarError("Opcion invalida"); break;
                }
            }
        }

        static int NuevoId() => siguienteId++;

        static void CargarDatosIniciales()
        {
            membresias.Add(new Membresia { Id = NuevoId(), Nombre = "Basica", Precio = 500, DuracionDias = 30 });
            membresias.Add(new Membresia { Id = NuevoId(), Nombre = "Premium", Precio = 900, DuracionDias = 30 });
            entrenadores.Add(new Entrenador { Id = NuevoId(), Nombre = "Carlos", Especialidad = "Musculacion", Telefono = "123456789" });
        }

        static void CrearMembresia()
        {
            var item = new Membresia { Id = NuevoId() };
            item.Nombre = LeerCadena("Nombre: ");
            item.Precio = LeerDecimal("Precio: ");
            item.DuracionDias = LeerEntero("Duracion en dias: ");
            membresias.Add(item);
            MostrarExito("Membresia creada");
        }

        static void EditarMembresia()
        {
            var item = BuscarPorId("Membresias", membresias);
            if (item == null) return;
            item.Nombre = LeerCadena($"Nombre ({item.Nombre}): ", item.Nombre);
            item.Precio = LeerDecimal($"Precio ({item.Precio}): ", item.Precio);
            item.DuracionDias = LeerEntero($"Duracion ({item.DuracionDias}): ", item.DuracionDias);
            MostrarExito("Membresia actualizada");
        }

        static void EliminarMembresia()
        {
            if (EliminarPorId("Membresias", membresias)) MostrarExito("Membresia eliminada");
        }

        static void ListarMembresias() => Listar("Membresias", membresias, m => $"Id: {m.Id}, Nombre: {m.Nombre}, Precio: {m.Precio:C}, Duracion: {m.DuracionDias} dias");

        static void CrearMiembro()
        {
            var item = new Miembro { Id = NuevoId() };
            item.Nombre = LeerCadena("Nombre: ");
            item.Telefono = LeerCadena("Telefono: ");
            item.FechaNacimiento = LeerFecha("Fecha de nacimiento (dd/MM/yyyy): ");
            item.Activo = LeerBooleano("Activo (s/n): ");
            ListarMembresias();
            item.MembresiaId = LeerEntero("Id de membresia: ");
            miembros.Add(item);
            MostrarExito("Miembro creado");
        }

        static void EditarMiembro()
        {
            var item = BuscarPorId("Miembros", miembros);
            if (item == null) return;
            item.Nombre = LeerCadena($"Nombre ({item.Nombre}): ", item.Nombre);
            item.Telefono = LeerCadena($"Telefono ({item.Telefono}): ", item.Telefono);
            item.FechaNacimiento = LeerFecha($"Fecha de nacimiento ({item.FechaNacimiento:dd/MM/yyyy}): ", item.FechaNacimiento);
            item.Activo = LeerBooleano($"Activo ({(item.Activo ? "s" : "n")}): ", item.Activo);
            ListarMembresias();
            item.MembresiaId = LeerEntero($"Id de membresia ({item.MembresiaId}): ", item.MembresiaId);
            MostrarExito("Miembro actualizado");
        }

        static void EliminarMiembro()
        {
            if (EliminarPorId("Miembros", miembros)) MostrarExito("Miembro eliminado");
        }

        static void ListarMiembros() => Listar("Miembros", miembros, m => $"Id: {m.Id}, Nombre: {m.Nombre}, Telefono: {m.Telefono}, Nacimiento: {m.FechaNacimiento:dd/MM/yyyy}, Activo: {(m.Activo ? "Si" : "No")}, MembresiaId: {m.MembresiaId}");

        static void CrearEntrenador()
        {
            var item = new Entrenador { Id = NuevoId() };
            item.Nombre = LeerCadena("Nombre: ");
            item.Especialidad = LeerCadena("Especialidad: ");
            item.Telefono = LeerCadena("Telefono: ");
            entrenadores.Add(item);
            MostrarExito("Entrenador creado");
        }

        static void EditarEntrenador()
        {
            var item = BuscarPorId("Entrenadores", entrenadores);
            if (item == null) return;
            item.Nombre = LeerCadena($"Nombre ({item.Nombre}): ", item.Nombre);
            item.Especialidad = LeerCadena($"Especialidad ({item.Especialidad}): ", item.Especialidad);
            item.Telefono = LeerCadena($"Telefono ({item.Telefono}): ", item.Telefono);
            MostrarExito("Entrenador actualizado");
        }

        static void EliminarEntrenador()
        {
            if (EliminarPorId("Entrenadores", entrenadores)) MostrarExito("Entrenador eliminado");
        }

        static void ListarEntrenadores() => Listar("Entrenadores", entrenadores, e => $"Id: {e.Id}, Nombre: {e.Nombre}, Especialidad: {e.Especialidad}, Telefono: {e.Telefono}");

        static void CrearClase()
        {
            var item = new Clase { Id = NuevoId() };
            item.Nombre = LeerCadena("Nombre: ");
            item.Horario = LeerCadena("Horario: ");
            item.CupoMaximo = LeerEntero("Cupo maximo: ");
            ListarEntrenadores();
            item.EntrenadorId = LeerEntero("Id de entrenador: ");
            clases.Add(item);
            MostrarExito("Clase creada");
        }

        static void EditarClase()
        {
            var item = BuscarPorId("Clases", clases);
            if (item == null) return;
            item.Nombre = LeerCadena($"Nombre ({item.Nombre}): ", item.Nombre);
            item.Horario = LeerCadena($"Horario ({item.Horario}): ", item.Horario);
            item.CupoMaximo = LeerEntero($"Cupo maximo ({item.CupoMaximo}): ", item.CupoMaximo);
            ListarEntrenadores();
            item.EntrenadorId = LeerEntero($"Id de entrenador ({item.EntrenadorId}): ", item.EntrenadorId);
            MostrarExito("Clase actualizada");
        }

        static void EliminarClase()
        {
            if (EliminarPorId("Clases", clases)) MostrarExito("Clase eliminada");
        }

        static void ListarClases() => Listar("Clases", clases, c => $"Id: {c.Id}, Nombre: {c.Nombre}, Horario: {c.Horario}, Cupo: {c.CupoMaximo}, EntrenadorId: {c.EntrenadorId}");

        static void CrearCobranza()
        {
            var item = new Cobranza { Id = NuevoId() };
            item.Fecha = LeerFecha("Fecha (dd/MM/yyyy): ");
            ListarMiembros();
            item.MiembroId = LeerEntero("Id de miembro: ");
            item.Monto = LeerDecimal("Monto: ");
            item.Pagado = LeerBooleano("Pagado (s/n): ");
            cobranzas.Add(item);
            MostrarExito("Cobranza creada");
        }

        static void EditarCobranza()
        {
            var item = BuscarPorId("Cobranzas", cobranzas);
            if (item == null) return;
            item.Fecha = LeerFecha($"Fecha ({item.Fecha:dd/MM/yyyy}): ", item.Fecha);
            ListarMiembros();
            item.MiembroId = LeerEntero($"Id de miembro ({item.MiembroId}): ", item.MiembroId);
            item.Monto = LeerDecimal($"Monto ({item.Monto}): ", item.Monto);
            item.Pagado = LeerBooleano($"Pagado ({(item.Pagado ? "s" : "n")}): ", item.Pagado);
            MostrarExito("Cobranza actualizada");
        }

        static void EliminarCobranza()
        {
            if (EliminarPorId("Cobranzas", cobranzas)) MostrarExito("Cobranza eliminada");
        }

        static void ListarCobranzas() => Listar("Cobranzas", cobranzas, c => $"Id: {c.Id}, Fecha: {c.Fecha:dd/MM/yyyy}, MiembroId: {c.MiembroId}, Monto: {c.Monto:C}, Pagado: {(c.Pagado ? "Si" : "No")}");

        static T BuscarPorId<T>(string entidad, List<T> lista) where T : class, IEntidad
        {
            Listar(entidad, lista, x => x.ToString());
            int id = LeerEntero("Id: ");
            var item = lista.FirstOrDefault(x => x.Id == id);
            if (item == null) MostrarError("No encontrado");
            return item;
        }

        static bool EliminarPorId<T>(string entidad, List<T> lista) where T : class, IEntidad
        {
            Listar(entidad, lista, x => x.ToString());
            int id = LeerEntero("Id a eliminar: ");
            var item = lista.FirstOrDefault(x => x.Id == id);
            if (item == null) { MostrarError("No encontrado"); return false; }
            lista.Remove(item);
            return true;
        }

        static void Listar<T>(string titulo, List<T> lista, Func<T, string> formateador)
        {
            Console.Clear();
            Console.WriteLine($"=== LISTADO DE {titulo.ToUpper()} ===");
            if (lista.Count == 0) Console.WriteLine("Sin registros.");
            else foreach (var item in lista) Console.WriteLine(formateador(item));
            Pausar();
        }

        static int LeerEntero(string mensaje, int valorDefault = 0)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada) && valorDefault != 0) return valorDefault;
                if (int.TryParse(entrada, out int valor)) return valor;
                MostrarError("Ingrese un numero entero valido");
            }
        }

        static decimal LeerDecimal(string mensaje, decimal valorDefault = 0)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada) && valorDefault != 0) return valorDefault;
                if (decimal.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor)) return valor;
                MostrarError("Ingrese un numero decimal valido");
            }
        }

        static DateTime LeerFecha(string mensaje, DateTime? valorDefault = null)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada) && valorDefault.HasValue) return valorDefault.Value;
                if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime valor)) return valor;
                MostrarError("Ingrese una fecha valida (dd/MM/yyyy)");
            }
        }

        static string LeerCadena(string mensaje, string valorDefault = "")
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) ? valorDefault : entrada.Trim();
        }

        static bool LeerBooleano(string mensaje, bool? valorDefault = null)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(entrada) && valorDefault.HasValue) return valorDefault.Value;
                if (entrada == "s" || entrada == "si" || entrada == "true" || entrada == "1") return true;
                if (entrada == "n" || entrada == "no" || entrada == "false" || entrada == "0") return false;
                MostrarError("Ingrese s/n");
            }
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
            Pausar();
        }

        static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }

    public interface IEntidad
    {
        int Id { get; set; }
    }

    public class Membresia : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public override string ToString() => $"Id: {Id}, Nombre: {Nombre}, Precio: {Precio:C}, Duracion: {DuracionDias} dias";
    }

    public class Miembro : IEntidad
    {
        /*public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public int MembresiaId { get; set; }*/
        public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool Activo { get; set; }
    public string Direccion { get; set; }
    public int MembresiaId { get; set; }
    public virtual Membresia Membresia { get; set; }
    public virtual ICollection<Clase> ListaClases { get; set; } = new List<Clase>();

        public override string ToString() => $"Id: {Id}, Nombre: {Nombre}, Telefono: {Telefono}, Nacimiento: {FechaNacimiento:dd/MM/yyyy}, Activo: {(Activo ? "Si" : "No")}, MembresiaId: {MembresiaId}";
    }

    public class Entrenador : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public override string ToString() => $"Id: {Id}, Nombre: {Nombre}, Especialidad: {Especialidad}, Telefono: {Telefono}";
    }

    public class Clase : IEntidad
    {
        /*public int Id { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public int CupoMaximo { get; set; }
        public int EntrenadorId { get; set; }*/
          public int Id { get; set; }
    public string Nombre { get; set; }
    public string Horario { get; set; }
    public int CupoMaximo { get; set; }
    public int EntrenadorId { get; set; }
    public virtual List<Miembro> Miembros { get; set; } = new List<Miembro>();
        public override string ToString() => $"Id: {Id}, Nombre: {Nombre}, Horario: {Horario}, Cupo: {CupoMaximo}, EntrenadorId: {EntrenadorId}";
    }

    public class Cobranza : IEntidad
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int MiembroId { get; set; }
        public decimal Monto { get; set; }
        public bool Pagado { get; set; }
        public override string ToString() => $"Id: {Id}, Fecha: {Fecha:dd/MM/yyyy}, MiembroId: {MiembroId}, Monto: {Monto:C}, Pagado: {(Pagado ? "Si" : "No")}";
    }
}