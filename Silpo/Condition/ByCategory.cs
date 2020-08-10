namespace Silpo.Condition
{
    public class ByCategory : ICondition
    {
        private Category category;

        public ByCategory(Category category) => this.category = category;

        public bool Verify(Check check)
        {
            return check.getCostByCategory(this.category) > 0;
        }
    }
}