using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BusinessService
{
    public class MenuItem
    {
        public string Caption { get; set; }
        public Module Module { get; set; }
        public string Url { get; set; }
    }

    public static class MenuLayout
    {
        public static Dictionary<string, List<Dictionary<string, List<MenuItem>>>> GetMenuLayout(UrlHelper helper)
        {
            if (helper == null) throw new ArgumentNullException(nameof(helper));

            var layout = new Dictionary<string, List<Dictionary<string, List<MenuItem>>>>();
            var menu = new Dictionary<string, List<MenuItem>>
            {
                {
                     "", new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Caption = "People"
                        },
                        new MenuItem
                        {
                            Caption = "Money",
                            Module = Module.Money,
                            Url = helper.Action("Index", "People", new {Id=1})
                        }
                        
                    }
                }
            };
            layout.Add("People", new List<Dictionary<string, List<MenuItem>>> {menu});
            return layout;
        }
    }
}