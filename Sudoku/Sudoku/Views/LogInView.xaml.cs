﻿using System.Windows;

namespace Sudoku.Views
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            Username.Focus();
        }
    }
}
