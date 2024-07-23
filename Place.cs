using Reversi_game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame
{
    public class Place : Button
    {
        public Piece Piece { get; private set; }
        public Position Position { get; set; }

        public Place() { Piece = Piece.None; }

        public void SetPlace(Piece piece)
        {
            switch (piece)
            {
                case Piece.None:
                    Image = null;
                    Piece = Piece.None;
                    break;
                case Piece.Black:
                    Image = Resources.Instance.GetImage(Piece.Black);
                    Piece = Piece.Black;
                    break;
                case Piece.White:
                    Image = Resources.Instance.GetImage(Piece.White);
                    Piece = Piece.White;
                    break;
                case Piece.Possible:
                    Image = Resources.Instance.GetImage(Piece.Possible);
                    Piece = Piece.Possible;
                    break;
            }
        }

    }
}
