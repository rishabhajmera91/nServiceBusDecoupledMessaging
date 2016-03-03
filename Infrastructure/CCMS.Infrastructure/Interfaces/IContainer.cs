namespace CCMS.Infrastructure.Interfaces
{
    public interface IContainer
    {
        IDependencyRegistrar Registrar { get; set; }
        IDependencyResolver Resolver { get; set; }
        object Container { get; }        
    }
}
