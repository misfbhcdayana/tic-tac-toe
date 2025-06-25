namespace tic_tac_toe
{
    public class Player
    {
        public string Name { get; set; }
        public char Piece { get; }
        public int Score { get; set; }
        public Player() { }
        public Player(string name, char piece, int score = 0)
        {
            Name = name;
            Piece = piece;
            Score = score;
        }
    }
}
