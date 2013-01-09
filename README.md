DLAnimatorLib
=============
WPF has an excellent animation library. It has a shortcoming in the fact that it only animates dependency properties.
This library makes it possible to animate any Matrix, Point or Rectangle you chose.

WPF does not provide a Matrix interpolation animation so this library includes one.

            // create animator
            var animator = new DLAnimator();
            // animate from 1,0,0,1,0,0
            var fromMatrix = Matrix.Identity;
            // set a fancy to value
            var toMatrix = new Matrix(2, 2, -2, 2, 40, 40);
            // library uses WPF easing functions
            var easing = new ElasticEase();
            // add animations to animator
            // labbda will be called with interpolated value each frame
            animator.Add(new DLMatrixAnimation(fromMatrix, toMatrix, TimeSpan.FromSeconds(4), o =>
                {
                    var current = (Matrix) o;
                    _matrixTransform.Matrix = current;
                    label.Content = current;
                }, easing));
            // start the animation
            animator.BeginAnimations();
        }
