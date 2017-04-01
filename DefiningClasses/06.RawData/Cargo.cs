

namespace _06.RawData
{
    class Cargo
    {
        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
