Pelao aquí estaba vealo igualito al papá todo escondido. 

*[Al ver la cara de pedro, la rabia te consume y te lanzas a atacar sin pensarlo #play false false Misc/mixkit-arrow-whoosh-1491 #play false false Misc/mixkit-heartbeat-medium-speed-495] -> piso

== piso ==
El guerrillero te empuja al piso, pero te vuelves a parar y otra vez tratas de pegarle con lo que sea

*[Asesino! Usted mató a mi papá maldito asesino!] -> empuja

==empuja==
El guerrillero se pone bravo y te empuja otra vez con más fuerza
*[...] -> R1

==R1==
Vea pelado marica, está muy equivocado. Yo no fui quien mató a su papá. Era un bruto que la cagaba mucho, pero era parte del grupo yo no tendría por qué matarlo.

*[Confundido, te quedas perplejo en el piso] -> R2

==R2==
Mentira! Yo sé que fue usted! si no quien más, usted lo estaba buscando el otro día y me estaba persiguiendo a mi también seguramente para matarlo.

*[...] -> R3

==R3==
Pelado a su papa lo mataron los militares. Como el bruto comenzó a divulgar lo que no debía, se dieron cuenta que estaba trabajando con nosotros y lo mataron. Vea chino, esos hijueputas nos matan sin pensarlo. Así le pasó a su papá. 
*[La rabia no se va.] -> rabia
==rabia==
Se forma en el pecho como una bola hirviendo un sentimiento que ningún niño debería tener que sentir nunca, un profundo odio incontrolable.

*[Quién mató a mi papá!?] -> choice

==choice==
Pelado... vea si usted quiere vengarse por su papá, yo le tengo la forma. Chino yo se que usté es pilo y aprende rápido. Venga conmigo y verá que le va bien.
 
* [Está bien, me quiero unir al grupo #dp unirse greeting 8]-> unirse
* [Yo no quiero ser guerrillero #dp rechazar greeting 8] -> rechazar

== unirse ==
- Listo pues. Camine a ver que el campamento está lejos. 
    # Aca debe haber un condicional que cambie al final de reclutado
*[Ahora eres un guerrillero...]  -> END 

== rechazar ==
- Pelado marica, todas las soluciones le llegan así de fácil y no aprovecha la oportunidad. Le aseguro chino que se va a arrepentir.. 
*[El guerrillero se va...] -> END

    