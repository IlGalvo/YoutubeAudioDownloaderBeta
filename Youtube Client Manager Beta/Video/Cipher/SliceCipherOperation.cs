namespace YoutubeClientManagerBeta.Video.Cipher
{
    internal sealed class SliceCipherOperation : ICipherOperation
    {
        #region GLOBAL_VARIABLE
        private int index;
        #endregion

        #region CONSTRUCTOR
        public SliceCipherOperation(int index)
        {
            this.index = index;
        }
        #endregion

        #region INTERFACE
        public string Decipher(string input)
        {
            return input.Substring(index);
        }
        #endregion
    }
}