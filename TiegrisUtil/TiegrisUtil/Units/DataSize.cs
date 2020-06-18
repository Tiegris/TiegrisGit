namespace TiegrisUtil.Units
{
    public class DataSize
    {
        long bytes;

        public DataSize(long bytes) {
            this.bytes = bytes;
        }

        public long kiB => bytes / 1024;
        public long MiB => kiB / 1024;
        public long GiB => MiB / 1024;
        public long TiB => GiB / 1024;

        private static readonly string[] units = 
            { "B", "kiB", "MiB", "GiB", "TiB" , "PiT"};
        private static readonly string[] unitsLong =
            { "Byte", "kiloByte", "MegaByte", "GigaByte", "TeraByte", "PetaByte"};

        public double GetHumanReadableValue() {
            double len = bytes;
            int selUnit = 0;
            while (len >= 1024 && selUnit < units.Length - 1) {
                selUnit++;
                len = len / 1024;
            }
            return len;
        }

        public string GetHumanReadableUnit(bool longNames = false) {
            double len = bytes;
            int selUnit = 0;
            while (len >= 1024 && selUnit < units.Length - 1) {
                selUnit++;
                len = len / 1024;
            }
            return longNames ? unitsLong[selUnit] : units[selUnit];
        }

    }
}
