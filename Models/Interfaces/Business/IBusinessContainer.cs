namespace Models.Interfaces.Business
{
    public interface IBusinessContainer
    {
        T Get<T>(string businessName);
    }
}