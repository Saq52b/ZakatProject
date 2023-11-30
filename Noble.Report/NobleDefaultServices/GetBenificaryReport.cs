﻿using DevExpress.CodeParser;
using DevExpress.Xpo;
using Newtonsoft.Json;
using Noble.Report.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;


namespace Noble.Report.NobleDefaultServices
{
    public static class GetBenificaryReport
    {

        public static List<BenificariesLookupModel> GetBenificaryReportDtl(string authorizationPersonId, string approvalperson,string registered,string uqamaNo, string BanificaryId,string searchTerm, string fromDate,string toDate,string token,string serverName) {
        
            string ipPath = ConfigurationManager.ConnectionStrings["ipAdress"].ConnectionString;
            RestClient client1 = new RestClient(serverName);

            // create a new RestRequest instance for the API endpoint
            RestRequest request1 = new RestRequest("Benificary/GetBenificaryReport?authorizationPersonId=" + authorizationPersonId + "&approvalPersonId=" + approvalperson + "&registered=" + registered+ "&fromDate=" +fromDate + "&toDate=" +toDate+ "&uqamaNo="+ uqamaNo + "&beneficiaryId="+ BanificaryId+ "&searchTerm="+ searchTerm);

            // add the token to the Authorization header of the request
            request1.AddHeader("Authorization", "Bearer " + token);
            var response1 = client1.Execute(request1);
            var content1 = response1.Content;
          var GetBenificaryReport = JsonConvert.DeserializeObject<List<BenificariesLookupModel>>(content1);

            return GetBenificaryReport;
        }
    }
}