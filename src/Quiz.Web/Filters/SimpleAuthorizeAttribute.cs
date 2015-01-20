using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Quiz.Domain;
using Quiz.Framework.Services;
using WebMatrix.WebData;
using Quiz.Web.Models;

namespace Quiz.Web.Filters
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
    AllowMultiple = true)]
    public class SimpleAuthorize : AuthorizeAttribute
    {
        public SimpleAuthorize(int ResourceId, Operations operation)
        {
            _resourceId = ResourceId;
            _operation = operation;
        }

        private int _resourceId;
        private Operations _operation;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Get the current claims principal
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            //Make sure they are authenticated
            if (!prinicpal.Identity.IsAuthenticated)
                return false;
            //Get the roles from the claims
            var roles = prinicpal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
            //Check if they are authorized
            return UserResourceService.Authorize(_resourceId, _operation, roles);
        }


    }
}
