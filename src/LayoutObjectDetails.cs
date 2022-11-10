namespace CSharpGalenWrapper
{
    public class LayoutObjectDetails
    {
        private int[] _area;

        public LayoutObjectDetails(int[] area)
        {
            _area = area;
        }

        public int[] GetArea()
        {
            return _area;
        }

        public void SetArea(int[] area)
        {
            _area = area;
        }
    }
}