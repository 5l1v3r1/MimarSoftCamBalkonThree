using System.Collections.Generic;

namespace Repository.Business.Logic.Malzeme
{
    public class Toplamlar
    {
        private List<int> kasaProfilBoy;

        public Toplamlar()
        {
            kasaProfilBoy = new List<int>();
        }

        public List<int> KasaProfilBoy
        {
            get { return kasaProfilBoy; }
            set { kasaProfilBoy = value; }
        }

        public int AcilirKolluKapakSayisi { get; set; }
        public int GenisAci135Sayisi { get; set; }
        public int DuzAra180Sayisi { get; set; }
        public int Kose90Sayisi { get; set; }
        public int ToplamPlastikAdet { get; set; }
        public int ToplamTekerAdet { get; set; }
        public int ToplamCamAdet { get; set; }
        public float ToplamCamEni { get; set; }
        public float ToplamCamYukseklik { get; set; }
        public float ToplamCamMetreKaresi { get; set; }
        public float ToplamKasaProfilBoy { get; set; }
        public float BuyukHFitilAdet { get; set; }
        public float KucukhFitilAdet { get; set; }
        public float FitilYukseklik { get; set; }
        public float ProfilYukseklik { get; set; }
        public float AraFitilAdet { get; set; }
        public float DikmeYukseklik { get; set; }
        public float DikmeAdet { get; set; }
        public float SabitUYukseklik { get; set; }
        public byte SabitUAdet { get; set; }
        public byte OrtaKolSayisi { get; set; }
    }
}