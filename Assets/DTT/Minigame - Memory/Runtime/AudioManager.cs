using System;
using UnityEngine;

namespace DTT.Minigame___Memory.Runtime
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickCard;
        [SerializeField] private AudioClip goodMatch;
        [SerializeField] private AudioClip badMatch;

        private void OnEnable()
        {
            CardAudioEvent.OnClickCard += CardAudioEvent_OnClickCard;
            CardAudioEvent.OnGoodMatch += CardAudioEvent_OnGoodMatch;
            CardAudioEvent.OnBadMatch += CardAudioEvent_OnBadMatch;
        }

        private void OnDisable()
        {
            CardAudioEvent.OnClickCard -= CardAudioEvent_OnClickCard;
            CardAudioEvent.OnGoodMatch -= CardAudioEvent_OnGoodMatch;
            CardAudioEvent.OnBadMatch -= CardAudioEvent_OnBadMatch;
        }

        private void CardAudioEvent_OnBadMatch()
        {
            audioSource.PlayOneShot(badMatch);
        }

        private void CardAudioEvent_OnGoodMatch()
        {
            audioSource.PlayOneShot(goodMatch);
        }

        private void CardAudioEvent_OnClickCard()
        {
            audioSource.PlayOneShot(clickCard);
        }
    }
}