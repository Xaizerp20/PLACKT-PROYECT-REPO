using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace manageRegistersApp.Data
{
    

    public  class GlobalMethods: IGlobalService
    {
        private readonly IJSRuntime JSRuntime;

        public async void  ShowAlert(string msg)
        {
            await JSRuntime.InvokeVoidAsync("alert", msg);
        }
    }
}
