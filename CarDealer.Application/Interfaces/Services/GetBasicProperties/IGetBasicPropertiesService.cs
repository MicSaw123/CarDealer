using CarDealer.Application.DataTransferObjects.Dtos.GetBasicProperties;

namespace CarDealer.Application.Interfaces.Services.GetBasicProperties
{
    public interface IGetBasicPropertiesService
    {
        public Task<RequestResult<GetBasicPropertiesDto>> GetBasicProperties();
    }
}
