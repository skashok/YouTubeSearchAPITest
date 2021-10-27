using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheHandyTube.Models;

namespace TheHandyTube.Services
{
    public interface ISearchService<T>
    {
        Task<IEnumerable<VideoItems>> GetSearchResultAsync(string searchString, bool forceRefresh = false);
    }
}
