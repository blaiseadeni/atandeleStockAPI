﻿using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Models;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepenseController : ControllerBase
    {
        private readonly IDepense _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public DepenseController(IDepense repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Depense>> Add([FromBody] DepenseMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Depense>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Depense>> Update(Guid id, [FromBody] DepenseMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.Montant = request.Montant;
            query.Beneficiaire = request.Beneficiaire;
            query.Motif = request.Motif;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Depense>> FindAll()
        {
            var items = await _repository.FindAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Find(Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }

    }
}
