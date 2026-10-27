using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    
    // aca muestra cuantos lugares quedan cada vez que entra o sale un auto
     
    public class PantallaLugares : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            Console.WriteLine("[Pantalla] Lugares libres: " + evento.LugaresLibres);
        }
    }
}
