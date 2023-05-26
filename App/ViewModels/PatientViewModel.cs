using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class PatientViewModel:ViewModelBase
    {
        private IPatientsService? _patientsService;
        private DoctorsViewModel _doctorsViewModel;
        private int _doctorId;
        private bool _isNewPatient;

        #region Properties

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
            set
            {
                Set(ref _currentPatient, value);
                if (_currentPatient is null)
                {
                    PatientAddress = null;
                }
                else
                {
                    PatientAddress = _currentPatient.Address;
                }
            }
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

        private IEnumerable<string> _genders = new List<string> { "Мужчина", "Женщина" };

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

        #region IsMedCardsComboBoxReadOnly

        private bool _isMedCardsComboBoxReadOnly;

        public bool IsMedCardsComboBoxReadOnly
        {
            get => _isMedCardsComboBoxReadOnly;
            set => Set(ref _isMedCardsComboBoxReadOnly, value);
        }

        #endregion IsMedCardsComboBoxReadOnly

        #endregion Properties

        #region Commands

        #region Save command

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);

        private bool CanSaveCommandExecute() => true;

        private void OnSaveCommandExecuted()
        {
            SaveChanges();
        }

        #endregion Save

        #region Close command

        private ICommand _closeCommand;

        public ICommand CloseCommand => _closeCommand
            ??= new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);

        private bool CanCloseCommandExecute() => true;

        private void OnCloseCommandExecuted()
        {
            if (_isNewPatient)
            {
                var answer = MessageBox.Show("Вы уверены, что хотите закрыть окно создания новой записи? Все изменения удалятся!",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (answer != MessageBoxResult.Yes) return;
            }

            CloseView();
        }

        #endregion Close

        #region CancelCurrentUser command

        private ICommand _cancelCurrentPatientCommand;

        public ICommand CancelCurrentPatientCommand => _cancelCurrentPatientCommand
            ??= new LambdaCommand(OnCancelCurrentPatientCommandExecuted, CanCancelCurrentPatientCommandExecute);

        private bool CanCancelCurrentPatientCommandExecute() => true;

        private void OnCancelCurrentPatientCommandExecuted()
        {
            CurrentPatient = null;
        }

        #endregion CancelCurrentPatient

        #endregion Commands

        private void CloseView()
        {
            _doctorsViewModel.CurrentPatient = null;
        }

        private void SaveChanges()
        {
            bool saved = _patientsService.SaveNewPatient(CurrentPatient, PatientAddress);
            if (saved)
                CloseView();
            else
                MessageBox.Show(
                    "Не удалось сохранить данные. Не все поля заполнены. В случае проблем обратитесь к сотрудникам отдела IT",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void PopUp(
            DoctorsViewModel doctorsViewModel,
            IPatientsService patientsService, 
            MedCard patient, 
            int doctorId)
        {
            _doctorsViewModel = doctorsViewModel;
            _patientsService = patientsService;
            _doctorId = doctorId;
            CurrentPatient = patient;

            if (CurrentPatient.Id == 0)
            {
                _isNewPatient = true;
                SelectedTabItem = 3;
                PatientAddress = new Address();
                IsMedCardsComboBoxReadOnly = false;
            }
            else
            {
                _isNewPatient = false;
                SelectedTabItem = 0;
                PatientAddress = CurrentPatient.Address;
                IsMedCardsComboBoxReadOnly = true;
            }

            MedCardsCollection = _patientsService.GetAllMedCards();
        }
    }
}
