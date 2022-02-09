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

### Build from source

Download .net sdk, then run

```
dotnet publish
```
   
## Copy exe into the directory of your images

call
```
SpriteCombiner.exe
```
from your terminal