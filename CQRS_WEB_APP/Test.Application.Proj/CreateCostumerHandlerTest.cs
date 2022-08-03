using Application.DTOs;
using Application.Features.CustomerType.Handlers.Command;
using Application.Features.CustomerType.Handlers.Query;
using Application.Features.CustomerType.Request.Command;
using Application.Features.CustomerType.Request.Queries;
using Application.Persistence.Contracts;
using Application.Profiles;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Proj.Mocks;

namespace Test.Application.Proj
{

    public class CreateCostumerHandlerTest
    {
        private readonly IMapper _maper;
        private readonly Mock<ICostumerRepository> _repoMock;

        public CreateCostumerHandlerTest()
        {
            _repoMock = CostumerRepositoryMock.GetCostumerRepository();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _maper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async void GetCostumerList()
        {
            var handler = new CostumerListRequestHandler(_repoMock.Object, _maper);

            var result = await handler.Handle(new CostumerListRequest(), CancellationToken.None);

            result.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async void Costumer_Create_returnNewCostumer()
        {
            var handler = new CreateCostumerRequestHandler(_repoMock.Object, _maper);

            var result = await handler.Handle(new CreateCostumerCommandRequest(){
                costumer = new CostumerDTO()
                {
                    BirthDate = DateTime.Parse("1975-12-04"),
                    Email = "pai@gmail.com",
                    Name="Dalmasio Pai"
                }
            }, CancellationToken.None);

            
            result.ShouldBeOfType<int>();
        }

    }
}
