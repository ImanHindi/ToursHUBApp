using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToursHUB.Models.User;
using ToursHUB.ViewModels.Base;
using Xamarin.Forms;

namespace ToursHUB.ViewModels
{
   public class TourDetailViewModel : ViewModelBase
    {


        public ICommand EditTripCommand => new Command<Trip>(async (trip) => await EditTripAsync(trip));


        private async Task EditTripAsync(Trip trip)
        {
            await NavigationService.NavigateToAsync<CreatorEditTripViewModel>(trip);
        }

    }
}
