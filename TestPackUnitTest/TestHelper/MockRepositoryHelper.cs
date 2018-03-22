using System;
using System.Linq;
using BusinessService.Entities;
using DataAccess;
using Moq;

namespace TestPackUnitTest
{
    public static class MockRepositoryHelper
    {
        public static void SetupRepository<TEntity>(this Mock<IUnitOfWork<IMbsContext>> unitOfWork, IRepository<TEntity> repository) where TEntity : class
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            unitOfWork.Setup(u => u.GetRepository<TEntity>()).Returns(repository).Verifiable();
        }

        public static void SetupRepositoryGetAll<TEntity>(this Mock<IRepository<TEntity>> repository, params TEntity[] entities) where TEntity : class
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            repository.Setup(r => r.GetAll()).Returns(entities.AsQueryable()).Verifiable();
        }
    }
}