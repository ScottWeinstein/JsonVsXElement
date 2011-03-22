using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Xml.Linq;

namespace JsonVsXElement
{
    public class Tests
    {
        static int iterations=10000;
        
        [Benchmark]
        public static void JsonTest()
        {
            for (int ii = 0; ii < iterations; ii++)
            {
            	var jsonString = "{Instrument: 'IBM', Details: { Price: 50, Size: 1000}}";
                var obj = Json.Decode(jsonString);
                var instrument = obj.Instrument;
                var price = obj.Details.Price;
            }
        }

        [Benchmark]
        public static void XElementTest()
        {
            for (int ii = 0; ii < iterations; ii++)
            {
                var xString = "<item Instrument='IBM'><Details Price='50' Size='1000'/></item>";
                var obj = XElement.Parse(xString);
                var instrument = obj.Attribute("Instrument").Value;
                var price = obj.Element("Details").Attribute("Price").Value;
            }
        }

    }
}
