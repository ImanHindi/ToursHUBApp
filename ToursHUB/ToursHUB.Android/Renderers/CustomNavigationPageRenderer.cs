using Android.Content;
using Android.Widget;
using ToursHUB.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using ViewStates=Android.Views.ViewStates;
using Toolbar=Android.Support.V7.Widget.Toolbar;
[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPageRenderer))]
namespace ToursHUB.Droid.Renderers
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        public CustomNavigationPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (Element.CurrentPage == null)
            {
                return;
            }

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                var image = toolbar.FindViewById<ImageView>(Resource.Id.image);

                if (!string.IsNullOrEmpty(Element.CurrentPage.Title))
                    image.Visibility = ViewStates.Invisible;
                else
                    image.Visibility = ViewStates.Visible;
            }
        }
    }
}
