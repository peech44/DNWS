using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class testPlugin : IPlugin
  {

     

    protected static Dictionary<String, int> testDictionary = null;
    public testPlugin()
    {
      if (testDictionary == null)
      {
        testDictionary = new Dictionary<String, int>();

      }
    }

    public void PreProcessing(HTTPRequest request)
    {
      if (testDictionary.ContainsKey(request.Url))
      {
        testDictionary[request.Url] = (int)testDictionary[request.Url] + 1;
      }
      else
      {
        testDictionary[request.Url] = 1;
      }
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      sb.Append("<br>");
      sb.Append("<h5>client IP and Port:   " + DotNetWebServer.var1.name + "<br /><br /><br />"); 
      sb.Append("Browser Information:  " + request.getPropertyByKey("user-agent") + "<br /><br /><br />");
      sb.Append("Accept Language:  " + request.getPropertyByKey("accept-language") + "<br /><br /><br />");
      sb.Append("Accept Encoding:  " + request.getPropertyByKey("accept-encoding") + "<br /><br /><br />");
      sb.Append("</h5>");

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