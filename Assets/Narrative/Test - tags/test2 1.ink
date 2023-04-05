-> start

== start ==
A long time ago

+ [in a galaxy far far away #stop #play false true Testing/starwars] -> stop
+ [uh there was a man? #stop #play false true Testing/men] -> stop
+ [leave] -> END

== stop ==
Stop the song?
+ [yes #stop] -> oneshots
+ [no] -> start
+ [leave] -> END

== oneshots ==
Play oneshots
+ [oh nyo #play true true Tracks/eerie/Horrible-Realization] -> oneshots
+ [hello #play true false Animals/Morning-Birds_Looping_01] -> oneshots
+ [go back to start] -> start 