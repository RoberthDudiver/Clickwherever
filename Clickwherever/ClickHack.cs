using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clickwherever
{
    public partial class ClickHack : Form
    {
        public ClickHack()
        {
            InitializeComponent();
            KeyboardHook.Hook();
            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
        }
        public Point _Location
        {
            get;
            set;
        }
        bool A;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CursorHandler.MoveMouseTo(_Location.X, _Location.Y);
            CursorHandler.SendMouseLeftClick();
        }

        private void KeyboardHook_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && ModifierKeys == Keys.Control)
            {
                timer1.Enabled = true;
                this.TopMost = false;

                _Location = Cursor.Position;
                A = true;
                this.WindowState = FormWindowState.Minimized;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && ModifierKeys == Keys.Control)

            {
                _Location = new Point();
                A = false;
                timer1.Enabled = false;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            KeyboardHook.Unhook();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32( numericUpDown1.Value * 1000);
        }

        private void ClickHack_Load(object sender, EventArgs e)
        {

        }
    }
}
