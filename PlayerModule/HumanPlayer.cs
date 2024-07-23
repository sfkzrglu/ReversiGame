using Reversi_game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.PlayerModule
{
    internal class HumanPlayer : Player, IPlayerMove
    {
        public HumanPlayer(Piece playerColor) : base(playerColor)
        {

        }

        public override Position MakeMove(Board board)
        {
            Position lastClickedPosition = board.GetLastClickedPosition();
            if (lastClickedPosition.x>=0 && lastClickedPosition.y >= 0)
            {
                return lastClickedPosition;
            }
            return null;
        }
    }
}
