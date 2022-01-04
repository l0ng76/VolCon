using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolCon
{
    public enum TaskBarLocation { TOP, BOTTOM, LEFT, RIGHT }

    public static class Taskbar
    {
        public static TaskBarLocation GetLocation()
        {
            TaskBarLocation taskBarLocation = TaskBarLocation.BOTTOM;
            bool taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);
            if (taskBarOnTopOrBottom) {
                if (Screen.PrimaryScreen.WorkingArea.Top > 0) taskBarLocation = TaskBarLocation.TOP;
            } else {
                if (Screen.PrimaryScreen.WorkingArea.Left > 0) {
                    taskBarLocation = TaskBarLocation.LEFT;
                } else {
                    taskBarLocation = TaskBarLocation.RIGHT;
                }
            }
            return taskBarLocation;
        }
    }
}