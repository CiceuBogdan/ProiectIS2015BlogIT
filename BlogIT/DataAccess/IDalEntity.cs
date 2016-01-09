using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogIT.Models;
using MongoDB.Driver;

namespace BlogIT.DataAccess
{




    public interface IDalEntity<TEntity> where TEntity : BaseModel
    {
        Task InsertAsync(TEntity entity);
        //Task<ReplaceOneResult> ReplaceOneAsync(TEntity entity);
        //Task<DeleteResult> DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> FindAsync(FilterDefinition<TEntity> filter);
        Task<TEntity> GetByIdAsync(string id);
        
    }
}
