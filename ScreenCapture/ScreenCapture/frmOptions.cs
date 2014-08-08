using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmOptions : Form
    {
        #region Class Variables

        private int maxHeight;
        private int maxWidth;
        private Options usersOptions;

        public enum CursPos : int
        {

            WithinSelectionArea = 0,
            OutsideSelectionArea,
            TopLine,
            BottomLine,
            LeftLine,
            RightLine,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight

        }

        public enum ClickAction : int
        {

            NoClick = 0,
            Dragging,
            Outside,
            TopSizing,
            BottomSizing,
            LeftSizing,
            TopLeftSizing,
            BottomLeftSizing,
            RightSizing,
            TopRightSizing,
            BottomRightSizing

        }

        public ClickAction CurrentAction;
        public bool LeftButtonDown = false;
        public bool RectangleDrawn = false;
        public bool ReadyToDrag = false;
        string ScreenPath = "";

        public Point ClickPoint = new Point();
        public Point CurrentTopLeft = new Point();
        public Point CurrentBottomRight = new Point();
        public Point DragClickRelative = new Point();

        public int RectangleHeight = new int();
        public int RectangleWidth = new int();
        public int PrimMon = 0;
        public int showMon = 0;

        Graphics g;
        Pen MyPen = new Pen(Color.White, 1);
        Pen EraserPen = new Pen(Color.FromArgb(0, 0, 0), 20);

        #endregion Class Variables

        #region Constructor

        /// <summary>
        /// Makes a new instance of a Options menu form.
        /// </summary>
        /// <param name="options">The options that are currently doing run.</param>
        public frmOptions(Options options)
        {
            UsersOptions = options;
            InitializeComponent();

            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            //this.KeyUp += new KeyEventHandler(key_press);

            g = this.CreateGraphics();
        }

        #endregion Constructor

        #region Click Events

        /// <summary>
        /// It will close the form discarding the new options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// It will save the new options.
        /// It will check to make sure that all the new values are correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validWidth() && validHeight())
            {
                if (radFullScreen.Checked)
                {
                    UsersOptions = new Options();
                }
                else
                {
                    UsersOptions = new Options((int)nudWidth.Value, (int)nudHeight.Value, new Point((int)nudXSourcePoint.Value, (int)nudYSourcePoint.Value));
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                System.Console.WriteLine("Capture area too large for the screen.");
                this.DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// It will only close when the values are correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }

        /// <summary>
        /// Will make the capture options enabled or disabled depending whether full-screen is on or off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radNotFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (radFullScreen.Checked)
            {
                grpCaptureOptions.Enabled = false;
            }
            else
            {
                grpCaptureOptions.Enabled = true;
            }
        }

        #endregion Click Events

        #region Form Loading

        /// <summary>
        /// When the form loads.
        /// It will set the limits on the options numeric up and downs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOptions_Load(object sender, EventArgs e)
        {
            nudWidth.Maximum = ScreenSize.Width;
            nudHeight.Maximum = ScreenSize.Height;

            nudXSourcePoint.Maximum = ScreenSize.Width;
            nudYSourcePoint.Maximum = ScreenSize.Height;

            maxWidth = ScreenSize.Width;
            maxHeight = ScreenSize.Height;

            nudHeight.Value = UsersOptions.Height;
            nudWidth.Value = UsersOptions.Width;

            nudXSourcePoint.Value = UsersOptions.SourcePoint.X;
            nudYSourcePoint.Value = UsersOptions.SourcePoint.Y;

            radFullScreen.Checked = UsersOptions.Fullscreen;
        }

        #endregion Form Loading

        #region Square Sizing

        private void ResizeSelection()
        {

            if (CurrentAction == ClickAction.LeftSizing)
            {

                if (Cursor.Position.X < CurrentBottomRight.X - 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.X = Cursor.Position.X;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }

            }
            if (CurrentAction == ClickAction.TopLeftSizing)
            {

                if (Cursor.Position.X < CurrentBottomRight.X - 10 && Cursor.Position.Y < CurrentBottomRight.Y - 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.X = Cursor.Position.X;
                    CurrentTopLeft.Y = Cursor.Position.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }
            }
            if (CurrentAction == ClickAction.BottomLeftSizing)
            {

                if (Cursor.Position.X < CurrentBottomRight.X - 10 && Cursor.Position.Y > CurrentTopLeft.Y + 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.X = Cursor.Position.X;
                    CurrentBottomRight.Y = Cursor.Position.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }

            }
            if (CurrentAction == ClickAction.RightSizing)
            {

                if (Cursor.Position.X > CurrentTopLeft.X + 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.X = Cursor.Position.X;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }
            }
            if (CurrentAction == ClickAction.TopRightSizing)
            {

                if (Cursor.Position.X > CurrentTopLeft.X + 10 && Cursor.Position.Y < CurrentBottomRight.Y - 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.X = Cursor.Position.X;
                    CurrentTopLeft.Y = Cursor.Position.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }
            }
            if (CurrentAction == ClickAction.BottomRightSizing)
            {

                if (Cursor.Position.X > CurrentTopLeft.X + 10 && Cursor.Position.Y > CurrentTopLeft.Y + 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.X = Cursor.Position.X;
                    CurrentBottomRight.Y = Cursor.Position.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }
            }
            if (CurrentAction == ClickAction.TopSizing)
            {

                if (Cursor.Position.Y < CurrentBottomRight.Y - 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.Y = Cursor.Position.Y;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }
            }
            if (CurrentAction == ClickAction.BottomSizing)
            {

                if (Cursor.Position.Y > CurrentTopLeft.Y + 10)
                {

                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.Y = Cursor.Position.Y;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

                }

            }

        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                SetClickAction();
                LeftButtonDown = true;
                ClickPoint = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);

                if (RectangleDrawn)
                {

                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    DragClickRelative.X = Cursor.Position.X - CurrentTopLeft.X;
                    DragClickRelative.Y = Cursor.Position.Y - CurrentTopLeft.Y;

                }

            }
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {

            RectangleDrawn = true;
            LeftButtonDown = false;
            CurrentAction = ClickAction.NoClick;

        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {

            if (LeftButtonDown && !RectangleDrawn)
            {

                DrawSelection();

            }

            if (RectangleDrawn)
            {

                CursorPosition();

                if (CurrentAction == ClickAction.Dragging)
                {
                    DragSelection();
                }

                if (CurrentAction != ClickAction.Dragging && CurrentAction != ClickAction.Outside)
                {
                    ResizeSelection();
                }
            }
        }

        private CursPos CursorPosition()
        {
            if (((Cursor.Position.X > CurrentTopLeft.X - 10 && Cursor.Position.X < CurrentTopLeft.X + 10)) && ((Cursor.Position.Y > CurrentTopLeft.Y + 10) && (Cursor.Position.Y < CurrentBottomRight.Y - 10)))
            {

                this.Cursor = Cursors.SizeWE;
                return CursPos.LeftLine;

            }
            if (((Cursor.Position.X >= CurrentTopLeft.X - 10 && Cursor.Position.X <= CurrentTopLeft.X + 10)) && ((Cursor.Position.Y >= CurrentTopLeft.Y - 10) && (Cursor.Position.Y <= CurrentTopLeft.Y + 10)))
            {

                this.Cursor = Cursors.SizeNWSE;
                return CursPos.TopLeft;

            }
            if (((Cursor.Position.X >= CurrentTopLeft.X - 10 && Cursor.Position.X <= CurrentTopLeft.X + 10)) && ((Cursor.Position.Y >= CurrentBottomRight.Y - 10) && (Cursor.Position.Y <= CurrentBottomRight.Y + 10)))
            {

                this.Cursor = Cursors.SizeNESW;
                return CursPos.BottomLeft;

            }
            if (((Cursor.Position.X > CurrentBottomRight.X - 10 && Cursor.Position.X < CurrentBottomRight.X + 10)) && ((Cursor.Position.Y > CurrentTopLeft.Y + 10) && (Cursor.Position.Y < CurrentBottomRight.Y - 10)))
            {

                this.Cursor = Cursors.SizeWE;
                return CursPos.RightLine;

            }
            if (((Cursor.Position.X >= CurrentBottomRight.X - 10 && Cursor.Position.X <= CurrentBottomRight.X + 10)) && ((Cursor.Position.Y >= CurrentTopLeft.Y - 10) && (Cursor.Position.Y <= CurrentTopLeft.Y + 10)))
            {

                this.Cursor = Cursors.SizeNESW;
                return CursPos.TopRight;

            }
            if (((Cursor.Position.X >= CurrentBottomRight.X - 10 && Cursor.Position.X <= CurrentBottomRight.X + 10)) && ((Cursor.Position.Y >= CurrentBottomRight.Y - 10) && (Cursor.Position.Y <= CurrentBottomRight.Y + 10)))
            {

                this.Cursor = Cursors.SizeNWSE;
                return CursPos.BottomRight;

            }
            if (((Cursor.Position.Y > CurrentTopLeft.Y - 10) && (Cursor.Position.Y < CurrentTopLeft.Y + 10)) && ((Cursor.Position.X > CurrentTopLeft.X + 10 && Cursor.Position.X < CurrentBottomRight.X - 10)))
            {

                this.Cursor = Cursors.SizeNS;
                return CursPos.TopLine;

            }
            if (((Cursor.Position.Y > CurrentBottomRight.Y - 10) && (Cursor.Position.Y < CurrentBottomRight.Y + 10)) && ((Cursor.Position.X > CurrentTopLeft.X + 10 && Cursor.Position.X < CurrentBottomRight.X - 10)))
            {

                this.Cursor = Cursors.SizeNS;
                return CursPos.BottomLine;

            }
            if (
                (Cursor.Position.X >= CurrentTopLeft.X + 10 && Cursor.Position.X <= CurrentBottomRight.X - 10) && (Cursor.Position.Y >= CurrentTopLeft.Y + 10 && Cursor.Position.Y <= CurrentBottomRight.Y - 10))
            {
                this.Cursor = Cursors.Hand;
                return CursPos.WithinSelectionArea;
            }

            this.Cursor = Cursors.No;
            return CursPos.OutsideSelectionArea;
        }

        private void SetClickAction()
        {

            switch (CursorPosition())
            {
                case CursPos.BottomLine:
                    CurrentAction = ClickAction.BottomSizing;
                    break;
                case CursPos.TopLine:
                    CurrentAction = ClickAction.TopSizing;
                    break;
                case CursPos.LeftLine:
                    CurrentAction = ClickAction.LeftSizing;
                    break;
                case CursPos.TopLeft:
                    CurrentAction = ClickAction.TopLeftSizing;
                    break;
                case CursPos.BottomLeft:
                    CurrentAction = ClickAction.BottomLeftSizing;
                    break;
                case CursPos.RightLine:
                    CurrentAction = ClickAction.RightSizing;
                    break;
                case CursPos.TopRight:
                    CurrentAction = ClickAction.TopRightSizing;
                    break;
                case CursPos.BottomRight:
                    CurrentAction = ClickAction.BottomRightSizing;
                    break;
                case CursPos.WithinSelectionArea:
                    CurrentAction = ClickAction.Dragging;
                    break;
                case CursPos.OutsideSelectionArea:
                    CurrentAction = ClickAction.Outside;
                    break;
            }

        }

        private void DragSelection()
        {
            //Ensure that the rectangle stays within the bounds of the screen

            //Erase the previous rectangle
            g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

            if (GetX(Cursor.Position.X) - DragClickRelative.X > 0 && GetX(Cursor.Position.X) - DragClickRelative.X + RectangleWidth < this.Width/*System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width*/)
            {

                CurrentTopLeft.X = Cursor.Position.X - DragClickRelative.X;
                CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;

            }
            else
                //Selection area has reached the right side of the screen
                if (GetX(Cursor.Position.X) - DragClickRelative.X > 0)
                {

                    CurrentTopLeft.X = this.Width/*System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width*/ - RectangleWidth;
                    CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;

                }
                //Selection area has reached the left side of the screen
                else
                {

                    CurrentTopLeft.X = this.Left;
                    CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;

                }

            if (Cursor.Position.Y - DragClickRelative.Y > 0 && Cursor.Position.Y - DragClickRelative.Y + RectangleHeight < this.Width/*System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height*/)
            {

                CurrentTopLeft.Y = Cursor.Position.Y - DragClickRelative.Y;
                CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;

            }
            else
                //Selection area has reached the bottom of the screen
                if (Cursor.Position.Y - DragClickRelative.Y > 0)
                {

                    CurrentTopLeft.Y = this.Height/*System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height*/ - RectangleHeight;
                    CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;

                }
                //Selection area has reached the top of the screen
                else
                {

                    CurrentTopLeft.Y = 0;
                    CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;

                }

            //Draw a new rectangle
            g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

        }

        private int GetX(int X)
        {
            if (showMon == PrimMon)
                return X;
            else if (this.Left < 0)
                return X + Math.Abs(this.Left);
            else
                return X - System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        }

        private void DrawSelection()
        {

            this.Cursor = Cursors.Arrow;

            //Erase the previous rectangle
            g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, GetX(CurrentBottomRight.X) - GetX(CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);

            //Calculate X Coordinates
            if (Cursor.Position.X < ClickPoint.X)
            {

                CurrentTopLeft.X = Cursor.Position.X;
                CurrentBottomRight.X = ClickPoint.X;

            }
            else
            {

                CurrentTopLeft.X = ClickPoint.X;
                CurrentBottomRight.X = Cursor.Position.X;

            }

            //Calculate Y Coordinates
            if (Cursor.Position.Y < ClickPoint.Y)
            {

                CurrentTopLeft.Y = Cursor.Position.Y;
                CurrentBottomRight.Y = ClickPoint.Y;

            }
            else
            {

                CurrentTopLeft.Y = ClickPoint.Y;
                CurrentBottomRight.Y = Cursor.Position.Y;

            }

            //Draw a new rectangle
            g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, GetX(CurrentBottomRight.X) - GetX(CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);

        }

        #endregion Square Sizing

        #region Validation Checks

        /// <summary>
        /// It will check if its a valid height.
        /// </summary>
        /// <returns>If the height and the source point are less than the max height.</returns>
        private bool validHeight()
        {
            if (nudHeight.Value + nudYSourcePoint.Value > maxHeight)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// It will check if its a valid width.
        /// </summary>
        /// <returns>If the width and the source point are less than the max width.</returns>
        private bool validWidth()
        {
            if (nudWidth.Value + nudXSourcePoint.Value > maxWidth)
            {
                return false;
            }

            return true;
        }

        #endregion Validation Checks

        #region Properties

        /// <summary>
        /// Holds all the options for the capture
        /// </summary>
        public Options UsersOptions
        {
            get
            {
                return usersOptions;
            }
            set
            {
                usersOptions = value;
            }
        }

        #endregion Properties
    }
}