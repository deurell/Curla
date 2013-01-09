using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DLabs.Animation;

namespace DLAnimatorExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MatrixTransform _matrixTransform;

        public MainWindow()
        {
            InitializeComponent();
            _matrixTransform = new MatrixTransform(Matrix.Identity);
            label.RenderTransform = _matrixTransform;
        }

        private void Label_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var animator = new DLAnimator();
            var fromMatrix = Matrix.Identity;
            var toMatrix = new Matrix(2, 2, -2, 2, 40, 40);
            var easing = new ElasticEase();
            animator.Add(new DLMatrixAnimation(fromMatrix, toMatrix, TimeSpan.FromSeconds(4), o =>
                {
                    var current = (Matrix) o;
                    _matrixTransform.Matrix = current;
                    label.Content = current;
                }, easing));
            animator.BeginAnimations();

        }
    }
}
