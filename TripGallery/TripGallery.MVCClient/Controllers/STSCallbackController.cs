using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityModel.Client;

namespace TripGallery.MVCClient.Controllers
{
    public class STSCallbackController : Controller
    {
        // GET: STSCallback
        public async Task<ActionResult> Index()
        {
            // get the authorization code from the query string
            var authCode = Request.QueryString["code"];

            // with the auth code, we can request an access token.
            var client = new TokenClient(TripGallery.Constants.TripGallerySTSTokenEndpoint, "tripgalleryauthcode",
                TripGallery.Constants.TripGalleryClientSecret);

            var tokenRqsponse =
                await client.RequestAuthorizationCodeAsync(authCode, TripGallery.Constants.TripGalleryMVCSTSCallback);

            // we save the token in a cookie for use later on
            Response.Cookies["TripGalleryCookie"]["access_token"] = tokenRqsponse.AccessToken;

            return Redirect(Request.QueryString["state"]);
        }
    }
}