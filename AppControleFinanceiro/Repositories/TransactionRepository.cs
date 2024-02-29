using AppControleFinanceiro.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly LiteDatabase _dataBase;
    private readonly string collectionName = "transactions";
    public TransactionRepository()
    {
        _dataBase = new LiteDatabase("Filename=C:/users/AppData/database.db;Connection=Shared");
    }

    public List<Transaction> GelAll()
    {
        return _dataBase
                .GetCollection<Transaction>(collectionName)
                .Query()
                .OrderByDescending(data => data.Date)
                .ToList();
    }

    public void Add(Transaction transaction)
    {
        var collection =_dataBase.GetCollection<Transaction>(collectionName);
        collection.Insert(transaction);
        collection.EnsureIndex(a => a.Date);

    }
    public void Update(Transaction transaction)
    {
        var collection = _dataBase.GetCollection<Transaction>(collectionName);
        collection.Update(transaction);
    }
    public void Delete(Transaction transaction)
    {
        var collection = _dataBase.GetCollection<Transaction>(collectionName);
        collection.Delete(transaction.Id);
    }
}
