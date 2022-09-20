using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atom.Forms.ImageShare.iOS;
using Foundation;
using ToursHUB.iOS.ShareServices_Ios;
using ToursHUB.Services.Share;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ShareService))]

namespace ToursHUB.iOS.ShareServices_Ios
{
    public class ShareService : IShare
    {
        public void Share(string ImagePath, string Imagetitle)
        {

            Share_iOS shareImages = new Share_iOS();
            Share_iOS.Init();
            shareImages.ShareImage(ImagePath, Imagetitle);
            //        var handler = new ImageLoaderSourceHandler();
            //        var uiImage = await handler.LoadImageAsync(image);

            //        var img = NSObject.FromObject(uiImage);
            //        var mess = NSObject.FromObject(message);

            //        var activityItems = new[] { mess, img };
            //        var activityController = new UIActivityViewController(activityItems, null);

            //        var topController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            //        while (topController.PresentedViewController != null)
            //        {
            //            topController = topController.PresentedViewController;
            //        }

            //        topController.PresentViewController(activityController, true, () => { });
        }
    }
    }