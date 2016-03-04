namespace Infrastructure.Interfaces
{
    public interface IContainer
    {
        IDependencyRegistry Registry { get; set; }
        IDependencyResolver Resolver { get; set; }
        object Container { get; }        
    }
}
