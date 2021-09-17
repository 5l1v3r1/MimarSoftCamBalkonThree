namespace Repository.Business.Logic.Geometri
{
    /// <summary>
    /// Camın Yukseklik, genişlik gibi sayısal bilgilerini tutan sınıf
    /// </summary>
    public class CamBilgisi
    {
        public int Yukseklik { get; set; }
        public int Genislik { get; set; }
        public int BazaGenisligi { get; set; }
        public CamKonumu CaminKonumu { get; set; }

        public CamBilgisi()
        {
            Yukseklik = 0;
            Genislik = 0;
            BazaGenisligi = 0;
            CaminKonumu = CamKonumu.Yok;
        }

        public CamBilgisi(int yukseklik, int genislik, CamKonumu camKonumu)
        {
            Yukseklik = yukseklik;
            Genislik = genislik;
            CaminKonumu = camKonumu;
            BazaGenisligi = 0;
        }

        public override string ToString()
        {
            return "Genişlik:" + Genislik + " Yukseklik:" + Yukseklik + " " + CaminKonumu.ToString();
        }
    }
}