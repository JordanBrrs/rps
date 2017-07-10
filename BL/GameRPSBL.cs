using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class GameRPSBL
    {
        /// <summary>
        /// Recebe uma lista com 2 jogadores para verificar qual o vencedor
        /// </summary>
        /// <param name="Players">Lista com 2 Players</param>
        /// <returns></returns>
        public static Player RpsGameWinner(List<Player> Players)
        {
            if (Players.Count != 2)
                throw new Exception("WrongNumberOfPlayersError");

            var moveWrong = Players.Any(p => p.Move != "R" && p.Move != "S" && p.Move != "P");
            if (moveWrong)
                throw new Exception("NoSuchStrategyError");

            var p1 = Players[0];
            var p2 = Players[1];
            /*
             Aplicação das regras do Jogo
             R > S: Pedra esmaga tesoura
             S > P: Tesoura corta papel
             P > R: Papel cobre pedra.
             */
            if (p1.Move == p2.Move)
                return p1;
            else if (p1.Move == "R" && p2.Move == "S")
                return p1;
            else if (p1.Move == "S" && p2.Move == "P")
                return p1;
            else if (p1.Move == "P" && p2.Move == "R")
                return p1;
            else
                return p2;
        }
        /// <summary>
        /// Recebe uma lista de jogadores para disputar um torneio
        /// </summary>
        /// <param name="Players">Lista de jogadore</param>
        /// <returns></returns>
        public static Player RpsTournamentWinner(List<Player> Players)
        {
            List<Player> listplayersTurn = new List<Player>();
            List<Player> listWinners = new List<Player>();

            foreach (Player player in Players)
            {
                listplayersTurn.Add(player);

                if (listplayersTurn.Count == 2)
                {
                    listWinners.Add(RpsGameWinner(listplayersTurn));
                    listplayersTurn.Clear();
                }

            }

            if (listWinners.Count > 1)
            {
                return RpsTournamentWinner(listWinners);
            }

            return listWinners.FirstOrDefault();
        }
    }
}
