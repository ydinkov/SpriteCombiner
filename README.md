# Sprite Combiner

A small example project used to combine a set of images into a sprite sheet

# How to use

## Setting up your images

- Your Images must have the same dimensions
- They must follow this naming convention indicating their XY-indexes on the map: 
```cs
$"<FileName>_{xCoordinate}_{yCoordinate}.<filetype>";
```
- put all your imges in the same directory
 
## Download or Build 

### Download latest release >

### Build from source to a single file

Download .net sdk, then run

```
dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false --output <YOUR OUTPUT DIRECTORY>
```
Navigate to your output directory and you will find `SpriteCombiner.exe`   
## Running the application

First you need to copy `SpriteCombiner.exe` to the directory coning your sprites

Then, run:
```
SpriteCombiner.exe
```

If your images are same-sized and follow the naming convention, you should have a 'output.png' containing the combined sprite sheet.


To customise input an doutput paths and filetypes, use:
```
SpriteCombiner.exe -h
```