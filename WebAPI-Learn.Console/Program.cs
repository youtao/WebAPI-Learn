using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Learn.Console
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Mime;

    using Microsoft.Win32.SafeHandles;

    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = WebRequest.Create("https://www.baidu.com/") as HttpWebRequest;
            request.Method = "GET";
            request.AddRange("bytes", 0, 1000);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            ContentType content = new ContentType();
            foreach (string header in response.Headers)
            {
                Console.WriteLine("{0}:{1}", header, response.Headers[header]);
            }
            var stream = response.GetResponseStream();
            //int count = (int)response.ContentLength;
            //byte[] bytes = new byte[count];
            //stream.Read(bytes, 0, count);
            //var str = Encoding.UTF8.GetString(bytes);

            using (StreamReader reader = new StreamReader(stream))
            {
                StreamWriter writer = new StreamWriter("index.html");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
