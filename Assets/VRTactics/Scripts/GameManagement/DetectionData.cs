namespace VRTactics.GameManagement
{
    public readonly struct DetectionData
    {
        public readonly string Name;
        public readonly DetectionsStatus Status;

        public DetectionData(string name, DetectionsStatus status)
        {
            Name = name;
            Status = status;
        }
    }
}