using System;
using System.Collections.Generic;
using System.Text;

namespace Lands8.Services
{
    using Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "LandPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new LandPage());
                    break;
            }
        }
        public async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
