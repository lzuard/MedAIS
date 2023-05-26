using System.Collections.Generic;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class PatientViewModel:ViewModelBase
    {
        private IPatientsService? _patientsService;
        private int _doctorId;

        #region SelectedTabItem

        private int _selectedTabItem = 3;

        public int SelectedTabItem
        {
            get => _selectedTabItem;
            set => Set(ref _selectedTabItem, value);
        }

        #endregion SelectedTabItem

        #region CurrentPatient

        private MedCard _currentPatient;

        public MedCard CurrentPatient
        {
            get => _currentPatient;
            set => Set(ref _currentPatient, value);
        }

        #endregion CurrentPatient

        #region PatientAddress

        private Address _patientAddress;

        public Address PatientAddress
        {
            get => _patientAddress;
            set => Set(ref _patientAddress, value);
        }

        #endregion PatientAddress

        #region SelectedGenderIndex

        private int _selectedGenderIndex = 0;

        public int SelectedGenderIndex
        {
            get => _selectedGenderIndex;
            set => Set(ref _selectedGenderIndex, value);
        }

        #endregion SelectedGenderIndex

        #region Genders

        private IEnumerable<string> _genders = new List<string>{"Мужчина", "Женщина"};

        public IEnumerable<string> Genders
        {
            get => _genders;
            set => Set(ref _genders, value);
        }

        #endregion Genders

        #region MedCardHeader

        private string _medCardHeader = "Новый пациент";

        public string MedCardHeader
        {
            get => _medCardHeader;
            set => Set(ref _medCardHeader, value);
        }

        #endregion MedCardHeader

        #region MedCardsCollection

        private IEnumerable<MedCard> _medCardsCollection;

        public IEnumerable<MedCard> MedCardsCollection
        {
            get => _medCardsCollection;
            set => Set(ref _medCardsCollection, value);
        }

        #endregion MedCardsCollection

        public void PopUp(IPatientsService patientsService, MedCard patient, int doctorId)
        {
            _patientsService = patientsService;
            _doctorId = doctorId;
            CurrentPatient = patient;

            SelectedTabItem = CurrentPatient.Id == 0 ? 3 : 0;

            MedCardsCollection = _patientsService.GetAllMedCards();
        }
    }
}
