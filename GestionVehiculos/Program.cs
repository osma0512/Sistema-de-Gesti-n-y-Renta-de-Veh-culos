using System;
using System.IO;

namespace GestionVehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorFlota gestor = new GestorFlota();
            int opcion;

            do
            {
                LimpiarPantalla();
                Console.WriteLine("========================================");
                Console.WriteLine("===== SISTEMA DE RENTA DE VEHÍCULOS =====");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar vehículo");
                Console.WriteLine("2. Mostrar todos los vehículos");
                Console.WriteLine("3. Buscar vehículo por código");
                Console.WriteLine("4. Mostrar vehículos disponibles");
                Console.WriteLine("5. Mostrar vehículos rentados");
                Console.WriteLine("6. Cambiar estado");
                Console.WriteLine("7. Vehículo con mayor kilometraje");
                Console.WriteLine("8. Calcular precio promedio de renta");
                Console.WriteLine("9. Cantidad de vehículos por tipo");
                Console.WriteLine("10. Realizar mantenimiento");
                Console.WriteLine("11. Salir");
                Console.WriteLine("========================================");

                opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1: gestor.RegistrarVehiculo(); break;
                    case 2: gestor.MostrarTodos(); break;
                    case 3: gestor.BuscarPorCodigo(); break;
                    case 4: gestor.MostrarDisponibles(); break;
                    case 5: gestor.MostrarRentados(); break;
                    case 6: gestor.CambiarEstado(); break;
                    case 7: gestor.VehiculoMayorKilometraje(); break;
                    case 8: gestor.CalcularPromedioRenta(); break;
                    case 9: gestor.ContarPorTipo(); break;
                    case 10: gestor.RealizarMantenimiento(); break;
                    case 11: Console.WriteLine("Saliendo del sistema..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

                if (opcion != 11)
                {
                    EsperarContinuacion();
                }

            } while (opcion != 11);
        }

        private static void LimpiarPantalla()
        {
            try
            {
                if (Environment.UserInteractive && !Console.IsOutputRedirected)
                {
                    Console.Clear();
                }
            }
            catch (IOException)
            {
                // Ignorar si no hay consola disponible
            }
        }

        private static void EsperarContinuacion()
        {
            try
            {
                if (Environment.UserInteractive && !Console.IsInputRedirected)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    return;
                }
            }
            catch (IOException)
            {
                // Ignorar si la consola no está disponible
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }

        public static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Entrada no válida. Ingrese un número entero: ");
                Console.ResetColor();
            }
            return valor;
        }

        public static double LeerDouble(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Entrada no válida. Ingrese un número válido: ");
                Console.ResetColor();
            }
            return valor;
        }
    }
}