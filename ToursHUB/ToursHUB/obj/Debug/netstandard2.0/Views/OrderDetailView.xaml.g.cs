//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("ToursHUB.Views.OrderDetailView.xaml", "Views/OrderDetailView.xaml", typeof(global::ToursHUB.Views.OrderDetailView))]

namespace ToursHUB.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views/OrderDetailView.xaml")]
    public partial class OrderDetailView : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Grid OrderInfo;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Grid ShippingAddress;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Grid OrderItems;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(OrderDetailView));
            OrderInfo = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "OrderInfo");
            ShippingAddress = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "ShippingAddress");
            OrderItems = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "OrderItems");
        }
    }
}