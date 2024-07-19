using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReversiGame;
using ReversiGame.PlayerModule;

namespace Reversi_game
{
    public class Board
    {
        public Place[,] Places { get; private set; }
        private int PlaceSize = 100;
        private Position LastClickedPlacePosition { get; set; }
        private Position[] neighborPositions = new Position[8]
        {
            new Position(-1, 1),
            new Position(0, 1),
            new Position(1, 1),
            new Position(-1, 0),
            new Position(1, 0),
            new Position(-1, -1),
            new Position(0, -1),
            new Position(1, -1)
        };
        private List<Position> possibleMoves;

        public Board(Control.ControlCollection control)
        {
            Places = new Place[8, 8];
            LastClickedPlacePosition = new Position(-1, -1);
            possibleMoves = new List<Position>();

            InitPlaces(control);
        }

        private void InitPlaces(Control.ControlCollection control)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Place place = new Place();
                    place.Position = new Position(i, k);
                    place.Location = new Point(200 + i * PlaceSize, k * PlaceSize);
                    place.Size = new Size(PlaceSize, PlaceSize);
                    place.FlatStyle = FlatStyle.Flat;
                    place.FlatAppearance.BorderSize = 0;
                    place.Click += Place_Click;
                    place.BackgroundImageLayout = ImageLayout.Stretch;
                    //debug
                    place.Font = new Font("Microsoft Sans Serif", 20);
                    place.ForeColor = Color.Red;
                    place.Text = i + "," + k + "/" + (i + k * 8);

                    if (i % 2 == ((k % 2 == 0) ? 0 : 1))
                    {
                        place.BackColor = Color.Green;
                    }
                    else
                    {
                        place.BackColor = Color.DarkGreen;
                    }
                    Places[i, k] = place;
                    control.Add(place);
                }
            }

        }

        public bool IsValidMove(Position position)
        {
            if (Places[position.x, position.y].Piece == Piece.Possible)
            {
                return true;
            }
            return false;
        }

        public void InitPossibleMoves(Player currentPlayer, Player enemyPlayer)
        {
            possibleMoves = new List<Position>();

            foreach (var currentPlayerPiecePosition in currentPlayer.PiecePositions)
            {
                foreach (var direction in neighborPositions)
                {
                    int x = currentPlayerPiecePosition.x;
                    int y = currentPlayerPiecePosition.y;

                    x += direction.x;
                    y += direction.y;

                    bool foundEnemyPiece = false;

                    while (IsTargetPositionOnBoard(new Position(x, y)))
                    {
                        if (Places[x, y].Piece == enemyPlayer.PlayerColor)
                        {
                            foundEnemyPiece = true;
                            x += direction.x;
                            y += direction.y;
                        }
                        else if (foundEnemyPiece && Places[x, y].Piece == Piece.None)
                        {
                            Places[x,y].SetPlace(Piece.Possible);
                            possibleMoves.Add(new Position(x, y));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        public Player[] FlipPieces(Player currentPlayer, Player enemyPlayer,Position position)
        {
            switch (currentPlayer)
            {
                case ComputerPlayer computerPlayer:
                    LastClickedPlacePosition = position;
                    break;
            }

            if (Places[LastClickedPlacePosition.x, LastClickedPlacePosition.y].Piece == Piece.Possible)
            {
                foreach (var direction in neighborPositions)
                {
                    Position searchedEnemyPosition = LastClickedPlacePosition + direction;

                    if (IsTargetPositionOnBoard(searchedEnemyPosition) && Places[searchedEnemyPosition.x, searchedEnemyPosition.y].Piece == enemyPlayer.PlayerColor)
                    {
                        List<Position> positionsToFlip = new List<Position>();
                        positionsToFlip.Add(searchedEnemyPosition);

                        Position currentPosition = searchedEnemyPosition + direction;
                        while (IsTargetPositionOnBoard(currentPosition))
                        {
                            if (Places[currentPosition.x, currentPosition.y].Piece == currentPlayer.PlayerColor)
                            {
                                foreach (var pos in positionsToFlip)
                                {
                                    PlacePiece(pos, currentPlayer);
                                    enemyPlayer.PiecePositions.Remove(pos);
                                }
                                PlacePiece(LastClickedPlacePosition, currentPlayer);
                                break;
                            }
                            else if (Places[currentPosition.x, currentPosition.y].Piece == Piece.None || Places[currentPosition.x, currentPosition.y].Piece == Piece.Possible)
                            {
                                break;
                            }
                            else if (Places[currentPosition.x, currentPosition.y].Piece == enemyPlayer.PlayerColor)
                            {
                                positionsToFlip.Add(currentPosition);
                            }

                            currentPosition += direction;
                        }
                    }
                }
            }
            return new Player[2] { currentPlayer, enemyPlayer };
        }

        private bool IsTargetPositionOnBoard(Position pos)
        {
            return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
        }

        public void ClearPossibleMoves()
        {
            for (int i = 0; i < possibleMoves.Count; i++)
            {
                Position p = possibleMoves[i];
                if (Places[p.x, p.y].Piece == Piece.Possible)
                {
                    Places[p.x, p.y].SetPlace(Piece.None);
                }
            }
            possibleMoves.Clear();
        }

        public Player PlacePiece(Position position, Player currentPlayer)
        {
            if (position.x >= 0 && position.y >= 0)
            {
                Place place = Places[position.x, position.y];
                if (place.Piece!=currentPlayer.PlayerColor)
                {
                    place.SetPlace(currentPlayer.PlayerColor);
                    currentPlayer.PiecePositions.Add(position);
                    return currentPlayer;
                }
               
            }
            return null;
        }

        private Piece GetPieceAt(int x, int y)
        {
            return Piece.None;
        }

        private void Place_Click(object sender, EventArgs e)
        {
            Place clickedPlace = sender as Place;
            if (clickedPlace != null)
            {
                LastClickedPlacePosition = clickedPlace.Position;
            }
        }

        public void ResetLastClickedPositon()
        {
            LastClickedPlacePosition.Set(-1, -1);
        }

        public Position GetLastClickedPosition()
        {
            return LastClickedPlacePosition;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Places[i, k].SetPlace(Piece.None);
                }
            }
            LastClickedPlacePosition = new Position(-1, -1);
            possibleMoves = new List<Position>();
        }

        public List<Position> GetPossibleMoves()
        {
            return possibleMoves;
        }


    }
}
