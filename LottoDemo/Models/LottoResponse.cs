using System;
namespace LottoDemo.Models
{
    

    public class LottoResponse
    {
        public List<Draw> Draws { get; set; }
        public object ErrorInfo { get; set; }
        public bool Success { get; set; }
    }

    public class Draw
    {
        public string ProductId { get; set; }
        public int DrawNumber { get; set; }
        public string DrawDisplayName { get; set; }
        public DateTime DrawDate { get; set; }
        public string DrawLogoUrl { get; set; }
        public string DrawType { get; set; }
        public double Div1Amount { get; set; }
        public bool IsDiv1Estimated { get; set; }
        public bool IsDiv1Unknown { get; set; }
        public DateTime DrawCloseDateTimeUTC { get; set; }
        public DateTime DrawEndSellDateTimeUTC { get; set; }
        public double DrawCountDownTimerSeconds { get; set; }
        public string DaysOfWeek { get; set; }
        public double PrizeBoostPercent { get; set; }
        public double PrizeBoost { get; set; }
    }

}

