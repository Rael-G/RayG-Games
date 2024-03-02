using Match3.Entities;
using RayG;
using Raylib_cs;

namespace Match3.GameLogic
{
    internal class GameController : GameObject
    {
        Rectangle _selector;
        Rectangle _selected;
        (int row, int col) _selectorPosition;
        (int row, int col)? _selectedPosition;
        MatchResolver _resolver;
        Board _board;
        public GameController(Board board) 
        {
            _board = board;
        }

        public override void Start()
        {
            _resolver = new(_board);
            _resolver.Resolve();
            _selectorPosition = _board.Blocks[0, 0].BoardPosition;
            _selector = _board.Blocks[_selectorPosition.row, _selectorPosition.col].Position;
            Deselect();
            base.Start();
        }

        public override void Update()
        {
            Move();
            Swap();

            _selector = _board.Blocks[_selectorPosition.row, _selectorPosition.col].Position;

            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawRectangleLines((int)_selector.X, (int)_selector.Y, (int)_selector.Width, 
                (int)_selector.Height, Raylib.Fade(Color.Red, 0.8f));

            Raylib.DrawRectangle((int)_selected.X, (int)_selected.Y, (int)_selected.Width,
                (int)_selected.Height, Raylib.Fade(Color.White, 0.5f));
            base.Render();
        }

        private void Swap()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                if (_selectedPosition == null)
                    Select();
                else
                {
                    var selectedPosition = _selectedPosition.Value;

                    var block = _board.Blocks[_selectorPosition.row, _selectorPosition.col];
                    var otherBlock = _board.Blocks[selectedPosition.row, selectedPosition.col];

                    _board.SwapInBoard(block, otherBlock);

                    Deselect();

                    var resolve = Timing.AfterAsync(0.2f, () => _resolver.Resolve());
                }
            }
        }

        private void Select()
        {
            _selected = _selector;
            _selectedPosition = _selectorPosition;
        }

        private void Deselect()
        {
            _selected = new Rectangle();
            _selectedPosition = null;
        }

        private void Move()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Up) && _selectorPosition.row > 0)
                TryMove((_selectorPosition.row - 1, _selectorPosition.col));

            if (Raylib.IsKeyPressed(KeyboardKey.Down) && _selectorPosition.row < Board.ROWS - 1)
                TryMove((_selectorPosition.row + 1, _selectorPosition.col));


            if (Raylib.IsKeyPressed(KeyboardKey.Left) && _selectorPosition.col > 0)
                TryMove((_selectorPosition.row, _selectorPosition.col - 1));


            if (Raylib.IsKeyPressed(KeyboardKey.Right) && _selectorPosition.col < Board.COLS - 1 )
                TryMove((_selectorPosition.row, _selectorPosition.col + 1));
        }

        private void TryMove((int row, int col) movement)
        {
            if (_selectedPosition != null)
            {
                var selectedPosition = _selectedPosition.Value;

                if (movement.row >= selectedPosition.row - 1
                    && movement.row <= selectedPosition.row + 1
                    && movement.col == selectedPosition.col
                    || movement.col >= selectedPosition.col - 1
                    && movement.col <= selectedPosition.col + 1
                    && movement.row == selectedPosition.row)
                    _selectorPosition = movement;
            }
            else
                _selectorPosition = movement;
        }

    }
}
