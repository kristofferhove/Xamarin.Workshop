using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Xamarin.Core.Services;

namespace Xamarin.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton<ICloudService, CloudService>();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}