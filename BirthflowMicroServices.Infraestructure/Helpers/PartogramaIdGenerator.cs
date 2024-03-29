﻿namespace BirthflowMicroServices.Infraestructure.Helpers
{
    public class PartogramaIdGenerator
    {
        private static readonly string[] ExcludedWords = { "de", "los", "las", "del", "y", "a" };
        private static readonly int MaxInitials = 6;

        public static string CreateUniqueId(string name, DateTime creationDate)
        {
            string creationDateString = creationDate.ToString("yyMMdd");
            string creationDateString2 = creationDate.ToString("mms");

            string[] nameWords = name.Split(' ');
            string nameInitials = string.Join("", nameWords
                  .Where(word => !ExcludedWords.Contains(word.ToLower()))
                  .Select(word => word.Length > 0 ? word[0].ToString() : "")
                  .Take(MaxInitials));

            string uniqueId = $"{nameInitials}{creationDateString}{creationDateString2}";

            return uniqueId;
        }
    }
}