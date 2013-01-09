using System.Windows;

namespace DLabs.Animation
{
    public class AreaRect : UIElement
    {
        public static readonly DependencyProperty AreaRectProperty =
            DependencyProperty.Register("AreaRect", typeof(Rect), typeof(AreaRect), new PropertyMetadata(default(Rect)));

        public Rect Rect
        {
            get { return (Rect)GetValue(AreaRectProperty); }
            set { SetValue(AreaRectProperty, value); }
        }
    }
}