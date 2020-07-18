using System;
using System.Collections.Generic;

namespace SimpleTodo.Models.ResponseModels
{
    public class PaginationMetaModel<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
