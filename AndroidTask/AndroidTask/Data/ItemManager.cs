using AndroidTask.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTask.Data
{
    public class ItemManager
    {
        IRestService restService;

        public ItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<GithubJavaGeeks.Item>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
