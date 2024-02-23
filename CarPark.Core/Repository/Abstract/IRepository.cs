using CarPark.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Repository.Abstract
{
    /// <summary>
    /// Core katmanı çekirdek alan olduğu için tüm interface leri buraya yazıcağız. CRUD işlemler.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        GetManyResult<TEntity> GetAll();
        Task<GetManyResult<TEntity>> GetAllAsync();
        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter); //lambda expressionlar gibi. (x=>x.Name=="Ercan")
        Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> GetById(string id);//id li işlem
        Task<GetOneResult<TEntity>> GetByIdAsync(string id);
        GetOneResult<TEntity> InsertOne(TEntity entity);//ekleme işlemi
        Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity);
        GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);//liste ekleme işlemi
        Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);
        GetOneResult<TEntity> ReplaceOne(TEntity entity, string id);//update işlemleri
        Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id);
        //Delete işlemleri
        GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
        Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);
        GetOneResult<TEntity> DeleteById(string id);
        Task<GetOneResult<TEntity>> DeleteByIdAsync(string id);
        void DeleteMany(Expression<Func<TEntity, bool>> filter);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
    }
}
