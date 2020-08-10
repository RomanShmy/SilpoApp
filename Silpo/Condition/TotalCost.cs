namespace Silpo.Condition
{
    public class TotalCost : ICondition
    {
        public int totalCost { get; protected set; } 
        public TotalCost(int totalCost) => this.totalCost = totalCost;
        public bool Verify(Check check) => check.GetTotalCost() >= totalCost;
    }
}