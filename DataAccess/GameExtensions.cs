using DataAccess.Entities;
using DataAccess.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class GameExtensions
    {
        public static IQueryable<Game> Filter(this IQueryable<Game> query, GameFilter filter)
        {
            if (!filter.Author.IsNullOrEmpty())
                query = query.Where(x => x.Author == filter.Author);

            if (!filter.Genre.IsNullOrEmpty())
                query = query.Where(x => x.Genre == filter.Genre);

            return query;
        }
    }
}
