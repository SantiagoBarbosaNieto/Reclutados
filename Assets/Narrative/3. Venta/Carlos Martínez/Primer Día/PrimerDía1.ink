== start ==
Don Jorge, mi buen amigo, ¿cuánto tiempo, eh? Ah, ya veo, su hijo lo está acompañando. -> a2

== a2 ==
Bueno joven, hoy es su día de suerte, ya que yo seré su primer cliente.
*[Supongo que esas son buenas noticias] -> a3
*[Esto será una buena práctica] -> a5

== a3 ==
Ja ja ja, y ya comenzamos mal. Juanito, si yo fuera cualquier otra persona ahora mismo podría irme sin comprar nada y solamente hubieses perdido tiempo.
*[Disculpa, no quería que eso sonara mal] -> a4
*[Perdón, creo que mi chiste se pasó un poco] -> a4

== a3b==
#-I1
Juan, no acabamos de hablar sobre esto? Vamos que yo se que lo lograrás. ->a5

== a4 ==
No te preocupes, te conozco desde que eras chiquito Juan. Ahora, intentemos de nuevo. -> a5
== a5 ==
Bueno joven, hoy es su día de suerte, ya que yo seré su primer cliente.
*[Supongo que esas son buenas noticias] -> a3b
*[Esto será una buena práctica] -> a6

== a6 ==
Eso, trata siempre de mostrarle interes al cliente y así él tambien te lo mostrará a ti. De igual manera, trata de no ser repetitivo con él cliente o si no este puede perder interes en tí. 
*[Ok, creo que estoy entendiendo esto] -> a7
*[Entiendo, pero aún no he hecho nada para vender] -> a8

== a7 ==
Eso muy bien, y cuanto más hables con un cliente más podrás saber sobre esa persona para el futuro y quien sabe, puede que con solo pasar un rato agradable este decida comprar algo. 
*[¡Don Carlos muchas gracias!]->a9
== a8 ==
Entiendo Juan, pero creeme cuando te digo que a veces nada más con mantener una buena conversación es suficiente para que un cliente decida comprarte algo. 
*[¡Don Carlos muchas gracias!]->a9

== a9 ==
#+S2
Mijito un gusto, y pues nada vendame 2 unidades para ver que tal. Si lo que me trajo es bueno, puede que regrese con más frecuencia.

*[¡A la orden don Carlos, y claro que sí, es de lo mejor!]->END

/*
== start ==
#TAG
DIALOGO EN PANTALLA
* [DIALOGO DE RESPUESTA] -> NOBRE_DE_SELECICON
->END
*/