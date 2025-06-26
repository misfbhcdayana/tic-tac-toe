using System;

namespace tic_tac_toe
{
    public class Game
    {
        //instance of the board
        private Board board = new Board();
        public Game()
        {
            //start the game
            Run();
        }
        private void Run()
        {
            //introduction
            Console.WriteLine("It's Tic Tac Toe");
            NamePlayers();
            WelcomePlayers();
            //track game play and round
            int Round = 1;
            string PlayAgain;
            do
            {
                //play the game
                PlayGame(ref Round);
                //prompt to play again
                Console.Write("Play again (y/n) ? ");
                PlayAgain = Console.ReadLine().Trim();
            } while (PlayAgain == "y");
            //announce the winner at the end
            AnnounceWinner();
        }//Run
        private void PlayGame(ref int _Round)
        {
            //set the current player to be the first player
            Player CurrentPlayer = board.player1;
            //display the board based on the game round  number
            board.DrawBoard(_Round);
            //while there are still available places
            while (board.SpaceAvailable())
            {
                //get position and place the player piece
                board.GetInputAndPlace(CurrentPlayer);
                //refresh the board
                board.DrawBoard(_Round);
                //check for a straight line
                bool win = board.CheckBoard(CurrentPlayer);
                if (win)
                {
                    //end game
                    CurrentPlayer.Score++;
                    board.DrawBoard(_Round);
                    Console.WriteLine($"\nRound {_Round} : {CurrentPlayer.Name} wins!");
                    _Round++;
                    board.ClearBoard();
                    return;
                }
                //switch player
                CurrentPlayer = board.SwitchPlayer(CurrentPlayer);
            }
            //if no one wins after the spaces have all been used
            Console.WriteLine($"Round {_Round} : Tie");
            _Round++;
            board.ClearBoard();
        }
        private void NamePlayers()
        {
            //Initialize players with their preferred names
            Console.Write("\nWould you like to name Player 1 (y/n) ? ");
            string NamePlayer = Console.ReadLine().ToLower().Trim();
            if (NamePlayer == "y")
            {
                Console.Write("Player 1: ");
                board.player1.Name = Console.ReadLine();
            }
            Console.Write("\nWould you like to name Player 2 (y/n) ? ");
            NamePlayer = Console.ReadLine().ToLower().Trim();
            if (NamePlayer == "y")
            {
                Console.Write("Player 2: ");
                board.player2.Name = Console.ReadLine();
            }
        }//NamePlayers
        private void WelcomePlayers()
        {
            Console.WriteLine($"\nWelcome {board.player1.Name} and {board.player2.Name}!");
            Console.Write("\nPress any key to play...");
            Console.ReadKey();
        }//WelcomePlayers.
        private void AnnounceWinner()
        {
            //compare the score and display winner
            if (board.player1.Score > board.player2.Score)
                Console.WriteLine($"\n\t!!{board.player1.Name} Wins The Game!!");
            else if (board.player2.Score > board.player1.Score)
                Console.WriteLine($"\n\t!!{board.player2.Name} Wins The Game!!");
            else
                Console.WriteLine("\n\tIt's a Tie!!");
            Console.Write("\nPress any Key to close...");
            Console.ReadKey();
        }
    }
}
