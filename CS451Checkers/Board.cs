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
        public Player Player1, Player2;
        Tile[,] tiles = new Tile[8, 8];
        
        public BoardDisplay display;

        public void MakeBoardDisplay(Button r, Canvas canvas)
        {
            int scale = (int)r.Width;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    MakeTile(r, canvas, scale, y, x);

                }
            }
            r.Width = 0;
            r.Height = 0;


        }

        private void MakeTile(Button r, Canvas canvas, int scale, int y, int x)
        {
            Brush c = (x + y) % 2 == 0 ? Brushes.Red : Brushes.Black;
            Button rec = new Button
            {
                Width = r.Width,
                Height = r.Height,
                Background = c,
            };
            int x2 = 7 - x;
            rec.Name = "Tile_" + x2 + "_" + y;
            rec.Click += Command.OnClick;
            canvas.Children.Add(rec);
            Canvas.SetTop(rec, scale * x);
            Canvas.SetLeft(rec, scale * y);

            Tile tile = new Tile(x2, y, c, rec);
            tiles[x2, y] = tile;
            display.buttons[x2, y] = rec;
        }

        public Tile GetTileFromButton(string buttonName)
        {
            string[] n = buttonName.Split('_');
            int x = int.Parse(n[1]);
            int y = int.Parse(n[2]);
            return GetTile(x, y);
        }

        public Tile GetTile(int x, int y)
        {
            if (x < 0 || y < 0 || x > 7 || y > 7)
            {
                return null;
            }
            else
            {
                return tiles[x, y];
            }
        }

        public void MovePiece(int startX, int startY, int newX, int newY)
        {
            GetTile(newX, newY).piece = GetTile(startX, startY).piece;
            GetTile(startX, startY).piece = null;

        }

        public void JumpPiece(int startX, int startY, int newX, int newY, int jumpX, int jumpY)
        {
            GetTile(newX, newY).piece = GetTile(startX, startY).piece;
            GetTile(startX, startY).piece = null;
            GetTile(jumpX, jumpY).piece.Remove();

        }
    }
}
