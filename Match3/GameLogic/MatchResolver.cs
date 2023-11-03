using Match3.Entities;

namespace Match3.GameLogic
{
    internal class MatchResolver
    {
        Board _board;
        List<Stack<Block>> matches = new List<Stack<Block>>();
        Stack<Block> actualMatch = new Stack<Block>();
        List<Block> verified = new List<Block>();

        public MatchResolver(Board board)
        { 
            _board = board;
        }

        public void Resolve()
        {
            for (int i = 0; i < Board.ROWS; i++)
            {
                for (int j = 0; j < Board.COLS; j++)
                {
                    if (Contains(matches, _board.Blocks[i, j]))
                        continue;
                    Search((i, j));
                    verified.Clear();
                    if (actualMatch.Count >= 3)
                    {
                        matches.Add(actualMatch);
                        actualMatch = new Stack<Block>();
                    }
                    else
                        actualMatch.Clear();
                }
            }
            Console.WriteLine(matches.Count());
        }

        private void Search((int row, int col) position)
        {
            var block = _board.Blocks[position.row, position.col];
            if (verified.Contains(block) || Contains(matches, block))
                return;

            verified.Add(block);

            if (!actualMatch.Any() || actualMatch.Peek().Tile == block.Tile)
            {
                actualMatch.Push(block);
                //UP
                if (position.row > 0)
                    Search((position.row - 1, position.col));

                //DOWN
                if (position.row < Board.ROWS - 1)
                    Search((position.row + 1, position.col));

                //LEFT
                if (position.col > 0)
                    Search((position.row, position.col - 1));

                //RIGHT
                if (position.col < Board.COLS - 1)
                    Search((position.row, position.col + 1));
            }
        }

        private static bool Contains(List<Stack<Block>> matches, Block block)
        {
            foreach (var match in matches)
            {
                if (match.Contains(block))
                    return true;
            }
            return false;
        }
    }
}
