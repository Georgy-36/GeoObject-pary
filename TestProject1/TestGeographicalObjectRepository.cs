using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GeoObjectModel.Domain;

namespace TestProject1
{
    public class TestGeographicalObjectRepository
    {
        [Fact]

        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var geoObjectRepository = testHelper.GeographicalObjectRepository;
            GeographicalObject geographicalObject = new GeographicalObject();
            Guid geoObjectId = Guid.NewGuid();
            geographicalObject.Id = geoObjectId;
            geographicalObject.GeoNameId = 111;
            geographicalObject.UpdatedTime = DateTime.Now;
            geographicalObject.CreationTime = DateTime.Now;

            /*Guid guidVersion1 = Guid.NewGuid();
            GeographicalObjectVersion geographicalObjectVersion1 = new GeographicalObjectVersion();
            geographicalObjectVersion1.Id = guidVersion1;
            geographicalObjectVersion1.FullName = "A1";
            geographicalObjectVersion1.ShortName = "1";
            geographicalObjectVersion1.AuthoritativeKnowledgeSource = "X";
            geographicalObjectVersion1.LanguageCode = "111";
            geographicalObjectVersion1.Language = "Ru";
            geographicalObjectVersion1.Status = GeoObjectStatus.Current;
            geographicalObjectVersion1.ArchiveTime = DateTime.Now;
            geographicalObjectVersion1.UpdateTime = DateTime.Now;
            geographicalObjectVersion1.CreationTime = DateTime.Now;
            geographicalObjectVersion1.CommonInfo = "CI1";
            geographicalObjectVersion1.Version = 1;

            Guid guidVersion2 = Guid.NewGuid();
            GeographicalObjectVersion geographicalObjectVersion2 = new GeographicalObjectVersion();
            geographicalObjectVersion2.Id = guidVersion2;
            geographicalObjectVersion2.FullName = "B2";
            geographicalObjectVersion2.ShortName = "2";
            geographicalObjectVersion2.AuthoritativeKnowledgeSource = "Y";
            geographicalObjectVersion2.LanguageCode = "222";
            geographicalObjectVersion2.Language = "UK";
            geographicalObjectVersion2.Status = GeoObjectStatus.In_process_of_generation;
            geographicalObjectVersion2.ArchiveTime = DateTime.Now;
            geographicalObjectVersion2.UpdateTime = DateTime.Now;
            geographicalObjectVersion2.CreationTime = DateTime.Now;
            geographicalObjectVersion2.CommonInfo = "CI2";
            geographicalObjectVersion2.Version = 2;*/


            GeographicalObject childObject1 = new GeographicalObject();
            Guid child1Id = new Guid("00000000-0001-0000-0000-000000000000");
            childObject1.Id = child1Id;
            childObject1.GeoNameId = 222;
            

            geoObjectRepository.AddAsync(childObject1).Wait();

            ParentChildObjectLink childObjectLink1 = new ParentChildObjectLink();
            childObjectLink1.Id = new Guid("00000000-0002-0000-0000-000000000000");
            childObjectLink1.ParentGeographicalObjectName = "P2";
            childObjectLink1.ChildGeographicalObjectName = "C2";
            childObjectLink1.CompletelyIncludedFlag = true;
            childObjectLink1.IncludedPercent = 30.0;
            childObjectLink1.CreationDateTime = DateTime.Now;
            childObjectLink1.LastUpdatedDateTime = DateTime.Now;
            childObjectLink1.GeographicalObjectChildId = new Guid("00000000-0001-0000-0000-000000000000");
            childObjectLink1.GeographicalObjectChild = childObject1;
            childObjectLink1.GeographicalObjectParent = geographicalObject;
            

            //geographicalObject.GeographicalObjectVersions.Add(geographicalObjectVersion1);
            //geographicalObject.GeographicalObjectVersions.Add(geographicalObjectVersion2);
            
            geographicalObject.ChildGeographicalObjects.Add(childObjectLink1);
            
            geoObjectRepository.AddAsync(geographicalObject).Wait();

            Assert.NotNull(geoObjectRepository.GetByIdAsync(child1Id));
            Assert.Equal(geoObjectId, geoObjectRepository.GetByIdAsync(geoObjectId).Result.Id);
            Assert.Equal(child1Id, geoObjectRepository.GetByIdAsync(child1Id).Result.Id);
            Assert.Equal(30.0, geoObjectRepository.GetByIdAsync(geoObjectId).Result.ChildGeographicalObjects[0].IncludedPercent);
            Assert.Equal(new Guid("00000000-0002-0000-0000-000000000000"), geoObjectRepository.GetByIdAsync(geoObjectId).Result.ChildGeographicalObjects[0].Id);
            Assert.Equal(111, geoObjectRepository.GetByIdAsync(child1Id).Result.GeoNameId);
            
        }
    }
}

