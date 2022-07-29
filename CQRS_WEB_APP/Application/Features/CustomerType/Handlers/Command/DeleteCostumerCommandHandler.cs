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
    public class DeleteCostumerCommandHandler : IRequestHandler<DeleteCostumerCommandRequest, bool>
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _map;

        public DeleteCostumerCommandHandler(ICostumerRepository costumerRepository, IMapper map)
        {
            _costumerRepository = costumerRepository;
            _map = map;
        }

        public Task<bool> Handle(DeleteCostumerCommandRequest request, CancellationToken cancellationToken)
        {
            return _costumerRepository.Delete(request.Id);            
        }
    }
}
