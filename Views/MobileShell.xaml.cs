﻿namespace OA.Public.Maui.SampleApp.Views;

public partial class MobileShell
{
    public MobileShell()
    {
        InitializeComponent();

        BindingContext = new ShellViewModel();
    }
}
