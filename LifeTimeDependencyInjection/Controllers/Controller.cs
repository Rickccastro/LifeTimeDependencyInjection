using LifeTimeDependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeTimeDependencyInjection.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly IOperationTransient _transientOperation1;
    private readonly IOperationTransient _transientOperation2;

    private readonly IOperationScoped _scopedOperation1;
    private readonly IOperationScoped _scopedOperation2;

    private readonly IOperationSingleton _singletonOperation1;
    private readonly IOperationSingleton _singletonOperation2;

    public Controller(IOperationTransient operationTransient1, IOperationTransient operationTransient2,
        IOperationScoped operationScoped1, IOperationScoped operationScoped2,
        IOperationSingleton operationSingleton1, IOperationSingleton operationSingleton2)
    {
        _transientOperation1 = operationTransient1;
        _transientOperation2 = operationTransient2;

        _scopedOperation1 = operationScoped1;
        _scopedOperation2 = operationScoped2;

        _singletonOperation1 = operationSingleton1;
        _singletonOperation2 = operationSingleton2;
    }

    [HttpGet]
    public string Index()
    {

        return $"Transient1:{_transientOperation1.OperationId}\n" +
               $"Transient2:{_transientOperation2.OperationId}\n" +
               $"Scoped1:{_scopedOperation1.OperationId}\n" +
               $"Scoped2:{_scopedOperation2.OperationId}\n" +
               $"Singleton1:{_singletonOperation1.OperationId}\n" +
               $"Singleton2:{_singletonOperation2.OperationId}\n";
    }
}
