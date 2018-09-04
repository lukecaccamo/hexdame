using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Hexdame
{
    class DrawBoardService
    {
        private enum sizes : int
        {
            totalWidth = 220,
            totalHeight = 190,
            oneSpaceX = 164,
            oneSpaceY = 95,
            maxSpacesInColumn = 9,
            numberOfSpaces = 61
        }

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
            int halfBoard = 4;
            int numInColumn = 5;
            boardSpaceCoordinates = new List<Vector2>();

            //For each column draw the correct number of spaces
            for (int x = 0; x < (int)sizes.maxSpacesInColumn; ++x)
            {
                for (int y = 0; y < numInColumn; ++y)
                {
                    boardSpaceCoordinates.Add(new Vector2(CalculateX(x), CalculateY(x, y)));

                    if (x == halfBoard && y == halfBoard)
                    {
                        boardCenter = new Vector2(CalculateX(x) + (int)sizes.oneSpaceY, CalculateY(x, y) + (int)sizes.oneSpaceY);
                    }
                }

                if (x < halfBoard)
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
            for (int i = 0; i < (int)sizes.numberOfSpaces; ++i)
            {
                spriteBatch.Draw(boardSpace, boardSpaceCoordinates[i], Color.SlateGray);
            }
        }

        /// <summary>
        /// Calculation for x coordinates.
        /// </summary>
        private float CalculateX(int x)
        {
            return (float)sizes.oneSpaceX * x;
        }

        /// <summary>
        /// Calculation for y coordinates.
        /// </summary>
        private float CalculateY(int x, int y)
        {
            if (x <= 4)
            {
                return (float)sizes.totalHeight * y - (int)sizes.oneSpaceY * x;
            }
                
            return (float)sizes.totalHeight * y - (int)sizes.oneSpaceY * (8 - x);
        }
    }
}
