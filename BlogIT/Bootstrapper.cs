using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using BlogIT.BusinessLogic.Interfaces;
using BlogIT.BusinessLogic;
using BlogIT.DataAccess;
using BlogIT.Models;

namespace BlogIT
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<IArticleBL, ArticleBL>();

            container.RegisterType<ICategoryBL, CategoryBL>();
            container.RegisterType<ICommentBL, CommentBL>();

            container.RegisterType(typeof(IDalEntity<>), typeof(DalEntity<>), "Db");
            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }
}