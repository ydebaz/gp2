﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Areas.MvcDashboardIdentity.Models;
using gp_.Areas.MvcDashboardIdentity.Models.ViewComponents;

namespace gp_.Areas.MvcDashboardIdentity.ViewComponents
{
    public class MvcDashboardIdentityPagerViewComponent : ViewComponent
    {
        #region Construction

        public MvcDashboardIdentityPagerViewComponent()
        { }

        #endregion

        public IViewComponentResult Invoke(DataPage page)
        {
            var model = new MvcDashboardIdentityPagerModel();
            model.DataPage = page;

            return View(model);
        }
    }
}
