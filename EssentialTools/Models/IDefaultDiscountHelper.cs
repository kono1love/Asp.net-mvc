namespace EssentialTools.Models
{
    public interface IDefaultDiscountHelper
    {
        decimal DiscountSize { get; set; }

        decimal ApplyDiscount(decimal totalParam);
    }
}