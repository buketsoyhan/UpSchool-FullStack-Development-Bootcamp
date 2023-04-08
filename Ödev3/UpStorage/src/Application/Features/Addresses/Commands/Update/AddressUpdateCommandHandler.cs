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
            
        }
    }
}