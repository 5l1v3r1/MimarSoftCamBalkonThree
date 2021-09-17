using Core.Entities;
using System.Collections.Generic;

namespace Repository.Entities.DTOs
{
    public class BalconyCalculateDto : IDto
    {
        public int BalconyHeight { get; set; }
        public byte? KolsuzKanatSayisi { get; set; }
        public bool EsikliMi { get; set; }
        public string GlassType { get; set; }
        public int[] ProfileLength { get; set; }
        public int[] GlassCount { get; set; }
        public int[] ProfileAngle { get; set; }
        public IList<string> IndexList { get; set; }
        public string BalkonMalzemeModeli { get; set; }
    }
}