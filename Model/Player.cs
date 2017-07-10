using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public string Name { get; private set; }
        public string Move { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public void EfetuarJogada(string move)
        {
            Move = move;
        }
    }
}
