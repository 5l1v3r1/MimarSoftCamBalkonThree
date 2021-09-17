namespace Repository.Business.Logic.Malzeme
{
    public class IsiCamSonPlastik
    {
        public byte YatayBoyu { get; set; } = 28;
        public byte DikeyYukseklik { get; set; } = 43;
        public byte YatayCamDerinligi { get; set; } = 26;// bitim kapağı 26mm baza ölçüsü
        public byte DikeyCamDerinligi { get; set; } = 22;
        public byte YatayCamSonrasiEti { get; set; } = 2;
        public byte DikeyCamSonrasıEti { get; set; } = 21;//21 ölçülen
        public PlastikTipi Tip { get; set; }
    }
}