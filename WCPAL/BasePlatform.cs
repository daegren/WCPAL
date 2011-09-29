﻿using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace WCPAL
{
    public class BasePlatform
    {
        String _apiUrl = "http://{0}.battle.net/api/{1}/{2}";
        String _httpsApiUrl = "https://{0}.battle.net/api/{1}/{2}";
        String _cnApiUrl = "http://battlenet.com.cn/api/{0}/{2}";
        String _httpsCnApiUrl = "https://battlenet.com.cn/api/{0}/{2}";
        String _controller;
        String _action;

        BattlenetConnectionOptions _connectionOptions;

        WebRequest _wr;

        protected BasePlatform(String url, BattlenetConnectionOptions connectionOptions)
        {
            _controller = url;
            _connectionOptions = connectionOptions;
        }

        protected XmlDictionaryReader ProcessRequest(String request)
        {
            _action = request;
            String r = "";
            
            if (_connectionOptions.Region != Region.CN && _connectionOptions.IsSecure)
                r = String.Format(_httpsApiUrl, _connectionOptions.Region.ToString().ToLower(), _controller, _action);
            else if (_connectionOptions.Region != Region.CN)
                r = String.Format(_apiUrl, _connectionOptions.Region.ToString().ToLower(), _controller, _action);
            else if (_connectionOptions.Region == Region.CN && _connectionOptions.IsSecure)
                r = String.Format(_httpsCnApiUrl, _controller, _action);
            else
                r = String.Format(_cnApiUrl, _controller, _action);

            _wr = WebRequest.Create(r);

            if (_connectionOptions.AuthenticationOptions.IsAuthenticated)
            {
                BattlenetAuthenticationOptions authOptions = _connectionOptions.AuthenticationOptions;
                DateTime currentTime = DateTime.UtcNow;
                String stringToSign = _wr.Method + "\n" + currentTime.ToString("R") + "\n" + r + "\n"; // from wow-api-docs
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytesToSign =  encoding.GetBytes(stringToSign);
                HMACSHA1 hasher = new HMACSHA1(encoding.GetBytes(authOptions.PrivateKey));
                hasher.ComputeHash(bytesToSign);
                String auth = String.Format("BNET {0}:{1}", authOptions.PublicKey, Convert.ToBase64String(hasher.Hash));
                _wr.Headers.Set(HttpRequestHeader.Authorization, auth);
            }
            XmlDictionaryReader xdr = null;
            
            try
            {
                HttpWebResponse wres = (HttpWebResponse)_wr.GetResponse();

                xdr = JsonReaderWriterFactory.CreateJsonReader(wres.GetResponseStream(), new XmlDictionaryReaderQuotas());
            }
            catch (WebException ex)
            {                
                XmlDictionaryReader x = JsonReaderWriterFactory.CreateJsonReader(ex.Response.GetResponseStream(), new XmlDictionaryReaderQuotas());
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                String m = null;
                if (code == HttpStatusCode.ServiceUnavailable)
                {
                    m = "Service temporarily unavailable";
                }
                else if (code == HttpStatusCode.InternalServerError)
                {
                    m = XElement.Load(x).Element("reason").Value;
                }
                BattlenetConnectionException e = new BattlenetConnectionException(m, code);

                throw e;
            }

            return xdr;
        }
    }
}
