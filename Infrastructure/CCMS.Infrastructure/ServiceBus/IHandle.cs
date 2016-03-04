namespace Infrastructure.ServiceBus
{
    public interface IHandle<in T> where T: IMessage
    {
        void Handle(T message);
    }
}