namespace POCO
{
    using System.Collections.Generic;

    public class TeachingAssistant
    {
        public int TeachingAssistantId { get; set; }

        public int TypeId { get; set; }

        public string typeDesc { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        public override string ToString()
        {
            return this.TeachingAssistantId + "-"
                + this.TypeId + "-"
                + this.First + "-"
                + this.Last;
        }
    }
}
