﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCalculatorProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = VM;
        }

        CalculatorVM VM = new CalculatorVM();
        
        private void Number_Clicked(object sender, RoutedEventArgs e)
        {
            var op = VM.Op as BinaryOperation;
            if (op != null)
                op.StrOperand += ((Button)sender).Content.ToString();
           
        }
        private void Operator_Clicked(object sender, RoutedEventArgs e)
        {
            VM.Operations.Add(VM.Op);
            VM.Op = new BinaryOperation
            {
                PreviousTotal = VM.Op.GetResults,
                Operator = ((Button)sender).Content.ToString()
            };
            
        }

        private void UnaryOperator_Clicked(object sender, RoutedEventArgs e)
        {
            
            var op = new Operation
            {
                PreviousTotal = VM.Op.GetResults,
                Operator = ((Button)sender).Content.ToString()
            };
            VM.Operations.Add(op);
            VM.Op = new BinaryOperation
            {
                PreviousTotal = op.GetResults,
                Operator = "+"
            };
        }
        }
    }

