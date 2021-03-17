using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Test.Framework.Helpers
{
    public static class MenuHelper
    {
        public static Stack<string> GetRmsMenuItems(this IEnumerable<RmsMenuItem> rmsMenuItems, string targetMenuItem, Stack<string> menuList)
        {
            if (menuList == null) menuList = new Stack<string>();

            var endItem = rmsMenuItems.Where(x => x.Name.Equals(targetMenuItem)).FirstOrDefault();

            if (endItem == null) return menuList;

            menuList.Push(endItem.Name);

            if (!endItem.ParentID.HasValue) return menuList;

            var parentItem = rmsMenuItems.Where(x => x.ID == endItem.ParentID.Value).FirstOrDefault();

            return rmsMenuItems.GetRmsMenuItems(parentItem.Name, menuList);
        }
    }
}
