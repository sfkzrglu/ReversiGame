using Reversi_game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.PlayerModule
{
    internal class ComputerPlayer : Player, IPlayerMove
    {
        public ComputerPlayer(Piece playerColor) : base(playerColor)
        {

        }

        public override Position MakeMove(Board board)
        {
            List<Position> pm = board.GetPossibleMoves();
            if (pm.Count > 0)
            {
                int r = new Random().Next(pm.Count);
                return pm[r];
            }
            return null;
        }
    }
}
