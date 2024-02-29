using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Repositories
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        void Delete(Transaction transaction);
        List<Transaction> GelAll();
        void Update(Transaction transaction);
    }
}