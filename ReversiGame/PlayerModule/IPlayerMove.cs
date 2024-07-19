using Reversi_game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.PlayerModule
{
    internal interface IPlayerMove
    {
        public Position MakeMove(Board board);
    }
}
