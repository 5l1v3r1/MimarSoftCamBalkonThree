namespace Repository.Business.Logic.Geometri
{
    /// <summary>
    ///  Cam Bilgileri ve çizimi ile ilgili sabit bilgileri tutan static sınıf
    /// </summary>
    public static class Panel
    {
        /// <summary>
        /// Bazaların çiziminde kullanılacak pixel cinsinden yükseklik
        /// </summary>
        public static int StandartBazaYuksekligi { get; set; } = 3;// 10 pixel

        public static int SonrakiCamUzakligi { get; set; } = 10;// 5
    }
}