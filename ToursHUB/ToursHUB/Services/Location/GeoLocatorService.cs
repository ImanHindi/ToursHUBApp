using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Maps;
using ToursHUB.Models;
using ToursHUB.Models.User;

namespace ToursHUB.Services
{
    class GeoLocatorService: IGeoLocatorService
    {
        public GeoLocatorService()
        {
          var CurrentLocation =  GetCurrentLocation();

        }
        public async Task<Plugin.Geolocator.Abstractions.Position> GetCurrentLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            var position = new Plugin.Geolocator.Abstractions.Position((await locator.GetPositionAsync()).Latitude, (await locator.GetPositionAsync()).Longitude);


            var Pin = new Pin
            {

                Type = PinType.Place,
              //  Position = position,
               // Label = user.FirstName+ user.LastName,
                Address = position.ToString()
            };


            //var map = new Map(MapSpan.FromCenterAndRadius(
            //    new Position(position.Latitude, position.Longitude),
            //    Distance.FromMiles(0.5)));


            // return map;
            return position;
        }

        public async Task<double> GetCurrentLongitude()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;
            var lo = await locator.GetPositionAsync();
            return lo.Longitude;
        }
        public async Task<double> GetCurrentLatitude()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;
          var la= await locator.GetPositionAsync();
            return la.Latitude;
        }
        public async Task StartListening()
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                return;
            }
                await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true);
                CrossGeolocator.Current.PositionChanged += PositionChanged;
                CrossGeolocator.Current.PositionError += PositionError;

        }

        private void PositionChanged(object sender, PositionEventArgs e)
        {

            //If updating the UI, ensure you invoke on main thread
            var position = e.Position;
            var output = "Full: Lat: " + position.Latitude + " Long: " + position.Longitude;
            output += "\n" + $"Time: {position.Timestamp}";
            output += "\n" + $"Heading: {position.Heading}";
            output += "\n" + $"Speed: {position.Speed}";
            output += "\n" + $"Accuracy: {position.Accuracy}";
            output += "\n" + $"Altitude: {position.Altitude}";
            output += "\n" + $"Altitude Accuracy: {position.AltitudeAccuracy}";


        }
        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            
            //Handle event here for errors
        }

        public async Task StopListening()
        {
            if (!CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= PositionChanged;
            CrossGeolocator.Current.PositionError -= PositionError;
        }

    }
}

//public async Task<Position> GetCurrentLocation()
        //    {

        //        Position position = null;
        //        try
        //        {
        //            var locator = CrossGeolocator.Current;
        //            locator.DesiredAccuracy = 100;

        //            position = await locator.GetPositionAsync();

        //            if (position != null)
        //            {
        //                //got a cahched position, so let's use it.
        //                return position;
        //            }

        //            if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
        //            {
        //                //not available or enabled
        //                return position;
        //            }

        //            position = await locator.GetPositionAsync(Convert.ToInt32(TimeSpan.FromSeconds(20)), null, true);
        //            return position;
        //        }
        //        catch (Exception ex)
        //        {
        //            DisplayAlert("error", "timed out or can't get location", "OK");
        //            //Display error as we have timed out or can't get location.
        //            return position;
        //        }

        //        if (position == null)
        //            return position;

        //        var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
        //            position.Timestamp, position.Latitude, position.Longitude,
        //            position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

        //        Debug.WriteLine(output);
        //    }
    