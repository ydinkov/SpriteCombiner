using System;

namespace SpriteCombiner
{
    public static class EnumExtensions
    {
        public enum EFileFormat
        {
            Bmp,
            Emf,
            Exif,
            Gif,
            //Icon,
            Jpeg,
            //MemoryBmp,
            Png,
            Tiff,
            Wmf,
        }
        
        public static System.Drawing.Imaging.ImageFormat Format(this EFileFormat format) =>
            format switch
            {
                EFileFormat.Bmp => System.Drawing.Imaging.ImageFormat.Bmp,
                EFileFormat.Emf => System.Drawing.Imaging.ImageFormat.Emf,
                EFileFormat.Exif => System.Drawing.Imaging.ImageFormat.Exif,
                EFileFormat.Gif => System.Drawing.Imaging.ImageFormat.Gif,
                //EFileFormat.Icon => System.Drawing.Imaging.ImageFormat.Icon,
                EFileFormat.Jpeg => System.Drawing.Imaging.ImageFormat.Jpeg,
                //EFileFormat.MemoryBmp => System.Drawing.Imaging.ImageFormat.MemoryBmp,
                EFileFormat.Png => System.Drawing.Imaging.ImageFormat.Png,
                EFileFormat.Tiff => System.Drawing.Imaging.ImageFormat.Tiff,
                EFileFormat.Wmf => System.Drawing.Imaging.ImageFormat.Wmf,
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
    }
}