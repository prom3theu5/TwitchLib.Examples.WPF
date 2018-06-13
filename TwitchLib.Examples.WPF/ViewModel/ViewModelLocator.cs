using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using TwitchLib.Api;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.RateLimiter;

namespace TwitchLib.Examples.WPF.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IRateLimiter>(() => TimeLimiter.GetFromMaxCountByInterval(2, TimeSpan.FromSeconds(1)));
            SimpleIoc.Default.Register<ITwitchAPI>(() => new TwitchAPI(null, null, null));
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ApiExamplesViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public ApiExamplesViewModel Api => ServiceLocator.Current.GetInstance<ApiExamplesViewModel>();

        public static void Cleanup()
        { }
    }
}