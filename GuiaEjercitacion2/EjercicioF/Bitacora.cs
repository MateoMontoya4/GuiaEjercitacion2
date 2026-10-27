using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class Bitacora //La bitacora guarda los registros de la playa. Usamos Singleton para tener una sola y que todos los movimientos queden juntos.
    {
        private static Bitacora _instancia;
        private List<string> _registros = new List<string>();

        private Bitacora()
        {
        }

        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Bitacora();
                }

                return _instancia;
            }
        }

        public void Registrar(string texto)
        {
            int numero = _registros.Count + 1;
            _registros.Add(numero.ToString("00") + ". " + texto);
        }

        public void MostrarTodo()
        {
            Console.WriteLine("--Bitacora ---");

            foreach (string registro in _registros)
            {
                Console.WriteLine(registro);
            }
        }
    }
}
