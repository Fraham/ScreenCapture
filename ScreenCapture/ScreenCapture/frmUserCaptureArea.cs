﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmUserCaptureArea : Form
    {
        #region:::::::::::::::::::::::::::::::::::::::::::Form level declarations:::::::::::::::::::::::::::::::::::::::::::

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

        public Point ClickPoint = new Point();
        public Point CurrentTopLeft = new Point();
        public Point CurrentBottomRight = new Point();
        public Point DragClickRelative = new Point();

        public int RectangleHeight = new int();
        public int RectangleWidth = new int();

        private Graphics g;
        private Pen MyPen = new Pen(Color.Red, 1);
        private Pen EraserPen = new Pen(Color.FromArgb(0, 0, 0), 20);

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                e = null;
            }

            base.OnMouseClick(e);
        }

        private Form m_InstanceRef = null;

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

        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Mouse Event Handlers & Drawing Initialization:::::::::::::::::::::::::::::::::::::::::::

        public frmUserCaptureArea()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            this.KeyUp += new KeyEventHandler(key_press);

            g = this.CreateGraphics();            
        }

        #endregion

        private void initPoints()
        {
            ClickPoint.X = 0;
            ClickPoint.Y = 0;

            DragClickRelative.X = 0;
            DragClickRelative.Y = 0;

            CurrentTopLeft.X = 0;
            CurrentTopLeft.Y = 0;
            CurrentBottomRight.X = 0;
            CurrentBottomRight.Y = 0;
            RectangleWidth = 0;
            RectangleHeight = 0;

            LeftButtonDown = false;
            RectangleDrawn = false;
            ReadyToDrag = false;

            this.Cursor = Cursors.Arrow;
        }

        private void InvertColors()
        {
            g.DrawRectangle(EraserPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, GetX(CurrentBottomRight.X) - GetX(CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);

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
            g.DrawRectangle(MyPen, GetX(CurrentTopLeft.X), CurrentTopLeft.Y, GetX(CurrentBottomRight.X) - GetX(CurrentTopLeft.X), CurrentBottomRight.Y - CurrentTopLeft.Y);
        }

        public void key_press(object sender, KeyEventArgs e)
        {
            string sKey = e.KeyCode.ToString();

            if (e.KeyCode == Keys.Escape)
            {
                this.InstanceRef.Show();
                this.Hide();
            }
            else if (sKey == "Z")
                InvertColors();
        }

        #region:::::::::::::::::::::::::::::::::::::::::::Mouse Buttons:::::::::::::::::::::::::::::::::::::::::::

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

        #endregion

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
            return X;
            /*if (showMon == PrimMon)
                return X;
            else if (this.Left < 0)
                return X + Math.Abs(this.Left);
            else
                return X - System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;*/
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
    }
}