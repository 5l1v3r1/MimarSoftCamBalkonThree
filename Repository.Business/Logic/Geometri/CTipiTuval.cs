using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace Repository.Business.Logic.Geometri
{
    public class CTipiTuval
    {
        private readonly List<AciliDortgen> Dortgenler;

        public List<AciliCamPanel> Paneller { get; set; }

        public CTipiTuval()
        {
            Paneller = new List<AciliCamPanel>();
            Dortgenler = new List<AciliDortgen>();
        }

        public int Aci { get; set; }

        private bool KusbakisiMi = false;

        private void PanelListesiOlustur(double oran, int startX, int startY)
        {
            Dortgenler.Clear();

            int x = startX;
            int y = startY;
            double aci = Aci;

            foreach (AciliCamPanel item in Paneller)
            {
                aci += item.Aci;
                AciliDortgen dortgen = new AciliDortgen(x, y, Convert.ToInt32(item.Genislik / oran), Convert.ToInt32(KusbakisiMi ? 0 : item.Yukseklik / oran), aci, item);
                Dortgenler.Add(dortgen);
                x = dortgen.GetNextX();
                y = dortgen.GetNextY();
            }

            if (Dortgenler.Count != 0)
                Dortgenler[Dortgenler.Count - 1].YukseklikGoster = false;
        }

        private void Calculate(int width, int height)
        {
            PanelListesiOlustur(1, 0, 0);

            // En noktaları hesaplanıyor
            Point enSolUst = new Point(int.MaxValue, int.MaxValue);
            Point enSagAlt = new Point(int.MinValue, int.MinValue);

            foreach (AciliDortgen item in this.Dortgenler)
            {
                for (int i = 1; i <= 4; i++)
                {
                    Point nokta = item.GetCornerPoint(i);

                    if (nokta.X < enSolUst.X)
                        enSolUst.X = nokta.X;
                    if (nokta.Y < enSolUst.Y)
                        enSolUst.Y = nokta.Y;
                    if (nokta.X > enSagAlt.X)
                        enSagAlt.X = nokta.X;
                    if (nokta.Y > enSagAlt.Y)
                        enSagAlt.Y = nokta.Y;
                }
            }

            int resimGenisligi = enSagAlt.X - enSolUst.X + 1500;
            int resimYuksekligi = enSagAlt.Y - enSolUst.Y + 1500;

            double oranx = (double)resimGenisligi / width;
            double orany = (double)resimYuksekligi / height;
            double oran = (oranx > orany) ? oranx : orany;

            int katkiY = Convert.ToInt32(((enSolUst.Y < 0) ? Math.Abs(enSolUst.Y) + 1000 : 100) / oran);
            int katkiX = Convert.ToInt32((width / 2) - ((resimGenisligi) / 2) / oran);

            PanelListesiOlustur(oran, katkiX, katkiY);
        }

        public Bitmap Draw(int width, int height)
        {
            Calculate(width, height);

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            _ = new LinearGradientBrush(new Point(0, -1 * height), new Point(0, 2 * height), Color.LightBlue, Color.LightGray);
            HatchBrush hb = new HatchBrush(HatchStyle.Percent10, Color.LightSkyBlue, Color.Transparent);

            foreach (AciliDortgen item in Dortgenler)
            {
                item.Draw(g, hb);
            }

            return bmp;
        }

        private int totalnumber = 0;

        public void PrintPreview()
        {
            totalnumber = 0;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Pd_PrintPage);

            pd.Print();// 30 Nisan 2021
            pd.Dispose();// 30 Nisan 2021
        }

        public void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            if (totalnumber == 0 || totalnumber == 2)
            {
                KusbakisiMi = false;
                totalnumber += 1;

                g.DrawString(Paneller[0].Adi, new Font("Arial", 12, FontStyle.Italic), Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y - g.MeasureString("A", new Font("Arial", 12)).Height - 20);

                g.DrawString("                                                                                              Tarih:" + DateTime.Today.ToShortDateString(), new Font("Arial", 12, FontStyle.Italic), Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y - g.MeasureString("A", new Font("Arial", 12)).Height - 20);

                g.DrawString("  Balkon Panel Çizim 1", new Font("Arial", 22), Brushes.Black, new Rectangle(10, 10, e.PageBounds.Width, 50));

                g.DrawRectangle(Pens.Black, new Rectangle(50, 50, 730, 1050));

                Bitmap bmp = Draw(e.MarginBounds.Width, e.MarginBounds.Height * 3 / 7 - 10);//* 2 / 3 //* 3 / 7
                e.Graphics.DrawImage(bmp, e.MarginBounds.X, e.MarginBounds.Y);

                g.DrawString(Nesaj.texr2, new Font("Arial", 8), Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y + e.MarginBounds.Height + 40);

                Font font = new Font("Arial", 12, FontStyle.Bold);
                int y = e.MarginBounds.X + e.MarginBounds.Height * 3 / 7 + 20;//orjinali 2/3
                int x = e.MarginBounds.X;

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                Table.Draw(g, x + 010, y + 20, Paneller.Count + 1, 2, new int[2] { 100, 100 }, font.Height);
                Table.Draw(g, x + 310, y + 20, Paneller.Count + 1, 3, new int[3] { 100, 100, 100 }, font.Height);

                g.DrawString("Camlar", font, Brushes.Black, new RectangleF(x + 10, +y + 20, 100, font.Height), sf);
                g.DrawString("Bazalar", font, Brushes.Black, new RectangleF(x + 110, +y + 20, 100, font.Height), sf);
                g.DrawString("Açılar", font, Brushes.Black, new RectangleF(x + 210, +y + 20, 100, font.Height), sf);

                g.DrawString("İlk Açı", font, Brushes.Black, new RectangleF(x + 310, +y + 20, 100, font.Height), sf);
                g.DrawString("Profil Boy", font, Brushes.Black, new RectangleF(x + 410, +y + 20, 100, font.Height), sf);
                g.DrawString("Son Açı", font, Brushes.Black, new RectangleF(x + 510, +y + 20, 100, font.Height), sf);

                int i2 = 0;
                foreach (AciliCamPanel item in Paneller)
                {
                    i2++;
                    Font fnt = new Font("Arial", 12, FontStyle.Regular);

                    g.DrawString(string.Format("{0:0.##}", item.Baza.Width) + " mm", fnt, Brushes.Black, new RectangleF(x + 10, (y + 20) + i2 * font.Height, 100, font.Height), sf);
                    g.DrawString(string.Format("{0:0.##}", item.Genislik) + " mm", fnt, Brushes.Black, new RectangleF(x + 110, (y + 20) + i2 * font.Height, 100, font.Height), sf);
                    g.DrawString(Paneller[(i2 < Paneller.Count) ? i2 : i2 - 1].Aci + "°", fnt, Brushes.Black, new RectangleF(x + 210, (y + 20) + i2 * font.Height, 100, font.Height), sf);

                    g.DrawString(item.Ilkaci.ToString(), fnt, Brushes.Black, new RectangleF(x + 310, (y + 20) + i2 * font.Height, 100, font.Height), sf);
                    g.DrawString(item.ProfilDisBoy.ToString() + " mm", fnt, Brushes.Black, new RectangleF(x + 410, (y + 20) + i2 * font.Height, 100, font.Height), sf);
                    g.DrawString(item.SonAci.ToString(), fnt, Brushes.Black, new RectangleF(x + 510, (y + 20) + i2 * font.Height, 100, font.Height), sf);
                }

                e.HasMorePages = true;
            }
            else if (totalnumber == 1 || totalnumber == 3)
            {
                KusbakisiMi = true;
                totalnumber += 1;
                Graphics grpchs = e.Graphics;

                grpchs.DrawString(Paneller[0].Adi, new Font("Arial", 12, FontStyle.Italic), Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y - grpchs.MeasureString("A", new Font("Arial", 12)).Height - 20);

                grpchs.DrawString("                                                                                            Tarih:" + DateTime.Today.ToShortDateString(), new Font("Arial", 12, FontStyle.Italic), Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y - grpchs.MeasureString("A", new Font("Arial", 12)).Height - 20);

                grpchs.DrawString("   Balkon Panel Çizim 2", new Font("Arial", 22), Brushes.Black, new Rectangle(10, 10, e.PageBounds.Width, 50));

                grpchs.DrawRectangle(Pens.Black, new Rectangle(50, 50, 730, 1050));

                Bitmap bmp = Draw(e.MarginBounds.Width, e.MarginBounds.Height * 3 / 7 - 10);//* 2 / 3
                e.Graphics.DrawImage(bmp, e.MarginBounds.X, e.MarginBounds.Y);

                grpchs.DrawString(Nesaj.texr2, new Font("Arial", 8), Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y + e.MarginBounds.Height + 40);

                Font font2 = new Font("Arial", 12, FontStyle.Bold);
                int y2 = e.MarginBounds.X + e.MarginBounds.Height * 3 / 7 + 20;//orjinali 2/3
                int x2 = e.MarginBounds.X;

                StringFormat strf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };

                StringFormat stf = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };

                Table.Draw(grpchs, x2 + 110, y2 + 20, Paneller[0].AraMalzemeler.Count + 1, 2, new int[2] { 300, 100 }, font2.Height);

                grpchs.DrawString("Malzeme", font2, Brushes.Black, new RectangleF(x2 + 110, +y2 + 20, 100, font2.Height), strf);
                grpchs.DrawString("Miktar", font2, Brushes.Black, new RectangleF(x2 + 410, +y2 + 20, 100, font2.Height), strf);

                int i = 0;
                for (int s = 0; s < 1; s++)
                {
                    foreach (AraMalzeme araMalzeme in Paneller[0].AraMalzemeler)
                    {
                        i++;
                        Font fnt = new Font("Arial", 12, FontStyle.Regular);
                        grpchs.DrawString(araMalzeme.Key, fnt, Brushes.Black, new RectangleF(x2 + 110, (y2 + 20) + i * font2.Height, 200, font2.Height + 2), strf);
                        grpchs.DrawString(araMalzeme.Value, fnt, Brushes.Black, new RectangleF(x2 + 410, (y2 + 20) + i * font2.Height, 100, font2.Height + 2), stf);
                    }
                }
            }

            KusbakisiMi = false;
        }
    }
}