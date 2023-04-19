->start
== start ==
Ja Ja Ja, pero si no es Juanito, mi casi sobrino.
*[¿Don Carlos, es usted? #play false false Misc/Man-Laughing-Sound]->saludoAcarlos
*[¿Doña Ana, es usted? #play false false Misc/Man-Laughing-Sound]->saludoAana

== saludoAcarlos ==
¡Pues claro! Déjame adivinar, ¿mi risa fue lo que me delató? No importa, sabía que estarías por acá, siempre regresas a casa a esta hora.
*[¿Cómo lo sabe?]->a3

== saludoAana ==
Ja Ja Ja, o tengo la voz delgada o Doña Ana tiene la voz gruesa, pero no pensaría que nos confundieras. No importa, sabía que estarías por acá, siempre regresas a casa a esta hora.
*[¿Cómo lo sabe?]->a3

== a3 ==
Pues, más o menos a esta hora regresaste con tu papá la primera vez que te pidieron ayuda vendiendo y me contó un pajarito que no has visto mucho a tu padre estos días, seguro a tu madre sí.
*[No entiendo qué sucede]->explicacion
*[¿No será que ayer me estabas mirando desde lejos?]->verDeLejos

== verDeLejos ==
¿Cómo así, Juanito, de qué hablas?
*[Pues ayer sentía que alguien me estaba observando de regreso a mi casa]->verDeLejos2

== verDeLejos2 ==
(Don Carlos no responde, nada más se queda mirándote tras escuchar lo que dijiste.)
->revelacion

== explicacion ==
No te preocupes, mijo, te cuento. ->revelacion

== revelacion ==
Mira, Juanito, lo que sucede es que tu padre debe cumplir unos deberes, por así decirlo. Él te está protegiendo a ti y a tu madre.
*[¿Pero dónde está?]->revelacion2

== revelacion2 ==
Tu padre está un poco lejos, a un par de horas caminando entre las matas.
*[¿Y qué hace?]->revelacion3

== revelacion3 ==
Tu padre se encuentra ahora en un cultivo de cocaína, lo que cosechan en su casa nunca fue suficiente para poder mantenerlos a tu madre y a ti.

*[¿Mi papá es un narcotraficante?]->explicacionNarco
*[¿Pero entonces, para qué me manda a vender en el mercado del pueblo?]->explicacionTrabajar

== explicacionNarco ==
No, no es así de simple. Es que hay un grupo que controla el movimiento por acá. Tu papá hace lo que hace para asegurarse de que no le pase nada a tu madre y a ti.
*[¿Pero entonces, para qué me manda a vender en el mercado del pueblo?]->explicacionTrabajarOp2

== explicacionTrabajar ==
Mucho del dinero que tu padre "gana" con la cosecha de cocaína es una "cuota" que debe pagar. Pero parece que algo salió mal y ya no podrá cumplir esa cuota.
->explicacionTrabajar2

== explicacionTrabajar2 ==
Como él no puede estar en dos lugares a la vez, se vio forzado a mandarte a trabajar. Además, debe ser más seguro que la escuela.
*[¿Entonces papá es un narcotraficante?] -> expliacionNarcoOp2

== expliacionNarcoOp2 ==
No, no es mucho más complicado. Es que hay un grupo que controla el movimiento por acá. Tu papá hace lo que hace para asegurarse de que no les pase nada a tu madre y a ti.
-> final

== explicacionTrabajarOp2 ==
Mucho del dinero que tu padre "gana" con la cosecha de cocaína es una "cuota" que debe pagar. Pero parece que algo salió mal, entonces ya no podrá cumplir esa cuota.
->explicacionTrabajar2

== explicacionTrabajar2Op2 ==
Como él no puede estar en dos lugares a la vez, se vio forzado a mandarte a trabajar. Además, debe ser más seguro que la escuela.
-> final

== final ==
Mira Juanito, ya está tarde, es mejor que regreses a casa. Solo quiero que sepas que tu padre fue quien me pidió que te contara lo que sucede. -> final2

== final2 ==
Si tu padre te considera lo suficientemente grande para trabajar, seguro también te considera lo suficientemente grande para entender la situación. Me tengo que ir pero me alegra saber que estás bien.
->END











