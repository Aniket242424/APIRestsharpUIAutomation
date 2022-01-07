using Newtonsoft.Json;
using RestSharp;
using SpecFlowProject1.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.API
{
   public class APIDataUtil
    {
        string url = "https://covid19.mathdro.id";
        public ListOfCasesDTO GetCases()
        {
            var restClient = new RestClient(url);
            var restRequest = new RestRequest("/api", Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Get(restRequest);
            var content = response.Content;
            var users = JsonConvert.DeserializeObject<ListOfCasesDTO>(content);
            return users;
        }
        
        public string GetInfectedCases()
        {
            var response = GetCases();
            return response.Confirmed.Value.ToString();
        }

        public string GetDeathsCases()
        {
            var response = GetCases();
            return response.Deaths.Value.ToString();
        }

        public string GetCountryWiseInfectedCases(string country)
        {
            var restClient = new RestClient(url);
            var restRequest = new RestRequest("/api/countries/"+country, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Get(restRequest);
            var content = response.Content;
            var details = JsonConvert.DeserializeObject<ListOfCountryWiseDataDTO>(content);
            String s = details.confirmed.value.ToString();
            return s;
        }


    }
}
