using System.Windows.Forms;
using System.Collections.Generic;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Ong.Friendly.FormsStandardControls
{
    /// <summary>
    /// TypeがSystem.Windows.Forms.ListViewのウィンドウに対応した操作を提供します。
    /// </summary>
    public class FormsListView : FormsControlBase
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
        public FormsListView(WindowControl src)
            : base(src) { }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
        public FormsListView(WindowsAppFriend app, AppVar appVar)
            : base(app, appVar) { }

        /// <summary>
        /// Viewモードを取得します。
        /// </summary>
        public View ViewMode
        {
            get { return (View)(this["View"]().Core); }
        }

        /// <summary>
        /// 列数を取得します。
        /// </summary>
        public int ColumnCount
        {
            get { return (int)(this["Columns"]()["Count"]().Core); }
        }

        /// <summary>
        /// アイテム数を取得します。
        /// </summary>
        public int ItemCount
        {
            get { return (int)(this["Items"]()["Count"]().Core); }
        }

        /// <summary>
        /// 選択されたインデックスの一覧を取得します。
        /// </summary>
        public int[] SelectIndexes
        {
            get { return (int[])(App[GetType(), "GetSelectedIndexesInTarget"](AppVar).Core); } 
        }
        
        /// <summary>
        /// 指定したインデックスのアイテムを取得します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <returns>指定したインデックスのアイテム。</returns>
        public FormsListViewItem GetListViewItem(int index)
        {
            return new FormsListViewItem(App, AppVar, this["Items"]()["[]"](index));
        }

        /// <summary>
        /// 指定したテキスト値で始まる最初のアイテムを検索します。
        /// </summary>
        /// <param name="itemText">テキスト。</param>
        /// <param name="includeSubItemsInSearch">検索にサブ項目を含める場合は true。それ以外の場合は false。</param>
        /// <param name="startIndex">検索を開始する位置の項目のインデックス。</param>
        /// <returns>指定したテキスト値で始まる最初のアイテム</returns>
        public FormsListViewItem FindItemWithText(string itemText, bool includeSubItemsInSearch, int startIndex)
        {
            AppVar returnItem = this["FindItemWithText"](itemText, includeSubItemsInSearch, startIndex);
            if ((bool)App[GetType(), "ReferenceEquals"](returnItem, null).Core)
            {
                return null;
            }
            return new FormsListViewItem(App, AppVar, returnItem);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムの選択状態を変更します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        public void EmulateChangeSelectedState(int index, bool isSelect)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget"](AppVar, index, isSelect);
        }

        /// <summary>
        /// 指定されたインデックスに該当するアイテムの選択状態を変更します。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        /// <param name="async">非同期オブジェクト</param>
        public void EmulateChangeSelectedState(int index, bool isSelect, Async async)
        {
            App[GetType(), "EmulateChangeSelectedStateInTarget", async](AppVar, index, isSelect);
        }

        /// <summary>
        /// 選択されたインデックスの一覧を取得します（内部）。
        /// </summary>
        /// <param name="listview">リストビュー</param>
        /// <returns>選択されたインデックス一覧。</returns>
        private static int[] GetSelectedIndexesInTarget(ListView listview)
        {
            List<int> list = new List<int>();
            for (int itemIndex = 0; itemIndex < listview.Items.Count; itemIndex++)
            {
                if (listview.Items[itemIndex].Selected == true)
                {
                    list.Add(itemIndex);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// リストビューアイテムを選択します（内部）。
        /// </summary>
        /// <param name="listview">リストビュー。</param>
        /// <param name="index">インデックス。</param>
        /// <param name="isSelect">選択状態にする場合はtrueを設定します。</param>
        private static void EmulateChangeSelectedStateInTarget(ListView listview, int index, bool isSelect)
        {
            listview.Focus();
            listview.Items[index].Selected = isSelect;
        }
    }
}