using FwksLabs.Libs.Postgres.Repositories;
using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Entities;

namespace FwksLabs.ResumeService.Infra.Data.Repositories;

internal sealed class EmploymentHistoryRepository(DatabaseContext dbContext) : TransactionalRepository<EmploymentHistoryEntity>(dbContext), IEmploymentHistoryRepository;
