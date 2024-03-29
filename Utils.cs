/**
*  @file      Utils.cs
*  @brief     The utilities for the modpack.
*
*  @author    Evan Elias Young
*  @date      2019-04-16
*  @date      2019-04-27
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

namespace EvanModpack
{
    internal static class Utils
    {

        public static int FrameTime(int seconds)
        {
            return seconds * 60;
        }

        public static int FrameTime(int minutes, int seconds)
        {
            return FrameTime(minutes * 60 + seconds);
        }
    }
}
