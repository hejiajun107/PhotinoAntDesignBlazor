using System.Collections.Generic;
using AntBlazorPro.Models;
using Microsoft.AspNetCore.Components;

namespace AntBlazorPro.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}