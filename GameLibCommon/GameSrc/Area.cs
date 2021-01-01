using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc
{
    internal class Area
    {
        public Area(int width, int height)
        {
            Width = width;
            Height = height;
        }

        internal float Width { get; }
        internal float Height { get; }
    }
}
