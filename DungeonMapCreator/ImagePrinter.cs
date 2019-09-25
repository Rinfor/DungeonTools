using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMapCreator
{
  public class ImagePrinter
  {
    private Bitmap ResizeImage(Image image, int width, int height)
    {
      Rectangle destRect = new Rectangle(0, 0, width, height);
      Bitmap destImage = new Bitmap(width, height);

      destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

      using (Graphics graphics = Graphics.FromImage(destImage))
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using (ImageAttributes wrapMode = new ImageAttributes())
        {
          wrapMode.SetWrapMode(WrapMode.TileFlipXY);
          graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }
      }
      return destImage;
    }

    //Creates a bitmap from printable
    public Bitmap Print(Printable p)
    {
      Bitmap bmp = new Bitmap(p.Width * p.PxSize, p.Height * p.PxSize);
      if (p.Brush != null)
      {
        using (Graphics graph = Graphics.FromImage(bmp))
        {
          Rectangle ImageSize = new Rectangle(0, 0, p.Width * p.PxSize, p.Height * p.PxSize);
          graph.FillRectangle(p.Brush, ImageSize);
        }
      }
      return bmp;
    }

    //Add a printable to existing bitmap
    public void PrintOnImage(Printable p, Bitmap image)
    {
      using (Graphics graph = Graphics.FromImage(image))
      {
        TextureBrush tBrush = p.Brush as TextureBrush;
        if (tBrush != null)
        {        
          Image imageFromTexture = ((TextureBrush)p.Brush).Image;
          tBrush = new TextureBrush(ResizeImage(imageFromTexture, p.PxSize, p.PxSize));
          for (int i = 0; i < p.Width * p.PxSize; i += p.PxSize)
          {
            for (int j = 0; j < p.Height * p.PxSize; j += p.PxSize)
            {
              Rectangle ImageSize = new Rectangle(p.X * p.PxSize + i, p.Y * p.PxSize + j, tBrush.Image.Width, tBrush.Image.Height);
              graph.FillRectangle(tBrush, ImageSize);
            }
          }
        }
        else
        {
          Rectangle ImageSize = new Rectangle(p.X*p.PxSize, p.Y * p.PxSize, p.Width * p.PxSize, p.Height * p.PxSize);
          graph.FillRectangle(p.Brush, ImageSize);
        }
      }
    }
  }
}
