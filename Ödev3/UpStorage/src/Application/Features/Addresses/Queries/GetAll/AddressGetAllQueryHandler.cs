using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Queries.GetAll
{
    public class AddressGetAllQueryHandler : IRequestHandler<AddressGetAllQuery, List<AddressGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<AddressGetAllDto>> Handle(AddressGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Addresses.AsQueryable();

            dbQuery = dbQuery.Where(x => x.CountryId == request.CountryId);

            dbQuery = dbQuery.Include(x => x.Country);

            var addresses = await dbQuery.ToListAsync(cancellationToken);

            var addressDtos = MapAddressToGetAllDtos(addresses);

            return addressDtos.ToList();
        }

        private IEnumerable<AddressGetAllDto> MapAddressToGetAllDtos(List<Address> addresses)
        {
            List<AddressGetAllDto> addressGetAllDtos = new List<AddressGetAllDto>();

            foreach (var address in addresses)
            {

                yield return new AddressGetAllDto()
                {
                    Name = address.Name,
                    UserId = address.UserId,
                    CountryId = address.CountryId,
                    CityId = address.CityId,
                    District = address.District,
                    PostCode = address.PostCode,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                };
            }
        }

    }
}
