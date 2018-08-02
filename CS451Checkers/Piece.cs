using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS451Checkers
{
    public class Piece
    {
        public Player owner;
        public int x, y;

        /// <summary>
        /// Moves a tile in a given direction
        /// </summary>
        /// <param name="d"></param>
        public void Move(Direction d)
        {
            if (d == Direction.NE)
            {
                Move(1, 1);
            }
            else if (d == Direction.SE)
            {
                Move(1, -1);
            }
            else if (d == Direction.SW)
            {
                Move(-1, -1);
            }
            else if (d == Direction.NW)
            {
                Move(-1, 1);
            }
        }

        /// <summary>
        /// Move tile based on x and y
        /// </summary>
        /// <param name="xDist"></param>
        /// <param name="yDist"></param>
        void Move(int xDist, int yDist)
        {
            Tile next = Board.board.GetTile(x + xDist, y + yDist);
            if (next == null)
            {
                return;
            }
            else if (next.piece == null)
            {
                int newX = x + xDist;
                int newY = y + yDist;
                Board.board.MovePiece(x, y, newX, newY);

            }
            else if (next.piece.owner != owner)
            {

                xDist *= 2;
                yDist *= 2;
                Tile jump = Board.board.GetTile(x + xDist, y + yDist);
                if (jump == null)
                {
                    return;
                }
                else if (jump.piece == null)
                {
                    int jumpedX = x + xDist / 2;
                    int jumpedY = y + yDist / 2;

                    int jumpX = x + xDist;
                    int jumpY = y + yDist;

                    Board.board.JumpPiece(x, y, jumpedX, jumpedY, jumpX, jumpY);
                }
                else { return; }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks if player can move in direction
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool CanMove(Direction d)
        {
            if (d == Direction.NE)
            {
                return CanMove(1, 1);
            }
            else if (d == Direction.SE)
            {
                return CanMove(1, -1);
            }
            else if (d == Direction.SW)
            {
                return CanMove(-1, -1);
            }
            else if (d == Direction.NW)
            {
                return CanMove(-1, 1);
            }
            return false;
        }

        /// <summary>
        /// Check if player can move based on x and y
        /// </summary>
        /// <param name="xDist"></param>
        /// <param name="yDist"></param>
        /// <returns></returns>
        bool CanMove(int xDist, int yDist)
        {
            Tile next = Board.board.GetTile(x + xDist, y + yDist);
            if (next == null)
            {
                return false;
            }
            else if (next.piece == null)
            {
                return true;
            }
            else if (next.piece.owner != owner)
            {

                xDist *= 2;
                yDist *= 2;
                Tile jump = Board.board.GetTile(x + xDist, y + yDist);
                if (jump == null)
                {
                    return false;
                }
                else if (jump.piece == null)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }

        public void Remove()
        {
        }

        /// <summary>
        /// Returns a list of valid moves
        /// </summary>
        /// <returns></returns>
        public List<Direction> ValidMoves()
        {
            List<Direction> moves = new List<Direction>();
            if (CanMove(Direction.NE))
            {
                moves.Add(Direction.NE);
            }
            if (CanMove(Direction.SE))
            {
                moves.Add(Direction.SE);
            }
            if (CanMove(Direction.SW))
            {
                moves.Add(Direction.SW);
            }
            if (CanMove(Direction.NW))
            {
                moves.Add(Direction.NW);
            }
            return moves;
        }
    }


    public struct Move
    {
        public Piece piece;
        public Direction direction;
    }
}