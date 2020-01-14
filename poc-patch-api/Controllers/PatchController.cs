using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using poc_patch_api.Models;
using poc_patch_api.Persistence.Repository;

namespace poc_patch_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatchController : ControllerBase
    {
        private readonly ILogger<PatchController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public PatchController(ILogger<PatchController> logger, IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        [HttpPatch("{id:guid}")]
        public ActionResult<PatchRequestModel> Patch(Guid id, [FromBody] JsonPatchDocument<PatchRequestModel> viewModel)
        {
            var entity = _repository.Get(id);
            if (entity == null) return NotFound();

            var entityModel = _mapper.Map<PatchRequestModel>(entity);
            viewModel.ApplyTo(entityModel);

            _mapper.Map(entityModel, entity);
            _repository.SaveChanges(entity);

            return Ok(entityModel);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatchRequestModel>> Get()
        {
            var entities = _repository.GetAll();
            var result = _mapper.Map<IEnumerable<PatchRequestModel>>(entities);

            return Ok(result);
        }
    }
}
