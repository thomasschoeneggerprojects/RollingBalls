using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal class ScreenSizeInformation 
    {
        private ScreenSizeInformation(float width, float height, float scaleFactor, Vector2 offset)
        {
            WidhtInnerScreen = width;
            HeightInnerScreen = height;
            ScaleFactor = scaleFactor;
            OffsetFromOutherScreen = offset;
        }

        public float WidhtInnerScreen { get; }

        public float HeightInnerScreen { get; }

        public float ScaleFactor { get; }

        public Vector2 OffsetFromOutherScreen { get; }
     

        internal static ScreenSizeInformation Create(float width, float height, float scaleFactor, Vector2 offset)
        {
            return new ScreenSizeInformation(width, height, scaleFactor, offset);
        }

    }
}
