using System;
using System.Collections.Generic;
using CoinCollection.Comparers;

namespace CoinCollection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static string testDataPath = @"/Users/jeffreyvaudrin-mclean/repos/CoinCollection/CoinCollection/Resources/CoinCollectionTestData.csv";

        // private static

        // 7 bins - bin id to collection hashset
        Dictionary<int, HashSet<CollectionItem>> intIdToCollectionSetDictionary = new Dictionary<int, HashSet<CollectionItem>>();

        // Queue for 7 bins/sets to draw lowest value bin
        //PriorityQueue<HashSet<CollectionItem>, HashSet<CollectionItem>> collectionSetPriorityQueue =
        //    new PriorityQueue<HashSet<CollectionItem>, HashSet<CollectionItem>>(new CollectionItemSetComparer());
        //PriorityQueue<HashSet<CollectionItem>, int> collectionSetPriorityQueue = new PriorityQueue<HashSet<CollectionItem>, int>();

        //Comparer<int>.Create((x, y) => y - x)

        //TPriority Priority
        static void Main(string[] args)
        {
            PriorityQueue<HashSet<CollectionItem>, float> collectionSetPriorityQueue =
                new PriorityQueue<HashSet<CollectionItem>, float>(Comparer<float>.Create((float x, float y) => x > y ? 1 : -1)); // sort ascending

            List<CollectionItem> rawCollection = CollectionReader.RetrieveRawCollection(testDataPath);
            List<CollectionItem> collection = CollectionReader.ComposeDiscreetItemList(rawCollection);

            List<CollectionItem> testCollection1 = new List<CollectionItem>()
            {
                new CollectionItem()
                {
                    Id = "testId1",
                    Name = "testName1",
                    RetailValue = 10,
                    WholesaleValue = 1,
                    Count = 1
                }
            };

            List<CollectionItem> testCollection2 = new List<CollectionItem>()
            {
                new CollectionItem()
                {
                    Id = "testId2",
                    Name = "testName2",
                    RetailValue = 20,
                    WholesaleValue = 2,
                    Count = 1
                }
            };

            // TEST: check CollectionItem compareto
            Console.WriteLine(rawCollection[0] > rawCollection[1]);

            // TEST: check HashSet comparer (collection > rawCollection)
            collectionSetPriorityQueue.Enqueu(testCollection1)

            // pre-process

            //

            Console.WriteLine("all done!");
        }
    }
}