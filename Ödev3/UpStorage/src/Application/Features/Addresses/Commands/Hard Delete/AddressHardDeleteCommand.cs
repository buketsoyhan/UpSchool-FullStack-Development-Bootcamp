using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Commands.Hard_Delete
{
    public class AddressHardDeleteCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
