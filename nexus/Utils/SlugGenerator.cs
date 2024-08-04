using System.Text.RegularExpressions;

namespace nexus.Utils
{
    public class SlugGenerator
    {
        private static readonly SlugGenerator _instance = new();
        public static SlugGenerator Instance
        {
            get
            {
                return _instance;
            }
        }

        // Method to generate slug from article title
        public string GenerateSlug(string title)
        {
            // Convert to lower case
            string slug = title.ToLowerInvariant();

            // Remove invalid characters
            slug = RemoveInvalidChars(slug);

            // Replace spaces with hyphens
            slug = ReplaceSpaces(slug);

            // Trim hyphens from ends
            slug = TrimHyphens(slug);

            // Append hexadecimal timestamp
            slug = AppendHexTimestamp(slug);

            return slug;
        }

        // Method to remove invalid characters using regular expressions
        private string RemoveInvalidChars(string input)
        {
            // Replace any character that is not a letter, digit, space or hyphen with an empty string
            return Regex.Replace(input, @"[^a-z0-9\s-]", string.Empty);
        }

        // Method to replace spaces with hyphens
        private string ReplaceSpaces(string input)
        {
            // Replace one or more spaces with a single hyphen
            return Regex.Replace(input, @"\s+", "-");
        }

        // Method to trim hyphens from start and end of the string
        private string TrimHyphens(string input)
        {
            return input.Trim('-');
        }

        // Method to append hexadecimal timestamp to the slug
        private string AppendHexTimestamp(string slug)
        {
            long timestamp = DateTime.UtcNow.Ticks;
            string hexTimestamp = timestamp.ToString("X");
            return $"{slug}-{hexTimestamp.ToLower()}";
        }
    }
}
