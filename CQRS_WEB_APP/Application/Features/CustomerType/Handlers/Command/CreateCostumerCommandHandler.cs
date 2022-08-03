using Application.Features.CustomerType.Request.Command;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerType.Handlers.Command
{
    public class CreateCostumerRequestHandler : IRequestHandler<CreateCostumerCommandRequest, int>
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _map;

        public CreateCostumerRequestHandler(ICostumerRepository costumerRepository,IMapper map)
        {
            _costumerRepository = costumerRepository;
            _map = map;
        }

        public async Task<int> Handle(CreateCostumerCommandRequest request, CancellationToken cancellationToken)
        {
            var costumerToCreate = _map.Map<Costumer>(request.costumer);
             
            var costumerCreated = await _costumerRepository.Create(costumerToCreate);

            return costumerCreated.Id;

        }
    }
}
