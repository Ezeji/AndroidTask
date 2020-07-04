using AndroidTask.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTask.Data
{
    public interface IRestService
    {
        Task<List<GithubJavaGeeks.Item>> RefreshDataAsync();  
    }
}
