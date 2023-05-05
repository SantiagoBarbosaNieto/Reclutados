-> start

== start ==
Papito una vez más nos vemos acá en el mercado.
*[Así es doña Gloria, pues mis padres me piden que ayude y los entiendo] ->buenaActitud
*[Pues sí, pero cuando toca trabajar, toca trabajar] ->malaActitud

==buenaActitud==
Todo un caballero, ¿pero sí estás asistiendo a la escuela me imagino?

*[Sí señora Gloria, mis padres tratan de dejarme estudiar en lo posible. # reg compra 2]->FinBuenaActitud
*[Pues doña Gloria, a decir verdad eso es como un sorteo todas las mañanas para ver si me dejan ir o no.] ->malaActitud
==malaActitud==
Papito pero usted está muy niño aún para tener que trabajar tan seguido. Yo pensé que las anteriores veces que me lo encontré eran días que salías temprano del colegio.

La verdad no me gusta mucho la idea de verte trabajando cada vez más, mucho menos cuando te veo tan aburrido en esto.
* [No se preocupe doña Gloria, yo creo que esto no durará mucho más # reg compra 0]-> FinMalaActitud

==FinMalaActitud==
//NO SE VENDE NADA
Ay papito, pues yo también espero que así sea. No me tome a mal, pero ya no quisiera verlo por acá, quiero verlo estudiando.
*[La entiendo doña Gloria, pero no se preocupe esto es temporal.]->END

==FinBuenaActitud==
//SE VENDEN 2 UNIDADES
Ah bueno, así sí me gusta verlo trabajando y estudiando. No debe ser fácil pero igual de guerrero que su padre. Regáleme 2 unidades de su mejor producto.

*[Doña Gloria con mucho gusto]->END

