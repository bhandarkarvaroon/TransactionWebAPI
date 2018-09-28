namespace TransactionWebApi.Models
{
    public enum TransactionType
    {
        Subscription = 0,
        Redemption
    }

    public enum TransactionSubType
    {
        NewSubscription = 1,
        AdditionalSubscription,
        PartialRedemption,
        FullRedemption
    }

    public class Status
    {
        const bool Inactive = false;
        const bool Active = true;

    }

    public enum TrasactionStatus
    {
        Final,
        Pending
    }
}