using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CS451Checkers
{
    public static class Command
    {
        public static void Hello()
        {
            Trace.WriteLine("Hello World");
        }

        public static void OnClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Tile t = Board.board.GetTileFromButton(b.Name);
            t.Test();
        }
    }
}
