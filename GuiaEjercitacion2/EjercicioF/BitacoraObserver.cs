using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
   // esta clase guarda en la bitacora las entradas y salidas de los autos
    
    public class BitacoraObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo == "Ingreso")
            {
                Bitacora.Instancia.Registrar(
                    "Ingresó " + evento.Patente);
            }
            else if (evento.Tipo == "Egreso")
            {
                Bitacora.Instancia.Registrar("Egreso " + evento.Patente + " - $ " + evento.Importe.ToString("N0"));
            }
        }
    }
}
