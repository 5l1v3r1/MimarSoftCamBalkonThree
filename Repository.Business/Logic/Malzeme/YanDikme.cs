namespace Repository.Business.Logic.Malzeme
{
    public class YanDikme : Malzeme
    {
        private readonly DikmeTipi _Tip;

        public YanDikme(DikmeTipi Tip)
        {
            _Tip = Tip;
        }

        public byte AlinacakDeger { get; set; } = 25;

        public int Kalinlik
        {
            get
            {
                if (_Tip == DikmeTipi.iki_lik)
                {
                    return 22;
                }
                else
                {
                    return 12;
                }
            }
        }
    }
}