using Domain.Entities;
using Domain.Interfaces.ExternalService;
using Infrastructure.ExternalService.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalService
{
    public class TaxRateServiceApi : ITaxRateServiceApi
    {
        HttpClient client = new HttpClient();

        private readonly IConfiguration Configuration;
        private readonly string apiParamKey;
        private readonly string apiKey;
        private readonly string apiParamSymbol;
        private readonly string apiUrl;




        public TaxRateServiceApi(IConfiguration configuration)
        {
            Configuration = configuration;
            apiParamKey = Configuration["ApiRateConfig:apiParamKey"];
            apiKey = Configuration["ApiRateConfig:apiKey"];
            apiParamSymbol = Configuration["ApiRateConfig:apiParamSymbol"];
            apiUrl = Configuration["ApiRateConfig:ApiUrl"];
        }

        public async Task<TaxRate> GetRateByPrefixAsync(string prefix)
        {
           
            var symbol = prefix + ",BRL";
            //EntityTagHeaderValue etag = null;
            //etag = new EntityTagHeaderValue()
           // client.DefaultRequestHeaders.IfNoneMatch.Add()
            HttpResponseMessage response = await client.GetAsync($"{apiUrl}?{apiParamKey}{apiKey}&{apiParamSymbol}={symbol}");
            string result = string.Empty;            
            var statusCode = response.StatusCode;
            var etag = response.Headers.ETag;
            ResponseTaxApi? model = null;
            TaxRate txRate = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<ResponseTaxApi>(result);
                var strEtag = etag is not null ? etag.Tag : string.Empty;
                txRate = new TaxRate(prefix, model.Rates.GetValueOrDefault(prefix), model.Rates.GetValueOrDefault("BRL"), strEtag);
            }
            return txRate;
        }
    }
}
