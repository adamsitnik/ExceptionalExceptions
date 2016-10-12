using System.Drawing;
using System.Windows.Forms;

namespace StackOverflowDoneWrong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "DotNext Sample";

            int OK = 29; // values can be different for different Windows versions
            int NOK = 35;

            Control parent = this;
            for (int groupIndex = 0; 
                groupIndex < NOK; // set to NOK
                groupIndex++)
            {
                //var groupBox = new GroupBox();
                var panel = new Panel();
                panel.Dock = DockStyle.Fill;
                panel.Parent = parent;
                panel.BorderStyle = BorderStyle.FixedSingle;
                if (groupIndex % 2 == 0)
                {
                    panel.Padding = new Padding(5);
                    panel.Margin = new Padding(5);
                }
                if (groupIndex > OK)
                {
                    panel.BackColor = Color.Red;
                }

                //groupBox.Parent = parent;
                //groupBox.Dock = DockStyle.Fill;

                parent = panel;
            }
        }
    }
}
