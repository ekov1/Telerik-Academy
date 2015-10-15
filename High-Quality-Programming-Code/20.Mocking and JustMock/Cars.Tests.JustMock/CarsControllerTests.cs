namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contracts;
    using Mocks;
    using Controllers;
    using Models;
    using Data;
    using Moq;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchingByConditionShouldReturnValidResultWithProperConditionsProvided()
        {
            var mockedData = new Mock<IDatabase>();

            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var carRepo = new CarsRepository(mockedData.Object);

            carRepo.Add(new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            });

            carRepo.Add(new Car
            {
                Id = 17,
                Make = "Mercedes",
                Model = "E-Class",
                Year = 2016
            });

            carRepo.Add(new Car
            {
                Id = 19,
                Make = "Mercedes",
                Model = "Benz",
                Year = 2014
            });

            var carsController = new CarsController(carRepo);
            var result = (List<Car>)carsController.Search("Mercedes").Model;

            var expectedModel = "Mercedes";

            foreach (var entry in result)
            {
                Assert.AreEqual(expectedModel, entry.Make);
            }
        }

        [TestMethod]
        public void SortingByMakeParameterShouldReturnProperView()
        {
            var mockedData = new Mock<IDatabase>();

            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var carRepo = new CarsRepository(mockedData.Object);

            carRepo.Add(new Car
            {
                Id = 12,
                Make = "Lamborghini",
                Model = "Hurricane",
                Year = 2014
            });

            carRepo.Add(new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            });

            carRepo.Add(new Car
            {
                Id = 15,
                Make = "Mercedes",
                Model = "E-Class",
                Year = 2016
            });

            var carsController = new CarsController(carRepo);

            var result = (List<Car>)carsController.Sort("make").Model;

            for (int i = 0; i < result.Count-1; i++)
            {
                if (string.Compare(result[i].Make, result[i].Make) > 0)
                {
                    Assert.Fail("Something happened...");
                }
            }
        }

        [TestMethod]
        public void SortingByYearParameterShouldReturnProperView()
        {
            var mockedData = new Mock<IDatabase>();

            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var carRepo = new CarsRepository(mockedData.Object);

            carRepo.Add(new Car
            {
                Id = 12,
                Make = "Lamborghini",
                Model = "Hurricane",
                Year = 2016
            });

            carRepo.Add(new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2017
            });

            carRepo.Add(new Car
            {
                Id = 15,
                Make = "Mercedes",
                Model = "E-Class",
                Year = 2013
            });

            var carsController = new CarsController(carRepo);

            var result = (List<Car>)carsController.Sort("year").Model;

            for (int i = 0; i < result.Count-1; i++)
            {
                if (result[i].Year < result[i+1].Year)
                {
                    Assert.Fail("The sorting must have failed... or its the test... has to be the latter...");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void SortingByInvalidParameterShouldThrow()
        {
            var mockedData = new Mock<IDatabase>();

            mockedData.Setup(x => x.Cars).Returns(new List<Car>());

            var carRepo = new CarsRepository(mockedData.Object);

            carRepo.Add(new Car
            {
                Id = 12,
                Make = "Lamborghini",
                Model = "Hurricane",
                Year = 2014
            });

            var carsController = new CarsController(carRepo);

            var result = carsController.Sort("id");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FetchingDetailsShouldThrowExceptionWhenCarIsNull()
        {
            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((Car) null);

            var carsController = new CarsController(mockedRepo.Object);
            carsController.Details(42);
        }

        [TestMethod]
        public void CarsControllerShouldInstantiateWithDefaultRepoWithoutThrowing()
        {
            var carsController = new CarsController();
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
