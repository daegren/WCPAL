using System.Net;
using System;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace WCPAL
{
    public class BasePlatform
    {
        string apiUrl = "http://us.battle.net/api/";
        string controller;
        string action;

        WebRequest _wr;

        internal void InitializeConnection(string url)
        {
            controller = url;
        }

        internal XmlDictionaryReader ProcessRequest(string request)
        {
            action = request;

            _wr = WebRequest.Create(apiUrl + controller + action);

            HttpWebResponse wres = (HttpWebResponse)_wr.GetResponse();

            XmlDictionaryReader xdr = JsonReaderWriterFactory.CreateJsonReader(wres.GetResponseStream(), new XmlDictionaryReaderQuotas());

            return xdr;
        }
    }
}
