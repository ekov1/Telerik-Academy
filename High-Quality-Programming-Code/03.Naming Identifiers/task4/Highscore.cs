namespace MineSweeper
{
    public class Highscore
    {
        private string name;
        private int score;

        public Highscore() { }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public Highscore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

}
