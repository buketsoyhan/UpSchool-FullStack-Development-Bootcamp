using Application.Common.Interfaces;
using Domain.Common;

namespace Application.Features.Addresses.Queries.GetById
{
    public class AddressGetByIdQueryHandler
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressGetByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<Response<int>> Handle(AddressGetByIdQuery request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Id == request.Id);

            if (address is null)
            {
                throw new InvalidOperationException("The address was not found");
            }

        }
    }
}
