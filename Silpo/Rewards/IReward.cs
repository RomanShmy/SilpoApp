namespace Silpo.Rewards
{
    public interface IReward
    {
        int CalcPoints(Check check);
    }
}