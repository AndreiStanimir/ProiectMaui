using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    public class CityDetailViewModel : ViewModelBase
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

        private int _majorCityId;

        public CityDetailViewModel(int majorCityId) : base()
        {
            _majorCityId = majorCityId;
            LoadMajorCityDetails();
        }

        private void LoadMajorCityDetails()
        {
            MajorCity = _dbContext.GetMajorCitiesAsync().Find(x => x.Id == _majorCityId);

        }
    }
}
