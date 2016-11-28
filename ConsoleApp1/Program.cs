using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var summary = BenchmarkRunner.Run<JsonVsString>();

           

            Console.Read();
        }
    }

    public class JsonVsString
    {
        private readonly bool data;
        public JsonVsString()
        {
            data = true;
        }

        [Benchmark]
        public string ToString()
        {
            return data.ToString().ToLower();
        }

        [Benchmark]
        public string ToJson()
        {
            return new JavaScriptSerializer().Serialize(data);
        }


        [Benchmark]
        public string NewtonSoft()
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
