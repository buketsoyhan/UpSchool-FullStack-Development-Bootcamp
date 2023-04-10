using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Update
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<Response<int>> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Id == request.Id);

            if (address is null)
            {
                throw new InvalidOperationException("The address was not found");
            }
            else
            {
                address.Name= request.Name;
                address.CountryId= request.CountryId;
                address.CityId= request.CityId;
                address.District= request.District;
                address.PostCode= request.PostCode;
                address.AddressLine1= request.AddressLine1;
                address.AddressLine2= request.AddressLine2;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new Response<int>("This address was successfully updated.");
            }
        }
    }
}