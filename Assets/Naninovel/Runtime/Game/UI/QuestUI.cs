using Naninovel.UI;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Naninovel.Runtime.Game.UI
{
    public class QuestUI : CustomUI
    {
        [SerializeField] private TMP_Text logText;
        [SerializeField] private GameObject globalMap;
        private readonly List<string> questLogs = new();
        private int counter;

        public void ShowLog(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                logText.text = String.Empty;
                return;
            }

            switch (text)
            {
                case "EnableGlobalMap":
                    GlobalMapEnableDisable(true);
                    break;
                case "DisableGlobalMap":
                    GlobalMapEnableDisable(false);
                    break;
                default:
                    SetupTextBlock(text);
                    break;
            }
        }

        private void SetupTextBlock(string text)
        {
            counter++;
            string showText = counter + ". " + text;
            questLogs.Add(showText);
            logText.text = showText;
        }

        private void GlobalMapEnableDisable(bool value)
        {
            globalMap.SetActive(value);
        }
    }
}