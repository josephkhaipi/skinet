using System.Linq;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        //static no need to instance 
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {

            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //p => p.ProductTypeId == id
            }

            
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);//p => p.ProductTypeId == id
            }

             if (spec.OrderByDecending != null)
            {
                query = query.OrderByDescending(spec.OrderByDecending);//p => p.ProductTypeId == id
            }

            if(spec.IsPagingEnabled){
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //inclde statement in productrepository and pass them into query which is IQueryable, so it can query the database
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}