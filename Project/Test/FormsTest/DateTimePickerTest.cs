﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Windows.Forms;

namespace FormsTest
{
    /// <summary>
    /// DateTimePickerテスト
    /// </summary>
    [TestClass]
    public class DateTimePickerTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath));
            testDlg = WindowControl.FromZTop(app);
            WindowsAppExpander.LoadAssemblyFromFile(app, GetType().Assembly.Location);
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //終了処理
            if (app != null)
            {
                app.Dispose();
                Process process = Process.GetProcessById(app.ProcessId);
                process.CloseMainWindow();
                app = null;
            }
        }

        /// <summary>
        /// EmulateSelectDay/SelectedDayのテスト
        /// </summary>
        [TestMethod]
        public void TestSelectDay()
        {
            FormsDateTimePicker datetimepicker = new FormsDateTimePicker(testDlg["dateTimePicker1"]());
            datetimepicker.EmulateSelectDay(new DateTime(2013,10,17));
            DateTime datetime = (DateTime)datetimepicker.SelectedDay;
            Assert.AreEqual(new DateTime(2013,10,17), datetime);

            // 非同期
            app[GetType(), "ChangeDateTimeEvent"](datetimepicker.AppVar);
            datetimepicker.EmulateSelectDay(new DateTime(2013, 10, 18), new Async());
            new NativeMessageBox(testDlg.WaitForNextModal()).EmulateButtonClick("OK");
            datetime = datetimepicker.SelectedDay;
            Assert.AreEqual(new DateTime(2013, 10, 18), datetime);
        }

        /// <summary>
        /// 日時変更時にメッセージボックスを表示する
        /// </summary>
        /// <param name="DateTimePicker">DateTimePicker</param>
        static void ChangeDateTimeEvent(DateTimePicker datetime)
        {
            EventHandler handler = null;
            handler = delegate
            {
                MessageBox.Show("");
                datetime.BeginInvoke((MethodInvoker)delegate
                {
                    datetime.ValueChanged -= handler;
                });
            };
            datetime.ValueChanged += handler;
        }
    }
}
