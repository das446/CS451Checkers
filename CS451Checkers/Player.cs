using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS451Checkers
{
    public class Player
    {

        string Name;
        List<Piece> pieces = new List<Piece>();

        public Piece selectedPiece;
        public Direction selectedDirection;

        /// <summary>
        /// Move a piece in a direction
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="d"></param>
        public void MovePiece(Piece piece,Direction d)
        {

        }

        public List<Move> ValidMoves()
        {
            List<Move> moves = new List<Move>();
            foreach (Piece piece in pieces)
            {
                
            }

            return null;
        }



        

    }


}

