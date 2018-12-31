using System.Text;

namespace YoutubeClientManagerBeta.Video.Cipher
{
    internal sealed class ReverseCipherOperation : ICipherOperation
    {
        #region INTERFACE
        public string Decipher(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input.Length);

            for (int i = (input.Length - 1); i >= 0; i--)
            {
                stringBuilder.Append(input[i]);
            }

            return stringBuilder.ToString();
        }
        #endregion
    }
}