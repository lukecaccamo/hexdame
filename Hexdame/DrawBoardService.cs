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

        public Vector2 boardCenter;

        public List<Vector2> boardSpaceCoordinates;

        //Calculates the coordinates for the board tiles
        public DrawBoardService()
        {
            int halfBoard = 4;
            int numInColumn = 5;
            boardSpaceCoordinates = new List<Vector2>();

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

        public void DrawBoard(SpriteBatch spriteBatch, Texture2D boardSpace)
        {
            for (int i = 0; i < (int)sizes.numberOfSpaces; ++i)
            {
                spriteBatch.Draw(boardSpace, boardSpaceCoordinates[i], Color.SlateGray);
            }
        }

        private float CalculateX(int x)
        {
            return (float)sizes.oneSpaceX * x;
        }

        private float CalculateY(int x, int y)
        {
            if (x <= 4)
                return (float)sizes.totalHeight * y - (int)sizes.oneSpaceY * x;
            return (float)sizes.totalHeight * y - (int)sizes.oneSpaceY * (8 - x);
        }
    }
}
