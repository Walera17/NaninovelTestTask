using Naninovel.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Naninovel.Runtime.Game.UI
{
    public class QuestUI : CustomUI
    {
        [SerializeField] private GameObject log;
        [SerializeField] private TMP_Text logText;
        [SerializeField] private GameObject globalMap;
        [SerializeField] private GameObject exitGame;
        [SerializeField] private TMP_Text exitGameText;
        private readonly List<string> questLogs = new();
        private int counter;

        public void ShowLog(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                logText.text = String.Empty;
                log.SetActive(false);
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
                case "ExitGame":
                    ExitGame();
                    break;
                default:
                    SetupTextBlock(text);
                    break;
            }
        }

        private void ExitGame()
        {
            exitGame.SetActive(true);
            StartCoroutine(FadeText());
        }

        private IEnumerator FadeText()
        {
            float a = 0.0f;

            while (a <= 1.0f)
            {
                a += Time.deltaTime;
                exitGameText.color = new Color(1, 1, 1, a);
                yield return null;
            }
        }

        private void SetupTextBlock(string text)
        {
            if(!log.activeSelf) log.SetActive(true);

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