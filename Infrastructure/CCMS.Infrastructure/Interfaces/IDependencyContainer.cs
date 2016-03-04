namespace Infrastructure.Interfaces
{
    public interface IDependencyContainer
    {
        IDependencyRegistry Registry { get; set; }
        IDependencyResolver Resolver { get; set; }
        object Container { get; }        
    }
}
