using QLNVSSV.Models.Modes;
using QLNVSSV.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
namespace QLNVSSV.Client.Components
{
    public partial class Filter
    {
        private List<Positions> listPosition { get; set; } = new();
        private List<Title> listTitle { get; set; } = new();
        [Parameter]
        public EventCallback<ApprovalFillterViewModel> Reload { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listPosition = await ApiIntergration.GetData<Positions>.GetList("http://localhost:37919/api/Position/GetAll");
            listTitle = await ApiIntergration.GetData<Title>.GetList("http://localhost:37919/api/Title/GetAll");
        }

        public ApprovalFillterViewModel model { get; set; } = new();
        
        public void FilterAction(ApprovalFillterViewModel model)
        {
            Reload.InvokeAsync(model);
            
        }
    }
}
