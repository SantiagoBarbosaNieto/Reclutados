== start ==
Buenas noches joven, disculpe el grito. De casualidad su papá o su mamá no estan en casa? 
*[¿Quien pregunta disculpe?]->a2nombre
*[No demoran en regresar]->a2

== a2nombre ==
Eso no es importante y creame cuando le digo que es mejor no volver a hacer preguntas. Sus padres estan en cas?
*[No demoran en regresar]->a2

== a2 ==
Huh, con que se estan escondiendo y mandan al hijo a dar la cara por ellos.
*[¿Perdon?]->a3
*[¿Ah si?]->a3ataque

== a3ataque ==
#+I3
Uy como que el pelado tiene huevas al menos. Eso es bueno de saber... ->a3ataque2

== a3ataque2 ==
Pero no se las de de varón conmigo. Mas bien hagame un favor y me le avisa a su papito que pase a saludar y que tuvimos una tierna conversación los dos.

*[Yo le comentare de su visita]->afinal
*[   ...   ] ->afinal
== a3 ==
#-I1
Tranquilo pelado, yo no vine por usted. Si su padre no esta avisale que vinieron a preguntar por él, él sabra quien soy.
*[Yo le comentare de su visita]->afinal

== afinal ==
Gracias pelado, espero que no nos tengamos que encontrar nuevamente.
->END
/*
== start ==
#TAG
DIALOGO EN PANTALLA
* [DIALOGO DE RESPUESTA] -> NOBRE_DE_SELECICON
->END
*/