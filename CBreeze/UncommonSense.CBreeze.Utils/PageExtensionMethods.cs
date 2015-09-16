﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class PageExtensionMethods
    {
        private static PageActionContainer GetRelatedInformation(this Page page)
        {
            return page.Properties.ActionList.OfType<PageActionContainer>().FirstOrDefault(c => c.Properties.ActionContainerType == ActionContainerType.RelatedInformation);
        }

        public static PageActionContainer GetRelatedInformation(this Page page, IEnumerable<int> range)
        {
            var result = GetRelatedInformation(page) ?? page.Properties.ActionList.Insert(0, new PageActionContainer(range.GetNextPageControlID(page), 0));
            result.Properties.ActionContainerType = ActionContainerType.RelatedInformation;
            return result;
        }


        /// <summary>
        /// Returns the (first/only) ContentArea container page control.
        /// </summary>
        private static ContainerPageControl GetContentArea(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.ContentArea);
        }

        /// <summary>
        /// Returns the (first/only) FactBoxArea container page control.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private static ContainerPageControl GetFactBoxArea(this Page page)
        {
            return page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == ContainerType.FactBoxArea);
        }

        /// <summary>
        /// Returns the (first/only) ContentArea container page control. If it didn't exist before,
        /// it will be created with an ID from <paramref name="range"/>, and inserted as the first 
        /// control.
        /// </summary>
        public static ContainerPageControl GetContentArea(this Page page, IEnumerable<int> range)
        {
            var result = GetContentArea(page) ?? page.Controls.Insert(0, new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.ContentArea;
            return result;
        }

        /// <summary>
        /// Returns the (first/only) FactBoxArea container page control. If it didn't exist before,
        /// it will be created with an ID form <paramref name="range"/>, and appended as the last 
        /// control.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static ContainerPageControl GetFactboxArea(this Page page, IEnumerable<int> range)
        {
            var result = GetFactBoxArea(page) ?? page.Controls.Add(new ContainerPageControl(range.GetNextPageControlID(page), 0));
            result.Properties.ContainerType = ContainerType.FactBoxArea;
            return result;
        }
    }
}