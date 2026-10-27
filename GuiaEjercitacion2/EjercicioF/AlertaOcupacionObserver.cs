using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    
   //esto  avisa cuando quedan pocos lugares libres en la playa
 
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres <= 2)
            {
                Console.WriteLine("[Alerta] ¡Quedan " +
                    evento.LugaresLibres + " lugares!!!!!!!!");
            }
        }
    }
}
