using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace YoutubeAudioDownloaderBeta.Main
{
    internal class AnimationManager
    {
        #region GLOBAL_VARIABLES
        private static readonly PropertyInfo PropertyInfoManager = typeof(Control).GetProperty("DoubleBuffered", (BindingFlags.Instance | BindingFlags.NonPublic));

        private bool animateControls;
        public bool AnimateControls { get { return animateControls; } set { animateControls = value; ManageAnimation(); } }

        private List<Control> locationControlList;
        private Dictionary<Control, bool> sizeControlDictionary;

        private int animationOffset;
        #endregion

        #region CONSTRUCTOR
        public AnimationManager(int animationOffset)
        {
            if (animationOffset < 0)
            {
                throw (new ArgumentException(nameof(animationOffset)));
            }

            animateControls = false;

            locationControlList = new List<Control>();
            sizeControlDictionary = new Dictionary<Control, bool>();

            this.animationOffset = animationOffset;
        }
        #endregion

        #region ADD_ANIMATIONS
        public void AddLocationAnimationControls(params Control[] controls)
        {
            if (controls == null)
            {
                throw (new ArgumentNullException(nameof(controls)));
            }

            foreach (Control control in controls)
            {
                PropertyInfoManager.SetValue(control, true);

                locationControlList.Add(control);
            }
        }

        public void AddSizeAnimationControls(bool isMenu, params Control[] controls)
        {
            if (controls == null)
            {
                throw (new ArgumentNullException(nameof(controls)));
            }

            foreach (Control control in controls)
            {
                PropertyInfoManager.SetValue(control, true);

                sizeControlDictionary.Add(control, isMenu);
            }
        }

        public void AddAllAnimationControls(params Control[] controls)
        {
            if (controls == null)
            {
                throw (new ArgumentNullException(nameof(controls)));
            }

            foreach (Control control in controls)
            {
                PropertyInfoManager.SetValue(control, true);

                locationControlList.Add(control);
                sizeControlDictionary.Add(control, false);
            }
        }
        #endregion

        #region MAGAGER
        private void ManageAnimation()
        {
            int tmpAnimationOffset = (AnimateControls ? animationOffset : -animationOffset);

            foreach (Control locationControl in locationControlList)
            {
                locationControl.Left -= tmpAnimationOffset;
            }

            foreach (KeyValuePair<Control, bool> sizeControl in sizeControlDictionary)
            {
                Control control = sizeControl.Key;

                if (sizeControl.Value)
                {
                    control.Width -= tmpAnimationOffset;

                    if (control is HideTextButton)
                    {
                        ((HideTextButton)control).TextVisible = (!AnimateControls);
                    }
                    else if (control is Panel)
                    {
                        int right = control.Margin.Right;

                        control.Width -= (AnimateControls ? right : -right);
                    }
                }
                else
                {
                    control.Width += tmpAnimationOffset;
                }
            }
        }
        #endregion
    }
}
