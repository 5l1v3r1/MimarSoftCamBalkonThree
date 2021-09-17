using System;
using System.Drawing;

namespace Repository.Business.Logic.Geometri
{
    /// <summary>
    /// Camların Çizilmesi sırasında kullanılan sınıf
    /// </summary>
    internal class CamCizimi
    {
        public int X
        {
            get; set;
        }

        public int Y
        {
            get; set;
        }

        public int Yukseklik
        {
            get; set;
        }

        public int Genislik
        {
            get; set;
        }

        public double Aci
        {
            get; set;
        }

        public CamBilgisi Cam
        {
            get; set;
        }

        public bool genislikGosterilsin = true;
        public bool yukseklikGosterilsin = false;

        public CamCizimi()
        {
        }

        public CamCizimi(CamBilgisi cam, double aci)
        {
            this.Cam = cam;
            X = 0;
            Y = 0;
            Aci = aci;
            Yukseklik = cam.Yukseklik;
            Genislik = cam.Genislik;
        }

        public CamCizimi(CamBilgisi cam, int x, int y, double aci)
        {
            X = x;
            Y = y;
            Aci = aci;
            this.Cam = cam;
            Yukseklik = cam.Yukseklik;
            Genislik = cam.Genislik;
        }

        public CamCizimi(CamBilgisi cam, int x, int y, int genislik, int yukseklik, double aci)
        {
            X = x;
            Y = y;
            Aci = aci;
            Genislik = genislik;
            Yukseklik = yukseklik;
            Cam = cam;
        }

        /// <summary>
        /// Açıya göre ikinci noktanın x ekseninde uzaklığını bulur.
        /// </summary>
        /// <returns>Dörtgenin açıdaki kenar uzunluğu</returns>
        private int Geta()
        {
            return Convert.ToInt32(Genislik * Math.Sin(Raci()));
        }

        /// <summary>
        /// Açıya göre ikinci noktanın y ekseninde uzaklığını bulur.
        /// </summary>
        /// <returns>Dörtgenin açıdaki kenar uzunluğu</returns>
        private int Getb()
        {
            return Convert.ToInt32(Genislik * Math.Cos(Raci()));
        }

        /// <summary>
        /// Derece olarak verilen aciyi radyan olarak döndürür
        /// </summary>
        /// <returns></returns>
        private double Raci()
        {
            return (Math.PI * Aci) / 180.0;
        }

        /// <summary>
        /// Dortgenin kose noktalarının kordinatını döndürür
        /// </summary>
        /// <param name="i">Köşe noktası:1 sol üst köşe,2 sağ üst köşe,3 sağ alt köşe,4 sol alt köşe</param>
        /// <returns>Point tipinde bir nesne döndürür</returns>
        /// <example>Point nokta = koseNoktasi(2);</example>
        public Point KoseNoktasi(int i)
        {
            int A = Geta();
            int B = Getb();

            switch (i)
            {
                case 1: return new Point(X, Y);
                case 2: return new Point(X + A, Y + B);
                case 3: return new Point(X + A, Y + B + Yukseklik);
                case 4: return new Point(X, Y + Yukseklik);
            }

            return new Point(0, 0);
        }

        public int SonrakiBaslangicNoktasiX()
        {
            return X + Convert.ToInt32((Genislik + Panel.SonrakiCamUzakligi) * Math.Sin(Raci()));
        }

        public int SonrakiBaslangicNoktasiX(int deep)
        {
            return X + Convert.ToInt32((Genislik + 1 + deep) * Math.Sin(Raci()));
        }

        public int SonrakiBaslangicNoktasiY(int deep)
        {
            return Y + Convert.ToInt32((Genislik + 1 + deep) * Math.Cos(Raci()));
        }

        public int SonrakiBaslangicNoktasiY()
        {
            return Y + Convert.ToInt32((Genislik + Panel.SonrakiCamUzakligi) * Math.Cos(Raci()));
        }

        public void Draw(Graphics g, Brush brush)
        {
            int A = Geta();
            int B = Getb();

            Point[] pts = new Point[4] {
            new Point(X,Y),
            new Point(X+A,Y+B),
            new Point(X+A,Y+B+Yukseklik),
            new Point(X,Y+Yukseklik)};

            g.FillPolygon(brush, pts);
            g.DrawPolygon(Pens.Black, pts);

            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

            // Genişlik bastırılıyor
            if (this.genislikGosterilsin && this.Cam != null)
            {
                Font font = new Font("Arial", 10);

                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;

                Rectangle rec = new Rectangle(X, Y, Genislik, Yukseklik);
                g.DrawString("G:" + Cam.Genislik.ToString(), font, Brushes.Black, rec, format);
            }

            // Yükseklik bastırılıyor
            if (yukseklikGosterilsin && this.Cam != null)
            {
                g.DrawString(Cam.Yukseklik.ToString(), new Font("Arial", 9), Brushes.Black, X + A + 5, Y + (B + Yukseklik) / 2);
            }

            // Baza Çizidiriliyor
            if (Cam != null && Cam.BazaGenisligi > 0)
            {
                int bazaX = SonrakiBaslangicNoktasiX(-Genislik + 5);
                int bazaY = SonrakiBaslangicNoktasiY(-Genislik + 5);

                CamCizimi baza = new CamCizimi(null, bazaX, bazaY - Panel.StandartBazaYuksekligi / 2,
                                  Yukseklik - 10, Panel.StandartBazaYuksekligi, Aci);
                baza.Draw(g, Brushes.LightGray);
            }
        }
    }
}