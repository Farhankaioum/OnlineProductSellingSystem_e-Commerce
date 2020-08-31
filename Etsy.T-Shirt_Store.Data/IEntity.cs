namespace Etsy.T_Shirt_Store.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
