namespace Repository.Business.Logic.Malzeme
{
    public class SonPlastik : Malzeme
    {
        public byte YatayBoyu { get; set; } = 28;
        public byte DikeyYukseklik { get; set; } = 43;
        public byte YatayCamDerinligi { get; set; } = 26;
        public byte DikeyCamDerinligi { get; set; } = 22;
        public byte YatayCamSonrasiEti { get; set; } = 2;
        public byte DikeyCamSonrasıEti { get; set; } = 21;
        public PlastikTipi Tip { get; set; }
    }
}