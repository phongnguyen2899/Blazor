using System.Collections.Generic;

namespace QLNVSSV.ViewModels.Common
{
    public class ServiceResponse
    {
        public List<string> Msg { get; set; } = new List<string>();

        public bool Success { get;set; }

        public object Data { get; set; }
    }
}
