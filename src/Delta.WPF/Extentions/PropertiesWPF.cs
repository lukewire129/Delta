using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF._archive.Controls.Extentions
{
    public static class AttachedPropertyExtensions
    {
        public static Dictionary<string, object?> GetAttachedProperty(this IElement element)
        {
            Dictionary<string, object?> values = new Dictionary<string, object?> ();
            if (element.TryGetValue ("Grid.Row", out var row))
            {
                values["Grid.Row"] = row;
            }
            if (element.TryGetValue ("Grid.Column", out var column))
            {
                values["Grid.Column"] = column;
            }
            if (element.TryGetValue ("Grid.RowSpan", out var rowspan))
            {
                values["Grid.RowSpan"] = rowspan;
            }
            if (element.TryGetValue ("Grid.ColumnSpan", out var columnspan))
            {
                values["Grid.ColumnSpan"] = columnspan;
            }
            if (element.TryGetValue ("Canvas.Left", out var canvasleft))
            {
                values["Canvas.Left"] = canvasleft;
            }
            if (element.TryGetValue ("Canvas.Right", out var canvasright))
            {
                values["Canvas.Right"] = canvasright;
            }
            if (element.TryGetValue ("Canvas.Top", out var canvastop))
            {
                values["Canvas.Top"] = canvastop;
            }
            if (element.TryGetValue ("Canvas.Bottom", out var canvasbottom))
            {
                values["Canvas.Bottom"] = canvasbottom;
            }
            if (element.TryGetValue ("RenderOptions.BitmapScalingMode", out var scalingMode))
            {
                values["RenderOptions.BitmapScalingMode"] = scalingMode;
            }
            return values;
        }

        public static void UpdateAttachedProperty(this FrameworkElement? element, string propertyName, object value)
        {
            if (propertyName == "RowDefinitions")
            {
                ((System.Windows.Controls.Grid)element).RowDefinitions.Clear ();

                foreach (var rowdefinition in (List<RowDefinition>)value)
                {
                    ((System.Windows.Controls.Grid)element).RowDefinitions.Add (rowdefinition);
                }
            }
            if (propertyName == "ColumnDefinitions")
            {
                ((System.Windows.Controls.Grid)element).ColumnDefinitions.Clear ();
                foreach (var columndefinition in (List<ColumnDefinition>)value)
                {
                    ((System.Windows.Controls.Grid)element).ColumnDefinitions.Add (columndefinition);
                }
            }
            if (propertyName == "Grid.Row")
            {
                System.Windows.Controls.Grid.SetRow (element, (int)value);
            }
            if (propertyName == "Grid.Column")
            {
                System.Windows.Controls.Grid.SetColumn (element, (int)value);
            }
            if (propertyName == "Grid.RowSpan")
            {
                System.Windows.Controls.Grid.SetRowSpan (element, (int)value);
            }
            if (propertyName == "Grid.ColumnSpan")
            {
                System.Windows.Controls.Grid.SetColumnSpan (element, (int)value);
            }
            if (propertyName == "Canvas.Bottom")
            {
                System.Windows.Controls.Canvas.SetBottom (element, (double)value);
            }
            if (propertyName == "Canvas.Top")
            {
                System.Windows.Controls.Canvas.SetTop (element, (double)value);
            }
            if (propertyName == "Canvas.Left")
            {
                System.Windows.Controls.Canvas.SetLeft (element, (double)value);
            }
            if (propertyName == "Canvas.Right")
            {
                System.Windows.Controls.Canvas.SetRight (element, (double)value);
            }
            if (propertyName == "RenderOptions.BitmapScalingMode")
            {
                System.Windows.Media.RenderOptions.SetBitmapScalingMode (element, (System.Windows.Media.BitmapScalingMode)value);
            }
            //else
            //{
            //    Console.WriteLine ($"Property '{propertyName}' does not exist or is not writable on '{element.GetType ().Name}'.");
            //}
        }
    }
}
