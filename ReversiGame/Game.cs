using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReversiGame;
using ReversiGame.PlayerModule;

namespace Reversi_game
{
    public class Game
    {
        public Board board { get; private set; }
        public Player[] players { get; private set; }
        private int currentPlayerIndex;
        private Position[] beginningSetupPositions;
        private bool possibleFound = false;
        private bool gameOver = false;


        public Game(Control.ControlCollection control)
        {
            board = new Board(control);
            players = new Player[2];
            currentPlayerIndex = 0;
            beginningSetupPositions = new Position[4]
            {
                new Position(3, 3),
                new Position(4, 4),
                new Position(4, 3),
                new Position(3, 4)
            };
        }

        public void InitPlayers(Player player1, Player player2)
        {
            players[0] = player1;
            players[1] = player2;
        }
        public void StartGame()
        {
            for (int i = 0; i < beginningSetupPositions.Length; i++)
            {
                Player player = (i < 2) ? players[0] : players[1];
                board.PlacePiece(beginningSetupPositions[i], player);
            }
        }

        private void SetLabelTextByName(Control.ControlCollection controls, string name,string text)
        {
            Control[] foundControls = controls.Find(name, true);
            foreach (Control control in foundControls)
            {
                if (control is Label)
                {
                     ((Label)control).Text=text;
                }
            }
           
        }

        public void Update(Control.ControlCollection control)
        {

            if (gameOver)
            {

                if (players[0].PiecePositions.Count > players[1].PiecePositions.Count)
                {
                    SetLabelTextByName(control, "endGameWinnerLabel", players[0].PlayerColor.ToString() + " won!");
                }
                else
                {
                    SetLabelTextByName(control, "endGameWinnerLabel", players[1].PlayerColor.ToString() + " won!");
                }

            }
            else
            {

                if (!possibleFound)
                {
                    board.InitPossibleMoves(players[currentPlayerIndex], players[getEnemyPlayerIndex()]);
                    Debug.WriteLine(board.GetPossibleMoves().Count);
                    possibleFound = true;
                }
                Position position = players[currentPlayerIndex].MakeMove(board);

                if (position != null)
                {
                    if (board.IsValidMove(position))
                    {
                        Player[] p = board.FlipPieces(players[currentPlayerIndex], players[getEnemyPlayerIndex()], position);
                        players[currentPlayerIndex] = p[0];
                        players[getEnemyPlayerIndex()] = p[1];
                        board.ClearPossibleMoves();
                        possibleFound = false;
                        SwitchPlayer();
                    }
                }

            }
            IsGameOver();
        }

        private void SwitchPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex == 0) ? 1 : 0;
        }

        private int getEnemyPlayerIndex()
        {
            return (currentPlayerIndex == 0) ? 1 : 0;
        }

        private void IsGameOver()
        {
            if (players[0].PiecePositions.Count + players[1].PiecePositions.Count >= 64)
            {
                gameOver = true;
            }
            else if (possibleFound && board.GetPossibleMoves().Count ==0)
            {
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }

        }


        public void Restart()
        {
            board.ResetBoard();
            for (int i = 0; i < players.Length; i++)
            {
                players[i].PiecePositions.Clear();
            }
            StartGame();
            possibleFound = false;
            currentPlayerIndex = 1;
            gameOver = false;
        }


    }

}
