using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaNocturna : ITarifa
    {
        public string Nombre => "NOCHE";

        public decimal Calcular(int minutos) // Esta tarifa siempre cobra 4500 pesos, no importa cuanto tiempo estuvo el auto.

        {
            return 4500m;
        }
    }
}
