using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Input
{
    internal interface IInputDataProvider
    {
        InputInformation Update();
    }
}
