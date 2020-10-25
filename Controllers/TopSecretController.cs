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
    [RoutePrefix("api/topsecret")]
    public class TopSecretController : ApiController
    {
        private TopSecretRepository topSecretRepository = new TopSecretRepository();
        public Response POST(object request)
        {
            return topSecretRepository.GetSecret(request);
        }
    }
}
