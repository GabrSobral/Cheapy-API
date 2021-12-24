using System.Collections.Generic;
using System;

namespace Cheapy_API.Models
{
    public class Category
    {
        #region Columns
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
        #endregion

        #region Navigations Objects
            public virtual List<Category_Product> CategoryProduct { get; set; }
        #endregion
    }
}