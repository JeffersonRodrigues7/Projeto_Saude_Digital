INCLUDE ../globals.ink

VAR NPC_NAME = "Rogério"

{NPC_NAME}: ALGUÉM CHEGOU, FINALMENTE!
{NPC_NAME}: Digo...
{NPC_NAME}: Olá!? Quem é?
{PLAYER_ACTOR}: Oi professor {format_name(NPC_NAME)}, aqui é o {format_name(player_name)}.
{NPC_NAME}: Oh sim! {format_name(player_name)}! O que você faz aqui?
{PLAYER_ACTOR}: Bom... eu estava conversando com a professora {format_name(professor_name)}, e ela parecia estar com bastante fome.
{PLAYER_ACTOR}: Aparentemente você deveria ter levado algo para ela comer.
{PLAYER_ACTOR}: Como ela não podia sair da escola eu decidi passar aqui para levar pra ela, se não tiver problema.

{NPC_NAME}: Ah sim! Então...
{NPC_NAME}: Como eu posso explicar isso...
{NPC_NAME}: Bom {format_name(player_name)}, é uma situação um pouco embaraçosa, mas eu meio que estou preso dentro de casa no momento. Se não fosse isso eu já teria levado o almoço dela faz tempo.
{PLAYER_ACTOR}: Preso dentro de casa???
{NPC_NAME}: Então... como eu disse, é um pouco embaraçoso.
{NPC_NAME}: Eu estava testando uma das minhas invenções. É basicamente uma tranca automática.
{NPC_NAME}: Ela funciona bem na maior parte das vezes, mas ela anda travando de tempos em tempos.
{NPC_NAME}: Isso não costuma ser uma problema, já que é possível destravar ela usando a chave de casa.
{NPC_NAME}: O problema é que a tranca automática resolveu travar, e eu não encontro a chave de casa em lugar nenhum!

{PLAYER_ACTOR}: Okay! Isso realmente parece um problema!

{NPC_NAME}: Acho que eu deixei cair no parque, quando estava fazendo minha caminhada hoje pela manhã, mas é impossível eu ir buscar ela estando preso aqui dentro, como você pode ver.
{NPC_NAME}: Eu sei que não deveria te pedir isso, mas eu estou em uma situação um pouco desesperada como você pode ver.
{NPC_NAME}: {format_name(player_name)}, você poderia dar uma passada no parque e ver se eu deixei a chave cair lá?

{PLAYER_ACTOR}: Claro que sim, professor! O parque é bem próximo daqui, não vai ser problema nenhum.
{PLAYER_ACTOR}: Além disso, estou mesmo precisando me exercitar.
{PLAYER_ACTOR}: Você sempre faz caminhada? é verdade que a realização de exercícios físicos pode ajudar na diminuição de estresse e ansiedade?

{NPC_NAME}: É sim {format_name(player_name)}, inclusive me ajuda muito com as minhas invenções, sempre tenho ideias novas quando saio para caminhar!!

{PLAYER_ACTOR}: Que legal!!
{PLAYER_ACTOR}: Me parece uma boa ideia fazer isso todas as manhãs... provavelmente irá me ajudar também.

{NPC_NAME}: Espero te encontrar enquanto eu estiver fazendo minhas caminhadas.


{PLAYER_ACTOR}: Bom, acho que vou precisar de ajuda para procurar a chave, o parque é grande...
{PLAYER_ACTOR}: Vou convidar alguns amigos para esta procura!
{PLAYER_ACTOR}: Assim que tiver novidades volto aqui para te informar.

{NPC_NAME}: Muito obrigado {format_name(player_name)}!


~ is_searching_for_key = true