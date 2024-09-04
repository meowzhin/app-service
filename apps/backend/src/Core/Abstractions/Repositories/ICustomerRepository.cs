using FwksLabs.AppService.Core.Abstractions.Services.Common;
using FwksLabs.AppService.Core.Resources.Customers;
using FwksLabs.Libs.Core.Abstractions.Repositories;

namespace FwksLabs.AppService.Core.Abstractions.Repositories;

public interface ICustomerRepository : IBaseRepository<int, CustomerEntity>, ITransacionalRepository, IService;
