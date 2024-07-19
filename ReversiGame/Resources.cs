using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame
{
    public sealed class Resources
    {
        private static Image WhitePieceImg { get; set; }
        private static Image BlackPieceImg { get; set; }
        private static Image PossibleMoveImg { get; set; }

        private static Resources instance = null;

        private Resources()
        {
            WhitePieceImg = Image.FromFile("Textures/white.png");
            BlackPieceImg = Image.FromFile("Textures/black.png");
            PossibleMoveImg = Image.FromFile("Textures/possibleMove.png");
        }

        public static Resources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Resources();
                }
                return instance;
            }
        }

        public Image GetImage(Piece piece)
        {    
            switch (piece)
            {
                case Piece.Black:
                    return BlackPieceImg;
                case Piece.White:
                    return WhitePieceImg;
                case Piece.Possible:
                    return PossibleMoveImg;
            }
            return null;
        }

    }
}
