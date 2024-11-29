﻿using DeltaWPFSample.Components;
using System.Windows;
using System.Windows.Controls;

namespace DeltaWPFSample
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "MVU Application";
            Width = 400;
            Height = 300;

            var counterComponent = new CounterComponent ();
            Content = counterComponent; // CounterComponent is its own root panel.
        }
    }
}