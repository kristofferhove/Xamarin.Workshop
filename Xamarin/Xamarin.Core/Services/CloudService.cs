﻿using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Core.Services
{
    public class CloudService
    {
        //Test
        private readonly string serviceUrl = "http://trafikkagent-test.azure-mobile.net/";
        private readonly string appKey = "CGTtzIseKnbjKyARkpZwDZahJOKwKo46";

        public CloudService()
        {
            var client = new MobileServiceClient(serviceUrl, appKey);
        }
    }
}
