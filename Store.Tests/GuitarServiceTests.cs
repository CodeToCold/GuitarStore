using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class GuitarServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithModelNumber_CallsGetAllByModelNumber()
        {
            var guitarRepositoryStub = new Mock<IGuitarRepository>();
            guitarRepositoryStub.Setup(x => x.GetAllByModelNumber(It.IsAny<string>()))
                                            .Returns(new[] { new Guitar("", 1, "", "") });
          
            guitarRepositoryStub.Setup(x => x.GetAllByCompanyOrName(It.IsAny<string>()))
                                            .Returns(new[] { new Guitar("", 2, "", "") });

            var guitarService = new GuitarService(guitarRepositoryStub.Object);
            var validNumber = "NUM 12312-12312";

            var actual = guitarService.GetAllByQuery(validNumber);

            Assert.Collection(actual, guitar => Assert.Equal(1, guitar.Id));
        }

        [Fact]
        public void GetAllByQuery_WithModelName_CallsGetAllByCompanyOrName()
        {
            var guitarRepositoryStub = new Mock<IGuitarRepository>();
            guitarRepositoryStub.Setup(x => x.GetAllByModelNumber(It.IsAny<string>()))
                                            .Returns(new[] { new Guitar("", 1, "", "") });

            guitarRepositoryStub.Setup(x => x.GetAllByCompanyOrName(It.IsAny<string>()))
                                            .Returns(new[] { new Guitar("", 2, "", "") });

            var guitarService = new GuitarService(guitarRepositoryStub.Object);
            var invalidNumber = "12312-12312";

            var actual = guitarService.GetAllByQuery(invalidNumber);

            Assert.Collection(actual, guitar => Assert.Equal(2, guitar.Id));
        }
    }
}
