using Application.DTOs;
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
    public class UpdateCostumerCommandHandler : IRequestHandler<UpdateCostumerCommandRequest, CostumerDTO>
    {
        private readonly ICostumerRepository _costumerRepositry;
        private readonly IMapper _map;

        public UpdateCostumerCommandHandler(ICostumerRepository costumerRepositry,IMapper map)
        {
            _costumerRepositry = costumerRepositry;
            _map = map;
        }

        public async Task<CostumerDTO> Handle(UpdateCostumerCommandRequest request, CancellationToken cancellationToken)
        {
            var costumerToUpdate = _map.Map<Costumer>(request.costumer);

            var costumorUpdated = _map.Map<CostumerDTO>(
            await _costumerRepositry.Update(costumerToUpdate)
            );
            return costumorUpdated;
        }
    }
}
