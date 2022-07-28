﻿using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerType.Request.Queries
{
    public class CostumerListRequest : IRequest<List<CostumerDTO>>
    {
    }
}
