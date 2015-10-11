using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portals.infrastructure
{
    public class GeneralHelper
    {
        // Summary:
        // 顯示時間
        public static string TimeAgo(DateTime d)
        {

            if (d == null)
            {
                return null;
            }
            TimeSpan s = DateTime.Now.Subtract(d);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 4.
            // Don't allow out of range values.
            if (dayDiff < 0)
            {
                return null;
            }
            else if (dayDiff > 30)
            {
                //return string.Format("{0} 個月前", Math.Ceiling((double)dayDiff / 30) - 1);
                return d.ToShortDateString();
            }
            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "剛剛";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 分鐘前";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} 分鐘前",
                        Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 小時前";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} 小時前",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return "昨天";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} 天前",
                dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} 週前",
                Math.Ceiling((double)dayDiff / 7));
            }
            return null;
        }
	}
}