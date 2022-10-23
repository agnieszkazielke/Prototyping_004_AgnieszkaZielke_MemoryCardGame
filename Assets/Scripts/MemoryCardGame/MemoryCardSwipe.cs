using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MemoryCardSwipe : MonoBehaviour
    
    // based on CarouselView from Oculus.Interaction.Samples
    {
        [SerializeField]
        private RectTransform _viewport;

        [SerializeField]
        private RectTransform _content;

        [SerializeField]
        private AnimationCurve _easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        [SerializeField]
        private GameObject _emptyCarouselVisuals;

        [SerializeField] private Logger _debugLogger;

        public int CurrentChildIndex => _currentChildIndex;

        public RectTransform ContentArea => _content;

        private bool _cardScrolled = false;
        private int _currentChildIndex = 0;
        private float _scrollVal = 0;

        
        protected virtual void Start()
        {
            Assert.IsNotNull(_viewport);
            Assert.IsNotNull(_content);
        }

        public void ScrollRight()
        {
            if (_cardScrolled) return;
           
           _currentChildIndex++;
           _scrollVal = Time.time;
           _cardScrolled = true;
           _debugLogger.LogInfo("contents revealed");
           
            /*
            if (_content.childCount <= 1)
            {
                return;
            }
            else if (_currentChildIndex > 0)
            {
                RectTransform currentChild = GetCurrentChild();
                _content.GetChild(0).SetAsLastSibling();
                LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
                ScrollToChild(currentChild, 1);
            }
            else
            {
                _currentChildIndex++;
            }
            _scrollVal = Time.time;
            */
        }
        

        public void ScrollLeft()
        {
            if (_cardScrolled) return;
            _currentChildIndex++;
            _scrollVal = Time.time;
            _cardScrolled = true;
            _debugLogger.LogInfo("contents revealed");

            /*
             if (_content.childCount <= 1)
            {
                return;
            }
            else if (_currentChildIndex < _content.childCount - 1)
            {
                RectTransform currentChild = GetCurrentChild();
                _content.GetChild(_content.childCount - 1).SetAsFirstSibling();
                LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
                ScrollToChild(currentChild, 1);
            }
            else
            {
                _currentChildIndex--;
            }
            _scrollVal = Time.time;
             */

        }


        public void ScrollBack()
        {
            if (!_cardScrolled) return;
            _currentChildIndex--;
            _scrollVal = Time.time;
            _cardScrolled = false;
            _debugLogger.LogInfo("card covered");
        }

        private RectTransform GetCurrentChild()
        {
            return _content.GetChild(_currentChildIndex) as RectTransform;
        }

        private void ScrollToChild(RectTransform child, float amount01)
        {
            if (child == null)
            {
                return;
            }

            amount01 = Mathf.Clamp01(amount01);

            Vector3 viewportCenter = _viewport.TransformPoint(_viewport.rect.center);
            Vector3 imageCenter = child.TransformPoint(child.rect.center);
            Vector3 offset = imageCenter - viewportCenter;

            if (offset.sqrMagnitude > float.Epsilon)
            {
                Vector3 targetPosition = _content.position - offset;
                float lerp = Mathf.Clamp01(_easeCurve.Evaluate(amount01));
                _content.position = Vector3.Lerp(_content.position, targetPosition, lerp);
            }
        }

        protected virtual void Update()
        {
            _currentChildIndex = Mathf.Clamp(
                _currentChildIndex, 0, _content.childCount - 1);

            bool hasImages = _content.childCount > 0;
            if (hasImages)
            {
                RectTransform currentImage = GetCurrentChild();
                ScrollToChild(currentImage, Time.time - _scrollVal);
            }

            if (_emptyCarouselVisuals != null)
            {
                _emptyCarouselVisuals.SetActive(!hasImages);
            }
        }
    }