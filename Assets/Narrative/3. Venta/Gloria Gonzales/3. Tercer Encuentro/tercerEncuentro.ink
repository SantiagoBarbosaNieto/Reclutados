-> start

== start ==
Papito una vez más nos vemos aca en el mercado.
*[Así es doña Gloria, pues mis padres me piden que ayude y los entiendo] ->buenaActitud
*[Pues sí, pero cuando toca trabajar toca trabajar] ->malaActitud

==buenaActitud==
Todo un caballero, ¿pero sí estás asistiendo a la escuela me imagino?

*[Sí señora Gloria, mis padres tratan de dejarme estudiar en lo posible.]->FinBuenaActitud
*[Pues doña Gloria, a decir verdad eso es como un sorteo todas las mañanas para ver si me dejan ir o no.] ->malaActitud
==malaActitud==
Papito pero usted esta muy niño aún para tener que trabajar tan seguido. Yo pense que las anteriores veces que me lo encontre eran días que salías temprano de la escuala.

La verdad no me gusta mucho la idea de verte trabajando cada vez más, mucho menos cuando te veo tan aburrido en esto.
* [No se preocupe doña Gloria, yo creo que esto no durará mucho más]-> FinMalaActitud

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

/*
== start ==
Ay papito, yo lo vi ayer ayudando a su padre, muy bonito ya se parece a todo un hombre. ¿Cuentame que está vendiendo?

* [Lo que ve señora] -> a2
* [Tan querida, me da hasta pena venderle. Por mi se lo regalaba] -> a3
== a2 ==
Joven así no se le habla a una señora de mi edad por favor. Su madre se molestaría de saber como le habla a la gente.

* [Lo siento doña, la verdad no se que me pasa.] -> b1

== a3 ==
Ay tan caballero, pero acá el trabajo y el esfuerzo se paga. Uno no puede vivir de la buena fe de los demás. 

Regaleme 3 unidades, papito.

* [Claro que sí, a la orden y que dios me la bendiga] -> a4

== b1 ==
Papito tiene entienda que yo solo le deseo lo mejor, de pronto por eso puede que suene molesta pero no es el caso.
* [No se preocupe, por el contrarió, le agradezco.] -> a3
== a4 == 
Igualmente papito que tenga un buen día.

*[¡Igualmente señora!... Debo preguntarle el nombre la próxima vez.]->END
*/