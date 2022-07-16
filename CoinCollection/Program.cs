using System;
using System.Collections.Generic;

namespace CoinCollection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static string testDataPath = @"C:\Users\jvaud\source\repos\CoinCollection\CoinCollection\Resources\CoinCollectionTestData.csv";
        static void Main(string[] args)
        {
            List<CollectionItem> rawCollection = CollectionReader.RetrieveRawCollection(testDataPath);
            List<CollectionItem> collection = CollectionReader.ComposeDiscreetItemList(rawCollection);

            Console.WriteLine("all done!");
        }
    }
}