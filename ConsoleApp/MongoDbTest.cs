using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Attributes;
using MongoDB;

namespace ConsoleApp
{
    class MongoDbTest : IDisposable
    {
        private readonly string _connectionString = "Server=127.0.0.1";
        private readonly string _dbName = "MyNorthWind";
        private Mongo _mongo;
        private IMongoDatabase _db;

        public MongoDbTest()
            : this("Server=127.0.0.1", "MyNorthWind")
        { }

        public MongoDbTest(string connectionString, string dbName)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");

            _mongo = new Mongo(connectionString);
            _mongo.Connect();
            if (!string.IsNullOrEmpty(dbName))
                _db = _mongo.GetDatabase(dbName);
        }
        public IMongoDatabase SetDb(string newDbName)
        {
            if (string.IsNullOrEmpty(newDbName))
                throw new ArgumentNullException("newDbName");
            _db = _mongo.GetDatabase(newDbName);
            return _db;
        }
        public IMongoDatabase Db
        {
            get
            {
                if (_db == null)
                    throw new Exception("没有指定连接的数据库，请调用SetDb()方法");
                return _db;
            }
        }
        public IMongoCollection<T> GetCollection<T>() where T : class
        {
            return _db.GetCollection<T>();
        }
        public IMongoCollection<T> GetCollection<T>(string name) where T : class
        {
            return _db.GetCollection<T>(name);
        }

        public void Dispose()
        {
            if (_mongo != null)
            {
                _mongo.Dispose();
                _mongo = null;
            }
        }


    }
    
    public class MyMongoDb
    {
        public void Insert(Customer customer)
        {
            using (MongoDbTest mongo = new MongoDbTest())
            {
                mongo.GetCollection<Customer>().Insert(customer);
            }
        }
        public void Delete(string customerName)
        {
            using (MongoDbTest mongo = new MongoDbTest())
            {
                mongo.GetCollection<Customer>().Remove(p => p.Tel == customerName);
            }
        }
        public void Update(Customer customer)
        {
            using (MongoDbTest mongo = new MongoDbTest())
            {
                mongo.GetCollection<Customer>().Update(customer, p => p.CustomerID == customer.CustomerID);
            }
        }
        public List<Customer> GetList(string searchWord)
        {
            using (MongoDbTest mongo = new MongoDbTest())
            {
                //if (string.IsNullOrEmpty(searchWord))
                //    return mongo.GetCollection<Customer>().Linq().OrderBy(p => p.CustomerName).ToList();
                //else
                //    return mongo.GetCollection<Customer>().Linq().Where(p => p.CustomerName.Contains(searchWord)).OrderBy(p => p.CustomerName).ToList();

                if (string.IsNullOrEmpty(searchWord))
                    return mongo.GetCollection<Customer>().Linq().ToList();
                else
                    return mongo.GetCollection<Customer>().Find(p => p.CustomerName.Contains(searchWord)).Documents.ToList();

            }
        }
        public Customer GetOneCustomer(string customerId)
        {
            using (MongoDbTest mongo = new MongoDbTest())
            {
                return mongo.GetCollection<Customer>().FindOne(p => p.CustomerID == customerId);
            }
        }

        public void RunCommand(string cmdKey,string cmdValue)
        {
            using (MongoDbTest mongo=new MongoDbTest())
            {
                mongo.Db.SendCommand(new Document(cmdKey, cmdValue));
            }
        }
    }

    public sealed class Customer
    {
        [MongoId]
        public string CustomerID { get; set; }
        //[MongoAlias("CName")]
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        //[MongoIgnore]
        public string Tel { get; set; }

        public override string ToString()
        {
            string outputformat = "{0}:{1}\r\n";
            string output = string.Empty;
            Type t = this.GetType();
            foreach (var pro in t.GetProperties())
            {
                output += string.Format(outputformat, pro.Name, pro.GetValue(this, null));
            }
            return output;
        }
    }
}
