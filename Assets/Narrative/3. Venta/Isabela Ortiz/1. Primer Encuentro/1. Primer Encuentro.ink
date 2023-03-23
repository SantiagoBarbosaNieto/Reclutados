-> start
== start ==
Disculpa, ¿de casualidad no eres el hijo de la señora María?
*[Si señora, ese soy yo] -> a1

== a1 ==
Ah mucho gusto, me llamo Isabela.
*[Isabela, mucho gusto, yo soy Juan] -> a2

== a2 ==
Si me había contado una amiga que ahora hay un niño en el mercado vendiendo lo de su finca. No estaba para nada contenta de verlo.
*[Seguramente se refiere a la señorita Teresa] -> a3

== a3 ==
Sí sí, espero que no te haya dejado aburrido ni nada por estar acá y no en la escuela.

*[Pues Tere no se veía muy contenta de verme trabajando, pero lo hago por ayudar a mis padres.] -> a4

== a4 ==
Me extraña, sobre todo porque lo que he escuchado de mi hermanastro, es que el señor Rodriguez siempre la ha ido lo suficientemente bien como para que su hijo se vea en la necesidad de trabajar.
*[Si le digo la verdad, no estoy muy seguro tampoco la razón. #+I3] -> a5
== a5 ==
Ya veo... Y cuenteme Juan, ¿como le ha ido el día de hoy?
*[Sabe, no me puedo quejar mucho, a parte de no ir a la escuela bien] -> a6

== a6 ==
Ja ja, me refería a las ventas, pero me alegra saber que aun tienes la escuela en mente. Se lo comentare a Tere a ver si con eso ya se preocupa menos. Sabes como su debilidad son los niños.

*[Gracias, Isabela] -> a7

== a7 ==
Me puedes decir Isa nada más si así quieres. De paso aprovecho y te ayudo un poco. Dame un par de unidades.
*[Isa muchas gracias, aqui tienes #pref money 20] -> a8

== a8 ==
#+S2
Juan te deseo lo mejor.
->END