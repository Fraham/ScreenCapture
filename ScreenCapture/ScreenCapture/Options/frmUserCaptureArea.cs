using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmUserCaptureArea : Form
    {
        #region Form Declared

        #region Form Variables

        public Point ClickPoint = new Point();
        public ClickAction CurrentAction;
        public Point CurrentBottomRight = new Point();
        public Point CurrentTopLeft = new Point();
        public Point DragClickRelative = new Point();
        public bool LeftButtonDown = false;
        public bool ReadyToDrag = false;
        public bool RectangleDrawn = false;
        public int RectangleHeight = new int();
        public int RectangleWidth = new int();
        private Pen EraserPen = new Pen(Color.FromArgb(0, 0, 0), 20);
        private Graphics g;
        private Form m_InstanceRef = null;
        private Pen MyPen = new Pen(Color.Red, 1);
        private Options.Options options;
        private bool show = false;

        #endregion Form Variables

        public frmUserCaptureArea(Options.Options options, bool show)
        {
            InitializeComponent();

            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            this.KeyUp += new KeyEventHandler(key_press);

            this.Location = ScreenSize.TopLeftPoint;

            g = this.CreateGraphics();

            CaptureOptions = options;

            this.show = show;
        }

        #endregion Form Declared

        #region Enums

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

        #endregion Enums

        #region Properties

        public Options.Options CaptureOptions
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
            }
        }

        public Form InstanceRef
        {
            get
            {
                return m_InstanceRef;
            }
            set
            {
                m_InstanceRef = value;
            }
        }

        #endregion Properties

        #region Keys

        public void key_press(object sender, KeyEventArgs e)
        {
            string sKey = e.KeyCode.ToString();

            if (e.KeyCode == Keys.Escape)
            {
                this.InstanceRef.Show();
                this.Hide();

                this.DialogResult = DialogResult.Cancel;
            }
            else if (sKey == "Z")
            {
                InvertColors();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                CaptureOptions.Width = CurrentBottomRight.X - CurrentTopLeft.X;
                CaptureOptions.Height = CurrentBottomRight.Y - CurrentTopLeft.Y;
                CaptureOptions.SourcePoint = CurrentTopLeft;

                this.InstanceRef.Show();
                this.Hide();

                this.DialogResult = DialogResult.OK;
            }
        }

        #endregion Keys

        #region Drawing

        private void DragSelection(MouseEventArgs Cursor)
        {
            //Ensure that the rectangle stays within the bounds of the screen

            //Erase the previous rectangle
            g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

            if ((Cursor.X) - DragClickRelative.X > 0 && (Cursor.X) - DragClickRelative.X + RectangleWidth < this.Width)
            {
                CurrentTopLeft.X = Cursor.X - DragClickRelative.X;
                CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;
            }
            else
                //Selection area has reached the right side of the screen
                if ((Cursor.X) - DragClickRelative.X > 0)
                {
                    CurrentTopLeft.X = this.Width - RectangleWidth;
                    CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;
                }
                //Selection area has reached the left side of the screen
                else
                {
                    CurrentTopLeft.X = this.Left;
                    CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;
                }

            if (Cursor.Y - DragClickRelative.Y > 0 && Cursor.Y - DragClickRelative.Y + RectangleHeight < this.Width)
            {
                CurrentTopLeft.Y = Cursor.Y - DragClickRelative.Y;
                CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;
            }
            else
                //Selection area has reached the bottom of the screen
                if (Cursor.Y - DragClickRelative.Y > 0)
                {
                    CurrentTopLeft.Y = this.Height - RectangleHeight;
                    CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;
                }
                //Selection area has reached the top of the screen
                else
                {
                    CurrentTopLeft.Y = 0;
                    CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;
                }

            //Draw a new rectangle
            g.DrawRectangle(MyPen, CurrentTopLeft.X, CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
        }

        private void DrawRectangle()
        {
            g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, (CurrentBottomRight.X) - (CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);
        }

        private void DrawSelection(MouseEventArgs Cursor)
        {
            this.Cursor = Cursors.Arrow;

            //Erase the previous rectangle
            g.DrawRectangle(EraserPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - (CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);

            //Calculate X Coordinates
            if (Cursor.X < ClickPoint.X)
            {
                CurrentTopLeft.X = Cursor.X;
                CurrentBottomRight.X = ClickPoint.X;
            }
            else
            {
                CurrentTopLeft.X = ClickPoint.X;
                CurrentBottomRight.X = Cursor.X;
            }

            //Calculate Y Coordinates
            if (Cursor.Y < ClickPoint.Y)
            {
                CurrentTopLeft.Y = Cursor.Y;
                CurrentBottomRight.Y = ClickPoint.Y;
            }
            else
            {
                CurrentTopLeft.Y = ClickPoint.Y;
                CurrentBottomRight.Y = Cursor.Y;
            }

            //Draw a new rectangle
            g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, (CurrentBottomRight.X) - (CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);
        }

        private void frmUserCaptureArea_Shown(object sender, EventArgs e)
        {
            if (show)
            {
                CurrentTopLeft = new Point(CaptureOptions.SourcePoint.X - ScreenSize.TopLeftPoint.X, CaptureOptions.SourcePoint.Y - ScreenSize.TopLeftPoint.Y);
                CurrentBottomRight = new Point(CaptureOptions.BottomRightCorner.X - ScreenSize.TopLeftPoint.X, CaptureOptions.BottomRightCorner.Y - ScreenSize.TopLeftPoint.Y);

                RectangleDrawn = true;

                DrawRectangle();
            }
        }

        private void InvertColors()
        {
            g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, (CurrentBottomRight.X) - (CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);

            if (this.BackColor == Color.Black)
            {
                this.BackColor = Color.Yellow;
                MyPen.Dispose();
                EraserPen.Dispose();
                MyPen = new Pen(Color.Black, 1);
                EraserPen = new Pen(Color.Yellow, 20);
            }
            else
            {
                this.BackColor = Color.Black;
                MyPen.Dispose();
                EraserPen.Dispose();
                MyPen = new Pen(Color.Red, 1);
                EraserPen = new Pen(Color.Black, 20);
            }

            Application.DoEvents();

            //Draw a new rectangle
            g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, (CurrentBottomRight.X) - (CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);
        }

        #endregion Drawing

        #region Mouse

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                e = null;
            }

            base.OnMouseClick(e);
        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetClickAction(e);
                LeftButtonDown = true;
                ClickPoint = new Point(e.X, e.Y);

                if (RectangleDrawn)
                {
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    DragClickRelative.X = e.X - CurrentTopLeft.X;
                    DragClickRelative.Y = e.Y - CurrentTopLeft.Y;
                }
            }
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (LeftButtonDown && !RectangleDrawn)
            {
                DrawSelection(e);
            }

            if (RectangleDrawn)
            {
                CursorPosition(e);

                if (CurrentAction == ClickAction.Dragging)
                {
                    DragSelection(e);
                }

                if (CurrentAction != ClickAction.Dragging && CurrentAction != ClickAction.Outside)
                {
                    ResizeSelection(e);
                }
            }
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {
            RectangleDrawn = true;
            LeftButtonDown = false;
            CurrentAction = ClickAction.NoClick;
        }

        #endregion Mouse

        #region Cursor

        public CursPos CursorPosition(MouseEventArgs e)
        {
            if (((e.X > CurrentTopLeft.X - 10 && e.X < CurrentTopLeft.X + 10)) && ((e.Y > CurrentTopLeft.Y + 10) && (e.Y < CurrentBottomRight.Y - 10)))
            {
                this.Cursor = Cursors.SizeWE;
                return CursPos.LeftLine;
            }
            if (((e.X >= CurrentTopLeft.X - 10 && e.X <= CurrentTopLeft.X + 10)) && ((e.Y >= CurrentTopLeft.Y - 10) && (e.Y <= CurrentTopLeft.Y + 10)))
            {
                this.Cursor = Cursors.SizeNWSE;
                return CursPos.TopLeft;
            }
            if (((e.X >= CurrentTopLeft.X - 10 && e.X <= CurrentTopLeft.X + 10)) && ((e.Y >= CurrentBottomRight.Y - 10) && (e.Y <= CurrentBottomRight.Y + 10)))
            {
                this.Cursor = Cursors.SizeNESW;
                return CursPos.BottomLeft;
            }
            if (((e.X > CurrentBottomRight.X - 10 && e.X < CurrentBottomRight.X + 10)) && ((e.Y > CurrentTopLeft.Y + 10) && (e.Y < CurrentBottomRight.Y - 10)))
            {
                this.Cursor = Cursors.SizeWE;
                return CursPos.RightLine;
            }
            if (((e.X >= CurrentBottomRight.X - 10 && e.X <= CurrentBottomRight.X + 10)) && ((e.Y >= CurrentTopLeft.Y - 10) && (e.Y <= CurrentTopLeft.Y + 10)))
            {
                this.Cursor = Cursors.SizeNESW;
                return CursPos.TopRight;
            }
            if (((e.X >= CurrentBottomRight.X - 10 && e.X <= CurrentBottomRight.X + 10)) && ((e.Y >= CurrentBottomRight.Y - 10) && (e.Y <= CurrentBottomRight.Y + 10)))
            {
                this.Cursor = Cursors.SizeNWSE;
                return CursPos.BottomRight;
            }
            if (((e.Y > CurrentTopLeft.Y - 10) && (e.Y < CurrentTopLeft.Y + 10)) && ((e.X > CurrentTopLeft.X + 10 && e.X < CurrentBottomRight.X - 10)))
            {
                this.Cursor = Cursors.SizeNS;
                return CursPos.TopLine;
            }
            if (((e.Y > CurrentBottomRight.Y - 10) && (e.Y < CurrentBottomRight.Y + 10)) && ((e.X > CurrentTopLeft.X + 10 && e.X < CurrentBottomRight.X - 10)))
            {
                this.Cursor = Cursors.SizeNS;
                return CursPos.BottomLine;
            }
            if (
                (e.X >= CurrentTopLeft.X + 10 && e.X <= CurrentBottomRight.X - 10) && (e.Y >= CurrentTopLeft.Y + 10 && e.Y <= CurrentBottomRight.Y - 10))
            {
                this.Cursor = Cursors.Hand;
                return CursPos.WithinSelectionArea;
            }

            this.Cursor = Cursors.No;
            return CursPos.OutsideSelectionArea;
        }

        private void ResizeSelection(MouseEventArgs Cursor)
        {
            if (CurrentAction == ClickAction.LeftSizing)
            {
                if (Cursor.X < CurrentBottomRight.X - 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.X = Cursor.X;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.TopLeftSizing)
            {
                if (Cursor.X < CurrentBottomRight.X - 10 && Cursor.Y < CurrentBottomRight.Y - 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.X = Cursor.X;
                    CurrentTopLeft.Y = Cursor.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.BottomLeftSizing)
            {
                if (Cursor.X < CurrentBottomRight.X - 10 && Cursor.Y > CurrentTopLeft.Y + 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.X = Cursor.X;
                    CurrentBottomRight.Y = Cursor.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.RightSizing)
            {
                if (Cursor.X > CurrentTopLeft.X + 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.X = Cursor.X;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.TopRightSizing)
            {
                if (Cursor.X > CurrentTopLeft.X + 10 && Cursor.Y < CurrentBottomRight.Y - 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.X = Cursor.X;
                    CurrentTopLeft.Y = Cursor.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.BottomRightSizing)
            {
                if (Cursor.X > CurrentTopLeft.X + 10 && Cursor.Y > CurrentTopLeft.Y + 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.X = Cursor.X;
                    CurrentBottomRight.Y = Cursor.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.TopSizing)
            {
                if (Cursor.Y < CurrentBottomRight.Y - 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentTopLeft.Y = Cursor.Y;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
            if (CurrentAction == ClickAction.BottomSizing)
            {
                if (Cursor.Y > CurrentTopLeft.Y + 10)
                {
                    //Erase the previous rectangle
                    g.DrawRectangle(EraserPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                    CurrentBottomRight.Y = Cursor.Y;
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    g.DrawRectangle(MyPen, (CurrentTopLeft.X), CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
                }
            }
        }

        public void SetClickAction(MouseEventArgs e)
        {
            switch (CursorPosition(e))
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

        #endregion Cursor
    }
}