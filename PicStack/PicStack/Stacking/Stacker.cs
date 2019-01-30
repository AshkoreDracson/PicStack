using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmapLib;

namespace PicStack
{
    public class Stacker
    {
        public string[] ImportFilenames { get; set; }
        public string ExportFilename { get; set; }
        public int PartAmount { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public MainForm ParentForm { get; }

        public Stacker(MainForm form)
        {
            ParentForm = form;
        }

        public void Process()
        {
            int photosPerPart = ImportFilenames.Length / PartAmount;
            int curIndex = 0;

            RawImage[] parts = new RawImage[PartAmount];

            for (int i = 0; i < PartAmount; i++)
            {
                string[] filenames = new string[photosPerPart];

                for (int j = 0; j < photosPerPart; j++)
                {
                    filenames[j] = ImportFilenames[curIndex++];
                }

                parts[i] = ProcessPart(filenames);
                ParentForm.progressBar.Increment(1);
                
            }

            RawImage finalOutput = new RawImage(Width, Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    RawColor outputColor = new RawColor();

                    for (int i = 0; i < parts.Length; i++)
                    {
                        outputColor += parts[i].RawColors[x, y];
                    }

                    finalOutput.RawColors[x, y] = outputColor;
                }
            }

            FastBitmap finalImage = new FastBitmap(Width, Height);

            for (int y = 0; y < Height; y++)
            {
                Application.DoEvents();

                for (int x = 0; x < Width; x++)
                {
                    finalImage.SetPixel(x, y, (FastColor)finalOutput.RawColors[x, y]);
                }
            }

            finalImage.Save(ExportFilename);
            finalImage.Dispose();
        }

        private RawImage ProcessPart(string[] filenames)
        {
            FastBitmap[] input = new FastBitmap[filenames.Length];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (Bitmap)Image.FromFile(filenames[i]);
            }

            if (Width == 0 || Height == 0) // Assume same image size for all photos
            {
                Width = input[0].Width;
                Height = input[0].Height;
            }

            RawImage output = new RawImage(Width, Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    RawColor outputColor = new RawColor();

                    for (int i = 0; i < input.Length; i++)
                    {
                        outputColor += (RawColor)input[i].GetPixel(x, y);
                    }

                    outputColor /= input.Length;
                    output.RawColors[x, y] = outputColor;
                }

                Application.DoEvents();
            }

            return output;
        }
    }
}