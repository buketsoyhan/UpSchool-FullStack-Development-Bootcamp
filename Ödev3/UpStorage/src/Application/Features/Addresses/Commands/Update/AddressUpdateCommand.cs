using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Update
{
    public class AddressUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
