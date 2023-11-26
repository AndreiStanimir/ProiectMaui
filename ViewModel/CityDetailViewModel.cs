using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    internal class CityDetailViewModel : INotifyPropertyChanged
    {
        private MajorCity _majorCity;
        public MajorCity MajorCity
        {
            get => _majorCity;
            set
            {
                _majorCity = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int _majorCityId;

        public CityDetailViewModel(int majorCityId)
        {
            _majorCityId = majorCityId;
            LoadMajorCityDetails();
        }

        private void LoadMajorCityDetails()
        {
            // Assuming you have a method to get major city details from the database
            // MajorCity = databaseContext.GetMajorCityAsync(_majorCityId).Result;

            // Replace the above with actual database call
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
