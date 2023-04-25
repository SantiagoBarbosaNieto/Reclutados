->start
== start ==
Pelado no se lo niego, usted es pilo pa andar en la calle. Supongo que estar todos estos días en el mercado le sirvieron para algo más que jugar al vendedor.
-> a2

== a2 ==
Parece que puedo asumir que lo que sabe es dado a la relación con su padre, un hombre que también sabe como manejar la situación.
*[¿Qué hace acá?]-> A3
*[¿De qué habla? #play false false Tracks/eerie/Hazy-Darkness-Short]-> B1


//  Rama B, detour corto mientras
//  se regresa a la A
== B1 ==
Hablo de su papá pelado.-> A5

//    Rama A donde se resuelve que hace el 
//    guerrillero hablando con Juan.
 == A3 ==
 Lo que hago aquí es buscarlo, me contaron que a esta hora más o menos es cuando pasas para regresar a tu casa. Aún que hoy fue más temprano de lo habitual.
 *[¿Qué quieres?]-> A4
 *[¿Por qué me buscas?]-> A4
 
 == A4 ==
 Te vengo a hacer una preguntita nada más. Algo muy sencillo que hasta tu me puedes ayudar a entender.
 *[¿Qué quiere? #play false false Tracks/eerie/Hazy-Darkness-Short]-> A5
 
 == A5 ==
 ¿Tu que sabes del trabajo de tu padre?
 *[... Pues se encarga de la finca con mi mamá]->A5b
 *[¿Cómo así?]-> A5b
 == A5b ==
 Pelado, no se haga el marica ahora. Usted sabe lo que él hace a sus espaldas. Cuénteme, que tanto sabe.
 *[...]-> A5c
 *[Se que él procesa droga]-> A6
 
 == A5c ==
 Chino, no tengo toda la noche, ¡Hable!
*[Se que él procesa droga]-> A6

== A6 ==
Ahhh, con que sabe donde procesa la procesa.
*[Sí]-> A6b
*[No no no, solo se que lo hace] -> A6b

== A6b ==
Ahhh ya veo, ¿y que más sabe?
*[Eso es todo] -> A7
*[¿Para qué me preguntas todo esto?] -> A6c

== A6c ==
Chino, yo soy quien pregunta.
*[...] -> A7

== A7 ==
Pero bueno, la cagada es que ya usted sabe, entonces más le vale a su papá no cagarla más. -> A8

== A8 ==
Pelado, venga, sígame que vamos a dar una vuelta.
*[No espere, ¿cómo así?] -> A9

== A9 ==
Chino no se haga pegar, venga.

->END