using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal class ScreenSizeInformation 
    {
        private ScreenSizeInformation(float width, float height, float scaleFactor)
        {
            Widht = width;
            Height = height;
            ScaleFactor = scaleFactor;
        }

        public float Widht { get; }

        public float Height { get; }

        public float ScaleFactor { get; }

        internal static ScreenSizeInformation Create(float width, float height, float scaleFactor)
        {
            return new ScreenSizeInformation(width, height, scaleFactor);
        }

    }
}
