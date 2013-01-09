using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace DLabs.Animation
{
    public class DLRectAnimation : IDLAnimatable
    {
        private readonly System.Windows.Media.Animation.RectAnimation _rectAnimation;
        private readonly AreaRect _areaRect;

        public Object CurrentValue
        {
            get { return _areaRect.Rect; }
        }

        public DLRectAnimation(Rect fromValue, Rect toValue, Duration duration, Action<object> frameCallback, IEasingFunction easingFunction = null)
        {
            FrameCallback = frameCallback;
            _areaRect = new AreaRect();
            _rectAnimation = new System.Windows.Media.Animation.RectAnimation(fromValue, toValue, duration);
            if(easingFunction != null)
            {
                _rectAnimation.EasingFunction = easingFunction;
            }
            _rectAnimation.Completed += (sender, args) =>
                {
                    FrameCallback(_rectAnimation.To);
                    _areaRect.BeginAnimation(AreaRect.AreaRectProperty, null);
                };
        }

        public AnimationTimeline Animation { get { return _rectAnimation; } }

        public IEasingFunction EasingFunction { get; set; }

        public Action<object> FrameCallback { get; set; }

        public void Begin()
        {
            _areaRect.BeginAnimation(AreaRect.AreaRectProperty, _rectAnimation);
        }
    }
}
