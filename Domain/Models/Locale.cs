namespace Domain.Models
{
    public class Locale
    {
        public string En { get; set; } = String.Empty;
        public string Th { get; set; } = String.Empty;
        public string Cn { get; set; } = String.Empty;


        public override string ToString()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "th":
                case "th-th":
                    return Th;

                case "cn":
                case "zh-cn":
                    return Cn;

                default:
                    return En;
            }
        }
    }
}