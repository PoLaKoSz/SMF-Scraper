using System;

namespace PoLaKoSz.SMF.Scraper.Models
{
    public class RootObject<T>
    {
        public T Data { get; }

        public bool HasPreviousPage => (PreviousPage != null);
        public bool HasNextPage => (NextPage != null);

        public int? PreviousPage { get; }
        public int? NextPage { get; }



        public RootObject(T data, int? prevPage, int? nextPage)
        {
            Data = data;
            PreviousPage = prevPage;
            NextPage = nextPage;
        }
    }
}
