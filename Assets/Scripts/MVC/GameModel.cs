using System.Collections.Generic;
using UnityEngine;

namespace ColorsPlay.Core
{
    public class GameModel
    {
        public List<Color> CurrentColors { get; } = new();
        public Color TargetColor { get; private set; }
        public int ColorsCount { get; }

        public GameModel(int colorsCount)
        {
            ColorsCount = colorsCount;
        }
        
        //JFYI: We might extract Color Generation to a separate service
        //and inject it to the model in .ctor()
        public void GenerateColors()
        {
            CurrentColors.Clear();

            for (int i = 0; i < ColorsCount; i++)
            {
                Color randomColor;

                do randomColor = new Color(Random.value, Random.value, Random.value);
                while (CurrentColors.Contains(randomColor));

                CurrentColors.Add(randomColor);
            }

            TargetColor = CurrentColors[Random.Range(0, ColorsCount)];
        }
    }
}