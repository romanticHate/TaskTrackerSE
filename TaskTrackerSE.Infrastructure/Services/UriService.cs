using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.QueryFilters;
using TaskTrackerSE.Infrastructure.Interfaces;

namespace TaskTrackerSE.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUri(TaskItemQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
