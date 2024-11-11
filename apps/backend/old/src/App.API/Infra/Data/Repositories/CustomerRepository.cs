using FwksLabs.AppService.Core.Abstractions.Repositories;

using FwksLabs.AppService.Core.Resources.Customers;
using FwksLabs.AppService.Infra.Data.Contexts;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Repositories;

namespace FwksLabs.AppService.Infra.Data.Repositories;

public sealed class CustomerRepository(DatabaseContext dbContext) : TransactionalRepository<int, CustomerEntity>(dbContext), ICustomerRepository;
