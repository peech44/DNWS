using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
    //give me somepoint
  class ClientInfo : IPlugin
  {
    protected static Dictionary<String, int> clientInfoDictionary = null;
    public ClientInfo()
    {
      if (clientInfoDictionary == null)
      {
        clientInfoDictionary = new Dictionary<String, int>();

      }
    }

    public void PreProcessing(HTTPRequest request)
    {
      if (clientInfoDictionary.ContainsKey(request.Url))
      {
        clientInfoDictionary[request.Url] = (int)clientInfoDictionary[request.Url] + 1;
      }
      else
      {
        clientInfoDictionary[request.Url] = 1;
      }
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      //
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      sb.Append("<html><body><h1>Client Information</h1>");
      //port
      sb.Append("Client IP: " + request.getPropertyByKey("IP") + "</br >");
      sb.Append("</br >");
      //ip
      sb.Append("Client Port: " + request.getPropertyByKey("Port") + "</br >");
      sb.Append("</br >");
      sb.Append("Browser information: " + request.getPropertyByKey("User-Agent") + "</br >");
      sb.Append("</br >");
      sb.Append("Accept Language: " + request.getPropertyByKey("Accept-Language") + "</br >");
      sb.Append("</br >");
      sb.Append("Accept Encoding: " + request.getPropertyByKey("Accept-Encoding") + "</br >");
      sb.Append("</body></html>");
      //
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
}