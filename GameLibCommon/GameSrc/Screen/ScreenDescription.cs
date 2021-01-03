using GameLibCommon.GameSrc.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    public class ScreenDescription
    {
        private ScreenDescription(ScreenSizeInformation info, List<GameObjectDescription> items, string assetNameBackground)
        {
            ScreenSizeInformation = info;
            Items = items;
            AssetNameBackground = assetNameBackground;
        }

        internal ScreenSizeInformation ScreenSizeInformation { get; private set;}

        internal List<GameObjectDescription> Items { get; private set; }

        internal string AssetNameBackground { get; set; }

        internal static ScreenDescription Create(ScreenSizeInformation info, List<GameObjectDescription> items, string assetNameBackground)
        {
            return new ScreenDescription(info, items, assetNameBackground);
        }

    }
}
