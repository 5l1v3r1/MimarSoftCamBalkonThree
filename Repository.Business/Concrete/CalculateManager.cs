using Repository.Business.Abstract;
using Repository.Business.Logic.Geometri;
using Repository.Business.Logic.Malzeme;
using Repository.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Business.Concrete
{
    public class CalculateManager : ICalculateService
    {
        public CalculateManager()
        {
        }

        private readonly List<AraMalzeme> araMalzemeler = new List<AraMalzeme>();
        private readonly Toplamlar toplamlar = new Toplamlar();
        private List<AciliCamPanel> AciliListesi = new List<AciliCamPanel>();
        private BazaDerinlikveAraMesafeler bazaDerinlikveAraMesafeler = new BazaDerinlikveAraMesafeler();
        private List<float> CamEnList = new List<float>();
        private readonly List<float> BazaList = new List<float>();

        public void Temizle()
        {
            BazaList.Clear();
            AciliListesi.Clear();
            araMalzemeler.Clear();
            CamEnList.Clear();
            if (bazaDerinlikveAraMesafeler.AraMesafeler != null)
            {
                bazaDerinlikveAraMesafeler.AraMesafeler.Clear();
            }
            if (bazaDerinlikveAraMesafeler.BazaDerinlikler != null)
            {
                bazaDerinlikveAraMesafeler.BazaDerinlikler.Clear();
            }
            if (toplamlar.KasaProfilBoy != null)
            {
                toplamlar.KasaProfilBoy.Clear();
            }

            toplamlar.ToplamCamAdet = 0;
            toplamlar.ProfilYukseklik = 0;
            toplamlar.Kose90Sayisi = 0;
            toplamlar.KucukhFitilAdet = 0;
            toplamlar.OrtaKolSayisi = 0;
            toplamlar.SabitUAdet = 0;
            toplamlar.SabitUYukseklik = 0;
            toplamlar.ToplamCamAdet = 0;
            toplamlar.ToplamCamEni = 0;
            toplamlar.ToplamCamMetreKaresi = 0;
            toplamlar.ToplamCamYukseklik = 0;
            toplamlar.ToplamKasaProfilBoy = 0;
            toplamlar.ToplamPlastikAdet = 0;
            toplamlar.ToplamTekerAdet = 0;
            toplamlar.GenisAci135Sayisi = 0;
            toplamlar.FitilYukseklik = 0;
            toplamlar.DuzAra180Sayisi = 0;
            toplamlar.DikmeYukseklik = 0;
            toplamlar.DikmeAdet = 0;
            toplamlar.BuyukHFitilAdet = 0;
            toplamlar.AraFitilAdet = 0;
            toplamlar.AcilirKolluKapakSayisi = 0;
        }

        public void TrendCalculate(BalconyCalculateDto balconyCalculateDTO)
        {
            Temizle();
            if (balconyCalculateDTO != null)
            {
                toplamlar.ToplamCamYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 180;
                toplamlar.FitilYukseklik = toplamlar.ToplamCamYukseklik - 46;
                toplamlar.DikmeYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 130;

                bazaDerinlikveAraMesafeler = GetTrendCamEnleriveMesafeler(balconyCalculateDTO);

                CamEnList = GetCamEnList(bazaDerinlikveAraMesafeler.AraMesafeler, balconyCalculateDTO);

                DoldurBazaList(bazaDerinlikveAraMesafeler, CamEnList);

                for (int i = 0; i < balconyCalculateDTO.ProfileLength.Length; i++)
                {
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[i]));
                }

                araMalzemeler.Add(new AraMalzeme(" Sistem H Yüksekliği", balconyCalculateDTO.BalconyHeight + "   mm  "));
                for (int i = 0; i < toplamlar.KasaProfilBoy.Count; i++)
                {
                    araMalzemeler.Add(new AraMalzeme(" " + (i + 1) + " . Alt ve Üst Kasa Profil Boyu", toplamlar.KasaProfilBoy[i] + "   mm  "));
                    toplamlar.ToplamKasaProfilBoy += toplamlar.KasaProfilBoy[i] * 2;
                }
                araMalzemeler.Add(new AraMalzeme(" Toplam Kasa Profili Boyu", string.Format("{0:0.##}", toplamlar.ToplamKasaProfilBoy / 1000) + "    mt  "));
                araMalzemeler.Add(new AraMalzeme(" Yan Dikme Yüksekliği", toplamlar.DikmeYukseklik + "   mm  "));
                araMalzemeler.Add(new AraMalzeme(" Fitil Yüksekliği", toplamlar.FitilYukseklik + "   mm  "));
                araMalzemeler.Add(new AraMalzeme(" Büyük H Fitil Adet", toplamlar.BuyukHFitilAdet + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Küçük h Fitil Adet", toplamlar.KucukhFitilAdet + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" 22,5 Fitil Adet", toplamlar.GenisAci135Sayisi * 2 + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" 90 Köşe Fitil Adet", toplamlar.Kose90Sayisi * 2 + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Açılır Kol Takımı", toplamlar.AcilirKolluKapakSayisi + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Plastik Adet", toplamlar.ToplamPlastikAdet + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Teker Adet", toplamlar.ToplamTekerAdet + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam Adet", toplamlar.ToplamCamAdet + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam En", string.Format("{0:0.##}", toplamlar.ToplamCamEni / 1000) + "    mt  "));
                araMalzemeler.Add(new AraMalzeme(" Cam Yükseklik", toplamlar.ToplamCamYukseklik + "   mm  "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam m²", string.Format("{0:0.##}", toplamlar.ToplamCamMetreKaresi) + "    m²  "));
            }
        }

        public void IsiCamCalculate(BalconyCalculateDto balconyCalculateDTO)
        {
            Temizle();
            if (balconyCalculateDTO != null)
            {
                toplamlar.DikmeYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 135;
                toplamlar.ToplamCamYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 195;
                toplamlar.ProfilYukseklik = toplamlar.ToplamCamYukseklik + 42;

                bazaDerinlikveAraMesafeler = GetIsiCamliCamEnleriveMesafeler(balconyCalculateDTO);

                CamEnList = GetCamEnList(bazaDerinlikveAraMesafeler.AraMesafeler, balconyCalculateDTO);

                DoldurBazaList(bazaDerinlikveAraMesafeler, CamEnList);

                for (int i = 0; i < balconyCalculateDTO.ProfileLength.Length; i++)
                {
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[i]));
                }

                araMalzemeler.Add(new AraMalzeme(" Sistem H Yüksekliği", balconyCalculateDTO.BalconyHeight + "   mm  "));
                for (int i = 0; i < toplamlar.KasaProfilBoy.Count; i++)
                {
                    araMalzemeler.Add(new AraMalzeme(" " + (i + 1) + ". Alt ve Üst Kasa Profil Boyu", toplamlar.KasaProfilBoy[i] + "   mm  "));
                    toplamlar.ToplamKasaProfilBoy += (toplamlar.KasaProfilBoy[i] + toplamlar.KasaProfilBoy[i]);
                }
                araMalzemeler.Add(new AraMalzeme(" Toplam Kasa Profili Boyu", string.Format("{0:0.##}", toplamlar.ToplamKasaProfilBoy / 1000) + "    mt  "));

                araMalzemeler.Add(new AraMalzeme(" Yan Dikme Yüksekliği", toplamlar.DikmeYukseklik + "   mm  "));
                araMalzemeler.Add(new AraMalzeme(" Profil Yüksekliği", toplamlar.ProfilYukseklik + "   mm  "));

                araMalzemeler.Add(new AraMalzeme(" Ara Çıta", toplamlar.Kose90Sayisi + toplamlar.AcilirKolluKapakSayisi + toplamlar.DuzAra180Sayisi * 2 + toplamlar.GenisAci135Sayisi * 2 + 2 + "  adet  "));//2 duvar tarafları için
                araMalzemeler.Add(new AraMalzeme(" 135° Profil Adet", toplamlar.GenisAci135Sayisi * 2 + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" 90° Köşe Profil Adet", toplamlar.Kose90Sayisi + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Açılır Kol Takımı", toplamlar.AcilirKolluKapakSayisi + "  adet  "));

                araMalzemeler.Add(new AraMalzeme(" Toplam Cam Adet", toplamlar.ToplamCamAdet + "  adet  "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam En", string.Format("{0:0.##}", toplamlar.ToplamCamEni / 1000) + "    mt  "));
                araMalzemeler.Add(new AraMalzeme(" Cam Yükseklik", toplamlar.ToplamCamYukseklik + "   mm  "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam m²", string.Format("{0:0.##}", toplamlar.ToplamCamMetreKaresi) + "    m²  "));
            }
        }

        public void SurmeSistemCalculate(BalconyCalculateDto balconyCalculateDTO)
        {
            Temizle();
            if (balconyCalculateDTO != null)
            {
                int profilAdet = balconyCalculateDTO.ProfileLength.Length;

                toplamlar.SabitUYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 30;
                toplamlar.DikmeAdet = 2;
                if (balconyCalculateDTO.EsikliMi)//0 eşikli true
                {
                    toplamlar.ToplamCamYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 190;
                    toplamlar.FitilYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 48;
                }
                else if (!balconyCalculateDTO.EsikliMi)//eşiksiz false
                {
                    if (balconyCalculateDTO.GlassType == "8mm cam")
                    {
                        toplamlar.ToplamCamYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 167;
                    }
                    else if (balconyCalculateDTO.GlassType == "Isı Camlı")
                    {
                        toplamlar.ToplamCamYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 165;
                    }

                    toplamlar.FitilYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 10;
                }

                toplamlar.DikmeYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight);
                toplamlar.SabitUYukseklik = Convert.ToSingle(balconyCalculateDTO.BalconyHeight) - 30;

                bazaDerinlikveAraMesafeler = GetSurmeSistemCamEnleriveMesafeler(balconyCalculateDTO);

                CamEnList = GetCamEnList(bazaDerinlikveAraMesafeler.AraMesafeler, balconyCalculateDTO);

                DoldurBazaList(bazaDerinlikveAraMesafeler, CamEnList);

                if (profilAdet == 1)
                {
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[0].ToString()) - 26);
                }
                else if (profilAdet == 2)
                {
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[0].ToString()) - 13);
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[1].ToString()) - 13);
                }
                else if (profilAdet == 3)
                {
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[0].ToString()) - 13);
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[1].ToString()));
                    toplamlar.KasaProfilBoy.Add(Convert.ToInt32(balconyCalculateDTO.ProfileLength[2].ToString()) - 13);
                }

                toplamlar.AraFitilAdet = toplamlar.DuzAra180Sayisi * 2;

                araMalzemeler.Add(new AraMalzeme(" Sistem H Yüksekliği", balconyCalculateDTO.BalconyHeight + " mm "));
                for (int i = 0; i < toplamlar.KasaProfilBoy.Count; i++)
                {
                    araMalzemeler.Add(new AraMalzeme(" " + (i + 1) + ". Alt ve Üst Kasa Profil Boyu", toplamlar.KasaProfilBoy[i] + " mm "));
                    toplamlar.ToplamKasaProfilBoy += toplamlar.KasaProfilBoy[i] * 2;
                }
                araMalzemeler.Add(new AraMalzeme(" Toplam Kasa Profili Boyu", toplamlar.ToplamKasaProfilBoy / 1000 + " mt "));
                araMalzemeler.Add(new AraMalzeme(" Yan Dikme Yüksekliği", toplamlar.DikmeYukseklik + " mm "));
                araMalzemeler.Add(new AraMalzeme(" U Profil Yükseklik", toplamlar.SabitUYukseklik + " mm "));
                araMalzemeler.Add(new AraMalzeme(" U Profil Adet", toplamlar.DikmeAdet + toplamlar.Kose90Sayisi * 2 + " adet "));
                araMalzemeler.Add(new AraMalzeme(" Ara Fitil Yüksekliği", toplamlar.FitilYukseklik + " mm "));
                araMalzemeler.Add(new AraMalzeme(" Ara Fitil Adet", toplamlar.AraFitilAdet + " adet "));

                araMalzemeler.Add(new AraMalzeme(" Tutamak Fitil Yüksekliği", toplamlar.FitilYukseklik + " mm "));
                araMalzemeler.Add(new AraMalzeme(" Tutamak Fitil Adet", toplamlar.OrtaKolSayisi * 2 + toplamlar.Kose90Sayisi * 2 + toplamlar.DikmeAdet + " adet "));

                araMalzemeler.Add(new AraMalzeme(" 45° Köşe Adet", toplamlar.Kose90Sayisi * 2 + " adet "));

                araMalzemeler.Add(new AraMalzeme(" Ara Adaptör Yüksekliği", toplamlar.FitilYukseklik + " mm "));
                araMalzemeler.Add(new AraMalzeme(" Ara Adaptör Adet", toplamlar.OrtaKolSayisi + " adet "));

                araMalzemeler.Add(new AraMalzeme(" Toplam Cam Adet", toplamlar.ToplamCamAdet + " adet "));
                araMalzemeler.Add(new AraMalzeme(" Cam Yükseklik", toplamlar.ToplamCamYukseklik + " mm "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam En", toplamlar.ToplamCamEni / 1000 + " mt "));
                araMalzemeler.Add(new AraMalzeme(" Toplam Cam m²", string.Format("{0:0.##}", toplamlar.ToplamCamMetreKaresi) + " m² "));
            }
        }

        public BazaDerinlikveAraMesafeler GetTrendCamEnleriveMesafeler(BalconyCalculateDto balconyCalculateDTO)
        {
            TrendYanDikme2 trendYanDikme2 = new TrendYanDikme2();
            TrendSonPlastik trendSonPlastik = new TrendSonPlastik();
            TrendDuzAra trendDuzAra = new TrendDuzAra();
            Trend225 trend_22_5 = new Trend225();
            Trend225Disi trend_22_5_Disi = new Trend225Disi();
            Trend225Erkek trend_22_5_Erkek = new Trend225Erkek();
            Trend45 trend_45 = new Trend45();
            Trend45Disi trend_45_Disi = new Trend45Disi();
            Trend45Erkek trend_45_Erkek = new Trend45Erkek();
            TrendAcilirKanatDarIkinci trendAcilirKanatDarIkinci = new TrendAcilirKanatDarIkinci();
            TrendAcilirKanatGenisBirinci trendAcilirKanatGenisBirinci = new TrendAcilirKanatGenisBirinci();

            List<float> tumAraMesafeler = new List<float>();
            List<float> tumAraBazaDerinlikleri = new List<float>();

            List<int> checklilerBytes = new List<int>();

            string[] strDizi = balconyCalculateDTO.IndexList.First() != null ? balconyCalculateDTO.IndexList.First().Split(',') : "".Split(',');
            foreach (string item in strDizi)
            {
                if (item != "")
                {
                    checklilerBytes.Add(Convert.ToInt32(item) + 1);
                }
            }

            List<float> tumAcilar = GetTumAcilar(balconyCalculateDTO);
            bool dahaOnceKullanildiMi90 = false;
            for (byte i = 0; i < tumAcilar.Count; i++)
            {
                float araAci = tumAcilar[i];
                if (araAci > 0 && araAci < 180)
                {
                    araAci = 180 - araAci;
                }

                if (checklilerBytes.Contains(i))
                {// Açılır Kollu Kanat Gelecek
                    tumAraMesafeler.Add(trendAcilirKanatGenisBirinci.CamArasi);
                    tumAraMesafeler.Add(trendAcilirKanatDarIkinci.CamArasi);
                    tumAraBazaDerinlikleri.Add(0);
                    tumAraBazaDerinlikleri.Add(0);
                    toplamlar.AcilirKolluKapakSayisi += 1;
                }
                else
                {// Açılara göre ara plastik kapaklar gelecek
                    if (157.5f < araAci && 180 >= araAci || araAci > 0 && 45 >= araAci || -157.5f > araAci && araAci > -180 || -45 <= araAci && araAci < 0)
                    {// Düz ara plastik kapak                       180
                        tumAraMesafeler.Add(trendDuzAra.CamArasi);
                        tumAraMesafeler.Add(trendDuzAra.CamArasi);
                        tumAraBazaDerinlikleri.Add(trendDuzAra.YatayCamDerinligi);
                        tumAraBazaDerinlikleri.Add(trendDuzAra.YatayCamDerinligi);
                        toplamlar.DuzAra180Sayisi += 1;
                    }
                    else if (112.5f <= araAci && araAci <= 157.5f || -112.5f >= araAci && araAci >= -157.5f)
                    {// Geniş açı ara plastik gelecek 135 derece    135
                        tumAraMesafeler.Add(trend_22_5.CamArasi);
                        tumAraMesafeler.Add(trend_22_5.CamArasi);
                        tumAraBazaDerinlikleri.Add(trend_22_5_Disi.YatayCamDerinligi);
                        tumAraBazaDerinlikleri.Add(trend_22_5_Erkek.YatayCamDerinligi);
                        toplamlar.GenisAci135Sayisi += 1;
                    }
                    else if (45 < araAci && araAci < 112.5f || -45 > araAci && araAci > -112.5f)//
                    {// Köşe ara plastik kapak                       90
                        tumAraMesafeler.Add(trend_45.CamArasi);
                        tumAraMesafeler.Add(trend_45.CamArasi);
                        if (dahaOnceKullanildiMi90 && araAci > 0 || araAci < 0 && !dahaOnceKullanildiMi90)
                        {
                            tumAraBazaDerinlikleri.Add(trend_45_Erkek.YatayCamDerinligi);
                            tumAraBazaDerinlikleri.Add(trend_45_Disi.YatayCamDerinligi);
                        }
                        else
                        {
                            tumAraBazaDerinlikleri.Add(trend_45_Disi.YatayCamDerinligi);
                            tumAraBazaDerinlikleri.Add(trend_45_Erkek.YatayCamDerinligi);
                        }
                        dahaOnceKullanildiMi90 = !dahaOnceKullanildiMi90;
                        toplamlar.Kose90Sayisi += 1;
                    }
                    else if (araAci == 0)
                    {// Bitim plastik kapağı                          0
                        tumAraMesafeler.Add(trendYanDikme2.DuvarArasi);
                        tumAraBazaDerinlikleri.Add(trendSonPlastik.YatayCamDerinligi);
                    }
                }
            }

            for (int i = 0; i < tumAraBazaDerinlikleri.Count; i++)
            {// Açılır kollu kapak yönünü ayarlıyoruz
                if (tumAraBazaDerinlikleri[i] == 0 && tumAraBazaDerinlikleri[i + 1] == 0)
                {
                    if (tumAraBazaDerinlikleri[i - 1] > tumAraBazaDerinlikleri[i + 2])
                    {
                        tumAraBazaDerinlikleri[i] = trendAcilirKanatGenisBirinci.YatayCamCikintisi;
                        tumAraBazaDerinlikleri[i + 1] = trendAcilirKanatDarIkinci.YatayCamCikintisi;
                    }
                    else
                    {
                        tumAraBazaDerinlikleri[i + 1] = trendAcilirKanatGenisBirinci.YatayCamCikintisi;
                        tumAraBazaDerinlikleri[i] = trendAcilirKanatDarIkinci.YatayCamCikintisi;
                    }
                    i++;
                }
            }

            bazaDerinlikveAraMesafeler = new BazaDerinlikveAraMesafeler
            {
                AraMesafeler = tumAraMesafeler,
                BazaDerinlikler = tumAraBazaDerinlikleri
            };

            toplamlar.BuyukHFitilAdet = toplamlar.DuzAra180Sayisi - Convert.ToInt32(balconyCalculateDTO.KolsuzKanatSayisi);
            toplamlar.KucukhFitilAdet = (toplamlar.DuzAra180Sayisi - toplamlar.BuyukHFitilAdet) * 2;

            return bazaDerinlikveAraMesafeler;
        }

        public BazaDerinlikveAraMesafeler GetIsiCamliCamEnleriveMesafeler(BalconyCalculateDto balconyCalculateDTO)
        {
            List<float> tumAraMesafeler = new List<float>();
            List<float> tumAraBazaDerinlikleri = new List<float>();

            List<int> checklilerBytes = new List<int>();

            string[] strDizi = balconyCalculateDTO.IndexList.First() != null ? balconyCalculateDTO.IndexList.First().Split(',') : "".Split(',');
            foreach (string item in strDizi)
            {
                if (item != "")
                {
                    checklilerBytes.Add(Convert.ToInt32(item) + 1);
                }
            }

            List<float> tumAcilar = GetTumAcilar(balconyCalculateDTO);
            for (byte i = 0; i < tumAcilar.Count; i++)
            {
                float araAci = tumAcilar[i];
                if (araAci > 0 && araAci < 180)
                {
                    araAci = 180 - araAci;
                }

                if (checklilerBytes.Contains(i))
                {// Açılır Kollu Kanat Gelecek
                    tumAraMesafeler.Add(22.5f);
                    tumAraMesafeler.Add(22.5f);
                    tumAraBazaDerinlikleri.Add(10);
                    tumAraBazaDerinlikleri.Add(10);
                    toplamlar.AcilirKolluKapakSayisi += 1;
                }
                else
                {// Açılara göre ara plastik kapaklar gelecek
                    if (157.5f < araAci && 180 >= araAci || araAci > 0 && 45 >= araAci || -157.5f > araAci && araAci > -180 || -45 <= araAci && araAci < 0)
                    {// Düz ara plastik kapak                       180
                        tumAraMesafeler.Add(7.5f);
                        tumAraMesafeler.Add(7.5f);
                        tumAraBazaDerinlikleri.Add(10);
                        tumAraBazaDerinlikleri.Add(10);
                        toplamlar.DuzAra180Sayisi += 1;
                    }
                    else if (112.5f <= araAci && araAci <= 157.5f || -112.5f >= araAci && araAci >= -157.5f)
                    {// Geniş açı ara plastik gelecek 135 derece    135
                        tumAraMesafeler.Add(26);
                        tumAraMesafeler.Add(26);
                        tumAraBazaDerinlikleri.Add(10);
                        tumAraBazaDerinlikleri.Add(10);
                        toplamlar.GenisAci135Sayisi += 1;
                    }
                    else if (45 < araAci && araAci < 112.5f || -45 > araAci && araAci > -112.5f)//
                    {// Köşe ara plastik kapak                       90
                        tumAraMesafeler.Add(45);
                        tumAraMesafeler.Add(45);
                        tumAraBazaDerinlikleri.Add(10);
                        tumAraBazaDerinlikleri.Add(10);
                        toplamlar.Kose90Sayisi += 1;
                    }
                    else if (araAci == 0)
                    {// Bitim plastik kapağı                          0
                        tumAraMesafeler.Add(29);
                        tumAraBazaDerinlikleri.Add(10);
                    }
                }
            }

            bazaDerinlikveAraMesafeler = new BazaDerinlikveAraMesafeler
            {
                AraMesafeler = tumAraMesafeler,
                BazaDerinlikler = tumAraBazaDerinlikleri
            };

            toplamlar.BuyukHFitilAdet = toplamlar.DuzAra180Sayisi - Convert.ToInt32(balconyCalculateDTO.KolsuzKanatSayisi);
            toplamlar.KucukhFitilAdet = (toplamlar.DuzAra180Sayisi - toplamlar.BuyukHFitilAdet) * 2;
            return bazaDerinlikveAraMesafeler;
        }

        public BazaDerinlikveAraMesafeler GetSurmeSistemCamEnleriveMesafeler(BalconyCalculateDto balconyCalculateDTO)
        {
            List<float> tumAraMesafeler = new List<float>();
            List<float> tumAraBazaDerinlikleri = new List<float>();

            List<int> checklilerBytes = new List<int>();

            string[] strDizi = balconyCalculateDTO.IndexList.First() != null ? balconyCalculateDTO.IndexList.First().Split(',') : "".Split(',');
            foreach (string item in strDizi)
            {
                if (item != "")
                {
                    checklilerBytes.Add(Convert.ToInt32(item) + 1);
                }
            }

            List<float> tumAcilar = GetTumAcilar(balconyCalculateDTO);
            for (byte i = 0; i < tumAcilar.Count; i++)
            {
                float araAci = tumAcilar[i];
                if (araAci > 0 && araAci < 180)
                {
                    araAci = 180 - araAci;
                }

                if (checklilerBytes.Contains(i))
                {// Methodumuz değişti
                    tumAraMesafeler.Add(40);
                    tumAraMesafeler.Add(40);
                    tumAraBazaDerinlikleri.Add(12.5f);
                    tumAraBazaDerinlikleri.Add(12.5f);
                    toplamlar.OrtaKolSayisi += 1;
                }
                else
                {// Açılara göre ara plastik kapaklar gelecek
                    if (157.5f < araAci && 180 >= araAci || araAci > 0 && 45 >= araAci || -157.5f > araAci && araAci > -180 || -45 <= araAci && araAci < 0)
                    {// Düz ara plastik kapak                       180
                        tumAraMesafeler.Add(3);
                        tumAraMesafeler.Add(3);
                        tumAraBazaDerinlikleri.Add(12.5f);
                        tumAraBazaDerinlikleri.Add(12.5f);
                        toplamlar.DuzAra180Sayisi += 1;
                    }
                    else if (112.5f <= araAci && araAci <= 157.5f || -112.5f >= araAci && araAci >= -157.5f)
                    {// Geniş açı ara plastik gelecek 135 derece    135
                        tumAraMesafeler.Add(0);
                        tumAraMesafeler.Add(0);
                        tumAraBazaDerinlikleri.Add(0);
                        tumAraBazaDerinlikleri.Add(0);
                        toplamlar.GenisAci135Sayisi += 1;
                    }
                    else if (45 < araAci && araAci < 112.5f || -45 > araAci && araAci > -112.5f)//
                    {// Köşe ara plastik kapak                       90
                        tumAraMesafeler.Add(80);
                        tumAraMesafeler.Add(80);
                        tumAraBazaDerinlikleri.Add(12.5f);
                        tumAraBazaDerinlikleri.Add(12.5f);
                        toplamlar.Kose90Sayisi += 1;
                    }
                    else if (araAci == 0)
                    {// Bitim plastik kapağı                          0
                        tumAraMesafeler.Add(80);
                        tumAraBazaDerinlikleri.Add(12.5f);
                    }
                }
            }

            bazaDerinlikveAraMesafeler = new BazaDerinlikveAraMesafeler
            {
                AraMesafeler = tumAraMesafeler,
                BazaDerinlikler = tumAraBazaDerinlikleri
            };
            return bazaDerinlikveAraMesafeler;
        }

        public List<float> GetCamEnList(List<float> tumAraMesafeler, BalconyCalculateDto balconyCalculateDTO)
        {
            List<float> camBasinaDusenFire = new List<float>();

            int toplamCamSayisi = 0;
            int camAdet;
            float profBoy;

            for (int i = 0; i < tumAraMesafeler.Count; i += 2)
            {
                camBasinaDusenFire.Add(tumAraMesafeler[i] + tumAraMesafeler[i + 1]);
            }

            foreach (int item in balconyCalculateDTO.GlassCount)
            {
                toplamCamSayisi += item;
            }

            for (int i = 0; i < balconyCalculateDTO.GlassCount.Length; i++)
            {
                camAdet = Convert.ToInt32(balconyCalculateDTO.GlassCount[i]);
                profBoy = Convert.ToSingle(balconyCalculateDTO.ProfileLength[i]);
                float fireAraToplam = 0;
                for (int t = 0; t < camAdet; t++)
                {
                    fireAraToplam += camBasinaDusenFire[t];
                }
                for (int t = camAdet - 1; t >= 0; t--)
                {
                    camBasinaDusenFire.RemoveAt(t);
                }

                float toplamCcamEni = profBoy - fireAraToplam;
                float camEn = toplamCcamEni / camAdet;

                for (int t = 0; t < camAdet; t++)
                {
                    CamEnList.Add(camEn);
                }
            }

            toplamlar.ToplamCamAdet = toplamCamSayisi;
            toplamlar.ToplamCamEni = CamEnList.Sum();
            toplamlar.ToplamPlastikAdet = toplamCamSayisi * 4;
            toplamlar.ToplamTekerAdet = toplamCamSayisi * 4;
            toplamlar.ToplamCamMetreKaresi = toplamlar.ToplamCamEni * toplamlar.ToplamCamYukseklik / 1000000;

            return CamEnList;
        }

        public void DoldurBazaList(BazaDerinlikveAraMesafeler bazaDerinlikveAraMesafeler, List<float> CamEnList)
        {
            for (int i = 0; i < bazaDerinlikveAraMesafeler.BazaDerinlikler.Count; i += 2)
            {
                BazaList.Add(CamEnList[i / 2] - bazaDerinlikveAraMesafeler.BazaDerinlikler[i] - bazaDerinlikveAraMesafeler.BazaDerinlikler[i + 1]);
            }
        }

        public List<decimal> GetAcilar(BalconyCalculateDto balconyCalculateDTO)
        {
            List<decimal> tumAcilar = new List<decimal>();
            byte y = 0;
            int sira = -1;
            tumAcilar.Add(0);
            foreach (int item in balconyCalculateDTO.GlassCount)
            {
                sira++;
                for (int x = 1; x < item; x++)
                {
                    sira++;
                    tumAcilar.Add(0);
                }
                if (balconyCalculateDTO.GlassCount.Length > y + 1)
                {
                    tumAcilar.Add(Convert.ToDecimal(balconyCalculateDTO.ProfileAngle[y].ToString()));
                }
                y++;
            }
            tumAcilar.Add(0);
            return tumAcilar;
        }

        public List<float> GetTumAcilar(BalconyCalculateDto balconyCalculateDTO)
        {
            List<float> tumAcilar = new List<float>();
            byte y = 0;
            int sira = -1;
            tumAcilar.Add(0);
            foreach (int item in balconyCalculateDTO.GlassCount)
            {
                sira++;
                for (int x = 1; x < item; x++)
                {
                    sira++;
                    tumAcilar.Add(180);
                }
                if (balconyCalculateDTO.GlassCount.Length > y + 1)
                {
                    tumAcilar.Add(Convert.ToSingle(balconyCalculateDTO.ProfileAngle[y]));
                }
                y++;
            }
            tumAcilar.Add(0);
            return tumAcilar;
        }

        public List<AciliCamPanel> GetAciliCamPanelList(BalconyCalculateDto balconyCalculateDTO, List<float> CamEnList)
        {
            AciliListesi.Clear();

            List<float> ilkAcilar = new List<float>();
            List<float> sonAcilar = new List<float>();
            ilkAcilar.Add(0);
            if (balconyCalculateDTO.ProfileAngle != null)
            {
                foreach (var item in balconyCalculateDTO.ProfileAngle)
                {
                    float yarisi = (item / 2);
                    sonAcilar.Add(yarisi);
                    ilkAcilar.Add(yarisi);
                }
            }
            sonAcilar.Add(0);

            List<int> camTotal = new List<int>();
            int toplam = 0;
            for (int i = 0; i < balconyCalculateDTO.GlassCount.Length; i++)
            {
                toplam += Convert.ToInt32(balconyCalculateDTO.GlassCount[i]);
                camTotal.Add(Convert.ToInt32(balconyCalculateDTO.GlassCount[i]));
            }
            toplamlar.ToplamCamAdet = toplam;// Genel ToplamCamAdet değişkeni
            List<decimal> tumAcilar = GetAcilar(balconyCalculateDTO);
            for (int i = 0; i < toplam; i++)
            {
                float boy = Convert.ToSingle(CamEnList[i].ToString());
                float aci = Convert.ToInt32(tumAcilar[i + 1]);
                float ilkaci = 0;
                float parca = 0;
                float sonaci = 0;
                for (int r = 0; r < balconyCalculateDTO.ProfileLength.Length; r++)
                {
                    if (i + r < balconyCalculateDTO.ProfileLength.Length)
                    {
                        ilkaci = Convert.ToSingle(ilkAcilar[r + i]);
                        parca = Convert.ToSingle(balconyCalculateDTO.ProfileLength[r + i]);
                        sonaci = Convert.ToSingle(sonAcilar[r + i]);
                        break;
                    }
                }
                AciliCamPanel acim = new AciliCamPanel("", Convert.ToInt32(balconyCalculateDTO.BalconyHeight), boy, aci, ilkaci, parca, sonaci, araMalzemeler);

                AciliListesi.Add(acim);
            }

            return AciliListesi;
        }

        public CTipiTuval GetCTipiTuval(BalconyCalculateDto balconyCalculateDTO)
        {
            AciliListesi = GetAciliCamPanelList(balconyCalculateDTO, CamEnList);
            CTipiTuval ctt = new CTipiTuval();

            float yukseklik = toplamlar.ToplamCamYukseklik;

            for (int i = 0; i < BazaList.Count; i++)
            {
                float genislik = Convert.ToSingle(BazaList[i]);
                float aci;
                float ilkaci = AciliListesi[i].Ilkaci;
                float profboy = AciliListesi[i].ProfilDisBoy;
                float sonaci = AciliListesi[i].SonAci;

                if (i == 0)
                    aci = 30;
                else
                    aci = Convert.ToInt32(AciliListesi[i - 1].Aci);
                AciliCamPanel yacp = new AciliCamPanel(balconyCalculateDTO.BalkonMalzemeModeli + " " + toplamlar.AcilirKolluKapakSayisi + " kollu", yukseklik, genislik, aci, ilkaci, profboy, sonaci, araMalzemeler)
                {
                    Baza = new Sizies(Convert.ToSingle(CamEnList[i]), 0)
                };
                ctt.Paneller.Add(yacp);
            }
            return ctt;
        }
    }
}