-> start

== start ==
Buenas noches, joven, disculpe el grito. ¿De casualidad su papá o su mamá no están en casa?
*[¿Quién pregunta, disculpe? #stop #play true true Tracks/eerie/Hazy-Darkness_Looping] -> a2nombre
*[No tardan en regresar #stop #play true true Tracks/eerie/Hazy-Darkness_Looping] -> a2

== a2nombre ==
Eso no es importante, y créame cuando le digo que es mejor no volver a hacer preguntas. ¿Sus padres están en casa?
*[No tardan en regresar] -> a2

== a2 ==
Huh, con que se están escondiendo y mandan al hijo a dar la cara por ellos.
*[¿Perdón? #play true true Misc/mixkit-slow-heartbeat-494] -> a3
*[¿Ah, sí? #play true true Misc/mixkit-heartbeat-medium-speed-495] -> a3ataque

== a3ataque ==
#+I3
Uy, como que el pelado tiene huevas al menos. Eso es bueno de saber... -> a3ataque2

== a3ataque2 ==
Pero no se las dé de varón conmigo. Más bien hágame un favor y me avisa a su papito que pase a saludar y que tuvimos una tierna conversación los dos.
*[Yo le comentaré de su visita] -> afinal
*[...] -> afinal

== a3 ==
#-I1
Tranquilo, pelado, yo no vine por usted. Si su padre no está, avísele que vinieron a preguntar por él, él sabrá quién soy.
*[Yo le comentaré de su visita] -> afinal

== afinal ==
Gracias, pelado, espero que no nos tengamos que encontrar nuevamente.
->END
/*
== start ==
#TAG
DIALOGO EN PANTALLA
* [DIALOGO DE RESPUESTA] -> NOBRE_DE_SELECICON
->END
*/