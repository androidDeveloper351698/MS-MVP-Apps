﻿namespace MVP.App.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Windows.ApplicationModel;
    using Windows.System;
    using Windows.UI.Xaml.Navigation;

    using GalaSoft.MvvmLight.Command;

    using MVP.App.Models;

    using WinUX.MvvmLight.Xaml.Views;

    public class AboutPageViewModel : PageBaseViewModel
    {
        public AboutPageViewModel()
        {
            this.Contributors = new ObservableCollection<Contributor>
                                    {
                                        new Contributor
                                            {
                                                Name = "James Croft",
                                                ImageUri =
                                                    "https://avatars0.githubusercontent.com/u/13505183?v=3&u=4f255f7523d26d5f661e297d3edc563eae6c4b02",
                                                LinkUri =
                                                    "https://github.com/jamesmcroft",
                                                IsMvp = true
                                            },
                                        new Contributor
                                            {
                                                Name = "Lance McCarthy",
                                                ImageUri =
                                                    "https://pbs.twimg.com/profile_images/821520899815997445/rnxj--UG.jpg",
                                                LinkUri =
                                                    "https://github.com/LanceMcCarthy",
                                                IsMvp = true
                                            }
                                    };

            this.ContributorClickedCommand = new RelayCommand<Contributor>(this.OnContributorClicked);
        }

        public ICommand ContributorClickedCommand { get; }

        public PackageVersion Version => Package.Current.Id.Version;

        public string VersionNumber
            => $"{this.Version.Major}.{this.Version.Minor}.{this.Version.Build}.{this.Version.Revision}";

        public string AppDescription
            =>
                $"The MVP Community app is built by community developers to provide an app experience for Microsoft MVPs worldwide. {Environment.NewLine}{Environment.NewLine}You can find a list of the app's contributors below."
        ;

        public ObservableCollection<Contributor> Contributors { get; }

        public override void OnPageNavigatedTo(NavigationEventArgs args)
        {
        }

        public override void OnPageNavigatedFrom(NavigationEventArgs args)
        {
        }

        public override void OnPageNavigatingFrom(NavigatingCancelEventArgs args)
        {
        }

        private async void OnContributorClicked(Contributor obj)
        {
            if (!string.IsNullOrWhiteSpace(obj?.LinkUri))
            {
                await Launcher.LaunchUriAsync(new Uri(obj.LinkUri));
            }
        }
    }
}