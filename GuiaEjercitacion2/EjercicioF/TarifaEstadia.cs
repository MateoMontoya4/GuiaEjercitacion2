using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public class TarifaEstadia : ITarifa
    {
        public string Nombre => "ESTADIA";

        public decimal Calcular(int minutos) //Esta clase cobra un precio fijo hasta las 12 horas.si el auto se queda mas tiempo, se le cobra un extra por cada hora o parte de hora.
        {
            if (minutos <= 720)
            {
                return 6000;
            }
            else
            {
                int extra = minutos - 720;
                int horas = (int)Math.Ceiling(extra / 60.0);

                return 6000 + horas * 1200;
            }
        }
    }
}
