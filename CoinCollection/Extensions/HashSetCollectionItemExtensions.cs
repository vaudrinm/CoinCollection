using System;
using System.Collections.Generic;

namespace CoinCollection.Extensions
{
	public static class ExtensionMethods
	{
		public static float CollectionItemSetValue(this HashSet<CollectionItem> col)
		{
            float setValue = 0;
            bool compareByRetailvalue = CollectionItem.CompareByRetailValue;
            foreach (CollectionItem item in col)
            {
                setValue += compareByRetailvalue ? item.RetailValue : item.WholesaleValue;
            }
            return setValue;
        }

        // new function on 
        public static void EnqueueCollectionItemSet(this PriorityQueue<HashSet<CollectionItem>, double> queue, HashSet<CollectionItem> set)
        {
            queue.Enqueue(set, set.CollectionItemSetValue());
        }
    }
}
