-> start
== start ==
Hijo buenos días, ¿que tal la noche dormiste bien?
*[Sí]-> A2
*[  ...  ]-> A2

== A2 ==
¿Hijo estás bien? Desde anoche te noto raro, pense que era por lo cansado pero tambíen por la mañana me extraña.
*[ ... ]-> A3
*[Es que anoche paso esto...]->L1


//  Todos los knots que comienzan con L
//  indican parte del loop. Estan para que el jugador
//  intente decirle algo al papá, pero se sienta
//  impotente al intentar hacerlo.
== L1 ==
¿Hijo estás bien? Desde anoche te noto raro, pense que era por lo cansado pero tambíen por la mañana me extraña.
*[ ... ]->A3
*["recuerdas que no debes de hablar de eso"]->L2

== L2 ==
¿Hijo estás bien? Desde anoche te noto raro, pense que era por lo cansado pero tambíen por la mañana me extraña.
*[ ... ]->A3
*["si no les digo nada, no va succeder nada"]-> L3

== L3 ==
¿Hijo estás bien? Desde anoche te noto raro, pense que era por lo cansado pero tambíen por la mañana me extraña.
*[ ... ]->A3

//  Continuacion de la historia principal
== A3 ==
...-> A4

== A4 ==
Esta bien hijo, si quieres arreglate para que no se te vaya hacer tarde ir al colegio. 
*[¿Hoy tambien voy a ir?]-> A5

== A5 ==
Obvio hijo, ayer te dije que ya no te tienes que preocupar por eso.

->END