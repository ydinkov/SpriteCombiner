using System;
using System.CommandLine;
using System.Drawing;
using System.IO;
using System.Linq;
using SpriteCombiner;

var rootCommand = new RootCommand
{
    new Option<DirectoryInfo>(new[]{"-i","--input"},GetCurrent,"Input directory"),
    new Option<FileInfo>(new[]{"-o","--output"},()=>new FileInfo($"{GetCurrent().FullName}/output"),"Output file"),
    new Option<EnumExtensions.EFileFormat>(new[]{"-f","--format"},()=>EnumExtensions.EFileFormat.Png,"The Image Format"),
};

rootCommand.SetHandler(
    (DirectoryInfo directory, FileInfo outputFile, EnumExtensions.EFileFormat format) =>
    {
        var files = directory.GetFiles().Where(x=>x.FullName.EndsWith("png")).ToArray();
        var output = BetterImageCombination(files);
        var outputFilePath = $"{outputFile.FullName.Split(".").First()}.{format.ToString().ToLower()}";
        output.Save(outputFilePath, format.Format());
        output.Dispose();
        Console.WriteLine($"Done writing {outputFilePath.Split("/")}");
    });

rootCommand.Invoke(args);


DirectoryInfo GetCurrent() => new (Directory.GetCurrentDirectory());

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





