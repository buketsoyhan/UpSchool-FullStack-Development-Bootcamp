﻿using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Update
{
    public class AddressUpdateCommand : IRequest<Response<int>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
    }
}
