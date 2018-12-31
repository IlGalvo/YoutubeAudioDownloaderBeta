using System.Collections.Generic;

namespace YoutubeClientManagerBeta.Video.Cipher
{
    internal sealed class PlayerSource
    {
        #region GLOBAL_VARIABLE
        private List<ICipherOperation> cipherOperations;
        #endregion

        #region CONSTRUCTOR
        public PlayerSource(List<ICipherOperation> cipherOperations)
        {
            this.cipherOperations = cipherOperations;
        }
        #endregion

        #region DECIPHER
        public string Decipher(string input)
        {
            foreach (ICipherOperation cipherOperation in cipherOperations)
            {
                input = cipherOperation.Decipher(input);
            }

            return input;
        }
        #endregion
    }
}