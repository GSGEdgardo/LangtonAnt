using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonAnt.LangtonsAntLogic
{
    internal class Ant
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Direction FacingDirection { get; private set; }
        public Ant(int startRow, int startCol)
        {
            Row = startRow;
            Col = startCol;
            FacingDirection = Direction.North;
        }

        // This method change the facing direction of the ant based on the current cell state
        public void Turn(CellState currentState) 
        {
            /* Here's the explanation of the logic behind the turn method:
            Directions are created like this:
            North,
            East,
            South,
            West
            So, if we want to turn right, we need to take this FacingDirection and transform to a number,
            later, we need to add 1 to this number because East is the the 'right' direction, and Langton's Ant
            when is in a white cell, turns to the right, and when is in a black cell, turns to the left.
            And West is the 'left' direction, so we need to add 3 to this number.
            The mod 4 part is because we need to stay between 0 and 3 to stay in the four directions, which are:
            North = 0,
            East = 1,
            South = 2,
            West = 3
            */
            if (currentState == CellState.White)
            {
                // Turn to the right, 
                FacingDirection = (Direction)(((int)FacingDirection + 1) % 4);
            }
            else
            {
                // Turn to the left
                FacingDirection = (Direction)(((int)FacingDirection + 3) % 4);
            }
        }

        // This method moves the ant in the direction it is facing
        public void Movement() 
        {
            switch (FacingDirection) 
            {
                case Direction.North:
                    Row--;
                    break;
                case Direction.South:
                    Row++;
                    break;
                case Direction.West:
                    Col--;
                    break;
                case Direction.East:
                    Col++;
                    break;
            }
        }
        
        // Adjusts the ant’s position after the grid has expanded (if rows/cols added at top/left)
        public void AdjustPosition(int rowOffset, int colOffset) 
        {
            /* Here's the logic behind the ExpandGrid method:
             * The thing is when you add a new column or a new row, and its like "behind" of the ant, 
             * behind means left and up, we need to fix the ant position, because the grid is now bigger,
             * and the ant is not more at 2,2, but at 2,2 + the new row and column added. So we need to 
             * use the offset to fix the ant position. So we add the offset to the ant position to fix it.
             */
            Row += rowOffset;
            Col += colOffset;
        }   
    }
}
