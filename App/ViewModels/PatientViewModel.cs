using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private IWindowService _windowService;
        private DoctorsViewModel _doctorsViewModel;
        private int _doctorId;
        private bool _isNewPatient;
        private bool _isMedCardSelected;

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

        #region OldPatientElementsVisibility

        private Visibility _oldPatientElementsVisibility;

        public Visibility OldPatientElementsVisibility
        {
            get => _oldPatientElementsVisibility;
            set => Set(ref _oldPatientElementsVisibility, value);
        }

        #endregion OldPatientElementsVisibility


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

        private ObservableCollection<Checkup> _checkups = new ObservableCollection<Checkup>();

        public ObservableCollection<Checkup> Checkups
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

        #region CurrentAnamnesisVitae

        private AnamnesisVitae _currentAnamnesisVitae;

        public AnamnesisVitae CurrentAnamnesisVitae
        {
            get => _currentAnamnesisVitae;
            set => Set(ref _currentAnamnesisVitae, value);
        }

        #endregion CurrentAnamnesisVitae

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
                LoadChambers();
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

        #region SelectedMedCardIndex

        private int _selectedMedCardIndex;

        public int SelectedMedCardIndex
        {
            get => _selectedMedCardIndex;
            set
            {
                Set(ref _selectedMedCardIndex, value);
                _isMedCardSelected = _selectedGenderIndex>0;
            }
        }

        #endregion SelectedMedCardIndex

        #endregion InfoTabProperties


        #region ExaminatioTabProperties

        #region Examinations

        private ObservableCollection<Examination> _examinations;

        public ObservableCollection<Examination> Examinations
        {
            get => _examinations;
            set => Set(ref _examinations, value);
        }

        #endregion Examinations

        #region Treatments

        private ObservableCollection<Treatment> _treatments;

        public ObservableCollection<Treatment> Treatments
        {
            get => _treatments;
            set => Set(ref _treatments, value);
        }

        #endregion Treatments

        #region SelectedExaminationIndex

        private int _selectedExaminationIndex;

        public int SelectedExaminationIndex
        {
            get => _selectedExaminationIndex;
            set => Set(ref _selectedExaminationIndex, value);
        }

        #endregion SelectedExaminationIndex

        #endregion ExaminatioTabProperties


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
           ResetMedCard();
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

        #region OpenExamination command

        private ICommand _openExaminationCommand;

        public ICommand OpenExaminationCommand => _openExaminationCommand
            ??= new LambdaCommand(OnOpenExaminationCommandExecuted, CanOpenExaminationCommandExecute);

        private bool CanOpenExaminationCommandExecute() => true;

        private void OnOpenExaminationCommandExecuted()
        {

        }

        #endregion OpenExamination

        #region AddCheckup command

        private ICommand _addCheckupCommand;

        public ICommand AddCheckupCommand => _addCheckupCommand
            ??= new LambdaCommand(OnAddCheckupCommandExecuted, CanAddCheckupCommandExecute);

        private bool CanAddCheckupCommandExecute() => true;

        private void OnAddCheckupCommandExecuted()
        {
            CreateCheckup();
        }

        #endregion AddCheckup

        #region AddExamination command

        private ICommand _addExaminationCommand;

        public ICommand AddExaminationCommand => _addExaminationCommand
            ??= new LambdaCommand(OnAddExaminationCommandExecuted, CanAddExaminationCommandExecute);

        private bool CanAddExaminationCommandExecute() => true;

        private void OnAddExaminationCommandExecuted()
        {

        }

        #endregion AddExamination


        #endregion Commands

        private void OpenCheckup()
        {
            _windowService.OpenExistingCheckupWindow(new Checkup());
        }

        private void CreateCheckup()
        {
            _windowService.OpenNewCheckupWindow(CurrentHospitalization.Id);
            LoadCheckups();
        }

        private void CloseView()
        {
            _doctorsViewModel.CurrentPatient = null;
        }

        private void ResetMedCard()
        {
            CurrentPatient = new MedCard();
            CurrentAnamnesisVitae = new AnamnesisVitae();
            CurrentHospitalization = new Hospitalization();
            PatientAddress = new Address();
            SelectedMedCardIndex = -1;
        }

        private void LoadChambers()
        {
            AvailableChambers = _patientsService.GetDoctorsChambers(_doctorId, _patientGender);
        }

        private void LoadCheckups()
        {
            var checkups = _patientsService.GetPatientCheckups(CurrentHospitalization.Id);
            Checkups = checkups is null
                ? new ObservableCollection<Checkup>()
                : new ObservableCollection<Checkup>(checkups);
        }

        private void SaveChanges()
        {
            bool saved;

            CurrentPatient.Gender = _patientGender;
            if (_isNewPatient)
            {
                if (_isMedCardSelected)
                    CurrentPatient = MedCardsCollection.ElementAt(SelectedMedCardIndex);

                saved = _patientsService.SaveNewPatient(CurrentPatient, PatientAddress, CurrentHospitalization,
                    CurrentAnamnesisVitae, AvailableChambers.ElementAt(SelectedChamber));
            }
            else
            {
                saved = _patientsService.SaveOldPatient(CurrentPatient, PatientAddress, CurrentHospitalization, 
                    CurrentAnamnesisVitae, AvailableChambers.ElementAt(SelectedChamber));
            }

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
            int doctorId,
            IWindowService windowService)
        {
            _doctorsViewModel = doctorsViewModel;
            _patientsService = patientsService;
            _windowService = windowService;
            _doctorId = doctorId;
            CurrentPatient = patient;

            MedCardsCollection = _patientsService.GetAllMedCards();

            if (CurrentPatient.Id == 0)
            {
                _isNewPatient = true;
                OldPatientElementsVisibility = Visibility.Hidden;
                SelectedTabItem = 3;
                PatientAddress = new Address();
                IsMedCardsComboBoxReadOnly = false;
                SelectedMedCardIndex = -1;
                CurrentHospitalization = new Hospitalization();
                CurrentAnamnesisVitae = new AnamnesisVitae();
                Examinations = new ObservableCollection<Examination>();
                Checkups = null;
                MedCardHeader = "Новый пациент";
            }
            else
            {
                _isNewPatient = false;
                OldPatientElementsVisibility = Visibility.Visible;
                SelectedTabItem = 0;
                PatientAddress = CurrentPatient.Address;
                IsMedCardsComboBoxReadOnly = true;
                SelectedMedCardIndex = MedCardsCollection.FirstIndexOf(CurrentPatient);
                CurrentHospitalization = _patientsService.GetCurrentHospitalization(CurrentPatient.Id);
                CurrentAnamnesisVitae = _patientsService.GetAnamnesisVitae(CurrentHospitalization.Id);
                LoadCheckups();
                //Examinations = CurrentHospitalization.Examinations;
                //Treatments = CurrentHospitalization.Treatments;

                //Debug
                Examinations = new ObservableCollection<Examination>
                {
                    new Examination()
                    {
                        Date = new DateTime(2023, 08, 10),
                        User = new User()
                        {
                            Name = "Василий",
                            Surname = "Иванов",
                            Patronymic = "Петрович"
                        },
                        Cabinet = new Cabinet()
                        {
                            Name = "Кабинет рентгенографии"
                        }
                    }
                };
                Treatments = new ObservableCollection<Treatment>
                {
                    new Treatment()
                    {
                        StartDate = new DateTime(2023, 01, 10),
                        EndDate = new DateTime(2023, 01, 15),
                        Medication = "Аспирин",
                        Volume = 200,
                        Frequency = "1 таблетка в день",
                        IsStopped = true,
                        Result = "Голова больше не болит"
                    }
                };
                //Debug
                
                MedCardHeader = CurrentPatient.ToString();
            }

            LoadChambers();
        }
    }
}
