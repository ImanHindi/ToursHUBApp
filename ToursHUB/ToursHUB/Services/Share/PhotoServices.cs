using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ToursHUB.Services.Share
{
  public  class PhotoServices: IPhotoServices
    {
     //   public IDependencyService _DependencyService;
        //public PhotoServices(IDependencyService dependencyService)
        //{
        //    _DependencyService = dependencyService;
        //}

        public MediaFile file { get; set; }

      



        public async Task<MediaFile> TakePhoto()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
              //  await DisplayAlert("No Camera", "No Camera Available", "OK");
              //  return;
            }
            file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
            });
            return file;
        }

        public async Task<MediaFile> PickPhotoButton()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsPickPhotoSupported)
            {
                //await DisplayAlert("No Camera", "No Camera Available", "OK");
                //return;
            }
            file = await CrossMedia.Current.PickPhotoAsync();
            return file;
            
           
        }

        public async Task<MediaFile> TakeVedioButton()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakeVideoSupported)
            {
                //await DisplayAlert("No Camera", "No Camera Available", "OK");
                //return;
            }
            file = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions()
            {
                SaveToAlbum = true,
                Quality = VideoQuality.Medium,
            });
            return file;
        }

        public async Task<MediaFile> PickVedioButton()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsPickVideoSupported)
            {
                //await DisplayAlert("No Camera", "No Camera Available", "OK");
                //return;
            }

            file = await CrossMedia.Current.PickVideoAsync();
            return file;
            
          
        }

        public void  SharePhoto(string filepath)
        {
          DependencyService.Get<IShare>().Share(filepath, "Hello");

        }
    }
}
