using Mvvm1125;
using System;
using System.Collections.ObjectModel;

namespace WpfApp14
{
    internal class VisitListVM : MvvmNotify, IPageVM
    {
        Model model;
        public ObservableCollection<DateTime> Visits { get; set; } = new ObservableCollection<DateTime>();
        public string Title { get; set; }
        public MvvmCommand Back { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            Back = new MvvmCommand(() => Pages.ChangePageTo(PageType.ClientList), () => true);
            model.SelectedClientChanged += Model_SelectedClientChanged;
        }

        private void Model_SelectedClientChanged(object sender, EventArgs e)
        {
            if (model.SelectedClient != null)
            {
                Title = $"История посещений клиента {model.SelectedClient.Name}";
                NotifyPropertyChanged("Title");
                Visits = new ObservableCollection<DateTime>(model.SelectedClient.VisitLog);
                NotifyPropertyChanged("Visits");
            }
        }
    }
}