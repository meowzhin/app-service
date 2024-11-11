using FwksLabs.Libs.Postgres.Repositories;
using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Entities;

namespace FwksLabs.ResumeService.Infra.Data.Repositories;

internal sealed class AcademicRecordRepository(DatabaseContext dbContext) : TransactionalRepository<AcademicRecordEntity>(dbContext), IAcademicRecordRepository;
