using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.core.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Critria { get; set; }
        public List<Expression<Func<T, object>>> Incliudes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>>? orderBy { get ; set ; }
        public string? orderType { get ; set; }
        public Expression<Func<T, object>>? orderByDesc { get ; set ; }
        private int Skip;

        public int skip
        {
            get { return Skip; }
            set { Skip = value>=0?value:0; }
        }
 
        private int Take;

        public int take
        {
            get { return Take; }
            set { Take = value>=0?value:0; }
        }

        public bool Pagination { get ; set ; }
        public int Count { get; set; }

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> expression)
        {
            Critria = expression;
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            this.orderBy = orderBy;
        } 
        protected void AddOrderByDesc(Expression<Func<T, object>> orderBy)
        {
            this.orderByDesc = orderBy;
        }
        protected void AddPagination(int skip , int take)
        {
            this.skip = skip;
            this.take = take;
            Pagination = true;
        }
    }
}
