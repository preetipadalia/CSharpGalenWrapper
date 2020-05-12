namespace CSharpGalenWrapper.Report
{
    public class LayoutObjectDetails
    {
        private int[] area;

        public LayoutObjectDetails(int[] area)
        {
            this.area = area;
        }

        public int[] getArea()
        {
            return this.area;
        }

        public void setArea(int[] area)
        {
            this.area = area;
        }
    }
}