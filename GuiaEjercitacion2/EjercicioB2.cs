
using System;

namespace EjercicioB2
{
    public interface IPropina
    {
        string Nombre { get; }
        decimal Calcular(decimal total);
    }

    public class SinPropina : IPropina
    {
        public string Nombre => "Sin propina";

        public decimal Calcular(decimal total) => 0;
    }

    public class Propina10 : IPropina
    {
        public string Nombre => "10%";

        public decimal Calcular(decimal total) => total * 0.10m;
    }

    public class PropinaFija : IPropina
    {
        private readonly decimal _monto;

        public PropinaFija(decimal monto)
        {
            _monto = monto;
        }

        public string Nombre => "Fija";

        public decimal Calcular(decimal total) => _monto;
    }

    public class Cuenta
    {
        private IPropina _propina;

        public Cuenta(IPropina propina)
        {
            _propina = propina;
        }

        public void CambiarPropina(IPropina propina)
        {
            _propina = propina;
        }

        public void Mostrar(decimal total)
        {
            decimal final = total + _propina.Calcular(total);

            Console.WriteLine($"{_propina.Nombre}: {final:0}");
        }
    }

    public class Demo
    {
        public static void Ejecutar()
        {
            var cuenta = new Cuenta(new SinPropina());
            cuenta.Mostrar(20000);

            cuenta.CambiarPropina(new Propina10());
            cuenta.Mostrar(20000);

            cuenta.CambiarPropina(new PropinaFija(1500));
            cuenta.Mostrar(20000);
        }
    }
}

/* 
/*
Antes de ejecutar:
Pensé que los tres resultados iban a ser parecidos,
pero me di cuenta de que depende de la propina elegida.

¿Qué imprime?
Sin propina: 20000
10%: 22000
Fija: 21500

¿Qué es el contexto y cuáles son las estrategias?
Cuenta es el contexto porque usa las propinas.
Las estrategias son SinPropina, Propina10 y PropinaFija,
porque cada una calcula una propina diferente.

¿Qué hubo que modificar de Cuenta para usar PropinaFija?
No hubo que cambiar Cuenta, porque ya estaba preparada
para usar distintas propinas. Se cumple el principio
Abierto/Cerrado.

Después de ejecutar:
Los resultados fueron los esperados. Cada estrategia
calculó el total de una forma distinta.
*/
