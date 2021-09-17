namespace Repository.Business.Logic.Malzeme
{
    public class GenelSonPlastik
    {
        public byte YatayBoyu { get; set; } = 0;
        public byte DikeyYukseklik { get; set; } = 0;
        public byte YatayCamDerinligi { get; set; } = 0;
        public byte DikeyCamDerinligi { get; set; } = 0;
        public byte YatayCamSonrasiEti { get; set; } = 0;
        public byte DikeyCamSonrasıEti { get; set; } = 0;
        public PlastikTipi Tip { get; set; }
    }
}