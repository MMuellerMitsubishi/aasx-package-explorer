﻿/*
Copyright (c) 2018-2019 Festo AG & Co. KG <https://www.festo.com/net/de_de/Forms/web/contact_international>
Author: Michael Hoffmeister

This source code is licensed under the Apache License 2.0 (see LICENSE.txt).

This source code may use other Open Source software components (see LICENSE.txt).
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AasxIntegrationBase;
using AasxWpfControlLibrary;
using AdminShellNS;

namespace AasxPackageExplorer
{
    public class AasCntlBrushes
    {
        public static AasCntlBrush Black { get { return new AasCntlBrush(0xff000000u); } }
        public static AasCntlBrush DarkBlue { get { return new AasCntlBrush(0xff00008bu); } }
        public static AasCntlBrush LightBlue { get { return new AasCntlBrush(0xffadd8e6u); } }
        public static AasCntlBrush White { get { return new AasCntlBrush(0xffffffffu); } }
    }

    public class AasCntlColumnDefinition : ColumnDefinition
    {
    }

    public class AasCntlRowDefinition : RowDefinition
    {
    }

    /*
    public class AasCntlGridLength : GridLength
    {
    }
    */

    public class AasCntlBrush
    {
        private Color solidColorBrush = Colors.Black;

        public AasCntlBrush() { }

        public AasCntlBrush(Color c)
        {
            solidColorBrush = c;
        }

        public AasCntlBrush(SolidColorBrush b)
        {
            solidColorBrush = b.Color;
        }

        public AasCntlBrush(UInt32 c)
        {
            byte[] bytes = BitConverter.GetBytes(c);
            solidColorBrush = Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
        }

        public Brush GetWpfBrush()
        {
            return new SolidColorBrush(solidColorBrush);
        }
    }

    public class AasCntlThickness
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }

        public AasCntlThickness() { }
        
        public AasCntlThickness(double all) 
        { 
            Left = all; Top = all; Right = all; Bottom = all; 
        }
        
        public AasCntlThickness(double left, double top, double right, double bottom) 
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public Thickness GetWpfTickness()
        {
            return new Thickness(Left, Top, Right, Bottom);
        }
    }

    public class AasCntlUIElement
    {
        protected UIElement wpfElement = null;

        public virtual void RenderUIElement(UIElement el) { }

        public virtual UIElement GetWpfElement()
        {
            if (wpfElement is UIElement)
                return wpfElement;
            wpfElement = new UIElement();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }

    public class AasCntlFrameworkElement : AasCntlUIElement
    {
        public AasCntlThickness Margin;
        public VerticalAlignment VerticalAlignment;
        public HorizontalAlignment HorizontalAlignment;

        public double? MinHeight = 0.0;
        public double? MinWidth = 0.0;
        public double? MaxHeight = 0.0;
        public double? MaxWidth = 0.0;

        public object Tag = null;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is FrameworkElement fe)
            {
                if (this.Margin != null)
                    fe.Margin = this.Margin.GetWpfTickness();
                fe.VerticalAlignment = this.VerticalAlignment;   
                if (this.MinHeight.HasValue)
                    fe.MinHeight = this.MinHeight.Value;
                if (this.MinWidth.HasValue)
                    fe.MinWidth = this.MinWidth.Value;
                if (this.MaxHeight.HasValue)
                    fe.MaxHeight = this.MaxHeight.Value;
                if (this.MaxWidth.HasValue)
                    fe.MaxWidth = this.MaxWidth.Value;
                fe.Tag = this.Tag;
            }
        }
       
        public virtual new UIElement GetWpfElement()
        {
            if (wpfElement is FrameworkElement)
                return wpfElement;
            wpfElement = new FrameworkElement();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }

    public class AasCntlControl : AasCntlFrameworkElement
    {
        public VerticalAlignment VerticalContentAlignment;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is Control co)
            {
                co.VerticalContentAlignment = this.VerticalContentAlignment;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            if (wpfElement is Control)
                return wpfElement;
            wpfElement = new Control();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }

    public class AasCntlContentControl : AasCntlControl
    {
        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is ContentControl cc)
            {
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            if (wpfElement is ContentControl)
                return wpfElement;
            wpfElement = new ContentControl();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }

    public class AasCntlDecorator : AasCntlFrameworkElement
    {
        public virtual UIElement Child { get; set; }

        public virtual new UIElement GetWpfElement()
        {
            if (wpfElement is Decorator)
                return wpfElement;
            wpfElement = new Decorator();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }    

    public class AasCntlPanel : AasCntlFrameworkElement
    {
        public AasCntlBrush Background;
        public List<AasCntlUIElement> Children = new List<AasCntlUIElement>();

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is Panel pan)
            {
                // normal members
                if (this.Background != null)
                    pan.Background = this.Background.GetWpfBrush();

                // children
                pan.Children.Clear();
                if (this.Children != null)
                    foreach (var ce in this.Children)
                        pan.Children.Add(ce.GetWpfElement());
            }
        }        
    }

    public class AasCntlGrid : AasCntlPanel
    {
        public List<RowDefinition> RowDefinitions = new List<RowDefinition>();
        public List<ColumnDefinition> ColumnDefinitions = new List<ColumnDefinition>();

        public static void SetRow(AasCntlUIElement element, int value) { }
        public static void SetRowSpan(AasCntlUIElement element, int value) { }
        public static void SetColumn(AasCntlUIElement element, int value) { }
        public static void SetColumnSpan(AasCntlUIElement element, int value) { }

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is Grid sp)
            {
                if (this.RowDefinitions != null)
                    foreach (var rd in this.RowDefinitions)
                        sp.RowDefinitions.Add(rd);

                if (this.ColumnDefinitions != null)
                    foreach (var cd in this.ColumnDefinitions)
                        sp.ColumnDefinitions.Add(cd);
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            if (wpfElement is Grid)
                return wpfElement;
            wpfElement = new Grid();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }

    public class AasCntlStackPanel : AasCntlPanel
    {
        public Orientation Orientation = Orientation.Horizontal;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is StackPanel sp)
            {
                sp.Orientation = this.Orientation;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            if (wpfElement is StackPanel)
                return wpfElement;
            wpfElement = new StackPanel();
            this.RenderUIElement(wpfElement);
            return wpfElement;
        }
    }

    public class AasCntlWrapPanel : AasCntlPanel
    {
        public Orientation Orientation = Orientation.Horizontal;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is WrapPanel sp)
            {
                sp.Orientation = this.Orientation;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new WrapPanel();
            this.RenderUIElement(el);
            return el;
        }
    }    

    public class AasCntlBorder : AasCntlDecorator
    {
        public AasCntlBrush Background = null;
        public AasCntlThickness BorderThickness;
        public AasCntlBrush BorderBrush = null;
        public AasCntlThickness Padding;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is Border brd)
            {
                if (this.Background != null)
                    brd.Background = this.Background.GetWpfBrush();
                if (this.BorderThickness != null)
                    brd.BorderThickness = this.BorderThickness.GetWpfTickness();
                if (this.BorderBrush != null)
                    brd.BorderBrush = this.BorderBrush.GetWpfBrush();
                if (this.Padding != null)
                    brd.Padding = this.Padding.GetWpfTickness();
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new Border();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlLabel : AasCntlContentControl
    {
        public AasCntlBrush Background;
        public AasCntlBrush Foreground;
        public AasCntlThickness Padding;

        public Nullable<FontWeight> FontWeight = null;
        public string Content = null;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is Label lb)
            {
                if (this.Background != null)
                    lb.Background = this.Background.GetWpfBrush();
                if (this.Foreground != null)
                    lb.Foreground = this.Foreground.GetWpfBrush();
                if (this.FontWeight != null)
                    lb.FontWeight = this.FontWeight.Value;
                if (this.Padding != null)
                    lb.Padding = this.Padding.GetWpfTickness();
                lb.Content = this.Content;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new Label();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlTextBlock : AasCntlFrameworkElement
    {
        public Brush Background;
        public Brush Foreground;
        public AasCntlThickness Padding;

        public Nullable<FontWeight> FontWeight = null;
        public string Text = null;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is TextBlock tb)
            {
                tb.Background = this.Background;
                tb.Foreground = this.Foreground;
                if (this.FontWeight != null)
                    tb.FontWeight = this.FontWeight.Value;
                if (this.Padding != null)
                    tb.Padding = this.Padding.GetWpfTickness();
                tb.Text = this.Text;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new TextBlock();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlHintBubble : AasCntlTextBox
    {
        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is HintBubble hb)
            {
                hb.Background = this.Background;
                hb.Foreground = this.Foreground;
                if (this.Padding != null)
                    hb.Padding = this.Padding.GetWpfTickness();
                hb.Text = this.Text;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new HintBubble();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlTextBox : AasCntlControl
    {
        public Brush Background = null;
        public Brush Foreground = null;
        public AasCntlThickness Padding;

        public ScrollBarVisibility VerticalScrollBarVisibility;

        public bool AcceptsReturn;
        public Nullable<int> MaxLines;

        public string Text = null;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is TextBox tb)
            {
                tb.Background = this.Background;
                tb.Foreground = this.Foreground;
                if (this.Padding != null)
                    tb.Padding = this.Padding.GetWpfTickness();
                tb.VerticalScrollBarVisibility = this.VerticalScrollBarVisibility;
                tb.AcceptsReturn = this.AcceptsReturn;
                if (this.MaxLines != null)
                    tb.MaxLines = this.MaxLines.Value;
                tb.Text = this.Text;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new TextBox();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlComboBox : AasCntlControl
    {
        public Brush Background = null;
        public Brush Foreground = null;
        public AasCntlThickness Padding;

        public bool? IsEditable;

        public List<object> Items = new List<object>();
        public string Text = null;

        public int? SelectedIndex;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is ComboBox cb)
            {
                cb.Background = this.Background;
                cb.Foreground = this.Foreground;
                if (this.Padding != null)
                    cb.Padding = this.Padding.GetWpfTickness();
                if (this.IsEditable.HasValue)
                    cb.IsEditable = this.IsEditable.Value;
                cb.Text = this.Text;
                if (this.SelectedIndex.HasValue)
                    cb.SelectedIndex = this.SelectedIndex.Value;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new ComboBox();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlCheckBox : AasCntlContentControl
    {
        public Brush Background = null;
        public Brush Foreground = null;
        public AasCntlThickness Padding;

        public string Content = null;

        public bool? IsChecked;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is CheckBox cb)
            {
                cb.Background = this.Background;
                cb.Foreground = this.Foreground;
                if (this.IsChecked.HasValue)
                    cb.IsChecked = this.IsChecked.Value;
                if (this.Padding != null)
                    cb.Padding = this.Padding.GetWpfTickness();
                cb.Content = this.Content;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new CheckBox();
            this.RenderUIElement(el);
            return el;
        }
    }

    public class AasCntlButton : AasCntlContentControl
    {
        public Brush Background = null;
        public Brush Foreground = null;
        public AasCntlThickness Padding;

        public string Content = null;
        public string ToolTip = null;

        public event RoutedEventHandler Click;

        public virtual new void RenderUIElement(UIElement el)
        {
            base.RenderUIElement(el);
            if (el is Button btn)
            {
                btn.Background = this.Background;
                btn.Foreground = this.Foreground;
                if (this.Padding != null)
                    btn.Padding = this.Padding.GetWpfTickness();
                btn.Content = this.Content;
                btn.ToolTip = this.ToolTip;
            }
        }

        public virtual new UIElement GetWpfElement()
        {
            var el = new Button();
            this.RenderUIElement(el);
            return el;
        }
    }
}
