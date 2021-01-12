namespace TNBase.Infrastructure.Helpers
{
    public static class DateHelpers
    {
        public static int GetDaysInMonth(int month)
        {
            switch (month)
            {
                case 2:
                    return 29;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 31;
            }
        }
    }
}
