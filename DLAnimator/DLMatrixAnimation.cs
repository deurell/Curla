using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DLabs.Animation
{
    public class DLMatrixAnimation : IDLAnimatable
    {
        private readonly MatrixAnimation _matrixAnimation;
        private readonly MatrixTransform _matrixTransform;

        public Object CurrentValue
        {
            get { return _matrixTransform.Matrix; }
        }

        public DLMatrixAnimation(Matrix fromValue, Matrix toValue, Duration duration, Action<object> frameCallback, IEasingFunction easingFunction = null)
        {
            FrameCallback = frameCallback;
            _matrixTransform = new MatrixTransform();
            _matrixAnimation = new MatrixAnimation(fromValue, toValue, duration);
            if(easingFunction != null)
            {
                _matrixAnimation.EasingFunction = easingFunction;
            }
            _matrixAnimation.Completed += (sender, args) =>
                {
                    FrameCallback(_matrixAnimation.To);
                    _matrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, null);
                };
        }

        public AnimationTimeline Animation { get { return _matrixAnimation; } }

        public IEasingFunction EasingFunction { get; set; }

        public Action<object> FrameCallback { get; set; }

        public void Begin()
        {
            _matrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, Animation);
        }
    }
}