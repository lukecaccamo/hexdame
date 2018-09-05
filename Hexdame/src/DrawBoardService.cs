using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Hexdame
{
    class DrawBoardService
    {

        /// <summary>
        /// Center board coordinates.
        /// </summary>
        public Vector2 boardCenter;

        /// <summary>
        /// Stores the coordinates of all spaces.
        /// </summary>
        public List<Vector2> boardSpaceCoordinates;

        /// <summary>
        /// Initializes board coordinates.
        /// </summary>
        //Calculates the coordinates for the board tiles
        public DrawBoardService()
        {
            int numInColumn = BoardConstants.MinSpacesInColumn;
            boardSpaceCoordinates = new List<Vector2>();

            //For each column draw the correct number of spaces
            for (int x = 0; x < BoardConstants.MaxSpacesInColumn; ++x)
            {
                for (int y = 0; y < numInColumn; ++y)
                {
                    boardSpaceCoordinates.Add(new Vector2(CalculateX(x), CalculateY(x, y)));

                    if (x == BoardConstants.HalfBoard && y == BoardConstants.HalfBoard)
                    {
                        boardCenter = new Vector2(CalculateX(x) + BoardConstants.OneSpaceY, CalculateY(x, y) + BoardConstants.OneSpaceY);
                    }
                }

                if (x < BoardConstants.HalfBoard)
                {
                    numInColumn++;
                }
                else
                {
                    numInColumn--;
                }
            }
        }

        /// <summary>
        /// Draws the spaces.
        /// </summary>
        public void DrawBoard(SpriteBatch spriteBatch, Texture2D boardSpace)
        {
            for (int i = 0; i < BoardConstants.NumberOfSpaces; ++i)
            {
                spriteBatch.Draw(boardSpace, boardSpaceCoordinates[i], Color.SlateGray);
            }
        }

        /// <summary>
        /// Calculation for x coordinates.
        /// </summary>
        private float CalculateX(int x)
        {
            return BoardConstants.OneSpaceX * x;
        }

        /// <summary>
        /// Calculation for y coordinates.
        /// </summary>
        private float CalculateY(int x, int y)
        {
            if (x <= BoardConstants.HalfBoard)
            {
                return BoardConstants.TotalHeight * y - BoardConstants.OneSpaceY * x;
            }

            return BoardConstants.TotalHeight * y - BoardConstants.OneSpaceY * (BoardConstants.FullBoard - x);
        }
    }
}
