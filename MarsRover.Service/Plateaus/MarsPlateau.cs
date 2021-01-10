namespace MarsRover.Service.Plateaus
{
    public class MarsPlateau : IPlateau
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public MarsPlateau(int weight, int height)
        {
            this.Width = weight;
            this.Height = height;
        }
        public MarsPlateau() : this(5, 5) { }

        public override string ToString()
        {
            return $"Width : {Width} Height : {Height}";
        }
    }
}
