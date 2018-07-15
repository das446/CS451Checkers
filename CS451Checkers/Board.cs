using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CS451Checkers
{
    class Board
    {
        public static Board board;
        Tile[,] tiles = new Tile[8,8];

        public void MakeBoardDisplay(Button r, Canvas canvas)
        {
            int scale = (int)r.Width;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Brush c = (x + y) % 2 == 0 ? Brushes.Red : Brushes.Black; 
                    Button rec = new Button
                    {
                        Width = r.Width,
                        Height = r.Height,
                        Background = c,
                    };
                    int x2 = 7 - x;
                    rec.Name = "Tile_"+x2+"_"+y;
                    rec.Click += Command.OnClick;
                    canvas.Children.Add(rec);
                    Canvas.SetTop(rec, scale*x);
                    Canvas.SetLeft(rec, scale*y);

                    Tile tile = new Tile(x2,y, c, rec);
                    tiles[x2, y] = tile;

                }
            }
            r.Width = 0;
            r.Height = 0;
        }

        public Tile GetTileFromButton(string buttonName)
        {
            string[] n = buttonName.Split('_');
            int x = int.Parse(n[1]);
            int y = int.Parse(n[2]);
            return tiles[x, y];
        }
    }
}
