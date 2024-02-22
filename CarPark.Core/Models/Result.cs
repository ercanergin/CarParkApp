using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Models
{
    /// <summary>
    /// Result modelini diğer modellerle kullanıp geri dönüş sağlamak.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Default true olsun
        /// </summary>
        public Result()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    /// <summary>
    /// GetOneResult TEntity yani herhangi bir model olacak class olacak ve new lenebilir olmalı.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GetOneResult<TEntity> : Result where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
    }
    /// <summary>
    /// Liste hali.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GetManyResult<TEntity> : Result where TEntity : class, new()
    {
        public IEnumerable<TEntity> Result { get; set; }
    }
}
