using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
   
    public interface IPlayaObserver  //esta interfaz sirve para que los observadores sepan cuando pasa algo en la playa.
    
    {
        void Actualizar(EventoPlaya evento);
    }
}
