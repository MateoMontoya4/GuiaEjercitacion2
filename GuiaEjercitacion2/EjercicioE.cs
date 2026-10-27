/*
E1
Patron: Strategy.

Lo usaria porque el envio cambia segun el vehiculo.
Si agregan el dron, se puede agregar otra forma
de calcular el precio.

E2
Patron: Observer.

Lo usaria porque cuando el pedido esta listo
se tienen que enterar la cocina, el mozo y la caja.
Despues se puede agregar WhatsApp tambien.

E3
Patron: Singleton.

Lo usaria porque todas las pantallas tienen que
tener la misma configuracion y no una distinta
cada una.

E4
Patron: Factory y Strategy.

Usaria Factory para crear el objeto segun el medio
de pago y Strategy para calcular el recargo
que corresponde en cada caso.

E5
Patron: Ninguno.

No usaria una factory porque el repositorio ya
se crea una vez y se pasa al controlador.
Seria una indirección gratuita porque agregaria
mas codigo sin necesidad.
*/