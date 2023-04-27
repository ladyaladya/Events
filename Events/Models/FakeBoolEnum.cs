namespace Events.UI.Models
{
    public enum FakeBoolEnum
    {
        n,
        y,
    }

    public static class StatusExtensions
    {
        public static FakeBoolEnum Toggle(this FakeBoolEnum status)
        {
            return status ^ FakeBoolEnum.y;
        }
    }
}
