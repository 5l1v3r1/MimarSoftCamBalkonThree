namespace Repository.Business.Logic.Geometri
{
    public class AraMalzeme
    {
        public AraMalzeme(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}