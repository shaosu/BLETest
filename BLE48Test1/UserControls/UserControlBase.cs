using BLETest1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLETest1.UserControls
{
    public class NoUseClass
    {
        // 用于占位，防止UserControlBase显示为控件
    }

    public class UserControlBase : UserControl
    {
        internal System.Windows.Forms.ListBox listboxMessage;
        internal StartParam StartParam;

        public void UI_Invoke(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void UI_Invoke<T>(Action<T> action, T param)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action, param);
            }
            else
            {
                action(param);
            }
        }
        public void UI_Invoke(Action<object> action, object param)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action, param);
            }
            else
            {
                action(param);
            }
        }
        internal virtual void AppendToLogFile(string timeMsg)
        {

        }

        public void AppendMessageWithTime(string msg)
        {
            if (this.InvokeRequired)
            {
                Action<string> action = AppendMessageWithTime;
                this.Invoke(action, msg);
                return;
            }
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string hb = time + ":" + msg;
            listboxMessage.Items.Add(hb);
            if (listboxMessage.Items.Count > 5000)
            {
                listboxMessage.Items.Clear();
            }
            AppendToLogFile(hb);
        }
    }
}
