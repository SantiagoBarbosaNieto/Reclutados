->start
== start==
Papito, le contaría, pero yo no me siento capaz. Más bien, esperemos a que tu padre regrese y que él te lo cuente.
*[¿Cómo así madre, papá otra vez no ha regresado?] -> a2

== a2 ==
Sí, mijito, tu papá ha estado ocupado cuidándonos.
*[Uy, ¿cómo así madre? Ahora sí me tienes preocupado] -> a3

== a3 ==
Lo siento, hijo, pero yo no creo que sea la mejor para contártelo.
*[Pero madre, ya empezaste. Ahora es mejor que me lo cuentes todo] -> a4feo
*[Está bien madre, no entiendo qué pasa, pero vale] -> a4bien

== a4feo==
Hijo, ya te dije, espera a que tu padre regrese y que él te lo cuente.
*[¿Y qué sucede si no regresa? Como me estás contando, parece que las cosas pueden salir mal] -> a5feo

== a5feo ==
¡No digas tonterías! Las palabras tienen poder.
*[Ok, ok, perdón ma] -> a4bien

== a4bien ==
Gracias, hijo, y hoy también te pediremos que vayas al pueblo. Por la tarde, le diré a tu padre que vaya a buscarte si pasa algo.
*[Listo, madre] -> END
