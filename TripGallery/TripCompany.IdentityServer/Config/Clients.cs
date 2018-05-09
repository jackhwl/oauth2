using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace TripCompany.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "tripgalleryclientcredentials",
                    ClientName = "Trip Gallery (Client Credentials)",
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(TripGallery.Constants.TripGalleryClientSecret.Sha256())
                    },
                    AllowAccessToAllScopes = true
                    //AllowedScopes = new List<string>()
                    //{
                    //    "gallerymanagement"
                    //}
                },

                new Client
                {
                    ClientId = "tripgalleryimplicit",
                    ClientName= "Trip Gallery (Implicit)",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    // redirect = URI of the Angular application callback page
                    RedirectUris = new List<string>
                    {
                        TripGallery.Constants.TripGalleryAngular + "callback.html"
                    }
                }, 

                new Client
                {
                    ClientId = "tripgalleryauthcode",
                    ClientName= "Trip Gallery (Authorization Code)",
                    Flow = Flows.AuthorizationCode,
                    AllowAccessToAllScopes = true,

                    // redirect = URI of the MVC application callback page
                    RedirectUris = new List<string>
                    {
                        TripGallery.Constants.TripGalleryMVCSTSCallback
                    },

                    // client secret
                    ClientSecrets = new List<Secret>
                    {
                        new Secret(TripGallery.Constants.TripGalleryClientSecret.Sha256())
                    }

                }
            };
        }
    }
}