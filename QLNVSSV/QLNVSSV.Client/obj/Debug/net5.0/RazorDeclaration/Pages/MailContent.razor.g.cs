// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace QLNVSSV.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using QLNVSSV.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using QLNVSSV.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Mailcontent")]
    public partial class MailContent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "C:\Users\PhongNV\Desktop\CRUDMYSQL\QLNVSSV\QLNVSSV.Client\Pages\MailContent.razor"
       
    public QLNVSSV.Models.Modes.MailContent mailContent { get; set; } = new();

    public List<QLNVSSV.Models.Modes.MailContent> listMail { get; set; } = new();

    public bool loading { get; set; } = false;

    void toggle(bool value) => loading = value;

    protected override async Task OnInitializedAsync()
    {
        toggle(true);
        listMail = await ApiIntergration.GetData<QLNVSSV.Models.Modes.MailContent>.GetList("http://localhost:37919/api/MailContent/GetAll");
        mailContent = listMail[0];
        toggle(false);
    }
    public void changeItem(ChangeEventArgs arg)
    {
        for (var i = 0; i < listMail.Count; i++)
        {
            if (Convert.ToInt32(arg.Value) == listMail[i].Id)
            {
                mailContent = listMail[i];
                break;
            }
        }
    }
    public void Update()
    {
        toggle(true);
        if (mailContent != null)
        {
            var rs = ApiIntergration.GetData<QLNVSSV.Models.Modes.MailContent>.Put("http://localhost:37919/api/MailContent", mailContent);
        }
        toggle(false);
         NoticeWithIcon(NotificationType.Success);

    }
    private void  NoticeWithIcon(NotificationType type)
    {
        _notice.Open(new NotificationConfig()
        {
            Message = "Thành công",
            Description = "",
            NotificationType = type
        });
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NotificationService _notice { get; set; }
    }
}
#pragma warning restore 1591
