using System.Threading.Tasks;

namespace ToursHUB.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
