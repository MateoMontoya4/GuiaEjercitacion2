
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioB3
{
    public interface IObservador
    {
        void Actualizar(string video);
    }

    public class Canal
    {
        private readonly List<IObservador> _suscriptores =
            new List<IObservador>();

        public void Suscribir(IObservador o) =>
            _suscriptores.Add(o);

        public void Desuscribir(IObservador o) =>
            _suscriptores.Remove(o);

        public void Publicar(string video)
        {
            Console.WriteLine($"Nuevo video: {video}");

            foreach (var s in _suscriptores.ToList())
                s.Actualizar(video);
        }
    }

    public class Fan : IObservador
    {
        private readonly string _nombre;

        public Fan(string nombre) => _nombre = nombre;

        public void Actualizar(string video) =>
            Console.WriteLine($" {_nombre} mira {video}");
    }

    public class Estadisticas : IObservador
    {
        private int _avisos = 0;

        public void Actualizar(string video)
        {
            _avisos++;
            Console.WriteLine($" Avisos registrados: {_avisos}");
        }
    }

    public class Demo
    {
        public static void Ejecutar()
        {
            var canal = new Canal();
            var lu = new Fan("Lu");

            canal.Suscribir(lu);
            canal.Suscribir(new Fan("Tomi"));
            canal.Suscribir(new Estadisticas());

            canal.Publicar("Patrones en C#");
            canal.Desuscribir(lu);
            canal.Publicar("Observer en WinForms");
        }
    }
}

/*
Antes de ejecutar:
Pensé que Lu iba a recibir los dos videos, pero después
vi que se desuscribe antes de publicar el segundo.

¿Qué imprime?
Muestra los dos videos, los fans que reciben cada aviso
y la cantidad de avisos registrados.

¿Por qué Lu no aparece en la segunda publicación?
Porque se la saca de la lista antes de publicar el
segundo video.

¿Canal conoce la clase Fan? ¿Cómo te das cuenta?
No directamente, porque trabaja con IObservador y
no necesita conocer cada clase que recibe los avisos.

Después de ejecutar:
La salida coincidió con lo que había pensado.
*/
