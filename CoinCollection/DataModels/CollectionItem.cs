namespace CoinCollection
{
    public class CollectionItem
    {
        public float Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public float RetailValue { get; set; }

        public float WholesaleValue { get; set; }

        public ushort Year { get; set; }

        public ushort Count { get; set; } 

        public string Description { get; set; } = string.Empty;

        public bool IsSummary { get; set; }

        public bool IsUnique { get; set; }
    }
}
