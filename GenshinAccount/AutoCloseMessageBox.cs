using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

public class AutoCloseMessageBox
{
    private Timer _timeoutTimer;
    private MessageBoxForm _msgBox;

    private class MessageBoxForm : Form
    {
        public DialogResult Result { get; private set; }

        public MessageBoxForm(string message, string title)
        {
            this.ControlBox = false;  // 隐藏关闭按钮
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(190, 80);  // 根据需要调整

            Label messageLabel = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.Controls.Add(messageLabel);
        }

        public new DialogResult ShowDialog()
        {
            base.ShowDialog();
            return Result;
        }

        public void CloseWithResult(DialogResult result)
        {
            this.Result = result;
            this.Close();
        }
    }

    public AutoCloseMessageBox(string message, string title)
    {
        _timeoutTimer = new Timer
        {
            Interval = 3000,  // 设置为3秒
            Enabled = true
        };

        _timeoutTimer.Tick += (sender, args) =>
        {
            _timeoutTimer.Stop();
            _msgBox.CloseWithResult(DialogResult.None);
        };

        _msgBox = new MessageBoxForm(message, title);
    }

    public DialogResult Show()
    {
        _timeoutTimer.Start();
        return _msgBox.ShowDialog();
    }
}

// 使用示例：
// var msgBox = new AutoCloseMessageBox("这是一个会在3秒后关闭的消息框", "提示");
// msgBox.Show();
