using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal static class ScreenSizeCalculator 
    {
        private const float SCALE_FACTOR_SMALL = 1;
        private const float SCALE_FACTOR_MEDIUM = 1.7f;

        private const float SCALE_FACTOR_LARGE = 2;

        private const int WIDHT_SMALL = 500;
        private const int HEIGHT_SMALL = 1000;

        internal static ScreenSizeInformation Calculate(float width, float height)
        {
            if (width/ WIDHT_SMALL > SCALE_FACTOR_LARGE && height/HEIGHT_SMALL > SCALE_FACTOR_LARGE)
            {
                return CreateScreenInfo(WIDHT_SMALL, HEIGHT_SMALL, SCALE_FACTOR_LARGE);
            }
            if (width / WIDHT_SMALL > SCALE_FACTOR_MEDIUM && height / HEIGHT_SMALL > SCALE_FACTOR_MEDIUM)
            {
                return CreateScreenInfo(WIDHT_SMALL, HEIGHT_SMALL, SCALE_FACTOR_MEDIUM);
            }

            if (width < WIDHT_SMALL || height < HEIGHT_SMALL)
            {
                new ArgumentException($"screen size widht:{width}, height:{height} not supported. Device is to small.");
            }

            return CreateScreenInfo(WIDHT_SMALL, HEIGHT_SMALL, SCALE_FACTOR_SMALL);
        }

        private static ScreenSizeInformation CreateScreenInfo(float width, float height, float scale)
        {
            var screenInfo = ScreenSizeInformation.Create(width * scale, height * scale, scale);
            return screenInfo;
        }

    }
}
