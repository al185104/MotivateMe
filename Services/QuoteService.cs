using MotivateMe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MotivateMe.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly string _urlBase;
        private readonly string _urlQuotes;
        private readonly string _urlAuthors;
        private readonly string _urlTags;
        private readonly string _urlRandom;
        private readonly HttpClient _client;

        public QuoteService()
        {
            _client = new HttpClient();
            _urlBase = "https://goquotes-api.herokuapp.com/api/v1/";
            _urlQuotes = $"{_urlBase}/quotes";
            _urlAuthors = $"{_urlBase}/authors";
            _urlTags = $"{_urlBase}/tags";
            _urlRandom = $"{_urlBase}/random?count=";
        }

        public async Task<Result> GetAuthorsAsync()
        {
            Result result;
            try
            {
                var response = await _client.GetAsync(_urlAuthors);

                await HandleResponse(response);
                string serialized = await response.Content.ReadAsStringAsync();
                result = await Task.Run(() => JsonConvert.DeserializeObject<Result>(serialized));
                
            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == HttpStatusCode.NotFound)
            {
                result = new Result { Status = 404, Message = exception.Message };
            }
            catch (Exception e)
            {
                result = new Result { Status = 400, Message = e.Message };
            }

            return result;
        }

        public async Task<Result> GetQuotesAsync()
        {
            Result result;
            try
            {
                var response = await _client.GetAsync(_urlQuotes);

                await HandleResponse(response);
                string serialized = await response.Content.ReadAsStringAsync();
                result = await Task.Run(() => JsonConvert.DeserializeObject<Result>(serialized));

            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == HttpStatusCode.NotFound)
            {
                result = new Result { Status = 404, Message = exception.Message };
            }
            catch (Exception e)
            {
                result = new Result { Status = 400, Message = e.Message };
            }

            return result;
        }

        public async Task<Result> GetRandomQuoteAsync(int count = 1)
        {
            Result result;
            try
            {
                var response = await _client.GetAsync(_urlRandom + count.ToString());

                await HandleResponse(response);
                string serialized = await response.Content.ReadAsStringAsync();
                result = await Task.Run(() => JsonConvert.DeserializeObject<Result>(serialized));

            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == HttpStatusCode.NotFound)
            {
                result = new Result { Status = 404, Message = exception.Message };
            }
            catch (Exception e)
            {
                result = new Result { Status = 400, Message = e.Message };
            }

            return result;
        }

        public async Task<Result> GetTagsAsync()
        {
            Result result;
            try
            {
                var response = await _client.GetAsync(_urlTags);

                await HandleResponse(response);
                string serialized = await response.Content.ReadAsStringAsync();
                result = await Task.Run(() => JsonConvert.DeserializeObject<Result>(serialized));

            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == HttpStatusCode.NotFound)
            {
                result = new Result { Status = 404, Message = exception.Message };
            }
            catch (Exception e)
            {
                result = new Result { Status = 400, Message = e.Message };
            }

            return result;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }
    }
}
