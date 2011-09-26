using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
using WCPAL.Model;

namespace WCPAL
{
    public class BasePlatform
    {
        String _apiUrl = "http://{0}.battle.net/api/{1}/{2}";
        String _cnApiUrl = "http://battlenet.com.cn/api/{0}/{2}";
        String _controller;
        String _action;
        Region _region;

        WebRequest _wr;

        internal BasePlatform(String url)
        {
            _controller = url;
        }

        internal BasePlatform(String url, Region region)
        {
            _controller = url;
            _region = region;
        }

        internal XmlDictionaryReader ProcessRequest(String request)
        {
            _action = request;
            String r = "";
            if (_region != Region.CN)
                r = String.Format(_apiUrl, _region, _controller, _action);
            else
                r = String.Format(_cnApiUrl, _controller, _action);
            _wr = WebRequest.Create(r);

            HttpWebResponse wres = (HttpWebResponse)_wr.GetResponse();

            XmlDictionaryReader xdr = JsonReaderWriterFactory.CreateJsonReader(wres.GetResponseStream(), new XmlDictionaryReaderQuotas());

            return xdr;
        }
    }
}
