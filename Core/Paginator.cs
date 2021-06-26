using System;

namespace Job_Board.Core
{
    public class Paginator
    {
        public int totalPages { get; set; }
        public int firstPage { get; set; }
        public int nextPage { get; set; }
        public int prevPage { get; set; }

        public void page(int count, int size, int page)
        {
            totalPages = Math.Max((int)Math.Ceiling(Decimal.Divide(count, size)), 1);
            firstPage = 1;
            nextPage = Math.Min(page + 1, totalPages);
            prevPage = Math.Max(page - 1, firstPage);
        }

    }
}
