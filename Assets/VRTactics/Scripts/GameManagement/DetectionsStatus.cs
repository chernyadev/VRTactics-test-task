namespace VRTactics.GameManagement
{
    public enum DetectionsStatus
    {
        Found,
        NotFound
    }

    public static class DetectionsStatusExtensions
    {
        public static string GetLabelText(this DetectionsStatus status)
        {
            return status switch
            {
                DetectionsStatus.Found => "Found",
                DetectionsStatus.NotFound => "Not Found",
                _ => ""
            };
        }
    }
}