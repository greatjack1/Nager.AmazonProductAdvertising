﻿using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;
using System;

namespace Nager.AmazonProductAdvertising.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchRequest();
            LookupRequest();

            Console.ReadLine();
        }

        static void SearchRequest()
        {
            var config = new AmazonAuthentication();
            config.AccessKey = "accesskey";
            config.SecretKey = "secretkey";

            var wrapper = new AmazonWrapper(config);
            var result = wrapper.Search("canon eos", AmazonEndpoint.DE, "nagerat-21", AmazonSearchIndex.Electronics, AmazonResponseGroup.Large);


            foreach(var item in result.Items.Item)
            {
                Console.WriteLine(item.ItemAttributes.Title);
            }

            Console.WriteLine("found {0} items", result.Items.Item.Length);
        }

        static void LookupRequest()
        {
            var config = new AmazonAuthentication();
            config.AccessKey = "accesskey";
            config.SecretKey = "secretkey";

            var wrapper = new AmazonWrapper(config);
            var result = wrapper.Lookup("B007KKKJYK", AmazonEndpoint.DE, "nagerat-21");

            Console.WriteLine("{0}", result.Items.Item.ItemAttributes.Title);
        }
    }
}
