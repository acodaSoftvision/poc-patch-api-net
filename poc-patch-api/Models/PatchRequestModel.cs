using System;
using System.Collections.Generic;

namespace poc_patch_api.Models
{
    public class PatchRequestModel
    {
        public Guid Id { get; set; } 

        public ConnectionStringModel ConnectionString { get; set; }
    }
}
