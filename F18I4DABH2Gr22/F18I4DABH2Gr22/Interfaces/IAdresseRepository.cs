namespace HandIn21_Udvidet.Interfaces
{
    public interface IAdresseRepository : IRepository<Adresse, int>
    {
        new Adresse Add(Adresse adresse);
        Adresse Update(Adresse adresse);
        Adresse Delete(int adresse);
    }
}