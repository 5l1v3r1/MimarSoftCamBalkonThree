namespace Repository.Business.Logic.Geometri
{
    public class CamPanel
    {
        public string Adi { get; set; }
        public double Yukseklik { get; set; }
        public double Genislik { get; set; }
        public Sizies Baza { get; set; }

        public CamPanel(string adi, double yukseklik, double genislik)
        {
            Adi = adi;
            Yukseklik = yukseklik;
            Genislik = genislik;
        }
    }
}