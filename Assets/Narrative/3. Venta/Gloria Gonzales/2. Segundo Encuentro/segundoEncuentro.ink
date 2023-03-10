-> start

== start ==
Papito que pena con usted, ayer yo toda grosera no me presente. 

* [No se preocupe señora, yo tambien grosero no le pregunté] -> a1

==a1==
Tan lindo, mi nombre es doña Gloria, pero me puedes llamar Gloria o Florecita que asi me decían mis amigas.

* [Me gusta Florecita] -> a2Florecita
* [Me gusta Gloria] -> a2Gloria

== a2Florecita ==
Me alegra papito, y hoy que tiene mijo para ver de que me antojo.

* [Lo mismo de siempre doña] -> a3
* [Mas de lo mejor florecita] -> a4Perfecto

== a2Gloria ==
Me alegra papito, y hoy que tiene mijo para ver de que me antojo.

* [Lo mismo de siempre doña] -> a3
* [Mas de lo mejor doña Gloria] -> a4Perfecto
== a3 ==
Papito me acabo de presentar, cualquiera de los dos nombres que le di me gustan pero uselos.
* [Disculpe doña Gloria, la costumbre] -> a4Disculpa

== a4Disculpa ==
//ACA SE LOGRA VENDER 2 UNIDADES DE LO QUE SEA
Esta bien papito, regaleme 2 unidades si es tan amable
* [A la orden señora Gloria] -> END

== a4Perfecto ==
// ACA SE LOGRA VENDER 5 UNIDADES DE LO QUE SEA
Claro que lo es, usted ya dentro de poco será todo un hombre y me alegra ver que será uno honesto y trabajador. Vendame 5 unidades.

* [Con mucho gusto] -> a5

==a5==
Gracias papito, si mañana me lo encuentro vuelvo y le compro.
*[Usted es muy amable doña Gloria]->END

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