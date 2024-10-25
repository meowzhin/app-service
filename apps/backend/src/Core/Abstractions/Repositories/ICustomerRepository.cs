using FwksLabs.Libs.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Abstractions.Services.Common;
using FwksLabs.ResumeService.Core.Resources.Customers;

namespace FwksLabs.ResumeService.Core.Abstractions.Repositories;

public interface ICustomerRepository : IBaseRepository<int, CustomerEntity>, ITransacionalRepository, IService;
