namespace BirthflowMicroServices.Infraestructure.Helpers
{
    public class Helper
    {
        public static string GenerateHeader(int number)
        {
            if (number < 0 || number > 16)
            {
                return " ";
            }

            char[] letras = "abcdefghijklmnop".ToCharArray();
            return letras[number].ToString();
        }
    }
}