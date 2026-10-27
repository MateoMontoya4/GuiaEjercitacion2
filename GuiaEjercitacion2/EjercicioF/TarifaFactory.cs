using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF
{
    public static class TarifaFactory
    {
        public static ITarifa Crear(string codigo) //Esta clase elige que tarifa crear segun el codigo.Si el codigo no existe, muestra un error.
        {
            switch (codigo)
            {
                case "HORA":
                    return new TarifaHora();

                case "ESTADIA":
                    return new TarifaEstadia();

                case "NOCHE":
                    return new TarifaNocturna();

                default:
                    throw new ArgumentException(
                        "codigo de tarifa desconocido: " + codigo);
            }
        }

        public static List<string> CodigosDisponibles()
        {
            return new List<string>
            {
                "HORA","ESTADIA","NOCHE"
            };
        }
    }
}
