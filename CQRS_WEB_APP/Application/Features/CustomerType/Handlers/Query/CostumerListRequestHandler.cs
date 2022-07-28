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
    public class CostumerListRequestHandler : IRequestHandler<CostumerListRequest, List<CostumerDTO>>
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _map;

        public CostumerListRequestHandler(ICostumerRepository costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _map = mapper;
        }
        public async Task<List<CostumerDTO>> Handle(CostumerListRequest request, CancellationToken cancellationToken)
        {
            var dbCostumers = await _costumerRepository.GetListAsync();
            var dbCostumersDTO = _map.Map<List<CostumerDTO>>(dbCostumers);
            return dbCostumersDTO;
            
        }
    }
}
