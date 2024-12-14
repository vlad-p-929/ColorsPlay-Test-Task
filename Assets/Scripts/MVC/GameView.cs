using System.Collections.Generic;
using ColorsPlay.Core.Interface;
using TMPro;
using UnityEngine;

namespace ColorsPlay.Core
{
    public class GameView : IGameView
    {
        private readonly CircleView[] circles;
        private readonly TMP_Text targetColorText;

        private readonly string message = "<size=-15>Select:</size>\n <color=#{0}>Target Color</color>";

        public GameView(CircleView[] circles, TMP_Text targetColorText)
        {
            this.circles = circles;
            this.targetColorText = targetColorText;
        }

        public void UpdateTargetColorText(Color color)
        {
            targetColorText.text = string.Format(message, ColorUtility.ToHtmlStringRGB(color));
        }

        public void ShowErrorEffect(CircleView circle)
        {
            circle.ShowErrorEffect();
        }

        public void UpdateObjectColors(List<Color> colors)
        {
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i].SetColor(colors[i]);
            }
        }
    }
}