
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }

    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores =
            new List<IAlarmaObserver>();

        public void Suscribir(IAlarmaObserver o) =>
            _observadores.Add(o);

        public void Desuscribir(IAlarmaObserver o) =>
            _observadores.Remove(o);

        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");

            foreach (var o in _observadores.ToList())
                o.Actualizar(this);
        }
    }

    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }

    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) =>
            Console.WriteLine("Luz encendida");
    }

    public class Demo
    {
        public static void Ejecutar()
        {
            var alarma = new Alarma();
            alarma.Suscribir(new AvisoUnico());
            alarma.Suscribir(new Luz());
            alarma.Sonar();
        }
    }
}

/*
C1

¿Cuál es el error y de qué tipo es?
Es un error de ejecución, porque el programa falla
cuando se está ejecutando.

¿Por qué es un error?
Porque AvisoUnico se elimina de la lista mientras
el foreach la está recorriendo.

¿Cómo se corrige?
Usando ToList(), que hace una copia de la lista
para poder recorrerla sin que dé error.
*/

namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }

    public class TarifaMotoMdp : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg)
        {
            return 1500 + pesoKg * 100;
        }
    }

    public class TarifaCamionMdp : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg)
        {
            return 8000 + pesoKg * 40;
        }
    }

    public class Demo
    {
        public static void Ejecutar()
        {
            IEnvioStrategy moto = new TarifaMotoMdp();
            Console.WriteLine("Costo de envio en moto: $" + moto.Calcular(5));

            IEnvioStrategy camion = new TarifaCamionMdp();
            Console.WriteLine("Costo de envio en camion: $" + camion.Calcular(5));
        }
    }

}

/*
C2

¿Cuál es el error y de qué tipo es?
Es un error de diseño, porque la clase decide
el tipo de envío usando varios if.

¿Qué pasa cuando llega un tipo nuevo, como Bicicleta?
Hay que modificar la clase para agregar otro if.
Si no lo hacemos, usa el cálculo por defecto.

¿Cómo se corrige?
Haciendo una clase para cada tipo de envío.
Así cada una tiene su propio cálculo y no hace
falta meter todos los tipos en la misma clase.
*/

namespace EjercicioC3
{
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }

    public class NotificadorMail : INotificador
    {
        public void Enviar(string destino, string mensaje)
        {
            Console.WriteLine($"Enviando mail a {destino}: {mensaje}");
        }
    }

    public class NotificadorSms : INotificador
    {
        public void Enviar(string destino, string mensaje)
        {
            Console.WriteLine($"Enviando SMS a {destino}: {mensaje}");
        }
    }

    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL")
                return new NotificadorMail();

            if (canal == "SMS")
                return new NotificadorSms();

            throw new ArgumentException($"Canal desconocido: {canal}");
        }
    }
    public class Demo
    {
        public static void Ejecutar()
        {
            INotificador mail = NotificadorFactory.Crear("MAIL");
            mail.Enviar("mateo@gmail.com", "Hola, este es un mail");

            INotificador sms = NotificadorFactory.Crear("SMS");
            sms.Enviar("2231234567", "Hola, este es un SMS");
        }
    }
}

/*
¿Cuál es el error y de qué tipo es?
Es un error de compilación porque el método puede
terminar sin devolver un notificador.

¿Cómo se corrige?
Agregando una excepción al final del método.

¿Por qué conviene lanzar una excepción con un mensaje
claro y no devolver null?
Porque explica qué salió mal y permite encontrar
el problema más fácil. Con null, el error puede
aparecer después al intentar usar el objeto.
*/
