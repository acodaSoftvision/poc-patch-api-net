using poc_patch_api.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace poc_patch_api.Persistence.Repository
{
    public interface IRepository
    {
        void SaveChanges(SampleEntity entity);

        SampleEntity Get(Guid id);

        IEnumerable<SampleEntity> GetAll();
    }
}
