using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace unt_bingoo.Class
{
    // Small vector icons for mainForm's menu, drawn with GDI+ primitives
    // instead of an icon font — a wrong/unverified Segoe MDL2 codepoint
    // renders as an empty box on machines without that glyph, so plain
    // shapes are the only option that's guaranteed to look right everywhere.
    public static class MenuIcons
    {
        private const int Size = 16;

        private static Bitmap NewCanvas(out Graphics g)
        {
            var bmp = new Bitmap(Size, Size);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            return bmp;
        }

        public static Bitmap Folder(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, 1, 3, 6, 3);
                g.FillRectangle(brush, 1, 5, 14, 8);
            }
            return bmp;
        }

        public static Bitmap Gear(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                var center = new PointF(8, 8);
                for (int i = 0; i < 8; i++)
                {
                    double angle = i * Math.PI / 4;
                    float x = center.X + (float)Math.Cos(angle) * 6.5f;
                    float y = center.Y + (float)Math.Sin(angle) * 6.5f;
                    g.FillRectangle(brush, x - 1.2f, y - 1.2f, 2.4f, 2.4f);
                }
                g.FillEllipse(brush, 3, 3, 10, 10);
                using (var hole = new SolidBrush(Color.White))
                    g.FillEllipse(hole, 5.5f, 5.5f, 5, 5);
            }
            return bmp;
        }

        public static Bitmap Cart(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.6f))
            using (var brush = new SolidBrush(color))
            {
                var basket = new[]
                {
                    new PointF(2, 3), new PointF(14, 3),
                    new PointF(12, 10), new PointF(4, 10)
                };
                g.DrawPolygon(pen, basket);
                g.FillEllipse(brush, 4, 11, 2.6f, 2.6f);
                g.FillEllipse(brush, 10, 11, 2.6f, 2.6f);
            }
            return bmp;
        }

        public static Bitmap BarChart(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, 2, 9, 3, 5);
                g.FillRectangle(brush, 6.5f, 5, 3, 9);
                g.FillRectangle(brush, 11, 2, 3, 12);
            }
            return bmp;
        }

        public static Bitmap Box(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.6f))
            {
                g.DrawRectangle(pen, 2, 3, 12, 11);
                g.DrawLine(pen, 2, 8.5f, 14, 8.5f);
                g.DrawLine(pen, 8, 3, 8, 6);
            }
            return bmp;
        }

        public static Bitmap Coin(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            using (var innerPen = new Pen(Color.White, 1.4f))
            {
                g.FillEllipse(brush, 2, 2, 12, 12);
                g.DrawLine(innerPen, 8, 5, 8, 11);
                g.DrawLine(innerPen, 5.5f, 6.5f, 10.5f, 6.5f);
            }
            return bmp;
        }

        public static Bitmap Tag(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                var pts = new[]
                {
                    new PointF(2, 6), new PointF(8, 2), new PointF(14, 8),
                    new PointF(8, 14), new PointF(2, 10)
                };
                g.FillPolygon(brush, pts);
                using (var hole = new SolidBrush(Color.White))
                    g.FillEllipse(hole, 4.5f, 5.5f, 2.4f, 2.4f);
            }
            return bmp;
        }

        public static Bitmap Truck(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, 1, 4, 8, 6);
                g.FillRectangle(brush, 9, 6, 5, 4);
                g.FillEllipse(brush, 2.5f, 10.5f, 2.6f, 2.6f);
                g.FillEllipse(brush, 9.5f, 10.5f, 2.6f, 2.6f);
            }
            return bmp;
        }

        public static Bitmap Person(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, 5.5f, 2, 5, 5);
                g.FillPie(brush, 2, 8, 12, 10, 180, 180);
            }
            return bmp;
        }

        public static Bitmap PeopleGroup(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var back = new SolidBrush(Color.FromArgb(140, color)))
            using (var front = new SolidBrush(color))
            {
                g.FillEllipse(back, 7, 2, 4.5f, 4.5f);
                g.FillPie(back, 5, 7, 9, 9, 180, 180);

                g.FillEllipse(front, 2.5f, 3, 5, 5);
                g.FillPie(front, 0.5f, 9, 10, 9, 180, 180);
            }
            return bmp;
        }

        public static Bitmap Shield(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            using (var check = new Pen(Color.White, 1.6f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                var pts = new[]
                {
                    new PointF(8, 1.5f), new PointF(14, 3.5f), new PointF(14, 8),
                    new PointF(8, 14.5f), new PointF(2, 8), new PointF(2, 3.5f)
                };
                g.FillPolygon(brush, pts);
                g.DrawLine(check, 5, 8, 7, 10.5f);
                g.DrawLine(check, 7, 10.5f, 11, 5.5f);
            }
            return bmp;
        }

        public static Bitmap Key(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.DrawEllipse(pen, 1.5f, 5, 6, 6);
                g.DrawLine(pen, 7, 8, 14.5f, 8);
                g.DrawLine(pen, 12, 8, 12, 11);
                g.DrawLine(pen, 14.5f, 8, 14.5f, 10.5f);
            }
            return bmp;
        }

        public static Bitmap Store(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                var roof = new[] { new PointF(1, 6), new PointF(8, 1.5f), new PointF(15, 6) };
                g.FillPolygon(brush, roof);
                g.FillRectangle(brush, 2.5f, 6, 11, 8);
                using (var door = new SolidBrush(Color.White))
                    g.FillRectangle(door, 6.5f, 9.5f, 3, 4.5f);
            }
            return bmp;
        }

        public static Bitmap Bank(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            {
                var roof = new[] { new PointF(1, 5), new PointF(8, 1), new PointF(15, 5) };
                g.FillPolygon(brush, roof);
                g.FillRectangle(brush, 1, 12.5f, 14, 1.5f);
                for (int i = 0; i < 4; i++)
                    g.FillRectangle(brush, 2.5f + i * 3.3f, 6, 1.6f, 6.5f);
            }
            return bmp;
        }

        public static Bitmap ArrowsExchange(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.8f) { EndCap = LineCap.ArrowAnchor })
            {
                g.DrawLine(pen, 2, 5, 12.5f, 5);
                g.DrawLine(pen, 14, 11, 3.5f, 11);
            }
            return bmp;
        }

        public static Bitmap Clock(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.6f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.DrawEllipse(pen, 2, 2, 12, 12);
                g.DrawLine(pen, 8, 8, 8, 4.5f);
                g.DrawLine(pen, 8, 8, 10.8f, 9.5f);
            }
            return bmp;
        }

        public static Bitmap Check(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var brush = new SolidBrush(color))
            using (var pen = new Pen(Color.White, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.FillEllipse(brush, 1.5f, 1.5f, 13, 13);
                g.DrawLine(pen, 4.5f, 8, 7, 10.5f);
                g.DrawLine(pen, 7, 10.5f, 11.5f, 5.5f);
            }
            return bmp;
        }

        public static Bitmap ExitDoor(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.6f) { EndCap = LineCap.ArrowAnchor, StartCap = LineCap.Round })
            {
                g.DrawRectangle(pen, 2, 2, 6, 12);
                g.DrawLine(pen, 6.5f, 8, 14, 8);
            }
            return bmp;
        }

        // Plain stroke, no circle backdrop — for placing on a button that
        // already has its own colored background (unlike Check, which fills
        // its own circle and would be invisible drawn in the same color).
        public static Bitmap CheckMark(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.DrawLine(pen, 2.5f, 8.5f, 6, 12);
                g.DrawLine(pen, 6, 12, 13.5f, 3.5f);
            }
            return bmp;
        }

        public static Bitmap Refresh(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.ArrowAnchor })
            {
                g.DrawArc(pen, 2, 2, 12, 12, -30, 270);
            }
            return bmp;
        }

        public static Bitmap Recipe(Color color)
        {
            var bmp = NewCanvas(out var g);
            using (g)
            using (var pen = new Pen(color, 1.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.DrawRectangle(pen, 3, 1.5f, 10, 13);
                g.DrawLine(pen, 5, 5, 11, 5);
                g.DrawLine(pen, 5, 8, 11, 8);
                g.DrawLine(pen, 5, 11, 9, 11);
            }
            return bmp;
        }
    }
}
