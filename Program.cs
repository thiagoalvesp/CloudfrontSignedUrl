using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Amazon.CloudFront;


namespace CloudfrontSignedUrl
{
    class Program
    {
        static void Main(string[] args)
        {

            var protocol = AmazonCloudFrontUrlSigner.Protocol.https;
            var distributionDomain =  "d1w1uj9kqe1ebe.cloudfront.net";
            var resourcePath = "narutoperfil.jpg";
            var keyPairId = "K2FBX61W5Y2MOL";
            var expiresOn = DateTime.Now.AddSeconds(45);
            var ipRange = "2804:1b3:a200:9dc7:cfc:d226:d38:7dff";


            // using (StreamReader reader = File.OpenText(System.IO.Path.GetFullPath("cloudfront-test-key.pem")))
            // {
            //        var text =   AmazonCloudFrontUrlSigner.GetCannedSignedURL(protocol, distributionDomain, reader, resourcePath, keyPairId, expiresOn);
            //        Console.WriteLine("CannedSignedURL");
            //        Console.WriteLine(text);
            //        Console.WriteLine("----------------------------------");
            // }
            
            using (StreamReader reader = File.OpenText(System.IO.Path.GetFullPath("cloudfront-test-key.pem")))
            {
                   var text =   AmazonCloudFrontUrlSigner.GetCustomSignedURL(protocol,distributionDomain, reader, resourcePath, keyPairId, expiresOn, ipRange);
                   Console.WriteLine("CustomSignedURL");
                   Console.WriteLine(text);
                   Console.WriteLine("----------------------------------");
            }

        }

    }
}
