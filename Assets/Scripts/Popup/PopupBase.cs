using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PopUp
{
    public enum ShowTweenTypes
    {
        NONE = 0,
        FromLeft,
        FromRight,
        FromDown,
        FromUp
    }

    public enum HideTweenTypes
    {
        NONE = 0,
        ToLeft,
        ToRight,
        ToUp,
        ToDown
    }

    public class PopupBase : MonoBehaviour
    {
        [Header("Base References:")] [SerializeField]
        protected Image transparentBGImage;

        [SerializeField] protected Color transparentBGColor;
        [SerializeField] protected RectTransform popupRoot;

        [Space(5)] [Header("Tween Settings:")] [SerializeField]
        protected ShowTweenTypes showTweenType;

        [SerializeField] protected float showTweenDuration = 0.25f;
        [SerializeField] protected Ease showEase = Ease.InOutSine;

        [SerializeField] protected HideTweenTypes hideTweenType;
        [SerializeField] protected float hideTweenDuration = 0.25f;
        [SerializeField] protected Ease hideEase = Ease.InOutSine;

        [SerializeField] protected float backgroundFadeDuration = 0.2f;

        protected Vector3 startPos;
        protected Vector3 targetPos;

        protected int backListenerOrder;
        
        private Vector3 hidePosOffset = Vector3.zero;

        protected virtual void OnEnable()
        {
            startPos = new Vector3();
            targetPos = new Vector3();
        }

        private void PreShow()
        {
            //Determine Start-x.
            if (showTweenType == ShowTweenTypes.FromLeft || showTweenType == ShowTweenTypes.FromRight)
            {
                int multiplier = (showTweenType == ShowTweenTypes.FromRight) ? 1 : -1;
                startPos.x = Screen.width * multiplier;
                targetPos.x = 0f;
                targetPos.y = popupRoot.localPosition.y;
            }
            else
            {
                startPos.x = popupRoot.localPosition.x;
            }

            //Determine Start-y.
            if (showTweenType == ShowTweenTypes.FromDown || showTweenType == ShowTweenTypes.FromUp)
            {
                int multiplier = (showTweenType == ShowTweenTypes.FromUp) ? 1 : -1;
                startPos.y = Screen.height * multiplier;
                targetPos.y = 0f;
                targetPos.x = popupRoot.localPosition.x;
            }
            else
            {
                startPos.y = popupRoot.localPosition.y;
            }

            startPos.z = popupRoot.localPosition.z;
            popupRoot.localPosition = startPos;

            if (transparentBGImage != null)
            {
                Color clearColor = transparentBGColor;
                clearColor.a = 0;
                transparentBGImage.color = clearColor;
            }
        }


        public virtual void Show(float delay = 0f)
        {
            PreShow();
            
            Sequence showSequence = DOTween.Sequence();
            if (transparentBGImage != null)
            {
                showSequence.Insert(0, transparentBGImage.DOFade(transparentBGColor.a, backgroundFadeDuration));
            }
            showSequence.Insert(0, popupRoot.DOLocalMove(targetPos, showTweenDuration).SetEase(showEase));
            showSequence.SetDelay(delay);
            showSequence.Play().OnComplete(OnShowCompleted);
        }

        private void PreHide()
        {
            if (hideTweenType == HideTweenTypes.ToLeft || hideTweenType == HideTweenTypes.ToRight)
            {
                var multiplier = hideTweenType == HideTweenTypes.ToLeft ? -1 : 1;
                hidePosOffset.x += Screen.width * multiplier;
            }

            if (hideTweenType == HideTweenTypes.ToDown || hideTweenType == HideTweenTypes.ToUp)
            {
                var multiplier = hideTweenType == HideTweenTypes.ToDown ? -1 : 1;
                hidePosOffset.y += Screen.height * multiplier;
            }
        }
        
        public virtual void Hide(float delay = 0f)
        {
            PreHide();
            Sequence hideSequence = DOTween.Sequence();
            hideSequence.Insert(0, popupRoot.DOLocalMove(transform.localPosition + hidePosOffset, hideTweenDuration).SetEase(hideEase));
            if (transparentBGImage != null)
            {
                hideSequence.Insert(0, transparentBGImage.DOFade(0f, backgroundFadeDuration));
            }
            hideSequence.SetDelay(delay);
            hideSequence.Play().OnComplete(OnHideCompleted);
        }

        protected virtual void OnShowCompleted()
        {

        }

        protected virtual void OnHideCompleted()
        {
            gameObject.SetActive(false);
        }
    }
}
