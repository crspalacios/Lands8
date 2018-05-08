namespace Lands8.MainViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Services;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Attributes
        string email;
        string password;
        bool isRemembered;
        bool isRunning;
        bool isEnabled;
        #endregion

        #region Services
        DialogService dialogServices;
        NavigationService navigationService;
        ApiService apiService;
        #endregion

        #region Properties
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemembered
        {
            get { return isRemembered; }
            set { SetValue(ref isRemembered, value); }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.dialogServices = new DialogService();
            this.navigationService = new NavigationService();
            this.apiService = new ApiService();
            IsEnabled = true;
            Email = "cpalacios@crealodigital.com";
            Password = "123456";

            //http:restcountries.eu/rest/v2/all"
        }
        #endregion

        #region Command
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }

        }

        private async void Register()
        {
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await navigationService.Navigate("Lands2Page");

        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await dialogServices.ShowMessage("Error",
                                                  "You  must enter an email.");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await dialogServices.ShowMessage("Error",
                                                  "You  must enter yur passowrd.");
                return;
            }

            this.IsRunning = true;
            this.isEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.isEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
            }
            var token = await this.apiService.GetToken("http://lands8api.azurewebsites.net/",
                                                        this.Email,
                                                        this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.isEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error",
                                                                "Somethis was woron, please trye later",
                                                                "Accept");
                return;
            }
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.isEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error",
                                                                token.ErrorDescription,
                                                                "Accept");
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.Lands = new LandsViewModel();
            await navigationService.Navigate("LandPage");

            this.IsRunning = false;
            this.isEnabled = true;


            Email = string.Empty;
            Password = string.Empty;


        }
        #endregion


    }
}
