using System;

namespace tic_tac_toe
{
    public class Board
    {
        private readonly char[] FieldReplacement = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] Field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public Player player1 = new Player("Player 1", 'X');
        public Player player2 = new Player("Player 2", 'O');
        public void DrawBoard(int _round)
        {
            Console.Clear();
            Console.WriteLine($"Round {_round}");
            Console.WriteLine($"\t {Field[0]} | {Field[1]} | {Field[2]} ");
            Console.WriteLine($"\t---+---+---");
            Console.WriteLine($"\t {Field[3]} | {Field[4]} | {Field[5]} ");
            Console.WriteLine($"\t---+---+---");
            Console.WriteLine($"\t {Field[6]} | {Field[7]} | {Field[8]} ");
        }
        public void GetInputAndPlace(Player player)
        {
            Console.Write($"\n{player.Name}, Where? ");
            int Pos;
            bool PositionTaken = true;
            do
            {
                //take in valid position index
                while (!int.TryParse(Console.ReadLine().Trim(), out Pos) || Pos < 1 || Pos > 9)
                {
                    Console.Write("Invalid position index. Try again: ");
                }
                //check if the position is already occupied
                if (Field[Pos - 1] == player1.Piece || Field[Pos - 1] == player2.Piece)
                {
                    Console.Write("Positon already taken. Try again: ");
                }
                else
                {
                    //if the spot is free
                    PositionTaken = false;
                }
            } while (PositionTaken);
            //set the player piece
            Field[Pos - 1] = player.Piece;
        }//GetInputAndPlace
        public Player SwitchPlayer(Player _currentplayer)
        {
            if (_currentplayer == player1)
                return player2;
            else
                return player1;
        }//SwitchPlayer
        public bool CheckBoard(Player player)
        {
            //check for any posible straight line
            if (Field[0] == Field[1] && Field[1] == Field[2] && Field[2] == player.Piece)
                return true;
            if (Field[3] == Field[4] && Field[4] == Field[5] && Field[5] == player.Piece)
                return true;
            if (Field[6] == Field[7] && Field[7] == Field[8] && Field[8] == player.Piece)
                return true;
            if (Field[0] == Field[3] && Field[3] == Field[6] && Field[6] == player.Piece)
                return true;
            if (Field[1] == Field[4] && Field[4] == Field[7] && Field[7] == player.Piece)
                return true;
            if (Field[2] == Field[5] && Field[5] == Field[8] && Field[8] == player.Piece)
                return true;
            if (Field[0] == Field[4] && Field[4] == Field[8] && Field[8] == player.Piece)
                return true;
            if (Field[2] == Field[4] && Field[4] == Field[6] && Field[6] == player.Piece)
                return true;
            return false;
        }//checkBoard
        public void ClearBoard()
        {
            //replace all slot with numbers
            for (int i = 0; i < 9; i++)
            {
                Field[i] = FieldReplacement[i];
            }
        }//ClearBoard
        public bool SpaceAvailable()
        {
            foreach (char c in Field)
                //if the current space is neither player's piece, then the slot is free, return true
                if (c != player1.Piece && c != player2.Piece)
                    return true;
            //f there is either player's piece on al spaces, return false
            return false;
        }//SpaceAvailable
    }
}
