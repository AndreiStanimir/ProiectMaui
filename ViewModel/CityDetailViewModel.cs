using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    internal class CityDetailViewModel : ViewModelBase
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

        public CityDetailViewModel(DatabaseContext context, int majorCityId) : base(context)
        {
            _majorCityId = majorCityId;
            LoadMajorCityDetails();
        }

        private void LoadMajorCityDetails()
        {
            MajorCity = _dbContext.GetMajorCitiesAsync().Result.Find(x => x.Id == _majorCityId);

        }
    }
}
