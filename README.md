# rps
Jogo de pedra papel e tesoura

Para o jogo de pedra papel e tesoura, uma API(RPSApi) forneçe dois serviços:
1: srpsgame: Recebe uma lista com dois jogadores e verifica qual o vencedor.
2: srpstournamentgame: Recebe uma lista com vários jogadores para um torneio, processando as jogadas e retornando o vencedor.

#Tecnologias

.NET Framework > 4.5
c# 6.0
Web API 2
Visual Studio 2015 Update 3.

#Como rodar o projeto

Para rodar o projeto, deve-se usar o Visual Studio 2015 Update 3.
Coloque o projeto RPSApi como StartUp Project, então basta executar o Visual Studio.
A API irá rodar no endereço: http://localhost:56157/
A chamada aos serviços se dão colocando o nome da API mais o serviço, segue dos dois exemplos:

http://localhost:56157/rps/srpsgame


http://localhost:56157/rps/srpstournamentgame



