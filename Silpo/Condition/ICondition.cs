namespace Silpo.Condition
{
    public interface ICondition
    {
        bool Verify(Check check);
    }
}