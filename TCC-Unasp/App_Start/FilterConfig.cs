﻿using System.Web;
using System.Web.Mvc;

namespace TCC_Unasp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}