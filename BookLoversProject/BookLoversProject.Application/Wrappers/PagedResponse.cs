﻿namespace BookLoversProject.Application.Wrappers
{
    public class PagedResponse<T>
    {
        public T Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize, int totalPages)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalPages = totalPages;
        }
    }
}
