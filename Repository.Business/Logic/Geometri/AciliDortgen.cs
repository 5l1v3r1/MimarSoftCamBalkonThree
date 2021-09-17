using System;
using System.Drawing;

namespace Repository.Business.Logic.Geometri
{
    internal class AciliDortgen
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public double Angle { get; set; }

        public int A { get { return Geta(); } }
        public int B { get { return (int)Getb(); } }

        public CamPanel Panel { get; set; }

        public bool GenislikGoster { get; set; }
        public bool YukseklikGoster { get; set; }

        public AciliDortgen(int x, int y, int width, int height, double angle, CamPanel panel)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Angle = angle;
            Panel = panel;
            GenislikGoster = true;
        }

        private int Geta()
        {
            return Convert.ToInt32(Width * Math.Sin(Raci()));
        }

        private double Getb()
        {
            return Convert.ToInt32(Width * Math.Cos(Raci()));
        }

        private double Raci()
        {
            return Math.PI * Angle / 180.0d;
        }

        public Point GetCornerPoint(int i)
        {
            switch (i)
            {
                case 1: return new Point(X, Y);
                case 2: return new Point(X + A, Y + B);
                case 3: return new Point(X + A, Y + B + Height);
                case 4: return new Point(X, Y + Height);
            }

            return new Point(0, 0);
        }

        public void Draw(Graphics g, Brush brush)
        {
            Point[] pts = new Point[4] {
            new Point(X,Y),
            new Point(X+A,Y+B),
            new Point(X+A,Y+B+Height),
            new Point(X,Y+Height)};

            g.FillPolygon(brush, pts);
            g.DrawPolygon(Pens.Black, pts);

            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

            if (Panel != null && YukseklikGoster)
            {
                g.DrawString(Panel.Yukseklik.ToString(), new Font("Arial", 8), Brushes.Black, X + A + 10, Y + (B + Height) / 2);
            }

            if (Panel != null)
            {
                int bazaX = GetNextX(-Width + 5);
                int bazaY = GetNextY(-Width + 5);

                AciliDortgen baza = new AciliDortgen(bazaX, bazaY - 5, Width - 10, 0, Angle, null);

                baza.Draw(g, Brushes.Bisque);

                Font font = new Font("Pericles Light", 10, FontStyle.Regular, GraphicsUnit.Pixel);

                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;

                //Genişlikleri yazdırıyor
                Rectangle rec = new Rectangle(baza.X - 7, baza.Y - 7, baza.Width, baza.Height);
                g.DrawString(Math.Round(Panel.Baza.Width)
                    .ToString(), font, Brushes.Black, rec, format);

                // Alt bazalar
                baza = new AciliDortgen(bazaX, bazaY + Height - 5, Width - 10, 0, Angle, null);
                baza.Draw(g, Brushes.Bisque);
            }
        }

        public int GetNextX()
        {
            return X + Convert.ToInt32((Width + 5) * Math.Sin(Raci()));
        }

        public int GetNextX(int deep)
        {
            return X + Convert.ToInt32((Width + 1 + deep) * Math.Sin(Raci()));
        }

        public int GetNextY()
        {
            return Y + Convert.ToInt32((Width + 5) * Math.Cos(Raci()));
        }

        public int GetNextY(int deep)
        {
            return Y + Convert.ToInt32((Width + 1 + deep) * Math.Cos(Raci()));
        }
    }
}