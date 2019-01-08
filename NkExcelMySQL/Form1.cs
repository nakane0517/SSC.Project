//
//  NdExcelMySQL
//      EXCEL と MySQL相互変換ツール
//
//      Copylight 2014 Next Dimension Co. Ltd.
//                                              T.Nakane
//
//      2014/10/08  MySQL 単体に分離
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;                // ファイルの有無確認，ログファイル出力用

// SQLite と MySQL を分離したため，削除（参照からも削除）
// using System.Data.SQLite;    // SQLite 参照先は，D:\SQLiteNET\NET35\System.Data.SQLite.dll
using MySql.Data.MySqlClient;   // アセンブリ/拡張（V2 と V4 あり，V4 を指定）

using Microsoft.Office.Core;    // COM/タイプライブラリ/Microsoft Office 14.0 Object Library
                                // X60 は 12.0 
using Excel = Microsoft.Office.Interop.Excel;   // アセンブリ/拡張 

namespace ExcelDB
{
    public partial class Form1 : Form
    {
        // MySQL 対応に必要情報
        private string Uid = "";     // MySQL User ID
        private string Pwd = "";     // MySQL Password
        private string Host = "";    // MySQL Server Host (Nmae or IP Address)
        // private string Mcon = "";    // MySQL コネクションストリング   "Server=Host; Database=DB; Uid=Uid; Pwd=Pwd"
        
        public Form1()
        {
            InitializeComponent();

            button8.Enabled = false;    // ログファイル選択ボタン，初期は無効
            button2.Enabled = false;    // EXCEL から DB 開始ボタン，初期は無効
            button5.Enabled = false;    // DB から EXCEL 開始ボタン，初期は無効

            Form0 frm = new Form0();
            frm.ShowDialog();
            if (frm.GetRetval() == 0)
            {
                // キャンセル
                frm.Dispose();
                // this.Close();    // コンストラクタでこれはエラーとなる
            }
            else
            {
                Host = frm.GetHost();
                Uid = frm.GetUid();
                Pwd = frm.GetPwd();

                label11.Text = "DB 名";
                label7.Text = "DB 名";

                frm.Dispose();      // DB 種類選択 Form 破棄

                button2.Enabled = true;     // EXCEL から DB 開始ボタン有効
                button5.Enabled = true;     // DB から EXCEL 開始ボタン有効
            }
        }

