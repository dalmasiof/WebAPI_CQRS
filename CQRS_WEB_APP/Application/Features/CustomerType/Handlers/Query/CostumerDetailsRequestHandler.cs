using Application.DTOs;
using Application.Features.CustomerType.Request.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerType.Handlers.Query
{
    public class CostumerDetailsRequestHandler : IRequestHandler<CostumerDetailsRequest, CostumerDTO>
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _map;

        public CostumerDetailsRequestHandler(ICostumerRepository costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _map = mapper;
        }

        public async Task<CostumerDTO> Handle(CostumerDetailsRequest request, CancellationToken cancellationToken)
        {
            var dbCostumer = await _costumerRepository.GetByIdAsync(request.Id);
            var dbCostumersDTO = _map.Map<CostumerDTO>(dbCostumer);
            return dbCostumersDTO;
        }
    }
}
