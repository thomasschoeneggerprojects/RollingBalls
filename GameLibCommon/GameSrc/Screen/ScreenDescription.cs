using GameLibCommon.GameSrc.Game;
using GameLibCommon.GameSrc.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    public class ScreenDescription
    {
        private ScreenDescription(
            ScreenSizeInformation info, 
            List<GameObjectDescription> items, 
            string assetNameBackground, 
            GameScreenExecutionId id, 
            TimeSpan timeOut)
        {
            ScreenSizeInformation = info;
            Items = items;
            AssetNameBackground = assetNameBackground;
            Id = id;
            TimeOut = timeOut;
        }

        internal GameScreenExecutionId Id { get; private set; }

        internal TimeSpan TimeOut { get; private set; }

        internal ScreenSizeInformation ScreenSizeInformation { get; private set;}

        internal List<GameObjectDescription> Items { get; private set; }

        internal string AssetNameBackground { get; set; }

        internal static ScreenDescription Create(
            ScreenSizeInformation info, 
            List<GameObjectDescription> items, 
            string assetNameBackground, 
            GameScreenExecutionId id, 
            TimeSpan timeOut)
        {
            return new ScreenDescription(info, items, assetNameBackground, id, timeOut);
        }

    }
}
