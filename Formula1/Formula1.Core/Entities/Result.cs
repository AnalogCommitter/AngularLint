

namespace Formula1.Core.Entities
{
    public class Result
    {
        public Race Race { get; set; }

        public Team Team { get; set; }

        public Driver Driver { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }
    }
}
