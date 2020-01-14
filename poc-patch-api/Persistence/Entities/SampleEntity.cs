using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc_patch_api.Persistence.Entities
{
    public class SampleEntity
    {
        public Guid Id { get; set; }

        public ConnectionString ConnectionString { get; set; } 
    }
}
