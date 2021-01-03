using GameLibCommon.GameSrc.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    public class ScreenSequenceDescription
    {
        private ScreenSequenceDescription(List<ScreenDescription> descriptions)
        {
            ScreenDescriptions = descriptions;
        }

        internal List<ScreenDescription> ScreenDescriptions { get; private set; }

        internal static ScreenSequenceDescription Create(List<ScreenDescription> descriptions)
        {
            return new ScreenSequenceDescription(descriptions);
        }

    }
}
