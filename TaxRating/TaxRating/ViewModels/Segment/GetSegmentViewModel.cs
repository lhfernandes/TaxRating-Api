namespace TaxRating.ViewModels.Segment
{
    public class GetSegmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Tax { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
