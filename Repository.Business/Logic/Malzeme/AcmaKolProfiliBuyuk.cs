namespace Repository.Business.Logic.Malzeme
{
    public class AcmaKolProfiliBuyuk : AcmaKolProfil
    {
        public byte YatayBoyu { get; set; } = 64;
        public byte YatayCamSonrasiEti { get; set; } = 20; // 50mm/2
    }
}