using FwksLab.AppService.Core.Entities;
using FwksLab.Libs.Core.Abstractions.Repositories;

namespace FwksLab.AppService.Core.Abstractions.Repositories;

public interface ICustomerRepository : IBaseRepository<Guid, CustomerEntity>, ITransacionalRepository;