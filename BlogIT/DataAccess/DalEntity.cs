using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BlogIT.Models;
using MongoDB.Driver;




namespace BlogIT.DataAccess
{
    public class DalEntity<TEntity> : IDalEntity<TEntity> where TEntity : BaseModel
    {
        private IMongoDatabase database;
        private IMongoCollection<TEntity> collection;

        public DalEntity()
        {
            GetDatabase();
            GetCollection();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(FilterDefinition<TEntity> filter)
        {
            var entities= await collection.FindAsync(filter);
            return entities.ToList();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = await collection.FindAsync(entity => entity.Id.Equals(id));

                if (await result.MoveNextAsync())
                {
                    return result.Current.FirstOrDefault() ?? null;
                }
            }

            return null;
        }

        #region Private Helper Methods

        private async Task<IEnumerable<TEntity>> ToList(IAsyncCursor<TEntity> asyncCursor)
        {
            List<TEntity> list = new List<TEntity>();
            while (await asyncCursor.MoveNextAsync())
            {
                foreach (var entity in asyncCursor.Current)
                {
                    list.Add(entity);
                }
            }

            return list;
        }

        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());

            database = client.GetDatabase(GetDatabaseName());
        }

        private string GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbDatabaseName");
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbConnectionString")
                        .Replace("{DB_NAME}", GetDatabaseName());
        }


        private void GetCollection()
        {
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion


    }
}