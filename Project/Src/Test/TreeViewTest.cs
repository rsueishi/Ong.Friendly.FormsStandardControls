using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;
using Codeer.Friendly.Windows.NativeStandardControls;
using System.Windows.Forms;

namespace Test
{
    /// <summary>
    /// TreeViewテスト
    /// </summary>
    [TestFixture]
    public class TreeViewTest
    {
        WindowsAppFriend app;
        WindowControl testDlg;

        /// <summary>
        /// 初期化
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            //テスト用の画面起動
            app = new WindowsAppFriend(Process.Start(Settings.TestApplicationPath), "2.0");
            testDlg = WindowControl.FromZTop(app);
        }

        /// <summary>
        /// 終了
        /// </summary>
        [TestFixtureTearDown]
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
        /// ノードをテキストで検索して選択します
        /// </summary>
        [Test]
        public void TestTreeViewFindNodeAndSelect()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindNode("Child 2");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
        }

        /// <summary>
        /// 現在選択されているノードのテキストを取得します
        /// </summary>
        [Test]
        public void TestTreeViewSelectNodeText()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindNode("Child 1");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
            FormsTreeNode selectedNode = treeView1.SelectNode;
            Assert.AreEqual("Child 1", selectedNode.Text);
        }

        /// <summary>
        /// ノードをテキストで検索して選択します
        /// </summary>
        [Test]
        public void TestTreeViewFindNodeAndSelectAndExpand()
        {
            FormsTreeView treeView1 = new FormsTreeView(app, testDlg["treeView1"]());
            FormsTreeNode node = treeView1.FindNode("Child 2");
            Assert.NotNull(node);
            treeView1.EmulateNodeSelect(node, new Async());
            node.EmulateExpand();
        }
    }
}
