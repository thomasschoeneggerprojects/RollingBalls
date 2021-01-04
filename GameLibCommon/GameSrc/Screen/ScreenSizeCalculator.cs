using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal static class ScreenSizeCalculator 
    {
        private const float SCALE_FACTOR_SMALL = 1;
        private const float SCALE_FACTOR_MEDIUM = 1.5f;

        private const float SCALE_FACTOR_LARGE = 1.8f;

        private const int WIDHT_SMALL = 500;
        private const int HEIGHT_SMALL = 1000;

        internal static ScreenSizeInformation Calculate(float width, float height)
        {
            if (width/ WIDHT_SMALL > SCALE_FACTOR_LARGE && height/HEIGHT_SMALL > SCALE_FACTOR_LARGE)
            {
                return CreateScreenInfo(WIDHT_SMALL, HEIGHT_SMALL, width, height, SCALE_FACTOR_LARGE,
                    CalculateOffset(width, height, SCALE_FACTOR_LARGE));
            }

            if (width / WIDHT_SMALL > SCALE_FACTOR_MEDIUM && height / HEIGHT_SMALL > SCALE_FACTOR_MEDIUM)
            {
                return CreateScreenInfo(WIDHT_SMALL, HEIGHT_SMALL, width, height, SCALE_FACTOR_MEDIUM,
                    CalculateOffset(width, height, SCALE_FACTOR_MEDIUM));
            }

            if (width < WIDHT_SMALL || height < HEIGHT_SMALL)
            {
                new ArgumentException($"screen size widht:{width}, height:{height} not supported. Device is to small.");
            }

            return CreateScreenInfo(WIDHT_SMALL, HEIGHT_SMALL, width, height, SCALE_FACTOR_SMALL,
                    CalculateOffset(width, height, SCALE_FACTOR_SMALL));
        }

        private static Vector2 CalculateOffset(float width, float height, float scale)
        {
            return new Vector2((width - WIDHT_SMALL * scale) / 2, (height - HEIGHT_SMALL * scale) / 2);
        }


        private static ScreenSizeInformation CreateScreenInfo(float width, float height, float widthOuter, float heightOuter, float scale, Vector2 offsetToOutherScreen)
        {
            var screenInfo = ScreenSizeInformation.Create(width * scale, height * scale, widthOuter, heightOuter, scale, offsetToOutherScreen);
            return screenInfo;
        }

    }
}
