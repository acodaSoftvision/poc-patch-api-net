using poc_patch_api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace poc_patch_api.Persistence.Repository
{
    public class Repository : IRepository
    {
        private IEnumerable<SampleEntity> sampleEntities;

        public Repository()
        {
            sampleEntities = Initialize();
        }

        public IEnumerable<SampleEntity> GetAll()
        {
            return this.sampleEntities;
        }

        public SampleEntity Get(Guid id)
        {
            return this.sampleEntities.Where(e => e.Id == id).FirstOrDefault();
        }
        
        public void SaveChanges(SampleEntity entityModified)
        {
            var entity = this.sampleEntities.Where(e => e.Id == entityModified.Id).FirstOrDefault();
            if (entity != null)
            {
                entity = entityModified;
            }
        }

        private IEnumerable<SampleEntity> Initialize()
        {
            return new List<SampleEntity>()
        {
            new SampleEntity
            {
                ConnectionString = new ConnectionString
                {
                    Message = string.Empty,
                    Status = "Submitted"
                },
                Id = new Guid("ada148bb-71d4-449c-b813-d867e1567ec6")
            },

            new SampleEntity
            {
                ConnectionString = new ConnectionString
                {
                    Message = "I was approved!",
                    Status = "Approved"
                },
                Id = new Guid("1ef08b1d-fb76-4aa2-8abd-bd9dfd6e486f")
            },

            new SampleEntity
            {
                ConnectionString = new ConnectionString
                {
                    Message = "I was rejected",
                    Status = "Rejected"
                },
                Id = new Guid("bbdb06e2-dc27-447a-8d86-1f89575ed33d")
            },

            new SampleEntity
            {
                ConnectionString = new ConnectionString
                {
                    Message = string.Empty,
                    Status = "Submitted"
                },
                Id = new Guid("96b9e9e9-ce3c-4150-9e4f-c06210356631")
            },
        };
        }
    }
}
