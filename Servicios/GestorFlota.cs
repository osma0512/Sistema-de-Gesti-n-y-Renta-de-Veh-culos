using System;
using System.Collections.Generic;
using GestionVehiculos.Modelos;
using GestionVehiculos.Interfaces;

namespace GestionVehiculos
{
    public class GestorFlota
    {
        private List<Vehiculo> flota;

        public GestorFlota()
        {
            flota = new List<Vehiculo>();
        }

        public void RegistrarVehiculo()
        {
            Console.WriteLine("--- REGISTRAR VEHÍCULO ---");
            Console.WriteLine("1. Automóvil");
            Console.WriteLine("2. Camioneta");
            Console.WriteLine("3. Motocicleta");
            int tipoVehiculo = Program.LeerEntero("Seleccione el tipo de vehículo: ");

            Console.Write("Código: ");
            string codigo = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            int anio = Program.LeerEntero("Año: ");
            double kilometros = Program.LeerDouble("Kilometraje: ");
            double precioRenta = Program.LeerDouble("Precio de Renta por Día: ");

            if (tipoVehiculo == 1)
            {
                int puertas = Program.LeerEntero("Número de puertas: ");
                Console.Write("Transmisión (Manual/Automática): ");
                string transmision = Console.ReadLine();
                Console.Write("Combustible (Gasolina/Diésel/Híbrido): ");
                string combustible = Console.ReadLine();
                Console.Write("¿Tiene Aire Acondicionado? (s/n): ");
                bool aire = Console.ReadLine().ToLower() == "s";
                int pasajeros = Program.LeerEntero("Número de pasajeros: ");

                flota.Add(new Automovil(codigo, marca, modelo, anio, kilometros, precioRenta, puertas, transmision, combustible, aire, pasajeros));
            }
            else if (tipoVehiculo == 2)
            {
                double carga = Program.LeerDouble("Capacidad de carga (Toneladas): ");
                Console.Write("Tracción (4x2/4x4): ");
                string traccion = Console.ReadLine();
                Console.Write("¿Tiene Doble Cabina? (s/n): ");
                bool dobleCabina = Console.ReadLine().ToLower() == "s";
                int pasajeros = Program.LeerEntero("Número de pasajeros: ");

                flota.Add(new Camioneta(codigo, marca, modelo, anio, kilometros, precioRenta, carga, traccion, dobleCabina, pasajeros));
            }
            else if (tipoVehiculo == 3)
            {
                int cilindrada = Program.LeerEntero("Cilindrada (cc): ");
                Console.Write("Tipo (Scooter/Enduro/Pistera): ");
                string tipoMoto = Console.ReadLine();
                Console.Write("¿Tiene Baúl? (s/n): ");
                bool baul = Console.ReadLine().ToLower() == "s";
                int cascos = Program.LeerEntero("Número de cascos: ");

                flota.Add(new Motocicleta(codigo, marca, modelo, anio, kilometros, precioRenta, cilindrada, tipoMoto, baul, cascos));
            }
            else
            {
                Console.WriteLine("Tipo de vehículo no válido.");
                return;
            }
            Console.WriteLine("Vehículo registrado con éxito.");
        }

        public void MostrarTodos()
        {
            if (flota.Count == 0) { Console.WriteLine("No hay vehículos registrados."); return; }
            foreach (var v in flota) v.MostrarInformacion();
        }

        public void BuscarPorCodigo()
        {
            Console.Write("Ingrese el código del vehículo a buscar: ");
            string codigo = Console.ReadLine();
            foreach (var v in flota)
            {
                if (v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    v.MostrarInformacion();
                    return;
                }
            }
            Console.WriteLine("Vehículo no encontrado.");
        }

        public void MostrarDisponibles()
        {
            Console.WriteLine("--- VEHÍCULOS DISPONIBLES ---");
            foreach (var v in flota)
            {
                if (v.Estado == "Disponible") v.MostrarInformacion();
            }
        }

        public void MostrarRentados()
        {
            Console.WriteLine("--- VEHÍCULOS RENTADOS ---");
            foreach (var v in flota)
            {
                if (v.Estado == "Rentado") v.MostrarInformacion();
            }
        }

        public void CambiarEstado()
        {
            Console.Write("Ingrese el código del vehículo: ");
            string codigo = Console.ReadLine();
            foreach (var v in flota)
            {
                if (v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Estado actual: {v.Estado}");
                    Console.Write("Nuevo estado (Disponible/Rentado/En Mantenimiento): ");
                    v.Estado = Console.ReadLine();
                    Console.WriteLine("Estado actualizado.");
                    return;
                }
            }
            Console.WriteLine("Vehículo no encontrado.");
        }

        public void VehiculoMayorKilometraje()
        {
            if (flota.Count == 0) { Console.WriteLine("No hay vehículos registrados."); return; }
            
            Vehiculo mayor = flota[0];
            foreach (var v in flota)
            {
                if (v != null && v.Kilometros > mayor.Kilometros)
                {
                    mayor = v;
                }
            }
            Console.WriteLine("--- VEHÍCULO CON MAYOR KILOMETRAJE ---");
            mayor.MostrarInformacion();
        }

        public void CalcularPromedioRenta()
        {
            if (flota.Count == 0) { Console.WriteLine("No hay vehículos registrados."); return; }
            double suma = 0;
            foreach (var v in flota) suma += v.PrecioRenta;
            Console.WriteLine($"El precio promedio de renta es: ${suma / flota.Count:F2}");
        }

        public void ContarPorTipo()
        {
            int autos = 0, camionetas = 0, motos = 0;
            foreach (var v in flota)
            {
                if (v is Automovil) autos++;
                else if (v is Camioneta) camionetas++;
                else if (v is Motocicleta) motos++;
            }
            Console.WriteLine("--- CANTIDAD DE VEHÍCULOS POR TIPO ---");
            Console.WriteLine($"Automóviles: {autos}");
            Console.WriteLine($"Camionetas: {camionetas}");
            Console.WriteLine($"Motocicletas: {motos}");
        }

        public void RealizarMantenimiento()
        {
            Console.Write("Ingrese el código del vehículo para mantenimiento: ");
            string codigo = Console.ReadLine();
            foreach (var v in flota)
            {
                if (v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    v.ConsultarMantenimiento();
                    v.RealizarMantenimiento();
                    return;
                }
            }
            Console.WriteLine("Vehículo no encontrado.");
        }
    }
}