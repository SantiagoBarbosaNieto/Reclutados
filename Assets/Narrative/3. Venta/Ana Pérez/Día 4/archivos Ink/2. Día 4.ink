->start
== start ==
Buenos días chiquillo.
*[Buenos días, doña Ana]->a2
*[¡Doña Ana, qué alegría verla por aquí!]->a2

==a2==
Igualmente, chiquillo. No se lo tome a mal, pero no sé si me alegra o no volver a verlo por acá.
*[Yo tampoco sé]->a31
*[No se preocupe doña Ana, yo estoy bien]->a32

==a31==
¿Por qué lo dice?
*[No sé qué está sucediendo, solo sé que algo pasa, pero mi madre no me cuenta y no veo a papá desde hace un tiempo]->a311

==a311==
Ay, chiquillo. Es que justo de eso quería preguntarle->a3

==a32==
Me alegra, chiquillo. Lo siento por meterme en esto, pero es que quería preguntarle algo sobre su madre->a3

==a3==
La verdad, hace un rato pasé a saludarla, pero...->a4

==a4==
Lo siento, chiquillo. No sé qué me pasa. No debería preocuparle a usted por tales cosas.
*[¿Cómo así, doña Ana? ¿Usted también sabe algo?]->a5

==a5==
Chiqui, ¿qué es lo que vende hoy?
*[Hoy vendemos papas]->a6
*[Doña Ana, ¿qué iba a decir?]->a6

== a6 ==
¡Ah, son papas! Vea pues, ¿a cuánto me deja el bulto?
*[Doña Ana, a 5 #pref money 5]-> a7
*[Doña Ana, a 7 #pref money 7]-> a7

== a7 ==
Listo, chiqui. Muchas gracias. Siga dándole duro para conseguir más plata.
->END