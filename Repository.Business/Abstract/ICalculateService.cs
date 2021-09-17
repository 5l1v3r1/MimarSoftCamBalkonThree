using Repository.Business.Logic.Geometri;
using Repository.Entities.DTOs;

namespace Repository.Business.Abstract
{
    public interface ICalculateService
    {
        void TrendCalculate(BalconyCalculateDto balconyCalculateDTO);

        void IsiCamCalculate(BalconyCalculateDto balconyCalculateDTO);

        void SurmeSistemCalculate(BalconyCalculateDto balconyCalculateDTO);

        CTipiTuval GetCTipiTuval(BalconyCalculateDto balconyCalculateDTO);
    }
}