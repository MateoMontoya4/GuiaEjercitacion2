using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public interface ITarifa
    {
        string Nombre { get; }
        /*
         esta interfaz sirve para que todas las tarifas
         tengan un nombre y una forma de calcular el precio.
        */
        decimal Calcular(int minutos);
    }
}
