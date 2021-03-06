﻿using IntegrationTests.Infrastructure;
using MongoDbGenericRepository.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class UpdateTestsDocument : Document
    {
        public UpdateTestsDocument()
        {
            Version = 2;
        }
        public string SomeContent { get; set; }
    }

    public class UpdateTests : BaseMongoDbRepositoryTests<UpdateTestsDocument>
    {
        [Test]
        public void UpdateOne()
        {
            // Arrange
            var document = CreateTestDocument();
            SUT.AddOne(document);
            document.SomeContent = "UpdateOneContent";
            // Act
            var result = SUT.UpdateOne(document);
            // Assert
            Assert.IsTrue(result);
            var updatedDocument = SUT.GetById<UpdateTestsDocument>(document.Id);
            Assert.IsNotNull(updatedDocument);
            Assert.AreEqual("UpdateOneContent", updatedDocument.SomeContent);
        }

        [Test]
        public async Task UpdateOneAsync()
        {
            // Arrange
            var document = CreateTestDocument();
            SUT.AddOne(document);
            document.SomeContent = "UpdateOneAsyncContent";
            // Act
            var result = await SUT.UpdateOneAsync(document);
            // Assert
            Assert.IsTrue(result);
            var updatedDocument = SUT.GetById<UpdateTestsDocument>(document.Id);
            Assert.IsNotNull(updatedDocument);
            Assert.AreEqual("UpdateOneAsyncContent", updatedDocument.SomeContent);
        }
    }
}
