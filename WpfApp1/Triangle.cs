namespace GeometryApp
{
    public class Triangle : Figure
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double bas, double height)
        {
            Base = bas;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
