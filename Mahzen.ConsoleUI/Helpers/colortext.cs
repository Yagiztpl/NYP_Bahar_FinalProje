namespace ColortextFunction
{
    internal class ColorText
    {
         public static void CWriteLine(string color, string text)
        {
            switch (color.ToLower())
            {
                case "red": Console.ForegroundColor = ConsoleColor.Red; break;
                case "r": Console.ForegroundColor = ConsoleColor.Red; break;
                case "green": Console.ForegroundColor = ConsoleColor.Green; break;
                case "g": Console.ForegroundColor = ConsoleColor.Green; break;
                case "blue": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "b": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "yellow": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "y": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "purple": Console.ForegroundColor = ConsoleColor.Magenta; break;
                case "p": Console.ForegroundColor = ConsoleColor.Magenta; break;
                case "cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "c": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "orange": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "o": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "white": Console.ForegroundColor = ConsoleColor.White; break;
                case "w": Console.ForegroundColor = ConsoleColor.White; break;
                case "black": Console.ForegroundColor = ConsoleColor.Black; break;
                case "bl": Console.ForegroundColor = ConsoleColor.Black; break;
                default:
                    break;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void CWrite(string color, string text)
        {
            switch (color.ToLower())
            {
                case "red": Console.ForegroundColor = ConsoleColor.Red; break;
                case "r": Console.ForegroundColor = ConsoleColor.Red; break;
                case "green": Console.ForegroundColor = ConsoleColor.Green; break;
                case "g": Console.ForegroundColor = ConsoleColor.Green; break;
                case "blue": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "b": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "yellow": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "y": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "purple": Console.ForegroundColor = ConsoleColor.Magenta; break;
                case "p": Console.ForegroundColor = ConsoleColor.Magenta; break;
                case "cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "c": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "orange": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "o": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case "white": Console.ForegroundColor = ConsoleColor.White; break;
                case "w": Console.ForegroundColor = ConsoleColor.White; break;
                case "black": Console.ForegroundColor = ConsoleColor.Black; break;
                case "bl": Console.ForegroundColor = ConsoleColor.Black; break;
                default:
                    break;
            }
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
