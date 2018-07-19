using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CS451Checkers
{
    class Tile
    {
        int x, y;
        Brush color;
        Button button;

        public Piece piece;

        public TileDisplay display;

        public Tile(int x, int y, Brush color, Button button)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.button = button;

        }

        

        public void Test()
        {
            Trace.WriteLine(x + "," + y);
        }

        public void OnClick()
        {
            if (piece == null && Board.board.Player1.selectedPiece==null)
            {
                return;
            }
            else if (piece== null && Board.board.Player1.selectedPiece!=null)
            {

            }
            else if (piece != null)
            {
                ClickedWithPiece();
            }
        }

        public void ClickedWithPiece()
        {
            if (piece.owner != Board.board.Player1)
            {
                return;
            }
            List<Direction> moves = piece.ValidMoves();
            if (moves.Count > 0)
            {
                Board.board.Player1.selectedPiece = piece;
            }
        }

        public void UpdateDisplay()
        {

        }
    }
}

public enum Direction { NW,NE,SW,SE}
