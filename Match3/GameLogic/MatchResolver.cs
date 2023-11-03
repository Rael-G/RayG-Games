using Match3.Entities;
using RayG;
using Raylib_cs;

namespace Match3.GameLogic
{
    internal class MatchResolver
    {
        readonly Board _board;
        readonly List<Stack<Block>> _matches;
        readonly List<Block> _verified;
        Stack<Block> _actualMatch;

        public MatchResolver(Board board)
        { 
            _board = board;
            _matches = new List<Stack<Block>>();
            _actualMatch = new Stack<Block>();
            _verified = new List<Block>();
        }

        public void Resolve()
        {
            for (int i = 0; i < Board.ROWS; i++)
            {
                for (int j = 0; j < Board.COLS; j++)
                {
                    if (Contains(_matches, _board.Blocks[i, j]))
                        continue;
                    Search((i, j));
                    _verified.Clear();
                    if (_actualMatch.Count >= 3)
                    {
                        _matches.Add(_actualMatch);
                        _actualMatch = new Stack<Block>();
                    }
                    else
                        _actualMatch.Clear();
                }
            }

            if (_matches.Any()) 
            {
                Remove();
                Drop();
            }
        }

        private void Search((int row, int col) position)
        {
            var block = _board.Blocks[position.row, position.col];
            if (_verified.Contains(block) || Contains(_matches, block))
                return;

            _verified.Add(block);

            if (!_actualMatch.Any() || _actualMatch.Peek().Tile == block.Tile)
            {
                _actualMatch.Push(block);
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

        private void Remove()
        {
            for (int i = Board.ROWS - 1; i >= 0; i--)
            {
                for (int j = Board.COLS - 1; j >= 0; j--)
                {
                    if (Contains(_matches, _board.Blocks[i, j]))
                    {
                        _board.Blocks[i, j].Dead = true;
                    }
                }
            }
            _matches.Clear();
        }

        private void Drop()
        {
            for (int i = Board.COLS - 1; i >= 0; i--)
            {
                Queue<Block> liveQueue = new Queue<Block>();
                Queue<Block> deadQueue = new();
                for (int j = Board.ROWS - 1; j >= 0; j--)
                {
                    var block = _board.Blocks[j, i];

                    if (block.Dead)
                    {
                        deadQueue.Enqueue(block);
                    }
                    else
                        liveQueue.Enqueue(block);
                }

                for (int j = Board.ROWS - 1; j >= 0; j--)
                {
                    if (liveQueue.Any())
                        _board.SwapInBoard(liveQueue.Dequeue(), _board.Blocks[j, i]);
                    else
                        _board.SwapInBoard(_board.Blocks[j, i], deadQueue.Dequeue());
                }
            }
            _board.ReplaceBoard();
            //Wait a bit to avoid asynchronous bugs
            var resolve = Timing.AfterAsync(0.3f, () => Resolve());
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
