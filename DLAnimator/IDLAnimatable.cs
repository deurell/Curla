using System;
using System.Windows.Media.Animation;

namespace DLabs.Animation
{
    public interface IDLAnimatable
    {
        AnimationTimeline Animation { get; }
        Object CurrentValue { get; }
        void Begin();
        Action<object> FrameCallback { get; set; }
    }
}