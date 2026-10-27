
using System;

namespace EjercicioB1
{
    public class Contador
    {
        private static Contador _instancia;
        private int _valor = 0;

        private Contador()
        {
            Console.WriteLine("Creando contador");
        }

        public static Contador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Contador();
                }

                return _instancia;
            }
        }

        public int Siguiente()
        {
            _valor++;
            return _valor;
        }
    }
}


/*
B1. Singleton: ¿cuántos contadores hay?

Salida que pensé antes de ejecutar:
Creando contador
1
2
3
4
5
True

¿Qué imprime?
Imprime esa salida pero hasta 3 porque se crea un contador y después
se va sumando uno cada vez que llamamos a Siguiente().

¿Cuántas veces aparece "Creando contador" y por qué?
Aparece una sola vez porque el contador se crea la primera
vez y después se sigue usando el mismo.

¿Por qué b.Siguiente() no devuelve 1?
Porque a y b apuntan al mismo contador. Entonces, cuando
a lo aumenta a 1, b lo aumenta a 2. 

Antes de ejecutar pensé que el contador podía seguir
aumentando y que no iba a terminar en 3.
 */



