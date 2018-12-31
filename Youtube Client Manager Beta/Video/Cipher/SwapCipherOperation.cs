using System.Text;

namespace YoutubeClientManagerBeta.Video.Cipher
{
    internal sealed class SwapCipherOperation : ICipherOperation
    {
        #region GLOBAL_VARIABLE
        private int index;
        #endregion

        #region CONSTRUCTOR
        public SwapCipherOperation(int index)
        {
            this.index = index;
        }
        #endregion

        #region INTERFACE
        public string Decipher(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input)
            {
                [0] = input[index],
                [index] = input[0]
            };

            return stringBuilder.ToString();
        }
        #endregion
    }
}