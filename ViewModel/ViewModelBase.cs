using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    public class ViewModelBase
    {
        protected readonly DatabaseContext _dbContext;

        public ViewModelBase()
        {
            _dbContext= MauiProgram.CreateMauiApp().Services.GetService<DatabaseContext>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}