using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerType.Request.Command
{
    public class CreateCostumerCommand : IRequest<int>
    {
        public CostumerDTO costumer { get; set; }
    }
}
