using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;


namespace Engine;


public class Image
{
    public readonly ivec2  size;
    public readonly byte[] pixels;


    public Image(string _name)
    {
        using (Image<Rgba32> _image = SixLabors.ImageSharp.Image.Load<Rgba32>(_name))
        {
            _image.Mutate(_img => _img.Flip(FlipMode.Vertical));
            size   = new ivec2(_image.Width, _image.Height);
            pixels = new byte [size.x * size.y * 4];

            _image.ProcessPixelRows(_pixels =>
            {
                for (int _y = 0, _i = 0; _y < size.y; _y++)
                {
                    System.Span<Rgba32> _row = _pixels.GetRowSpan(_y);
                    for (int _x = 0; _x < size.x; _x++, _i += 4)
                    {
                        Rgba32 _color = _row[_x];
                        
                        pixels[_i + 0] = _color.R;
                        pixels[_i + 1] = _color.G;
                        pixels[_i + 2] = _color.B;
                        pixels[_i + 3] = _color.A;
                    }
                }
            });
        }
    }
    
    
    public void SetPixel(ivec2 _pos, Rgba32 _color)
    {
        int _loc = (_pos.x + _pos.y * size.x) * 4;
        
        pixels[_loc + 0] = _color.R;
        pixels[_loc + 1] = _color.G;
        pixels[_loc + 2] = _color.B;
        pixels[_loc + 3] = _color.A;
    }
}