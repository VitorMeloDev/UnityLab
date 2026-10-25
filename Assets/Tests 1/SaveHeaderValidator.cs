namespace VMGames.Core.Validation
{
    public class SaveHeaderValidator
    {
        private const int MinVersion = 1;

        public bool IsValidHeader(int dataVersion, string checksum)
        {
            return dataVersion >= MinVersion && !string.IsNullOrEmpty(checksum);
        }
    }
}