using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace ToursHUB.Services.Share
{
  public  interface IPhotoServices
  {
      Task<MediaFile> TakePhoto();
      Task<MediaFile> PickPhotoButton();
      Task<MediaFile> TakeVedioButton();
      Task<MediaFile> PickVedioButton();
      void SharePhoto(string filepath);

  }
}
