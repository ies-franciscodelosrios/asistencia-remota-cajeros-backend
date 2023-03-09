namespace Proyecto_BackEnd.Utils
{
    public class HashPassWord
    {
        public static string encodedPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            } catch(Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }

        public string DecodeFrom64(string input)
        {
            System.Text.UTF8Encoding enconder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = enconder.GetDecoder();
            byte[] toDecode_byte = Convert.FromBase64String(input);
            int charCount = utf8Decode.GetCharCount(toDecode_byte,0,toDecode_byte.Length);
            char[] decode_char = new char[charCount];
            utf8Decode.GetChars(toDecode_byte,0,toDecode_byte.Length,decode_char,0);
            string result = new string(decode_char);
            return result;
        }
    }
}
