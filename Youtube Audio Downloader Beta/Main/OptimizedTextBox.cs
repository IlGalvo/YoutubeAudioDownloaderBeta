using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YoutubeAudioDownloaderBeta.Main
{
    public class OptimizedTextBox : TextBox
    {
        #region GLOBAL_VARIABLE
        private enum PlaceholderStatus
        {
            Enable,
            Hide,
            Disable
        }

        [DefaultValue("")]
        public string PlaceholderText { get; set; }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25")]
        public Font PlaceholerFont { get; set; }

        [DefaultValue(typeof(Color), "DimGray")]
        public Color PlaceholderForeColor { get; set; }

        [DefaultValue(typeof(Color), "Window")]
        public Color PlaceholderBackColor { get; set; }

        private PlaceholderStatus placeholderStatus;
        private bool doubleClick;
        #endregion

        #region CONSTRUCTOR
        public OptimizedTextBox()
        {
            DoubleBuffered = true;

            PlaceholderText = string.Empty;
            PlaceholerFont = SystemFonts.DefaultFont;
            PlaceholderForeColor = Color.DimGray;
            PlaceholderBackColor = SystemColors.Window;

            placeholderStatus = PlaceholderStatus.Disable;
            doubleClick = false;
        }
        #endregion

        #region CONTROL_EVENTS
        protected override void OnCreateControl()
        {
            ManagePlaceholderChanges();

            base.OnCreateControl();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            ManagePlaceholderChanges();

            base.OnTextChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            ManagePlaceholderChanges();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            ManagePlaceholderChanges();

            base.OnLostFocus(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (doubleClick)
            {
                SelectAll();

                doubleClick = false;
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            doubleClick = true;

            base.OnMouseDoubleClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (placeholderStatus)
            {
                case PlaceholderStatus.Enable:
                    e.Graphics.FillRectangle(new SolidBrush(PlaceholderBackColor), ClientRectangle);

                    PlaceholerFont = new Font(PlaceholerFont.FontFamily, Font.Size, PlaceholerFont.Style, PlaceholerFont.Unit, PlaceholerFont.GdiCharSet);
                    e.Graphics.DrawString(PlaceholderText, PlaceholerFont, new SolidBrush(PlaceholderForeColor), new PointF(0, 0));
                    break;
                case PlaceholderStatus.Hide:
                case PlaceholderStatus.Disable:
                    e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                    string text = ((placeholderStatus == PlaceholderStatus.Hide) ? string.Empty : Text);
                    e.Graphics.DrawString(text, Font, new SolidBrush(ForeColor), new PointF(0, 0));
                    break;
            }

            base.OnPaint(e);
        }
        #endregion

        #region PLACEHOLDER_MANAGER
        private void ManagePlaceholderChanges()
        {
            if (Text == string.Empty)
            {
                if (Focused)
                {
                    placeholderStatus = PlaceholderStatus.Hide;
                }
                else
                {
                    placeholderStatus = PlaceholderStatus.Enable;
                }
            }
            else
            {
                placeholderStatus = PlaceholderStatus.Disable;
            }

            SetStyle(ControlStyles.UserPaint, ((placeholderStatus == PlaceholderStatus.Enable) ? true : false));
            Refresh();
        }
        #endregion
    }
}
