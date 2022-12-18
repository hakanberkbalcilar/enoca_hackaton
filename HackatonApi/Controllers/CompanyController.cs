using AutoMapper;
using FluentValidation;
using HackatonApi.Core.DbOperations;
using HackatonApi.Features.CompanyOperations.Commands.CreateCompany;
using HackatonApi.Features.CompanyOperations.Commands.UpdateCompany;
using HackatonApi.Features.CompanyOperations.Queries.GetCompanies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApi.Controllers;

[ApiController]
[Authorize]
[Route("api/Companies")]
public class CompanyController : ControllerBase
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CompanyController(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        GetCompaniesQuery query = new GetCompaniesQuery(_context, _mapper);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateCompany(CreateCompanyModel newCompany)
    {
        CreateCompanyCommand command = new CreateCompanyCommand(_context, _mapper);
        command.Model = newCompany;

        CreateCompanyCommandValidator validator = new CreateCompanyCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(int id, [FromBody] UpdateCompanyModel newCompany)
    {
        UpdateCompanyCommand command = new UpdateCompanyCommand(_context, _mapper);
        command.Id = id;
        command.Model = newCompany;

        UpdateCompanyCommandValidator validator = new UpdateCompanyCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}