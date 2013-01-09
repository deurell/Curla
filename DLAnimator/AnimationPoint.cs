using System.Windows;

namespace DLabs.Animation
{
    public class AnimationPoint : UIElement
    {
        public static readonly DependencyProperty PointProperty =
            DependencyProperty.Register("Point", typeof (Point), typeof (AnimationPoint), new PropertyMetadata(default(Point)));

        public Point Point
        {
            get { return (Point) GetValue(PointProperty); }
            set { SetValue(PointProperty, value); }
        }
    }
}