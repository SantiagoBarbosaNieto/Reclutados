-> start
== start ==
Hijo buenos días, ¿qué tal la noche dormiste bien?
*[Sí]-> A2
*[  ...  ]-> A2

== A2 ==
¿Hijo estás bien? Desde anoche te noto raro, pensé que era por lo cansado pero también por la mañana me extraña.
*[ ... ]-> A3
*[Es que anoche paso esto...]->L1


//  Todos los knots que comienzan con L
//  indican parte del loop. Estan para que el jugador
//  intente decirle algo al papá, pero se sienta
//  impotente al intentar hacerlo.
== L1 ==
¿Hijo estás bien? Desde anoche te noto raro, pensé que era por lo cansado pero también por la mañana me extraña.
*[ ... ]->A3
*["recuerdas que no debes de hablar de eso"]->L2

== L2 ==
¿Hijo estás bien? Desde anoche te noto raro, pensé que era por lo cansado pero también por la mañana me extraña.
*[ ... ]->A3
*["si no les digo nada, no va pasar nada"]-> L3

== L3 ==
¿Hijo estás bien? Desde anoche te noto raro, pensé que era por lo cansado pero también por la mañana me extraña.
*[ ... ]->A3

//  Continuacion de la historia principal
== A3 ==
...-> A4

== A4 ==
Está bien hijo, si quieres arréglate para que no se te vaya hacer tarde para ir al colegio. 
*[¿Hoy también voy a ir?]-> A5

== A5 ==
Claro hijo, ayer te dije que ya no te tienes que preocupar por eso.

->END