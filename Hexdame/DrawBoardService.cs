using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            maxSpacesInColumn = 9
        }

        private float calculateX(int x)
        {
            return (float)sizes.oneSpaceX * x;
        }

        private float calculateY(int x, int y)
        {
            if (x <= 4)
                return (float)sizes.totalHeight * y + (int)sizes.oneSpaceY * (8 - x);
            return (float)sizes.totalHeight * y + (int)sizes.oneSpaceY * x;
        }

        public void DrawBoard(SpriteBatch spriteBatch, Texture2D boardSpace)
        {
            spriteBatch.Begin();

            int minSpacesInColumn = 5;

            for (int x = 0; x < (int)sizes.maxSpacesInColumn; ++x)
            {

                for (int y = 0; y < minSpacesInColumn; ++y)
                {
                    spriteBatch.Draw(boardSpace, new Vector2(calculateX(x), calculateY(x, y)), Color.SlateGray);


                }

                if (minSpacesInColumn < (int)sizes.maxSpacesInColumn)
                    minSpacesInColumn++;
                else
                    minSpacesInColumn--;
            }


            spriteBatch.End();
        }



    }
}
