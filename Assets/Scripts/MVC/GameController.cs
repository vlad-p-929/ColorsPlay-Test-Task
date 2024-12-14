using ColorsPlay.Core.Interface;
using UnityEngine;

namespace ColorsPlay.Core
{
    public class GameController
    {
        private readonly GameModel gameModel;
        private readonly IGameView gameView;

        public GameController(GameModel gameModel, IGameView gameView)
        {
            this.gameModel = gameModel;
            this.gameView = gameView;

            StartNewRound();
        }

        public void OnObjectClicked(CircleView circle)
        {
            Color selectedColor = circle.Color;
            if (selectedColor == gameModel.TargetColor)
            {
                StartNewRound();
            }
            else
            {
                gameView.ShowErrorEffect(circle);
            }
        }

        private void StartNewRound()
        {
            gameModel.GenerateColors();
            gameView.UpdateObjectColors(gameModel.CurrentColors);
            gameView.UpdateTargetColorText(gameModel.TargetColor);
        }
    }
}