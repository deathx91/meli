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
    public class TopSecretController : ApiController
    {
        private TopSecretRepository topSecretRepository;
        public TopSecretController()
        {
            topSecretRepository = new TopSecretRepository();
        }
        public TopSecret[] Get(int Distance)
        {
            return topSecretRepository.GetSecret(Distance);
        }
    }
}