        // Excel ファイルパス (To DB)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"D:\";      // 初期ディレクトリ
            dlg.Filter = "EXCELファイル(*.xlsx;*.xlsm;*.xls)|*.xlsx;*.xlsm;*.xls|全て(*.*)|*.*";
            dlg.Title = "EXCEL ファイルを指定して下さい。";
            dlg.RestoreDirectory = true;        // ディレクトリ復帰

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ExFilePath1.Text = dlg.FileName;
            }
        }

        // Excel ファイルパス (From DB)
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"D:\";      // 初期ディレクトリ
            dlg.Filter = "EXCELファイル(*.xlsx;*.xlsm;*.xls)|*.xlsx;*.xlsm;*.xls|全て(*.*)|*.*";
            dlg.Title = "EXCEL ファイルを指定して下さい。";
            dlg.RestoreDirectory = true;        // ディレクトリ復帰

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ExFilePath2.Text = dlg.FileName;
            }
        }

        // 終了
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // To DB
        private void toDBMySQL()
        {
            // Excel ファイルオープン
            string path = ExFilePath1.Text;
            Excel.Application app = null;
            app = new Excel.Application();      // EXCEL アプリ生成
            app.Visible = true;                 // EXCEL 表示
            // Workbook オープン
            Excel.Workbook book = null;
            book = (Excel.Workbook)(app.Workbooks.Open(path));

            // Worksheet
            string sh = SheetNo.Text;
            int shno = int.Parse(sh);
            Excel.Worksheet sheet = (Excel.Worksheet)book.Worksheets[shno];

            int sr, er, sc, ec;     // 開始行，終了行，開始列，終了列
            sr = int.Parse(StartRow.Text);
            er = int.Parse(EndRow.Text);
            sc = int.Parse(StartColumn.Text);
            ec = int.Parse(EndColumn.Text);

            // テーブル名
            string table = TableName1.Text;

            // DB コネクションストリング
            string cons;

            cons = String.Format("Server={0}; Database={1}; Uid={2}; Pwd={3}",
                Host, DbFilePath1.Text, Uid, Pwd);
            string icmd = "";        // INSERT コマンド
            try
            {
                string dcmd = "DROP TABLE IF EXISTS " + @table + ";";

                if (LogOut == 1)
                {   // ログ出力有り
                    if (logWrite(dcmd) == false)
                    {   // 出力失敗
                        MessageBox.Show("ログファイルに書き込めませんでした。");
                        logClose();
                        return;     // エラーリターン
                    }
                }

                MySqlHelper.ExecuteNonQuery(cons, dcmd);

                // Table Create
                string ccmd = "CREATE TABLE " + @table + " (";
                int cno;             // カラム番号
                Excel.Range rng;     // 一度 Range に入れてからでないと値が取り出せない
                string colname;

                for (cno = sc; cno <= ec; cno++)
                {
                    rng = (Excel.Range)sheet.Cells[sr, cno];
                    colname = rng.Text.ToString();
                    // カラム名チェック     // 2014/07/16   Add
                    if (colname == "")
                    {
                        MessageBox.Show(cno.ToString() + " 列の項目名が有りません。\n 処理を中止します。");
                        book.Close(false);
                        app.Quit();
                        if (LogOut == 1)
                        {
                            logClose();
                        }
                        return;             // エラーリターン
                    }

                    ccmd = ccmd + colname;

                    // MySQL の時は，カラムのタイプが必要
                    rng = (Excel.Range)sheet.Cells[sr + 1, cno];
                    string ctyp = rng.Text.ToString();

                    if (ctyp.Equals("INT"))
                    {   // INT
                        ccmd = ccmd + " INT";
                    }
                    else if (ctyp.Equals("TEXT"))
                    {   // VARCHAR
                        ccmd = ccmd + " TEXT";
                    }
                    else if (ctyp.Equals("REAL"))
                    {   // FLOAT
                        ccmd = ccmd + " DOUBLE";
                    }
                    else
                    {
                        MessageBox.Show("EXCEL シートの型が INT, TEXT, REAL 以外です。:", ctyp);
                        book.Close(false);      // Workbook クローズ
                        app.Quit();             // Excel 終了
                        if (LogOut == 1)
                        {
                            logClose();
                        }
                        return;                 // エラーリターン
                    }

                    if (cno == ec)
                    {
                        ccmd = ccmd + ");";     // 最終カラム
                    }
                    else
                    {
                        ccmd = ccmd + ",";
                    }
                }

                if (LogOut == 1)
                {
                    if (logWrite(ccmd) == false)
                    {
                        MessageBox.Show("ログファイルに書き込めませんでした。");
                        book.Close();
                        app.Quit();
                        logClose();
                        return;     // エラーリターン 
                    }
                }

                // CREATE TABLE コマンド実行
                MySqlHelper.ExecuteNonQuery(cons, ccmd);
 
                int j;
                for (j = sr + 2; j <= er; j++)   // 開始行+2 から開始
                {
                    icmd = "INSERT INTO " + @table + " VALUES (";
                    int i;
                    for (i = sc; i <= ec; i++)
                    {
                        rng = (Excel.Range)sheet.Cells[sr + 1, i];    // Range に型取り出し
                        string t = rng.Text.ToString();             // 型取り出し

                        rng = (Excel.Range)sheet.Cells[j, i];       // Range に値取り出し
                        string v = rng.Text.ToString();             // 値取り出し
                        // 値セット
                        if (t == "TEXT" || t == "text")
                        {
                            icmd = icmd + "'";
                            icmd = icmd + v;
                            icmd = icmd + "'";
                        }
                        else
                        {
                            icmd = icmd + v;
                        }
                        if (i != ec)
                        {
                            icmd = icmd + ",";
                        }
                    }
                    icmd = icmd + ");";

                    if (LogOut == 1)
                    {   // ログ出力有り
                        if (logWrite(icmd) == false)
                        {
                            MessageBox.Show("ログファイルに書き込めませんでした。");
                            book.Close();
                            app.Quit();
                            logClose();
                            return;     // エラーリターン
                        }
                    }

                    // INSERT コマンド実行
                    MySqlHelper.ExecuteNonQuery(cons, icmd);
                }

                if (LogOut == 1)
                {
                    logClose();
                }

                book.Close(false);      // Workbook クローズ
                app.Quit();             // Excel 終了
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

                if (book != null)
                {
                    book.Close();
                }
                if (app != null)
                {
                    app.Quit();
                }
                if (LogOut == 1)
                {
                    logClose();
                }
            }
        }

        // toDB
        private void button2_Click(object sender, EventArgs e)
        {
            if (LogOut == 1)
            {
                if (LogPath.Text == "")
                {
                    MessageBox.Show("ログファイルのパスを指定して下さい。");
                    return;
                }
                // ログファイルオープン
                if (logOpen(LogPath.Text) == false)
                {
                    MessageBox.Show("ログファイルがオープン出来ませんでした。");
                    return;
                }
            }

                toDBMySQL();
        }

        // Table の有無確認
        //  MySQL
        private bool findTableMySQL()
        {
            string dbpath = DbFilePath2.Text;

            // DB コネクションストリング
            string cons = "";
            cons = String.Format("Server={0}; Database={1}; Uid={2}; Pwd={3}",
                Host, dbpath, Uid, Pwd);

            string tablename = TableName2.Text;

            DataSet ds = null;         // MySQL Data Set
            DataTable tbl = null;      // MySQL Data Table

            // コマンド生成
            string cmd = "SELECT * FROM " + tablename + ";";
            try
            {
                ds = MySqlHelper.ExecuteDataset(cons, cmd);
                tbl = ds.Tables[0];
                if (ds.Tables.Count <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ec)
            {
                return false;
            }
        }

        private bool findTable()
        {
            string dbpath = DbFilePath2.Text;

            // DB コネクションストリング
            string cons = "";
            // MySQL
            cons = String.Format("Server={0}; Database={1}; Uid={2}; Pwd={3}",
                Host, dbpath, Uid, Pwd);
            
            string tablename = TableName2.Text;

            // SQLite と MySQL を分離したため削除
            // SQLiteConnection con = null;
            // SQLiteCommand scmd = null;
            // SQLiteDataReader rd = null;

            DataSet ds = null;         // MySQL Data Set
            DataTable tbl = null;      // MySQL Data Table

            // コマンド生成
            string cmd = "SELECT * FROM " + tablename + ";";
            // MySQL
            try
            {
                ds = MySqlHelper.ExecuteDataset(cons, cmd);
                tbl = ds.Tables[0];
                if (ds.Tables.Count <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ec)
            {
                return false;
            }
        }


        // 開始 (From DB)
        private  void fromDBMySQL()
        {
            string path = ExFilePath2.Text;     // Excel ファイルパス
            string dbpath = DbFilePath2.Text;

            // Excel ファイルの有無確認
            if (File.Exists(path) == false)
            {
                MessageBox.Show(path + " ファイルが存在しません。");
                return;
            }
            // テーブルの有無確認
            if (findTableMySQL() == false)
            {
                MessageBox.Show("指定のDBまたは，テーブルが存在しません。\nDB，テーブル名を確認してください。");
                return;
            }

            // DB コネクションストリング
            string cons = "";
            cons = String.Format("Server={0}; Database={1}; Uid={2}; Pwd={3}",
                Host, dbpath, Uid, Pwd);
            
            string tablename = TableName2.Text;

            // Excel ファイルオープン
            Excel.Application app;
            app = new Excel.Application();      // EXCEL アプリ生成
            app.Visible = true;                 // EXCEL 表示

            // Workbook オープン
            Excel.Workbook book;
            book = (Excel.Workbook)(app.Workbooks.Open(path));

            // Worksheet
            string sh = SheetNo2.Text;
            int shno = int.Parse(sh);
            Excel.Worksheet sheet = (Excel.Worksheet)book.Worksheets[shno];

            try
            {
                DataSet ds = null;         // MySQL Data Set
                DataTable tbl = null;      // MySQL Data Table

                // コマンド生成
                string cmd = "SELECT * FROM " + tablename + ";";
                // MySqlHelper.ExecuteNonQuery(cons, "set names UTF8");    // UTF8 効果無し
                ds = MySqlHelper.ExecuteDataset(cons, cmd);
                tbl = ds.Tables[0];
                
                // DB パスセット
                sheet.Cells[1, 1] = dbpath;
                // テーブル名セット
                sheet.Cells[2, 1] = tablename;

                int rno, cno;   // Row 番号，Column 番号

                // カラム数取り出し
                int cnum = 0;
                cnum = tbl.Columns.Count;

                // カラム名取り出し     
                // SJIS の MySQL は，SHOW CREATE TABLE の結果から取り出さないと文字化けする。

                int i;
                String[] colnames = new String[cnum];       // MySQL 用
                for (i = 0; i < cnum; i++)
                {
                    colnames[i] = "";
                }
                if (GetMysqlColnames(cons, tablename, cnum, ref colnames) == false)
                {   // 取り出し失敗
                    return;
                }
                cno = 1;
                for (i = 0; i < cnum; i++)
                {
                    string cname = "";
                    cname = colnames[i];
                    sheet.Cells[3, cno] = cname;
                    cno++;
                }

                rno = 4;
                Type typ;       // カラムの型
                int rnum = tbl.Rows.Count;
                for (int r = 0; r < rnum; r++)
                {
                    cno = 1;
                    for (i = 0; i < cnum; i++)
                    {
                        string val = tbl.Rows[r].ItemArray[i].ToString();
                        sheet.Cells[rno, cno] = val;
                        cno++;
                    }
                    rno++;
                }
            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.Message);
            }
            book.Close(true);       // Workbook クローズ
            app.Quit();         // Excel 終了
        }

        // From DB
        private void button5_Click(object sender, EventArgs e)
        {
            // MySQL
            fromDBMySQL();
        }


        // MySQL 用カラム名取り出し（SJIS で文字化けに対応）
        //      ==> string cons     ..... コネクションストリング
        //      ==> string tblname  ..... テーブル名
        //      ==> int cnum        ..... カラム数  (カラム数を指定しないと PRIMARY_KEY (`xxx`) の所も取り出してしまう。)
        //      <== String[] cols   ..... カラム名配列    呼び出し元で初期化用
        //
        private Boolean GetMysqlColnames(string cons, string tblname, int cnum, ref String[] cols)
        {
            String cmd;             // SHOW CREATE TABLE コマンド
            DataSet ds;             // DataSet
            DataTable tbl;          // DataTable
            String item2;           // CREATE 文，\n 区切り
            int i = 0;              // カラム名インデックス

            cmd = "SHOW CREATE TABLE " + tblname + ";";     // コマンド生成
            try
            {
                ds = MySqlHelper.ExecuteDataset(cons, cmd);
                tbl = ds.Tables[0];
                item2 = tbl.Rows[0].ItemArray[1].ToString();    // CREATE 文 （[0] は Table名）

                String work;    // 取り出し用ワークエリア
                int s, e;       // 取り出し開始，終了インデックス
                int len;        // ワークエリア長

                work = item2;
                // 取り出し開始，終了インデックス取り出し
                s = work.IndexOf('(', 0);   // 頭の ( を捜す
                e = work.LastIndexOf(')');  // 最後の ) を捜す
                // ( ) 間取り出し
                work = work.Substring(s + 1, e - s - 1);

                s = 0;
                len = work.Length;

                for (i=0; i<cnum; i++)
                {
                    s = work.IndexOf('`', s);   // ` を捜す
                    if (s < 0)      break;      // 終了

                    e = work.IndexOf('`', s + 1);   // 次の ` を捜す
                    if (e < 0)      break;          // 終了

                    // カラム名取り出し ` ` 間
                    String col = work.Substring(s + 1, e - s - 1);
                    s = e + 1;

                    cols[i] = col;

                    if (s >= len)   break;
                }
                return true;
            }
            catch (MySqlException em)
            {
                MessageBox.Show("指定の体ブルが見つかりません。\n" + em.Message);
                return false;
            }
        }

        private int LogOut = 0;                 // ログ出力有無   0: 無し， 1: 有り
        private StreamWriter wrlog = null;      // ログファイル出力ストリーム

        // ログファイルオープン
        private bool logOpen(string path)
        {
            try
            {
                wrlog = new StreamWriter(path);
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }
        // ログファイルクローズ
        private bool logClose()
        {
            if (wrlog == null)
            {   // 未オープン
                return false;
            }
            else
            {
                wrlog.Close();
                wrlog.Dispose();
                return true;
            }
        }
        // ログファイル出力
        private bool logWrite(string cmd)
        {
            if (wrlog == null)
            {   // 未オープン
                return false;
            }
            else
            {
                try
                {
                    wrlog.WriteLine(cmd);
                    return true;
                }
                catch (IOException e)
                {   // 出力失敗
                    return false;
                }
            }
        }

        // ログ出力チェックボックス
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                LogOut = 1;
                button8.Enabled = true;
            }
            else
            {
                LogOut = 0;
                button8.Enabled = false;
            }
        }

        // ログファイルファイルダイアログ
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"D:\";      // 初期ディレクトリ
            dlg.Filter = "LOG ファイル(*.log)|*.log|全て(*.*)|*.*";
            dlg.Title = "LOG ファイルを指定して下さい。";
            dlg.CheckFileExists = false;        // 存在しないファイル許可
            dlg.RestoreDirectory = true;        // ディレクトリ復帰

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LogPath.Text = dlg.FileName;
            }
        }
    }
}
