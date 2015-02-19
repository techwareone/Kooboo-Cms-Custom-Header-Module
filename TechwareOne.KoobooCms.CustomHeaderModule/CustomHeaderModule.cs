using System;
using System.Web;

/*
	<system.webServer>
		<modules runAllManagedModulesForAllRequests="true">
            <add name="CustomHeaderModule" type="TechwareOne.KoobooCms.CustomHeaderModule.CustomHeaderModule" />
        </modules>
	</system.webServer>
 */

namespace TechwareOne.KoobooCms.CustomHeaderModule
{
    public class CustomHeaderModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        public void Dispose() { }

        void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-KoobooCMS-Version");

            // Other headers can also be added even after this event fires e.g...
				//
            //		HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            //		HttpContext.Current.Response.Headers.Remove("X-Powered-By-Plesk");
            //
            // To remove them from the response, add the following to the web.config
			   // 
            // <system.webServer>
            //    <httpProtocol>
            //       <customHeaders>
            //          <remove name="X-Powered-By" />
            //          <remove name="X-Powered-By-Plesk" />
            //       </customHeaders>
            //    </httpProtocol>
            // </system.webServer>
        }
    }
}