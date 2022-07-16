using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCollection
{
    public static class CollectionReader
    {
        public static List<CollectionItem> RetrieveRawCollection(string collectionFilePath)
        {
            StreamReader sr = new StreamReader(collectionFilePath);
            List<CollectionItem> collectionData = new List<CollectionItem>();
            string? line;
            string[] row = new string[11];
            while ((line = sr.ReadLine()) != null)
            {
                if (!(line.StartsWith(",") || line.StartsWith("Id")))
                {
                    row = line.Split(',');
                    CollectionItem rawItem = new CollectionItem
                    {
                        Id = float.Parse(row[0]),
                        Name = row[1],
                        RetailValue = float.Parse(row[2]),
                        WholesaleValue = float.Parse(row[3]),
                        Year = ushort.Parse(row[4]),
                        Count = ushort.Parse(row[5]),
                        Description = row[6],
                        IsSummary = bool.Parse(row[7]),
                        IsUnique = bool.Parse(row[8]),
                    };

                    collectionData.Add(rawItem);
                }
            }

            sr.Close();
            return collectionData;
        }

        public static List<CollectionItem> ComposeDiscreetItemList(List<CollectionItem> rawCollection)
        {
            List<CollectionItem> collectionData = new List<CollectionItem>();
            foreach (CollectionItem rawItem in rawCollection)
            {
                if (rawItem.Count == 1)
                {
                    collectionData.Add(rawItem);
                }
                else
                {
                    // for the number of count
                    for (int intSubIndex = 1; intSubIndex <= rawItem.Count; intSubIndex++)
                    {
                        // compose the subIndex
                        float subIndex = intSubIndex;
                        do
                        {
                            subIndex /= 10;
                        } while (subIndex >= 1);

                        collectionData.Add(new CollectionItem
                        {
                            Id = rawItem.Id + subIndex,
                            Name = rawItem.Name,
                            RetailValue = rawItem.RetailValue / rawItem.Count,
                            WholesaleValue = rawItem.WholesaleValue / rawItem.Count,
                            Year = rawItem.Year,
                            Count = rawItem.Count,
                            Description = rawItem.Description,
                            IsSummary = false,
                            IsUnique = rawItem.IsUnique,
                        });
                    }
                }
            }

            return collectionData;
        }
    }
}
