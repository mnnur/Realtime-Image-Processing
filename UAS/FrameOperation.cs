using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UAS
{
    internal unsafe static class FrameOperation
    {
        public unsafe static void AddFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)Math.Min(sptr[0] + tptr[0], 255);
                        sptr[1] = (byte)Math.Min(sptr[1] + tptr[1], 255);
                        sptr[2] = (byte)Math.Min(sptr[2] + tptr[2], 255);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void SubtractFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)Math.Max(sptr[0] - tptr[0], 0);
                        sptr[1] = (byte)Math.Max(sptr[1] - tptr[1], 0);
                        sptr[2] = (byte)Math.Max(sptr[2] - tptr[2], 0);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void DifferenceFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)Math.Abs(sptr[0] - tptr[0]);
                        sptr[1] = (byte)Math.Abs(sptr[1] - tptr[1]);
                        sptr[2] = (byte)Math.Abs(sptr[2] - tptr[2]);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void MultiplyFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)((sptr[0] * tptr[0]) / 255.0);
                        sptr[1] = (byte)((sptr[1] * tptr[1]) / 255.0);
                        sptr[2] = (byte)((sptr[2] * tptr[2]) / 255.0);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void AverageFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)((sptr[0] + tptr[0]) / 2);
                        sptr[1] = (byte)((sptr[1] + tptr[1]) / 2);
                        sptr[2] = (byte)((sptr[2] + tptr[2]) / 2);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void CrossFadingFrame(ref Bitmap source, ref Bitmap target, double weight)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)((sptr[0] * weight) + (tptr[0] * (1.0 - weight)));
                        sptr[1] = (byte)((sptr[1] * weight) + (tptr[1] * (1.0 - weight)));
                        sptr[2] = (byte)((sptr[2] * weight) + (tptr[2] * (1.0 - weight)));
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void MinFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)Math.Min(sptr[0], tptr[0]);
                        sptr[1] = (byte)Math.Min(sptr[1], tptr[1]);
                        sptr[2] = (byte)Math.Min(sptr[2], tptr[2]);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void MaxFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)Math.Max(sptr[0], tptr[0]);
                        sptr[1] = (byte)Math.Max(sptr[1], tptr[1]);
                        sptr[2] = (byte)Math.Max(sptr[2], tptr[2]);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void AmplitudeFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)((double)Math.Sqrt(sptr[0] * sptr[0] + tptr[0] * tptr[0]) / Math.Sqrt(2));
                        sptr[1] = (byte)((double)Math.Sqrt(sptr[1] * sptr[1] + tptr[1] * tptr[1]) / Math.Sqrt(2));
                        sptr[2] = (byte)((double)Math.Sqrt(sptr[2] * sptr[2] + tptr[2] * tptr[2]) / Math.Sqrt(2));
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void ANDFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)(sptr[0] & tptr[0]);
                        sptr[1] = (byte)(sptr[1] & tptr[1]);
                        sptr[2] = (byte)(sptr[2] & tptr[2]);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void ORFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)(sptr[0] | tptr[0]);
                        sptr[1] = (byte)(sptr[1] | tptr[1]);
                        sptr[2] = (byte)(sptr[2] | tptr[2]);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }

        public unsafe static void XORFrame(ref Bitmap source, ref Bitmap target)
        {
            if (source.Width != target.Width || source.Height != target.Height)
            {
                throw new ArgumentException("Images must have the same dimensions");
            }

            BitmapData sdata = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData tdata = target.LockBits(new Rectangle(0, 0, target.Width, target.Height),
                                       ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int snWidth = source.Width;
            int tnWidth = target.Width;
            unsafe
            {
                byte* sptr = (byte*)sdata.Scan0;
                byte* tptr = (byte*)tdata.Scan0;

                for (int y = 0; y < sdata.Height; ++y)
                {
                    for (int x = 0; x < snWidth; ++x)
                    {
                        sptr[0] = (byte)(sptr[0] ^ tptr[0]);
                        sptr[1] = (byte)(sptr[1] ^ tptr[1]);
                        sptr[2] = (byte)(sptr[2] ^ tptr[2]);
                        sptr += 3;
                        tptr += 3;
                    }
                    sptr += sdata.Stride - snWidth * 3;
                    tptr += tdata.Stride - tnWidth * 3;
                }
            }
            source.UnlockBits(sdata);
            target.UnlockBits(tdata);
        }
    }
}
