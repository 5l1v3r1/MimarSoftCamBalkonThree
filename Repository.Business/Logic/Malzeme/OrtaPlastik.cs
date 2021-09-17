namespace Repository.Business.Logic.Malzeme
{
    public class OrtaPlastik : Malzeme
    {
        public byte AlinacakDeger { get; set; } = 5;
        public byte YatayBoyu { get; set; } = 10;
        public byte DikeyYukseklik { get; set; } = 43;
        public byte YatayCamDerinligi { get; set; } = 8;
        public byte DikeyCamDerinligi { get; set; } = 22;
        public byte YatayCamSonrasiEti { get; set; } = 2;
        public byte DikeyCamSonrasıEti { get; set; } = 21;
        public PlastikTipi Tip { get; set; }
    }
}