using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonAnt.LangtonsAntLogic
{
    internal class Grid
    {
        // Created a List of list of cellstate to represent the grid
        private List<List<CellState>> cells;
        private int Rows => cells.Count;
        public int Cols => cells[0].Count;

        // Method to initialize the grid with a given number of rows and columns
        public Grid(int initialRows = 1, int initialCols = 1) 
        {
            cells = new List<List<CellState>>();
            
            for (int i = 0; i < initialRows; i++)
            {
                var row = new List<CellState>();
                for (int j = 0; j < initialCols; j++)
                {
                    row.Add(CellState.White);
                }
                cells.Add(row);
            }
        }

        //This method return the cell state at a given row and column
        public CellState GetCell(int row, int col)
        {
            return cells[row][col];
        }

        // This method sets the cell state at a given row and column
        public void ToggleCell(int row, int col) 
        {
            if (cells[row][col] == CellState.White)
            {
                cells[row][col] = CellState.Black;
            }
            else
            {
                cells[row][col] = CellState.White;
            }
        }

        // This method prints the grid to the console
        public void PrintGrid() 
        {
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Cols; j++) 
                {
                    if (cells[i][j] == CellState.White)
                    {
                        Console.Write("░");
                    }
                    else
                    {
                        Console.Write("█");
                    }
                }
                Console.WriteLine();
            }
        }

        // This method expands the grid by adding a new row and column
        // Expands the grid as needed and returns how much the ant's position needs to be shifted
        public (int rowOffset, int colOffset) ExpandGrid(int row, int col)
        {
            // The explanation of the offset is in Ant class -> AdjustPosition method
            int rowOffset = 0, colOffset = 0;

            while (row < 0)
            {
                // Enumerable.Repeat(value, count): creates a list of 'count' elements filled with 'value'
                // In this case, it creates a row of 'Cols' cells, all initialized to White.
                var newRow = Enumerable.Repeat(CellState.White, Cols).ToList();
                // Insert the new row at the beginning of the grid. Insert takes the index first, then the value.
                cells.Insert(0, newRow);
                row++;
                rowOffset++;
            }

            while (row >= Rows)
            {
                // This can also be done with Enumerable.Repeat as above, but here it's done with a regular for loop.
                var fila = new List<CellState>();
                for (int i = 0; i < Cols; i++)
                {
                    fila.Add(CellState.White);
                }
                cells.Add(fila);
            }

            while (col < 0)
            {
                // Iterate over each row and insert a white cell at the beginning of each row
                foreach (var r in cells)
                    r.Insert(0, CellState.White);
                col++;
                colOffset++;
            }

            while (col >= Cols)
            {
                // Iterate over each row and add a white cell at the end of each row
                foreach (var r in cells)
                    r.Add(CellState.White);
            }
            return (rowOffset, colOffset);
        }

    }
}
