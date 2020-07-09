namespace InsuranceAPI.Models
{
    public class Insurance
    {
        const decimal safetyMargin = 0.03M;
        const decimal profit = 0.05M;

        public int idInsurance { get; set; }
        public Car car { get; set; }
        public Insured insured { get; set; }
        public double InsurancePrice { get; set; }

        public double riskRate { get; set; }
        public double riskPrize { get; set; }
        public double purePrize { get; set; }
        public double commercialPrize { get; set; }
    }
}