using Microsoft.AspNetCore.Components;
using QLNVSSV.Client.Features;
using QLNVSSV.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNVSSV.Client.Components
{
    public partial class Pagination
    {
        [Parameter]
        public MetaData MetaData { get; set; }
        
        // do rong cua index vd ..5,6,7,8,9 => 5
        [Parameter]
        public int Spread { get; set; }


        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        //
        public List<PagingLink> _link;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _link = new List<PagingLink>();
            //Nut prev
            _link.Add(new PagingLink(MetaData.CurrentPage - 1, MetaData.HasPrev, "Prev"));
            for(var i = 1; i < MetaData.TotalPage; i++)
            {
                //Render tu current page den - spread
                if (i > MetaData.CurrentPage - Spread && i < MetaData.CurrentPage + Spread)
                {
                    _link.Add(new PagingLink(i, true, i.ToString()) { Active=MetaData.CurrentPage==i});
                }
            }

            _link.Add(new PagingLink(MetaData.CurrentPage + 1, MetaData.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            //kiem tra xem co click vao page hien tai ko neu co return;
            if (link.Page == MetaData.CurrentPage || !link.Enabled)
                return;

            //
            MetaData.CurrentPage = link.Page;

            //Thực hiện event
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
