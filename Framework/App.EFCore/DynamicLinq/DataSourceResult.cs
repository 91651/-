﻿using System.Collections;

namespace App.EFCore.DynamicLinq
{
    public class DataSourceResult
    {
        public IEnumerable Data { get; set; }
        public int Total { get; set; }
    }
}
