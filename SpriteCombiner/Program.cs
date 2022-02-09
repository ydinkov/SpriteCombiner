using System;
using System.CommandLine;
using System.Drawing;
using System.IO;
using System.Linq;
using SpriteCombiner;

var rootCommand = new RootCommand
{
    //new Option<DirectoryInfo>(new[]{"-i","--input"},"Input directory"),
    //new Option<FileInfo>(new[]{"-o","--output"},"Output file"),
    //new Option<System.Drawing.Imaging.ImageFormat>(new[]{"-f","--format"},"The Image Format"),
};

rootCommand.SetHandler(
    () =>
    {
        var format = System.Drawing.Imaging.ImageFormat.Png;
        var workingDir = new DirectoryInfo(Directory.GetCurrentDirectory());
        var outputPath = $"{workingDir.FullName}/output.{format.ToString().ToLower()}";
        var file = new FileInfo(outputPath);
        var files = workingDir.GetFiles().Where(x=>x.FullName.EndsWith("png")).ToArray();
        var output = BetterImageCombination(files);
        output.Save(file.FullName, format);
        output.Dispose();
        Console.WriteLine("Done");
    });

rootCommand.Invoke(args);

Bitmap BetterImageCombination(FileInfo[] files)
{
    var imgs = files.Select(x => new Sprite(x));
    var imageHeights = imgs.Select(x => x.Height).OrderBy(x=>x).ToArray();
    var width = imgs.Sum(x => x.Width);
    var img3 = new Bitmap(width, imageHeights[^1]);
    var g = Graphics.FromImage(img3);
    g.Clear(Color.Transparent);
    var nIndex = 0;
    foreach (var img in imgs)
    {
        g.DrawImage(img.Image, img.Position);
        img.Dispose();
    }
    g.Dispose();
    return img3;
}





