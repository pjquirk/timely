namespace Timely.ViewModels.Groups.SampleData
{
    using System;
    using GalaSoft.MvvmLight;

    public class SampleGroupListItemViewModel : ViewModelBase, IGroupListItemViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}