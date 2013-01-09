using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace DLabs.Animation
{
    public class DLPointAnimation : IDLAnimatable
    {
        private readonly PointAnimation _pointAnimation;
        private readonly AnimationPoint _point;
        
        public object CurrentValue { get { return _point.Point; }}

        public DLPointAnimation(Point fromValue, Point toValue, Duration duration, Action<object> frameCallback, IEasingFunction easingFunction = null)
        {
            FrameCallback = frameCallback;
            _point = new AnimationPoint();
            _pointAnimation = new PointAnimation(fromValue, toValue, duration);
            if (easingFunction != null)
            {
                _pointAnimation.EasingFunction = easingFunction;
            }
            _pointAnimation.Completed += (sender, args) =>
                {
                    FrameCallback(_pointAnimation.To);
                    _point.BeginAnimation(AnimationPoint.PointProperty, null);
                };
        }

        public void Begin()
        {
            _point.BeginAnimation(AnimationPoint.PointProperty, _pointAnimation);
        }

        public Action<object> FrameCallback { get; set; }

        public AnimationTimeline Animation
        {
            get { return _pointAnimation; }
        }
    }
}