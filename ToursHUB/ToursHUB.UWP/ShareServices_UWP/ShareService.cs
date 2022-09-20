using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Services.Share;
using ToursHUB.UWP.ShareServices_UWP;
using Xamarin.Forms;
[assembly: Dependency(typeof(ShareService))]

namespace ToursHUB.UWP.ShareServices_UWP
{
 public   class ShareService : IShare
    {

        public void Share(string ImagePath, string Imagetitle)
        {
        }
            //public async Task ShareA(string image, string Imagetitle)
            //{

            //Share_uwp shareImages = new Share_iOS();
            //Share_iOS.Init();
            //shareImages.ShareImage(ImagePath, Imagetitle);

            //var intent = new Intent(Intent.ActionSend);
            //intent.PutExtra(Intent.ExtraSubject, subject);
            //intent.PutExtra(Intent.ExtraText, message);
            //intent.SetType("image/png");

            //var handler = new ImageLoaderSourceHandler();
            //var bitmap = await handler.LoadImageAsync(image, this);

            //var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures
            //    + Java.IO.File.Separator + "logo.png");

            //using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
            //{
            //    bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
            //}
            //intent.PutExtra(Intent.ExtraStream, path);
            //intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));
            //Forms.Context.StartActivity(Intent.CreateChooser(intent, "Share Image"))
            //}

        }
}
