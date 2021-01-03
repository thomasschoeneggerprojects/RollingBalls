using GameLibCommon.GameSrc.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    public class ScreenDescription
    {
        private ScreenDescription(ScreenSizeInformation info, List<GameObjectDescription> items, string assetNameBackground, TimeSpan timeOut)
        {
            ScreenSizeInformation = info;
            Items = items;
            AssetNameBackground = assetNameBackground;
            TimeOut = timeOut;
        }

        internal TimeSpan TimeOut { get; private set; }

        internal ScreenSizeInformation ScreenSizeInformation { get; private set;}

        internal List<GameObjectDescription> Items { get; private set; }

        internal string AssetNameBackground { get; set; }

        internal static ScreenDescription Create(ScreenSizeInformation info, List<GameObjectDescription> items, string assetNameBackground, TimeSpan timeOut)
        {
            return new ScreenDescription(info, items, assetNameBackground, timeOut);
        }

    }
}
