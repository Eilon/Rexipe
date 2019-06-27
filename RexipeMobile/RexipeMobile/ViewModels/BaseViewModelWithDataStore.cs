
using Xamarin.Forms;

using RexipeMobile.Models;
using RexipeMobile.Services;

namespace RexipeMobile.ViewModels
{
    public class BaseViewModelWithDataStore : BaseViewModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();
    }
}
