using FwksLabs.AppService.Core.Abstractions.Repositories;

using FwksLabs.AppService.Core.Resources.Customers;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Repositories;
using FwksLabs.ResumeService.Infra.Data.Contexts;

namespace FwksLabs.ResumeService.Infra.Data.Repositories;

public sealed class CustomerRepository(DatabaseContext dbContext) : TransactionalRepository<int, CustomerEntity>(dbContext), ICustomerRepository;
