using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QLNVSSV.Models.Modes;

namespace QLNVSSV.Client.Components
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
    }

    public partial class UpdateEdit
    {

        public string ModalDisplay { get; set; } = "none;";

        public string ModalClass { get; set; } = "";
        
        public int type { get; set; }

        public int Id { get; set; }

        private QLNVSSV.Models.Modes.Employee employee { get; set; } = new();
        private List<Positions> listPosition { get; set; } = new();
        private List<Title> listTitle { get; set; } = new();

        public EventCallback<int> typeChange { get; set; }

        private IBrowserFile fileSelect { get; set; }
        public void Open()
        {
            ModalDisplay = "block;";
            ModalClass = "show";
            StateHasChanged();
        }
        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            StateHasChanged();
        }

        public async Task Show(int id)
        {
            employee = new Employee();
            Id = id;
            if (id != 0)
            {
                employee = await ApiIntergration.GetData<Employee>.GetById($"http://localhost:37919/api/Employee/{id}");
            }
            //else
            //{
            //    employee = new Employee();
            //}
            Open();
        }

        protected override async Task OnInitializedAsync()
        {
            listPosition = await ApiIntergration.GetData<Positions>.GetList("http://localhost:37919/api/Position/GetAll");
            listTitle = await ApiIntergration.GetData<Title>.GetList("http://localhost:37919/api/Title/GetAll");
            Console.WriteLine(type);
            
        }

        
        public async void PostData()
        {
            Console.WriteLine(employee);
            //=0 create
            if (Id == 0)
            {
                
            }
            else
            {
               await ApiIntergration.GetData<Employee>.Put("http://localhost:37919/api/Employee",employee);
                if (fileSelect != null)
                {
                    //var fileInfo = await fileSelect.ReadFileInfoAsync();
                    //using (var ms = await fileSelect.CreateMemoryStreamAsync(4 * 1024))
                    //{
                    //    var content = new MultipartFormDataContent();
                    //    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    //    content.Add(new StreamContent(ms, Convert.ToInt32(ms.Length)), "image", fileInfo.Name);
                    //    //ImgUrl = await Repository.UploadProductImage(content);
                    //   // await OnChange.InvokeAsync(ImgUrl);
                    //}
                }
            }
        }
        
        public void Save()
        {
            
        }
        public void OnFileSelected(InputFileChangeEventArgs e)
        {
            fileSelect = null;
            fileSelect = e.File;
        }


    }
}
