namespace Exercise2
{
    public static class Extensions
    {
        public static string ReverseWords(this string input)
        {
            string buffer = string.Empty;
            string output = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char character = input[i];

                if (i == 0)
                {
                    output += character + buffer.ReverseLetters();
                }
                else if (character.isSpace() || character.isPunctuationMark())
                {
                    output += buffer.ReverseLetters() + character;
                    buffer = string.Empty;
                }
                else
                {
                    buffer += character;
                }
            }

            return output;
        }

        public static string ReverseLetters(this string input)
        {
            string output = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }

            return output;
        }

        private static bool isSpace(this char character)
        {
            return character.Equals(' ');
        }

        private static bool isPunctuationMark(this char character)
        {
            return (character.Equals('.') || character.Equals(',') || character.Equals('!') || character.Equals('?'));
        }
    }
}