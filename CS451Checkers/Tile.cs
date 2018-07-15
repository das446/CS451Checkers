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

        PieceData piece;

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
    }
}
