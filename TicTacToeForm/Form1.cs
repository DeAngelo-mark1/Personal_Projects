namespace TicTacToeForm
{
    public partial class TTT1 : Form
    {
        int turnCounter = 1;
        string Odd;
        string Even;
        bool didWin = false;

        public TTT1()
        {
            InitializeComponent();

            //Decide who goes first
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                Odd = "X";
                Even = "O";
            }
            else
            {
                Odd = "O";
                Even = "X";
            }
            lbl3.Text = Odd; // Display the first player


        }

        private void btn_Click(object sender, EventArgs e)
        {
           

            //while (didWin == false)
            {   //Turn Logic
                Button clickedButton = sender as Button;
                if ( clickedButton != null)
                {
                    //Displaying whose turn it is
                    string currentPlayer = GetCurrentPlayer(" ");
                    string inversePlayer = currentPlayer == "X" ? "O" : "X";// If it is X, then it is switched to contain O, otherwise it stays X
                    lbl3.Text = inversePlayer;

                    //Displays the Symbol of current player
                    clickedButton.Text = GetCurrentPlayer(clickedButton.Text);
                }
                turnCounter++;
                CheckWin();
                didWin = CheckWin();
                if (didWin == true)
                {
                    string currentPlayer = GetCurrentPlayer(" ");
                    string inversePlayer = currentPlayer == "X" ? "O" : "X";
                    MessageBox.Show("Player " + inversePlayer + " wins!");
                    // Reset the game
                    btn1.Text = btn2.Text = btn3.Text = btn4.Text = btn5.Text = btn6.Text = btn7.Text = btn8.Text = btn9.Text = "";
                    turnCounter = 1;
                    lbl3.Text = Odd;
                }
                else if (turnCounter >= 10) 
                {
                    MessageBox.Show("It's a draw!");
                    // Reset the game
                    btn1.Text = btn2.Text = btn3.Text = btn4.Text = btn5.Text = btn6.Text = btn7.Text = btn8.Text = btn9.Text = "";
                    turnCounter = 1;
                    lbl3.Text = Odd;
                }

            }
        }

        public string GetCurrentPlayer(string text)
        {

            if (turnCounter % 2 == 0)
            {
                text = Even;
            }
            else 
            {
                text = Odd;
            }
            return text;
            
        }

        public bool CheckWin()
        {
            // Assuming buttons are named btn1 to btn9 in a 3x3 grid
            string[,] board = new string[3, 3]
            {
                { btn1.Text, btn2.Text, btn3.Text },
                { btn4.Text, btn5.Text, btn6.Text },
                { btn7.Text, btn8.Text, btn9.Text }
            };

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (!string.IsNullOrEmpty(board[row, 0]) &&
                    board[row, 0] == board[row, 1] &&
                    board[row, 1] == board[row, 2])
                {
                    return true; // Winning row
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (!string.IsNullOrEmpty(board[0, col]) &&
                    board[0, col] == board[1, col] &&
                    board[1, col] == board[2, col])
                {
                    return true; // Winning column
                }
            }

            // Check diagonals
            if (!string.IsNullOrEmpty(board[0, 0]) &&
                board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2])
            {
                return true; // Winning diagonal (top-left to bottom-right)
            }

            if (!string.IsNullOrEmpty(board[0, 2]) &&
                board[0, 2] == board[1, 1] &&
                board[1, 1] == board[2, 0])
            {
                return true; // Winning diagonal (top-right to bottom-left)
            }

            return false; // No winner yet
        }
    }
}
