using RestWithASPNETUdemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportHyperMedia
    {
        public int CurrentePage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SortDirection { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public List<T> List { get; set; }

        public PagedSearchVO() { }

        public PagedSearchVO(int currentePage, int pageSize, string sortFields, string sortDirection)
        {
            CurrentePage = currentePage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirection = sortDirection;
        }

        public PagedSearchVO(int currentePage, int pageSize, string sortFields, string sortDirection, Dictionary<string, object> filters)
        {
            CurrentePage = currentePage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirection = sortDirection;
            Filters = filters;
        }

        public PagedSearchVO(int currentePage, string SortFields, string sortDirection) : this (currentePage, 10, SortFields, sortDirection) {}

        public int GetCurrentPage()
        {
            return CurrentePage == 0 ? 2 : CurrentePage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }


    }
}
