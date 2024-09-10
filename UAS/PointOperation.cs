using System.Drawing.Imaging;

namespace UAS
{
    internal static class PointOperation
    {
        public static unsafe void Brightness(ref Bitmap img, in int k)
        {
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                                           ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int nWidth = data.Width;  // Access only data.Width pixels per row
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        int bVal = (ptr[0] + k > 255) ? 255 : ptr[0] + k;
                        int gVal = (ptr[1] + k > 255) ? 255 : ptr[1] + k;
                        int rVal = (ptr[2] + k > 255) ? 255 : ptr[2] + k;
                        ptr[0] = (byte)bVal; // b
                        ptr[1] = (byte)gVal; // g
                        ptr[2] = (byte)rVal; // r
                        ptr += 3;  // Increment by 3 bytes for next pixel
                    }
                    ptr += data.Stride - nWidth * 3;  // Move to next row based on stride
                }
            }

            img.UnlockBits(data);
        }

        public static unsafe void Invert(ref Bitmap img)
        {
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                                           ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int nWidth = data.Width;  // Access only data.Width pixels per row
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        int bVal = 255 - ptr[0];
                        int gVal = 255 - ptr[1];
                        int rVal = 255 - ptr[2];
                        ptr[0] = (byte)bVal; // b
                        ptr[1] = (byte)gVal; // g
                        ptr[2] = (byte)rVal; // r
                        ptr += 3;  // Increment by 3 bytes for next pixel
                    }
                    ptr += data.Stride - nWidth * 3;  // Move to next row based on stride
                }
            }

            img.UnlockBits(data);
        }

        public static unsafe void Grayscale(ref Bitmap img)
        {
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int nWidth = data.Width;  // Access only data.Width pixels per row
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        int sum = (ptr[0] + ptr[1] + ptr[2]) / 3;
                        ptr[0] = (byte)sum; // b
                        ptr[1] = (byte)sum; // g
                        ptr[2] = (byte)sum; // r
                        ptr += 3;  // Increment by 3 bytes for next pixel
                    }
                    ptr += data.Stride - nWidth * 3;  // Move to next row based on stride
                }
            }

            img.UnlockBits(data);
        }

        public static unsafe void Thresholding(ref Bitmap img, in int k)
        {
            BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int nWidth = data.Width;  // Access only data.Width pixels per row
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < data.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        int gray = (ptr[0] + ptr[1] + ptr[2]) / 3;
                        int newVal = (gray < k) ? 0 : 255;
                        ptr[0] = (byte)newVal; // b
                        ptr[1] = (byte)newVal; // g
                        ptr[2] = (byte)newVal; // r
                        ptr += 3;  // Increment by 3 bytes for next pixel
                    }
                    ptr += data.Stride - nWidth * 3;  // Move to next row based on stride
                }
            }
            img.UnlockBits(data);
        }
    }
}
