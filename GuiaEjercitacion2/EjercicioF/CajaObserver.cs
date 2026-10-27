using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    
   //esta clase suma lo que se cobra cada vez que sale un auto
   
    public class CajaObserver : IPlayaObserver
    {
        private decimal _totalPlazaColon = 0;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == "Egreso")
            {
                _totalPlazaColon += evento.Importe;

                Console.WriteLine("[Caja] Cobrado $ " + evento.Importe.ToString("N0") + " a " + evento.Patente + ". recaudado: $ " + _totalPlazaColon.ToString("N0"));
            }
        }
    }
}
