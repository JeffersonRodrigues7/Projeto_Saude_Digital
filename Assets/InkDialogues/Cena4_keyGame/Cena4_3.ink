INCLUDE ../globals.ink

VAR NPC_NAME = "Rogério"

{PLAYER_ACTOR}: Professor! Consegui encontrar a chave!
{NPC_NAME}: Ótimo {player_name}! 
{NPC_NAME}: Você poderia abrir a porta para mim, por favor?
{PLAYER_ACTOR}: Claro que sim!

/* player abre a porta para o Professor */

{NPC_NAME}: Muito obrigado mesmo {player_name}! Nem sei como te agradecer!
{NPC_NAME}: Você disse que veio buscar algo para a {professor_name} comer, certo?
{PLAYER_ACTOR}: Isso mesmo. Ela parecia estar realmente com muita fome.
{NPC_NAME}: Pobre {professor_name}! Já era pra eu ter levado algo pra ela faz tempo.
{NPC_NAME}: Ainda bem que você me ajudou, senão ela só iria conseguir comer depois que voltasse pra cá.
{NPC_NAME}: Mas nem tudo é ruim! Eu acabei de assar uma fornada de cookies!
{NPC_NAME}: Eu não quero me gabar {player_name}, mas meus cookies são realmente muito bons.
{NPC_NAME}: Coloquei eles em um pote para você levar. Tem o suficiente pra {professor_name} e pra você também, então pode pegar alguns também.
{NPC_NAME}: Acho que depois de todo esse trabalho, você merece uma recompensa.

{NPC_NAME}: Entrega os cookies para {player_name}

{PLAYER_ACTOR}: Muito obrigado professor!
{PLAYER_ACTOR}: Bom... acho que vou indo entregar os cookies para a professora {professor_name} antes que ela morra de fome.

{NPC_NAME}: Ótimo {player_name}! Eu vou voltar para casa, pois preciso arrumar a bagunça que eu acabei deixando aqui.
{NPC_NAME}: E muito obrigado novamente {player_name}!

~ has_got_food = true

