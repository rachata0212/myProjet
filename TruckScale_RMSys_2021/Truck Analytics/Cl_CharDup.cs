using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Analytics
{
    class Cl_CharDup
    {
        public static List<T> RemoveDuplicatesSet<T>(List<T> items)
        {
            // Use HashSet to remember items seen.
            var result = new List<T>();
            var set = new HashSet<T>();
            for (int i = 0; i < items.Count; i++)
            {
                // Add if needed.
                if (!set.Contains(items[i]))
                {
                    result.Add(items[i]);
                    set.Add(items[i]);
                }
            }
            return result;
        }
    }
}
