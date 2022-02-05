namespace Mc2.CrudTest.Domain
{
    public interface ICustomerRepository
    {
        Customer Get(string customerId);
        void Save(Customer customer);
    }
}
