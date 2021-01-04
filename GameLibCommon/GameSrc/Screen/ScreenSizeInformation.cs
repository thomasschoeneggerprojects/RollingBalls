using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal class ScreenSizeInformation 
    {
        private ScreenSizeInformation(float width, float height, float widthOuter, float heightOuter, float scaleFactor, Vector2 offset)
        {
            WidhtInnerScreen = width;
            HeightInnerScreen = height;

            WidhtOuterScreen = widthOuter;
            HeightOuterScreen = heightOuter;

            ScaleFactor = scaleFactor;
            OffsetFromOutherScreen = offset;
        }

        public float WidhtInnerScreen { get; }

        public float HeightInnerScreen { get; }
        
        public float WidhtOuterScreen { get; }

        public float HeightOuterScreen { get; }

        public float ScaleFactor { get; }

        public Vector2 OffsetFromOutherScreen { get; }
     

        internal static ScreenSizeInformation Create(float widthInner, float heightInner, float widthOuter, float heightOuter, float scaleFactor, Vector2 offset)
        {
            return new ScreenSizeInformation(widthInner, heightInner, widthOuter, heightOuter, scaleFactor, offset);
        }

    }
}
