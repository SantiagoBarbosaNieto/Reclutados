-> start

== start ==
Papito una vez más nos vemos aca en el mercado.
*[Así es doña Gloria, pues mis padres me piden que ayude y los entiendo] ->buenaActitud
*[Pues sí, pero cuando toca trabajar toca trabajar] ->malaActitud

==buenaActitud==
Todo un caballero, ¿pero sí estás asistiendo a la escuela me imagino?

*[Sí señora Gloria, mis padres tratan de dejarme estudiar en lo posible. #+S2]->FinBuenaActitud
*[Pues doña Gloria, a decir verdad eso es como un sorteo todas las mañanas para ver si me dejan ir o no.] ->malaActitud
==malaActitud==
Papito pero usted esta muy niño aún para tener que trabajar tan seguido. Yo pense que las anteriores veces que me lo encontre eran días que salías temprano de la escuala.

La verdad no me gusta mucho la idea de verte trabajando cada vez más, mucho menos cuando te veo tan aburrido en esto.
* [No se preocupe doña Gloria, yo creo que esto no durará mucho más #+S0]-> FinMalaActitud

==FinMalaActitud==
//NO SE VENDE NADA
#+S0
Ay papito, pues yo tambien espero que así sea. No me tome a mal, pero ya no quisiera verlo por acá, quiero verlo estudiando.
*[La entiendo doña Gloria, pero no se preocupe esto es temporal.]->END

==FinBuenaActitud==
//SE VENDEN 2 UNIDADES
#+S2
Ah bueno, así sí me gusta verlo trabajando y estudiando. No debe ser fácil pero igual de guerrero que su padre. Regaleme 2 unidades de su mejor producto.

*[Doña Gloria con mucho gusto]->END

