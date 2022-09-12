// <copyright file="LoopItemTemplateSelector.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Utilities
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using PowerLoop.UI.Settings;

    public class LoopItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element == null || item == null || !(item is LoopItem i))
            {
                return null;
            }

            if (i.Type == LoopItemType.Image)
            {
                return element.FindResource("ImageTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
