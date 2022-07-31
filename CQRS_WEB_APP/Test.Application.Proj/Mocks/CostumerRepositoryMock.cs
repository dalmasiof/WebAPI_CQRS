using Application.Persistence.Contracts;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Proj.Mocks
{
    public static class CostumerRepositoryMock
    {
        public static Mock<ICostumerRepository> GetCostumerRepository()
        {
            var costumers = new List<Costumer>()
            {
                new Costumer()
                {
                    BirthDate = DateTime.Parse("1997-12-21"),
                    Email = "dalmasiof@gmail.com",
                    Id = 1,
                    Name = "Dalmasio"
                },
                new Costumer()
                {
                    BirthDate = DateTime.Parse("2007-05-13"),
                    Email = "joaosao291@gmail.com",
                    Id = 2,
                    Name = "Joao Pedro"
                },
            };

            var mockRepo = new Mock<ICostumerRepository>();
            mockRepo.Setup(
                repo => repo.GetListAsync()
            ).ReturnsAsync(costumers);

            mockRepo.Setup(
                repo => repo.Create(It.IsAny<Costumer>())
            ).ReturnsAsync(It.IsAny<Costumer>());

            return mockRepo;


        }
    }
}
