namespace PicStack
{
    public struct RawImage
    {
        public int Width { get; }
        public int Height { get; }

        public RawColor[,] RawColors { get; }

        public RawImage(int width, int height)
        {
            Width = width;
            Height = height;

            RawColors = new RawColor[width, height];
        }
    }
}