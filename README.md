# Sprite Combiner

![Icon](SpriteCombiner/spritecombiner.ico)

A small example project used to combine a set of images into a sprite sheet

# Setting up your images

- Your Images must have the same dimensions
- They must follow this naming convention indicating their XY-indexes on the map: 
```cs
$"<FileName>_{xCoordinate}_{yCoordinate}.<filetype>";
```
- put all your imges in the same directory
 
# Download

You can [download latest release](https://github.com/ydinkov/SpriteCombiner/releases/latest) release and start using the application

### 

## OR

# Or Build from source

1. [Download .net sdk](https://dotnet.microsoft.com/en-us/download)
1. Run: ```dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false --output <YOUR OUTPUT DIRECTORY>```
1. Navigate to your output directory and you will find `SpriteCombiner.exe`   
1. Congrats you built it! 🥳


# Running the application

First you need to copy `SpriteCombiner.exe` to the directory coning your sprites

Then, run:
```
SpriteCombiner.exe
```

If your images are same-sized and follow the naming convention, you should have a 'output.png' containing the combined sprite sheet.

# Advanced usage
To customise input an doutput paths and filetypes, use:
```
SpriteCombiner.exe -h
```