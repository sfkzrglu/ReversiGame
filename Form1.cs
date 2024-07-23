using ReversiGame;
using ReversiGame.PlayerModule;
using System.Diagnostics;
using System.Windows.Forms;

namespace Reversi_game
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inGamePanel.Visible = false;
            game = new Game(this.Controls);
            endGameWinnerLabel.Text = "";
        }

        private void update_Tick(object sender, EventArgs e)
        {
            game.Update(this.Controls);
            whiteCountLabel.Text = "White: " + game.players[0].PiecePositions.Count;
            blackCountLabel.Text = "Black: " + game.players[1].PiecePositions.Count;

        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            game.Restart();
            UpdateTimer.Start();
            endGameWinnerLabel.Text = "";
        }

        private void pvpButton_Click(object sender, EventArgs e)
        {
            UpdateTimer.Start();
            game.InitPlayers(new HumanPlayer(Piece.White), new HumanPlayer(Piece.Black));
            game.StartGame();
            menuPanel.Visible = false;
            inGamePanel.Visible = true;           
            endGameWinnerLabel.Text = "";
        }

        private void pvcButton_Click(object sender, EventArgs e)
        {
            UpdateTimer.Start();
            game.InitPlayers(new HumanPlayer(Piece.White), new ComputerPlayer(Piece.Black));
            game.StartGame();
            menuPanel.Visible = false;
            inGamePanel.Visible = true;          
            endGameWinnerLabel.Text = "";
        }

        private void gobackmenuButton_Click(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            game.Restart();
            game.board.ResetBoard();       
            menuPanel.Visible = true;
            inGamePanel.Visible = false;
            endGameWinnerLabel.Text = "";
        }
    }
}

