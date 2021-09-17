namespace Repository.Business.Logic.Malzeme
{
    public class KosePlastikDisi : KosePlastik
    {
        public byte YatayBoyu { get; set; } = 36;
        public byte DikeyYukseklik { get; set; } = 43;
        public byte DikeyCamDerinligi { get; set; } = 22;
        public byte YatayCamSonrasiEti { get; set; } = 2;
        public byte DikeyCamSonrasıEti { get; set; } = 21;
        public byte YatayCamDerinligi { get; set; } = 14;
        public byte DigerCamOnuneGelenYer { get; set; } = 10;//ölçülen 9
    }
}