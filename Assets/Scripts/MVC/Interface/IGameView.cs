using System.Collections.Generic;
using UnityEngine;


namespace ColorsPlay.Core.Interface
{
    public interface IGameView
    {
        public void UpdateTargetColorText(Color color);
        public void ShowErrorEffect(CircleView circle);
        public void UpdateObjectColors(List<Color> colors);
    }
}