﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// コード生成
    /// </summary>
    public class FormsDateTimePickerGenerator : GeneratorBase
    {
        DateTimePicker _control;

        /// <summary>
        /// アタッチ。
        /// </summary>
        protected override void Attach()
        {
            _control = (DateTimePicker)ControlObject;
            _control.ValueChanged += DateTimeValueChanged;
            _control.CloseUp += DateTimeValueChanged;
        }

        /// <summary>
        /// ディタッチ。
        /// </summary>
        protected override void Detach()
        {
            _control.ValueChanged -= DateTimeValueChanged;
            _control.CloseUp -= DateTimeValueChanged;
        }

        /// <summary>
        /// 日付変更
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベント内容</param>
        void DateTimeValueChanged(object sender, EventArgs e)
        {
            if (_control.Focused)
            {
                AddSentence(new TokenName(), ".EmulateSelectDay(new DateTime(", _control.Value.Year , "," , _control.Value.Month , "," ,_control.Value.Day , "));");
            }
        }
    }
}