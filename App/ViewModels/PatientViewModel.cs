using System;
using System.Collections.Generic;
using System.Linq;
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

        private Gender _patientGender = 0;

        #region Properties

        #region SelectedTabItem

        private int _selectedTabItem;

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

        #region MedCardHeader

        private string _medCardHeader = "Новый пациент";

        public string MedCardHeader
        {
            get => _medCardHeader;
            set => Set(ref _medCardHeader, value);
        }

        #endregion MedCardHeader

        #region ShortDiagnosis

        private string _shortDiagnosis = "Не установлен";

        public string ShortDiagnosis
        {
            get => _shortDiagnosis;
            set => Set(ref _shortDiagnosis, value);
        }

        #endregion ShortDiagnosis

        #region Complaints

        private string _complaints;

        public string Complaints
        {
            get => _complaints;
            set => Set(ref _complaints, value);
        }

        #endregion Complaints

        #region CurrentAnamnesisVitae

        private AnamnesisVitae _currentAnamnesisVitae;

        public AnamnesisVitae CurrentAnamnesisVitae
        {
            get => _currentAnamnesisVitae;
            set => Set(ref _currentAnamnesisVitae, value);
        }

        #endregion CurrentAnamnesisVitae

        #endregion Properties


        #region CardTabProperies

        #region CurrentHospitalization

        private Hospitalization _currentHospitalization;

        public Hospitalization CurrentHospitalization
        {
            get => _currentHospitalization;
            set => Set(ref _currentHospitalization, value);
        }

        #endregion CurrentHospitalization

        #region Checkups

        private IEnumerable<Checkups> _checkups = new List<Checkups>();

        public IEnumerable<Checkups> Checkups
        {
            get => _checkups;
            set => Set(ref _checkups, value);
        }

        #endregion Checkups

        #region CheckUpsDataGridSelectedIndex

        private int _checkUpsDataGridSelectedIndex;

        public int CheckUpsDataGridSelectedIndex
        {
            get => _checkUpsDataGridSelectedIndex;
            set => Set(ref _checkUpsDataGridSelectedIndex, value);
        }

        #endregion CheckUpsDataGridSelectedIndex

        #region HospitalizationTypesList

        private IEnumerable<string> _hospitalizationTypesList = new List<string>{"Направление", "СМП"};

        public IEnumerable<string> HospitalizationTypesList
        {
            get => _hospitalizationTypesList;
            set => Set(ref _hospitalizationTypesList, value);
        }

        #endregion HospitalizationTypesList

        #region SelectedHospitalizationType

        private int _selectedHospitalizationType;

        public int SelectedHospitalizationType
        {
            get => _selectedHospitalizationType;
            set => Set(ref _selectedHospitalizationType, value);
        }

        #endregion SelectedHospitalizationType

        #region AvailableChambers

        private IEnumerable<Chamber> _availableChambers;

        public IEnumerable<Chamber> AvailableChambers
        {
            get => _availableChambers;
            set => Set(ref _availableChambers, value);
        }

        #endregion AvaliableChambers

        #region SelectedChamber

        private int _selectedChamber;

        public int SelectedChamber
        {
            get => _selectedChamber;
            set => Set(ref _selectedChamber, value);
        }

        #endregion SelectedChamber

        #endregion


        #region InfoTabProperties

        #region PatientAddress

        private Address _patientAddress;

        public Address PatientAddress
        {
            get => _patientAddress;
            set => Set(ref _patientAddress, value);
        }

        #endregion PatientAddress

        #region Genders collection

        private IEnumerable<string> _genders = new List<string> { "Мужчина", "Женщина" };

        public IEnumerable<string> Genders
        {
            get => _genders;
            set => Set(ref _genders, value);
        }

        #endregion Genders Collection

        #region SelectedGenderIndex

        private int _selectedGenderIndex = 0;

        public int SelectedGenderIndex
        {
            get => _selectedGenderIndex;
            set
            {
                Set(ref _selectedGenderIndex, value);
                _patientGender = _selectedGenderIndex == 0 ? Gender.Male : Gender.Female;
            }
        }

        #endregion SelectedGenderIndex

        #region IsMedCardsComboBoxReadOnly

        private bool _isMedCardsComboBoxReadOnly;

        public bool IsMedCardsComboBoxReadOnly
        {
            get => _isMedCardsComboBoxReadOnly;
            set => Set(ref _isMedCardsComboBoxReadOnly, value);
        }

        #endregion IsMedCardsComboBoxReadOnly

        #region MedCardsCollection

        private IEnumerable<MedCard> _medCardsCollection;

        public IEnumerable<MedCard> MedCardsCollection
        {
            get => _medCardsCollection;
            set => Set(ref _medCardsCollection, value);
        }

        #endregion MedCardsCollection

        #endregion InfoTabProperties

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

        #region OpenCheckup command

        private ICommand _openCheckupCommand;

        public ICommand OpenCheckupCommand => _openCheckupCommand
            ??= new LambdaCommand(OnOpenCheckupCommandExecuted, CanOpenCheckupCommandExecute);

        private bool CanOpenCheckupCommandExecute() => true;

        private void OnOpenCheckupCommandExecuted()
        {
            OpenCheckup();
        }

        #endregion OpenCheckup

        #endregion Commands

        private void OpenCheckup()
        {
            MessageBox.Show("1", "1");
        }

        private void CloseView()
        {
            _doctorsViewModel.CurrentPatient = null;
        }

        private void SaveChanges()
        {
            CurrentPatient.Gender = _patientGender;
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

            //Debug
            Checkups = Checkups.Append(new Checkups()
            {
                Id = 10,
                CheckUpId = 122,
                Date = new DateTime(2021, 12, 21),
                Checkup_s = new Сheckup()
                {
                    Id = 111,
                    User = new User()
                    {
                        Name="Алексей",
                        Surname = "Петшашков",
                        Patronymic = "Дмитриевич",
                        Position = new Position()
                        {
                            Id=15,
                            Name= "Невролог"
                        }
                    }
                }
            });
            //Debug

            if (CurrentPatient.Id == 0)
            {
                _isNewPatient = true;
                SelectedTabItem = 3;
                PatientAddress = new Address();
                IsMedCardsComboBoxReadOnly = false;
                CurrentHospitalization = new Hospitalization();
                CurrentAnamnesisVitae = new AnamnesisVitae();
                Checkups = null;
            }
            else
            {
                _isNewPatient = false;
                SelectedTabItem = 0;
                PatientAddress = CurrentPatient.Address;
                IsMedCardsComboBoxReadOnly = true;
                CurrentHospitalization = _patientsService.GetCurrentHospitalization(CurrentPatient.Id);
                CurrentAnamnesisVitae = CurrentHospitalization.AnamnesisVitae.First();
                Checkups = CurrentHospitalization.Checkups;
                //TODO fix hospitalization-anamnesis vitae 1:N -> 1:1
            }

            MedCardsCollection = _patientsService.GetAllMedCards();
            AvailableChambers = _patientsService.GetDoctorsChambers(_doctorId, _patientGender);
        }
    }
}
