->start
== start ==
Mijo buenos días, ¿como estas?
*[Buenos días papá, bien gracias]-> a1saludo
*[Papá, regresaste #play true true Misc/mixkit-slow-heartbeat-494]-> 1regreso

/* 
Inicio de conversacion casual que
no se le pregunta al papá donde estuvo.
Hay unas opciones para cambiar a esa rama
*/
== a1saludo ==
Mijo me alegra saberlo, ¿que tal las ventas ayer eh?
*[Me fue bien padre, pues pude vender unos pares]-> a2saludo
*[Bien, ¿pero donde estabas estos días? #play true true Misc/mixkit-slow-heartbeat-494]-> 1regreso

== a2saludo ==
Ah me alegra mucho mijo, mira que te quería comentar que hoy no tendrás que ir a trabajar. Hoy regresaras al colegio.
*[¿Enserio?]-> a3saludo
*[¿Y eso pa, ya no necesitamos el dinero?]-> 1necesitarDinero

== a3saludo ==
Enserio mijo, dele al colegio tranquilo.
*[¡De una pa!]-> 1fin


/*
Inicio de la rama donde se le 
pregunta al papá donde estuvo.
No se puede regresar a la conversación casual
*/
== 1necesitarDinero ==
No mijo, pues por el momento no hay que preocuparse por eso.
*[¿Y donde estabas estos días? #play true true Misc/mixkit-slow-heartbeat-494] -> 1regreso
== 1regreso ==
Ay mijo, tenía que hacer unas vueltas por acá cerca. Disculpa si no me veías salir o llegar a casa. Siempre era o bien tarde o bien temprano.
*[Ayer me encontre con don Carlos]-> 2regreso

== 2regreso ==
... -> 3regreso

== 3regreso ==
Ah que bien que pasará a saludarte en el mercado, pero hoy no creo que lo veas, hoy irás al colegio mijo.
*[¿Enserio?]-> a3saludo
== 1fin ==
Jaja que animos los de este chino...
->END