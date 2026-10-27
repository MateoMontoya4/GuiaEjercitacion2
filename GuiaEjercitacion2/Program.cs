using GuiaEjercitacion2.EjercicioF;

namespace GuiaEjercitacion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Playa playa = new Playa(10); // creamos la playa con capacidad para 10 autos

            PantallaLugares pantalla = new PantallaLugares(); // creamos los observadores
            CajaObserver caja = new CajaObserver();
            AlertaOcupacionObserver alerta = new AlertaOcupacionObserver();
            BitacoraObserver bitacora = new BitacoraObserver();

            // conectamos los observadores con la playa
            playa.Suscribir(pantalla);
            playa.Suscribir(caja);
            playa.Suscribir(alerta);
            playa.Suscribir(bitacora);

            Console.WriteLine("----- PLAYA PLAZA COLON ----");

            // algunos autos entran
            playa.Ingresar("AB123CD", "HORA");
            playa.Ingresar("AC456EF", "ESTADIA");
            playa.Ingresar("AD789GH", "NOCHE");
            playa.Ingresar("AE111JK", "HORA");
            playa.Ingresar("AF222LM", "HORA");
            playa.Ingresar("AG333NP", "HORA");
            playa.Ingresar("AH444QR", "HORA");
            playa.Ingresar("AJ555ST", "HORA");


            // salen los autos y se calcula el importe
            playa.Egresar("AB123CD", 150);
            playa.Egresar("AC456EF", 900);
            playa.Egresar("AD789GH", 60);

            // dejamos de mostrar los lugares libres
            playa.Desuscribir(pantalla);

            Console.WriteLine();
            Console.WriteLine("--------- PRUEBA DE TARIFA INVALIDA ---------");

            try
            {
                playa.Ingresar("AK666UV", "SEMANAL");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // mostramos todos los movimientos registrados
            Console.WriteLine();
            Bitacora.Instancia.MostrarTodo();

            
            Console.ReadKey();



            //ejecutar ejercicios b,c,d = ejemplo: EjercicioC2.Demo.Ejecutar();





        }
    }
}
