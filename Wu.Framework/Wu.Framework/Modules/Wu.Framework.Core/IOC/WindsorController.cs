﻿using Castle.MicroKernel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wu.Framework.Core
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }
    }
}