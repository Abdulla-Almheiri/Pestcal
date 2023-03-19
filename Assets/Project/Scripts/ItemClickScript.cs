using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pestcal {
    public class ItemClickScript : MonoBehaviour
    {
        public GameController Game;
        public GameObject TextObject;

        public int Index = 0;
        [TextArea]
        public string Text = "";
        public int Cost = 1;
        public bool SingleUpgrade = false;
        private void OnMouseEnter()
        {
            Game.ShowTooltip(Text);
        }

        private void OnMouseExit()
        {
            Game.HideTooltip();
        }

        private void OnMouseDown()
        {
            var canBuy = Game.AttemptPurchase(Cost);
            if(canBuy)
            {
                Game.UpgradePurchased(Index);

                if(SingleUpgrade)
                {
                    Hide();
                }
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            if(TextObject != null)
            {
                TextObject.SetActive(false);
            }
        }
    }
}