using ToursHUB.ViewModels;
using ToursHUB.ViewModels.Base;
using SlideOverKit;
using System;
using Xamarin.Forms;

namespace ToursHUB.Views
{
    public partial class TourCatalogView : ContentPage, IMenuContainerPage
    {
        private FiltersView _filterView = new FiltersView();

        public TourCatalogView()
        {
            InitializeComponent();

            SlideMenu = _filterView;

            MessagingCenter.Subscribe<TourCatalogViewModel>(this, MessageKeys.Filter, (sender) =>
            {
                Filter();
            });
        }

        public Action HideMenuAction
        {
            get;
            set;
        }

        public Action ShowMenuAction
        {
            get;
            set;
        }

        public SlideMenuView SlideMenu
        {
            get;
            set;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _filterView.BindingContext = BindingContext;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            if (SlideMenu.IsShown)
            {
                HideMenuAction?.Invoke();
            }
            else
            {
                ShowMenuAction?.Invoke();
            }
        }
    }
}