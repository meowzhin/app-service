using FwksLabs.Libs.Postgres.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Entities;

namespace FwksLabs.ResumeService.Core.Abstractions.Repositories;

public interface ICompetencyRepository : IBaseRepository<int, CompetencyEntity>, ITransacionalRepository;
