using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DaBoyzApp.Services;

public static class CardAnimationService
{
    public static void Stagger(
        IEnumerable<UIElement> elements,
        double slideDistance = 20,
        double durationMilliseconds = 500,
        double staggerMilliseconds = 100)
    {
        int index = 0;

        foreach (UIElement element in elements)
        {
            element.Opacity = 0;

            TranslateTransform transform =
                new TranslateTransform(0, slideDistance);

            element.RenderTransform = transform;

            DoubleAnimation opacityAnimation =
                new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration =
                        TimeSpan.FromMilliseconds(
                            durationMilliseconds),
                    BeginTime =
                        TimeSpan.FromMilliseconds(
                            index * staggerMilliseconds),
                    EasingFunction =
                        new CubicEase
                        {
                            EasingMode =
                                EasingMode.EaseOut
                        }
                };

            DoubleAnimation slideAnimation =
                new DoubleAnimation
                {
                    From = slideDistance,
                    To = 0,
                    Duration =
                        TimeSpan.FromMilliseconds(
                            durationMilliseconds),
                    BeginTime =
                        TimeSpan.FromMilliseconds(
                            index * staggerMilliseconds),
                    EasingFunction =
                        new CubicEase
                        {
                            EasingMode =
                                EasingMode.EaseOut
                        }
                };

            element.BeginAnimation(
                UIElement.OpacityProperty,
                opacityAnimation);

            transform.BeginAnimation(
                TranslateTransform.YProperty,
                slideAnimation);

            index++;
        }
    }
}