using E_School_Diary.Auth;
using E_School_Diary.WebClient.Factories;
using E_School_Diary.WebClient.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace E_School_Diary.WebClient.Modules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.GetPresenter).NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
            
            this.Bind(typeof(UserStore<>)).ToSelf().InRequestScope();
            this.Bind(typeof(IUserStore<>)).To(typeof(UserStore<>));

            this.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            this.Bind(typeof(UserManager<>)).ToSelf().InRequestScope();// add scoping as necessary
            this.Bind(typeof(UserStore<>)).ToSelf().InRequestScope();
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}