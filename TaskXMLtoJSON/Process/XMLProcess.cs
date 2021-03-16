using System;
using System.Collections.Generic;
using System.Xml;
using TaskXMLtoJSON.Model;

namespace TaskXMLtoJSON.Process
{
    class XMLProcess
    {
        private string PathToXML;

        public XMLProcess(string pathToXML) { PathToXML = pathToXML; }

        public JSONModel XMLReader()
        {
            int cdsCount = 0;
            double pricesSum = 0;
            List<string> countries = new List<string>();
            int minYear = 0;
            int maxYear = 0;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(PathToXML);
            XmlElement catalogeElement = xmlDocument.DocumentElement;

            foreach (XmlNode cds in catalogeElement)
            {
                cdsCount++;
                foreach (XmlNode chiledCdNode in cds.ChildNodes)
                {
                    if (chiledCdNode.Name == "COUNTRY")
                    {
                       if (!countries.Contains(chiledCdNode.InnerText))
                            countries.Add(chiledCdNode.InnerText);
                    }

                    if (chiledCdNode.Name == "PRICE")
                    {
                        if (double.TryParse(chiledCdNode.InnerText, out double price))
                            pricesSum += price;
                    }

                    if (chiledCdNode.Name == "YEAR")
                    {
                        if (int.TryParse(chiledCdNode.InnerText, out int year))
                        {
                            if (minYear == 0 || year <= minYear)
                                minYear = year;

                            else if (maxYear == 0 || year >= maxYear)
                                maxYear = year;
                        }
                    }
                }
            }

            JSONModel model = new JSONModel
            {
                CdsCount = cdsCount,
                PricesSum = String.Format("{0:C2}", pricesSum),
                Countries = countries.ToArray(),
                MinYear = minYear.ToString(),
                MaxYear = maxYear.ToString()
            };

            return model;
        }
    }
}
