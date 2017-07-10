using BL;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace RPSApi.Controllers
{
    [RoutePrefix("rps")]
    public class SRPSController : ApiController
    {

        [Route("srpsgame")]
        [HttpPost]
        public HttpResponseMessage srps_game(JArray arrCompetidores)
        {
            try
            {
                List<Player> listPlayers = new List<Player>();
                //Faz um mapeamento do array para uma lista de jogadores
                foreach (JArray item in arrCompetidores)
                {
                    var pl = new Player(item[0].ToString());
                    pl.EfetuarJogada(item[1].ToString());
                    listPlayers.Add(pl);
                }

                return Request.CreateResponse(HttpStatusCode.OK, GameRPSBL.RpsGameWinner(listPlayers));

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("srpstournamentgame")]
        [HttpPost]
        public HttpResponseMessage srps_tournmentgame(JArray arrCompetidores)
        {
            try
            {
                List<Player> listPlayers = new List<Player>();

                foreach (JArray itemArrayFirst in arrCompetidores)
                {
                    foreach (JArray itemArraySecond in itemArrayFirst)
                    {
                        foreach (JArray itemArrayThird in itemArraySecond)
                        {
                            var pl = new Player(itemArrayThird[0].ToString());
                            pl.EfetuarJogada(itemArrayThird[1].ToString());
                            listPlayers.Add(pl);
                        }
                    }
                }

                Player play = GameRPSBL.RpsTournamentWinner(listPlayers);
                return Request.CreateResponse(HttpStatusCode.OK, play);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}