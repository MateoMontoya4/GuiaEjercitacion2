using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class Playa
    {
        private int _capacidad;
        
        private Dictionary<string, ITarifa> _vehiculos = new Dictionary<string, ITarifa>(); //guardamos la patente y la tarifa que eligio cada auto

 
        
        private List<IPlayaObserver> _observadores = new List<IPlayaObserver>(); //aca guardamos los que reciben avisos cuando entre y sale un auto

        public Playa(int capacidad)
        {
            _capacidad = capacidad;
        }

        // agrega un observador
        public void Suscribir(IPlayaObserver observador)
        {
            _observadores.Add(observador);
        }

        // saca un observador
        public void Desuscribir(IPlayaObserver observador)
        {
            _observadores.Remove(observador);
        }

        /*
        avisa a los observadores lo que paso
        recorremos una copia para evitar problemas
        si alguno se elimina de la lista
        */
        private void Notificar(EventoPlaya evento)
        {
            foreach (IPlayaObserver observador in _observadores.ToList())
            {
                observador.Actualizar(evento);
            }
        }

        // registra la entrada de un auto
        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente))
            {
                throw new ArgumentException("La patente no puede estar vacia.");
            }

            if (_vehiculos.ContainsKey(patente))
            {
                throw new InvalidOperationException("El auto ya esta en la playa.");
            }

            if (_vehiculos.Count >= _capacidad)
            {
                throw new InvalidOperationException("La playa esta llena.");
            }

            // buscamos la tarifa que eligio el cliente
            ITarifa tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculos.Add(patente, tarifa);

            // guardamos los datos de la entrada
            EventoPlaya evento = new EventoPlaya();
            evento.Tipo = "Ingreso";
            evento.Patente = patente;
            evento.Importe = 0;
            evento.LugaresLibres = _capacidad - _vehiculos.Count;

            Notificar(evento);
        }

        // registra la salida y calcula el precio
        public decimal Egresar(string patente, int minutos)
        {
            if (!_vehiculos.ContainsKey(patente))
            {
                throw new InvalidOperationException("El auto no esta en la playa.");
            }

            // usamos la tarifa que tenia cuando entro
            ITarifa tarifa = _vehiculos[patente];
            decimal importe = tarifa.Calcular(minutos);

            _vehiculos.Remove(patente);

            // avisamos que el auto salio
            EventoPlaya evento = new EventoPlaya();
            evento.Tipo = "Egreso";
            evento.Patente = patente;
            evento.Importe = importe;
            evento.LugaresLibres = _capacidad - _vehiculos.Count;

            Notificar(evento);

            return importe;
        }
    }
}
