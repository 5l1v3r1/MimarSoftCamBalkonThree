using System.Collections.Generic;

namespace Repository.Business.Logic.Geometri
{
    public class AciliCamPanel : CamPanel
    {
        public float Aci { get; set; }
        public float Ilkaci { get; set; } = 0;
        public float ProfilDisBoy { get; set; } = 0;
        public float SonAci { get; set; } = 0;
        public List<AraMalzeme> AraMalzemeler { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public AciliCamPanel(string adi, float yukseklik, float genislik, float aci, float ilkaci, float profilboy, float sonAci, List<AraMalzeme> araMalzemeler)
            : base(adi, yukseklik, genislik)
        {
            Adi = adi;
            Aci = aci;
            Genislik = genislik;
            Yukseklik = yukseklik;
            Ilkaci = ilkaci;
            ProfilDisBoy = profilboy;
            SonAci = sonAci;
            AraMalzemeler = araMalzemeler;
        }
    }
}