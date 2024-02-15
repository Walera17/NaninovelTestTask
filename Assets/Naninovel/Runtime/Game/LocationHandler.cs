using UnityEngine;
using UnityEngine.UI;

namespace Naninovel.Runtime.Game
{
    public class LocationHandler : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private string rewardName;

        private void OnEnable()
        {
            button.interactable = !GameFunctions.RewardExist(rewardName);
        }
    }
}