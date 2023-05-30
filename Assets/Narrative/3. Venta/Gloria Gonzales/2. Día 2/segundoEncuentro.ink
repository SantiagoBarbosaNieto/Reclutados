-> start

== start ==
-> a1 

==a1==
Tan lindo mijo trabajando duro, yo soy doña Gloria, pero me puedes llamar Gloria o Florecita que así me decían mis amigas.

* [Me gusta Florecita] -> a2Florecita
* [Me gusta Gloria] -> a2Gloria

== a2Florecita ==
Me alegra papito, y hoy qué tiene mijo para ver de que me antojo.

* [Lo mismo de siempre doña] -> a3
* [Más de lo mejor florecita] -> a4Perfecto

== a2Gloria ==
Me alegra papito, y hoy que tiene mijo para ver de que me antojo.

* [Lo mismo de siempre doña] -> a3
* [Más de lo mejor doña Gloria] -> a4Perfecto
== a3 ==
Papito me acabo de presentar, cualquiera de los dos nombres que le di me gustan pero úselos.
* [Disculpe doña Gloria, la costumbre] -> a4Disculpa

== a4Disculpa ==
//ACA SE LOGRA VENDER 2 UNIDADES DE LO QUE SEA
Está bien papito, no se preocupe
* [A la orden señora Gloria] -> END

== a4Perfecto ==
// ACA SE LOGRA VENDER 5 UNIDADES DE LO QUE SEA
Claro que lo es, usted ya dentro de poco será todo un hombre y me alegra ver que será uno honesto y trabajador. Más tarde paso y le compro alguito papito.

* [Con mucho gusto] -> a5

==a5==
Gracias papito, que le vaya bien
*[Usted es muy amable doña Gloria]->END
