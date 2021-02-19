using System;
using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
    public interface IPagedList
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string Query { get; set; }
        string ReferenceAction { get; set; }
        double TotalPages { get; }
        int TotalResults { get; set; }
    }

    public class PagedViewModel<T> : IPagedList where T : class
    {
        public string ReferenceAction { get; set; }
        public IEnumerable<T> List { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResults { get; set; }
        public double TotalPages => Math.Ceiling((double)TotalResults / PageSize);
    }
}
