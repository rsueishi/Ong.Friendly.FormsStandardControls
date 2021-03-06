﻿using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using System;
using System.Windows.Forms;

namespace Ong.Friendly.FormsStandardControls
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type System.Windows.Forms.ProgressBar.
    /// </summary>
#else
    /// <summary>
    /// TypeがSystem.Windows.Forms.ProgressBarのウィンドウに対応した操作を提供します。
    /// </summary>
#endif
    [ControlDriver(TypeFullName = "System.Windows.Forms.ProgressBar")]
    public class FormsProgressBar : FormsControlBase
    {
#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="src">WindowControl object for the underlying control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="src">元となるウィンドウコントロール。</param>
#endif
        public FormsProgressBar(WindowControl src)
            : base(src) { }

#if ENG
        /// <summary>
        /// Currently deprecated. 
        /// Please use FormsProgressBar(AppVar windowObject).
        /// </summary>
        /// <param name="app">Application manipulation object.</param>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// 現在非推奨です。
        /// FormsProgressBar(AppVar windowObject)を使用してください。
        /// </summary>
        /// <param name="app">アプリケーション操作クラス。</param>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        [Obsolete("Please use FormsProgressBar(AppVar windowObject).", false)]
        public FormsProgressBar(WindowsAppFriend app, AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public FormsProgressBar(AppVar appVar)
            : base(appVar) { }

#if ENG
        /// <summary>
        /// Minimum.
        /// </summary>
#else
        /// <summary>
        /// 最小値です。
        /// </summary>
#endif
        public int Min
        {
            get { return (int)this["Minimum"]().Core; }
        }

#if ENG
        /// <summary>
        /// Maximum.
        /// </summary>
#else
        /// <summary>
        /// 最大値です。 
        /// </summary>
#endif
        public int Max
        {
            get { return (int)this["Maximum"]().Core; }
        }

#if ENG
        /// <summary>
        /// Current value.
        /// </summary>
#else
        /// <summary>
        /// 現在位置です。  
        /// </summary>
#endif
        public int Pos
        {
            get { return (int)this["Value"]().Core; }
        }
    }
}