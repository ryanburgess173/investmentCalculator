internal class UserVariables
{
    public UserVariables()
    {
    }

    public UserVariables(int principalLumpSum, int timelineInMonths)
    {
        PrincipalLumpSum = principalLumpSum;
        TimelineInMonths = timelineInMonths;
    }

    public int PrincipalLumpSum { get; set; }
    public int TimelineInMonths { get; set; }
}