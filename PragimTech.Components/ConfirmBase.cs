using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace PragimTech.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }
        //custom event
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete confirmation";
        [Parameter]
        public string ConfirmationMsg { get; set; } = "Are you sure you want to delete?";
        //event handler
        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }

    }
}
