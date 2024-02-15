using System;

namespace DTT.Minigame___Memory.Runtime
{
    public class CardAudioEvent
    {
        public static event Action OnClickCard, OnGoodMatch, OnBadMatch;

        public void ClickCard()
        {
            OnClickCard?.Invoke();
        }

        public void GoodMatch()
        {
            OnGoodMatch?.Invoke();
        }

        public void BadMatch()
        {
            OnBadMatch?.Invoke();
        }
    }
}