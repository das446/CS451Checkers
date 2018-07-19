using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS451Checkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Board.board = new Board();
            Board.board.MakeBoardDisplay(Tile_0_0,MainCanvas);
            Board.board.display = new BoardDisplay();
            Board.board.display.board = Board.board;

            Board.board.Player1 = new Player();
            Board.board.Player2 = new Player();


        }
    }
}
