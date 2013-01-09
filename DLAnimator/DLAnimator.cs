using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DLabs.Animation
{
    public class DLAnimator
    {
        private readonly List<IDLAnimatable> _animations;
        private int _runningAnimations;


        public DLAnimator()
        {
            _animations = new List<IDLAnimatable>();
        }

        private void FrameCallback(object sender, EventArgs eventArgs)
        {
            foreach (var fenixAnimatable in _animations)
            {
                fenixAnimatable.FrameCallback(fenixAnimatable.CurrentValue);
            }
        }

        public void Add(IDLAnimatable animation)
        {
            animation.Animation.FillBehavior = FillBehavior.Stop;
            animation.Animation.Completed += AnimationCompleted;
            _animations.Add(animation);
        }

        private void AnimationCompleted(object sender, EventArgs e)
        {
            _runningAnimations--;
            if (_runningAnimations == 0)
            {
                CompositionTarget.Rendering -= FrameCallback;
            }
        }

        public void BeginAnimations()
        {
            CompositionTarget.Rendering += FrameCallback;
            _runningAnimations = _animations.Count;
            foreach (var animation in _animations)
            {
                animation.Begin();
            }
        }
    }
}