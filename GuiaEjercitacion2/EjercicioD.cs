
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioD1
{
    public interface ITemperaturaObserver
    {
        void Actualizar(double grados);
    }

    public class Termometro
    {
        private readonly List<ITemperaturaObserver> _observadores =
            new List<ITemperaturaObserver>();

        public void Suscribir(ITemperaturaObserver o) => _observadores.Add(o);

        public void Desuscribir(ITemperaturaObserver o) => _observadores.Remove(o);

        public void Medir(double grados)
        {
            Console.WriteLine($"Termómetro: {grados}°");

            foreach (var o in _observadores.ToList())
                o.Actualizar(grados);
        }
    }

    public class PantallaCocina : ITemperaturaObserver
    {
        public void Actualizar(double grados) =>
            Console.WriteLine($"Pantalla: {grados}°");
    }

    public class AlarmaCalor : ITemperaturaObserver
    {
        public void Actualizar(double grados)
        {
            if (grados > 30)
                Console.WriteLine("¡Alarma! Hace demasiado calor");
        }
    }

    public class Demo
    {
        public static void Ejecutar()
        {
            var termo = new Termometro();

            termo.Suscribir(new PantallaCocina());
            termo.Suscribir(new AlarmaCalor());

            termo.Medir(25);
            termo.Medir(34);
        }
    }
}

/*
D1

La interfaz es ITemperaturaObserver.
El método que deben implementar los observadores
es Actualizar.

El termómetro agrega y elimina observadores con
Add y Remove.

Usamos ToList() para recorrer una copia de la lista.
Actualizamos a cada observador con los grados medidos.

La pantalla muestra la temperatura y la alarma
avisa solamente cuando supera los 30 grados.
*/


namespace EjercicioD2
{
    public interface IDescuento
    {
        decimal Aplicar(decimal precio);
    }

    public class SinDescuento : IDescuento
    {
        public decimal Aplicar(decimal precio) => precio;
    }

    public class DescuentoJubilado : IDescuento
    {
        public decimal Aplicar(decimal precio) => precio * 0.85m;
    }

    public class DescuentoEstudiante : IDescuento
    {
        public decimal Aplicar(decimal precio) => precio * 0.90m;
    }

    public static class DescuentoFactory
    {
        public static IDescuento Crear(string tipo)
        {
            switch (tipo)
            {
                case "JUBILADO":
                    return new DescuentoJubilado();

                case "ESTUDIANTE":
                    return new DescuentoEstudiante();

                case "NINGUNO":
                    return new SinDescuento();

                default:
                    throw new ArgumentException(
                        $"Tipo desconocido: {tipo}");
            }
        }
    }

    public class Demo
    {
        public static void Ejecutar()
        {
            string tipoElegido = "JUBILADO";

            IDescuento descuento =
                DescuentoFactory.Crear(tipoElegido);

            Console.WriteLine(
                descuento.Aplicar(10000m).ToString("0"));
        }
    }
}

/*
D2

¿Por qué la factory está justificada?
Porque el tipo llega como texto y la factory
se encarga de crear el descuento que corresponde.
*/
