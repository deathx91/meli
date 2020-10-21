using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Services
{
    public class TopSecretRepository
    {
        public TopSecret[] GetSecret(int Distance)
        {
            return new TopSecret[]
            {
            new TopSecret
            {
                Id = 1,
                Name = "Glenn Block"
            },
            new TopSecret
            {
                Id = 2,
                Name = "Dan Roth"
            }
            };
        }
    }
}