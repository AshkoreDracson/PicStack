using System.Drawing;
using FastBitmapLib;

namespace PicStack
{
    public struct RawColor
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public RawColor(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
        public RawColor(byte r, byte g, byte b) : this(r / 255f, g / 255f, b / 255f) { }

        public static RawColor operator +(RawColor a, RawColor b) => new RawColor(a.R + b.R, a.G + b.G, a.B + b.B);
        public static RawColor operator -(RawColor a, RawColor b) => new RawColor(a.R - b.R, a.G - b.G, a.B - b.B);
        public static RawColor operator *(RawColor a, RawColor b) => new RawColor(a.R * b.R, a.G * b.G, a.B * b.B);
        public static RawColor operator /(RawColor a, RawColor b) => new RawColor(a.R / b.R, a.G / b.G, a.B / b.B);

        public static RawColor operator +(RawColor a, float b) => new RawColor(a.R + b, a.G + b, a.B + b);
        public static RawColor operator -(RawColor a, float b) => new RawColor(a.R - b, a.G - b, a.B - b);
        public static RawColor operator *(RawColor a, float b) => new RawColor(a.R * b, a.G * b, a.B * b);
        public static RawColor operator /(RawColor a, float b) => new RawColor(a.R / b, a.G / b, a.B / b);

        public static explicit operator FastColor(RawColor a) => new FastColor((byte)(a.R.Clamp01() * 255), (byte)(a.G.Clamp01() * 255), (byte)(a.B.Clamp01() * 255));
        public static explicit operator RawColor(FastColor a) => new RawColor(a.R, a.G, a.B);
    }
}