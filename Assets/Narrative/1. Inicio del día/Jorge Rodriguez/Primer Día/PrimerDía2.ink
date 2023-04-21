-> start

== start ==
Juanito, mi hijo, ¡buenos días!
*[Buenos días, padre #dp ataque greeting 2] -> a2

== a2 ==
¿Qué tal, cómo dormiste?
*[Bien, padre, gracias] -> a3

== a3 ==
Me alegra, papito... Ven, siéntate un momento que tengo algo que decirte.
*[...] -> a4

== a4 ==
Hijo, lo que sucede es que hoy voy a tener que pedirte un favor. ¿Me podrías acompañar hoy al mercado del pueblo para realizar unas ventas? Necesito que me ayudes en eso mientras me encargo de otros oficios.
*[Pero padre, ¿y la escuela?] -> a41
*[Claro que sí, padre] -> a5

== a41 ==
Por hoy no irías, pero no te preocupes que esto no será algo de todos los días.
*[Claro que sí, padre, entiendo] -> a5

== a5 ==
Dale, papito, entonces despídete de tu madre y vamos.
-> END

/*
== start ==
#TAG
DIALOGO EN PANTALLA
* [DIALOGO DE RESPUESTA] -> NOBRE_DE_SELECICON
->END
*/
