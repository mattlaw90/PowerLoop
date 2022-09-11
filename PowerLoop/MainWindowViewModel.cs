// <copyright file="MainWindowViewModel.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;

    public class MainWindowViewModel : ObservableObject
    {
        private RelayCommand addItemCommand;

        public ICommand AddItemCommand => this.addItemCommand ??= new RelayCommand(this.OnAddItem);

        private void OnAddItem()
        {

        }
    }
}
