-> start

== start ==
Papito que pena con usted, ayer yo toda grosera no me presenté.

* [No se preocupe señora, yo también grosero no le pregunté] -> a1

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
* [Mas de lo mejor doña Gloria # reg compra 5] -> a4Perfecto
== a3 ==
Papito me acabo de presentar, cualquiera de los dos nombres que le di me gustan pero uselos.
* [Disculpe doña Gloria, la costumbre # reg compra 2] -> a4Disculpa

== a4Disculpa ==
//ACA SE LOGRA VENDER 2 UNIDADES DE LO QUE SEA
#+S2
Esta bien papito, regaleme 2 unidades si es tan amable
* [A la orden señora Gloria] -> END

== a4Perfecto ==
// ACA SE LOGRA VENDER 5 UNIDADES DE LO QUE SEA
Claro que lo es, usted ya dentro de poco será todo un hombre y me alegra ver que será uno honesto y trabajador. Vendame 5 unidades.

* [Con mucho gusto] -> a5

==a5==
Gracias papito, si mañana me lo encuentro vuelvo y le compro.
*[Usted es muy amable doña Gloria]->END
