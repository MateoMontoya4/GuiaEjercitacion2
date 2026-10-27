using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaHora : ITarifa
    {
        public string Nombre => "HORA";  // Esta clase calcula el precio por hora. Si el auto estuvo una parte de la hora, se cobra la hora completa.


        public decimal Calcular(int minutos)
        {
            int horas = (int)Math.Ceiling(minutos / 60.0);
            return horas * 1200m;
        }
    }
}
