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
