using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelDB
{
    //
    //  使用 DB 指定フォーム
    //
    public partial class Form0 : Form
    {
        private string Host = "";       // Host 名
        private string UserID = "";     // User ID
        private string Password = "";   // Password
        private int RetVal = 0;         // リターン (0:Cancel, 1:開始)    2014/10/08 Add.

        public Form0()
        {
            InitializeComponent();

            hostName.Enabled = true;
            userId.Enabled   = true;
            passWord.Enabled = true;

            label6.Text = "      ";     // メッセージラベル
        }

        // Host, Uid, Pwd 取り出し
        public string GetHost()
        {
            return Host;
        }
        public string GetUid()
        {
            return UserID;
        }
        public string GetPwd()
        {
            return Password;
        }

        // リターン値を返す
        public int GetRetval()
        {
            return RetVal;
        }


        // 開始ボタン
        private void button1_Click(object sender, EventArgs e)
        {
            Host = hostName.Text;
            UserID = userId.Text;
            Password = passWord.Text;
            // 入力チェック
            if (Host == "" || UserID == "" || Password == "")
            {
                MessageBox.Show("MySQL を使用する時は，Host, User ID, Password を指定して下さい。");
            }
            else
            {
                // ホストに接続できるかチェック
                label6.Text = "ホストを確認しています。";
                this.Refresh();
                try
                {
                    System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient(Host, 3306);
                    tcp.Close();

                    RetVal = 1;     // 開始で戻り
                    this.Close();                           
                }
                catch (Exception ex)
                {
                    label6.Text = "ホストに接続出来ませんでした。";
                    MessageBox.Show("指定のホストが見つかりません。\nホスト名を確認して下さい。");
                }
            }
        }

        // キャンセル
        private void button2_Click(object sender, EventArgs e)
        {
            RetVal = 0;
            this.Close();
        }
    }
}
