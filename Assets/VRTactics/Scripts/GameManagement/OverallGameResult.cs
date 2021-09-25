namespace VRTactics.GameManagement
{
    public enum OverallGameResult
    {
        Victory,
        Defeat
    }

    public static class OverallGameResultExtensions
    {
        public static string GetLabelText(this OverallGameResult status)
        {
            return status switch
            {
                OverallGameResult.Defeat => "DEFEAT",
                OverallGameResult.Victory => "VICTORY",
                _ => ""
            };
        }
    }
}