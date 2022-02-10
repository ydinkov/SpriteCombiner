using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SpriteCombiner
{
    class Sprite: IDisposable
    {
        public Image Image { get; }
        public string FileName { get; }
        public int Height { get; }
        public int Width { get; }
        public int XIndex { get; }
        public int YIndex { get; }

        public Point Position => new Point(XIndex * Width, YIndex * Height);
    
        public Sprite(FileInfo file)
        {
            FileName = file.Name;
            XIndex = int.Parse(FileName.Split(".").First().Split("_")[^2]);
            YIndex = int.Parse(FileName.Split(".").First().Split("_")[^1]);
            var stream = file.Open(FileMode.Open);
            Image = Image.FromStream(stream);
            stream.Close();
            Width = Image.Width;
            Height = Image.Height;
        }
        public void Dispose()
        {
            Image.Dispose();
        }
    }
}