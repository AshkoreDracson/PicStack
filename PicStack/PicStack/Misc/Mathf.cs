namespace PicStack
{
    public static class Mathf
    {
        public static float Clamp(this float f, float min, float max)
        {
            if (f < min)
                return min;
            if (f > max)
                return max;
            return f;
        }
        public static float Clamp01(this float f)
        {
            if (f < 0f)
                return 0f;
            if (f > 1f)
                return 1f;
            return f;
        }
    }
}