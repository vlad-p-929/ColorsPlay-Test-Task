using ColorsPlay.Core;
using ColorsPlay.Input;
using TMPro;
using UnityEngine;
using static UnityEngine.Input;

namespace ColorsPlay
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text targetColorText;

        [SerializeField] 
        private CircleView[] circles;

        private InputController<CircleView> inputController;

        void Awake()
        {
            var gameModel = new GameModel(colorsCount: 3);
            var gameView = new GameView(circles, targetColorText);
            var gameController = new GameController(gameModel, gameView);

            inputController = new InputController<CircleView>();
            inputController.OnClick += gameController.OnObjectClicked;
        }

        void Update()
        {
            //Since we don't need anything fancy and cross-platform input
            if (GetMouseButtonDown(0))
            {
                inputController.HandleMouseClick();
            }
        }
    }
}