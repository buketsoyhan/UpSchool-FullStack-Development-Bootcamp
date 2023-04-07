namespace Application.Features.Addresses.Queries.GetAll
{
    public class AddressGetAllQuery
    {
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public AddressGetAllQuery(int countryId, int cityId)
        {
            CountryId = countryId;
            CityId= cityId;
        }
    }
}
