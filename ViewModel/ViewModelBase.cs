using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    internal class ViewModelBase
    {
        protected readonly DatabaseContext _dbContext;

        public ViewModelBase(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}