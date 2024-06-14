namespace webAPI.Models
{
    public class NuocHoaVM
    {
        public string TenNH {  get; set; }
        public double Dongia { get; set; }
    }

    public class NuocHoa : NuocHoaVM
    {
        public Guid MaNH { get; set; }
    }
}
