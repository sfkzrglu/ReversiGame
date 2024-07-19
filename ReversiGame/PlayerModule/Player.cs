using Reversi_game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.PlayerModule
{
    public abstract class Player : IPlayerMove
    {
        public Piece PlayerColor { get; private set; }
        public List<Position> PiecePositions { get; set; }

        public Player(Piece playerColor)
        {
            PlayerColor = playerColor;
            PiecePositions = new List<Position>();
        }

        public Player()
        {
            PiecePositions = new List<Position>();
        }

        public abstract Position MakeMove(Board board);
    }
}
