using Api.Models;
using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/topsecret_split")]
    public class TopSecret_SplitController : ApiController
    {
        private TopSecretRepository topSecretRepository = new TopSecretRepository();

        public Response POST(object request)
        {
            if (Request.RequestUri.Segments.Length == 4)
                return topSecretRepository.SaveDataSplit(request, Request.RequestUri.Segments[3]);
            else
                return new Response(404, null, null);
        }

        public Response GET()
        {
            return topSecretRepository.GetDataSplit();
        }
    }
}