/* 
 * Application de démonstration Silverlight 4
 * Model-View-ViewModel par la pratique
 * © Janvier 2010 Olivier Dahan, MVP C# 2009, MVP Client App Dev 2010
 * Contact : odahan@e-naxos.com
 * Blog : www.e-naxos.com/blog
 * 
 * Le code qui suit est fourni à titre d'exemple pour accompagner l'article
 * "M-V-VM avec Silverlight en pratique"
 * 
 * Reproduction, diffusion ou exploittion interdites sans l'autorisation
 * de l'auteur.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SpeakAndSpell.Helpers
{
    public partial class Frame : UserControl
    {
        public Frame()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        public static readonly DependencyProperty FrameContentProperty =
            DependencyProperty.Register("FrameContent", typeof(UIElement), typeof(Frame),
            new PropertyMetadata(null, OnContentPropertyChanged));

        public UIElement FrameContent
        {
            get { return (UIElement)GetValue(FrameContentProperty); }
            set { SetValue(FrameContentProperty, value); }
        }

        private static void OnContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var f = (Frame)d;
            UIElement u = (UIElement)((f.InternalPresenter.Content != null) ? f.InternalPresenter.Content : null);

            if (u == null) { f.InternalPresenter.Content = e.NewValue; return; }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation { To = 0, Duration = new Duration(TimeSpan.FromMilliseconds(200)) };
            Storyboard.SetTarget(animation, u);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.Opacity)"));
            storyboard.Children.Add(animation);
            storyboard.Completed += new EventHandler(storyboard_Completed);

            frame = f;
            newElement = (UIElement)e.NewValue;

            storyboard.Begin();
        }

        private static UIElement newElement;
        private static Frame frame;

        static void storyboard_Completed(object sender, EventArgs e)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation { From=0, To = 1, Duration = new Duration(TimeSpan.FromMilliseconds(200)) };
            Storyboard.SetTarget(animation, newElement);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.Opacity)"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
            frame.InternalPresenter.Content = newElement;
        }
    }
}