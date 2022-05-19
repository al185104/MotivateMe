using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotivateMe.Models;

namespace MotivateMe.Services
{
    public interface IQuoteService
    {
        /*
         * https://goquotes-api.herokuapp.com/api/v1/all/quotes
         * https://goquotes-api.herokuapp.com/api/v1/random?count=1
         * https://goquotes-api.herokuapp.com/api/v1/all/tags
         * https://goquotes-api.herokuapp.com/api/v1/all/authors
         */

        Task<Result> GetQuotesAsync();
        Task<Result> GetRandomQuoteAsync(int count = 1);
        Task<Result> GetTagsAsync();
        Task<Result> GetAuthorsAsync();
    }
}
