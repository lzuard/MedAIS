using System;
using MedData;
using System.Linq;
using System.Windows;
using MedData.Entities;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MedApp.ViewModels.Base;
using System.Collections.Generic;
using MedApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedApp.ViewModels
{
    internal class PatientViewModel : ViewModelBase
    {
        /*------------------------------------------------------------Private properties------------------*/

        private readonly IMessageService _messageService;
        private readonly IWindowService _windowService;
        private readonly IAuthService _authService;
        private readonly ICheckupService _checkupService;
        private IPatientsService? _patientsService;
        private readonly IExaminationsService _examinationsService;
        private DoctorsViewModel _doctorsViewModel;
        private bool _isNewPatient;
        private bool _isMedCardSelected;
        private Gender _patientGender = 0;

        /*Private properties------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Binding Properties------------------*/

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

        private IEnumerable<string> _hospitalizationTypesList = new List<string> { "Направление", "СМП" };

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
                try
                {
                    UpdateData();
                }
                catch (Exception e)
                {
                    _messageService.ShowError($"Ошибка загрузки данных: {e.Message}", "Ошибка");
                    CloseView();
                }
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
                _isMedCardSelected = _selectedGenderIndex > 0;
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

        /*Binding Properties------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Commands------------------*/

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
                var answer = MessageBox.Show(
                    "Вы уверены, что хотите закрыть окно создания новой записи? Все изменения удалятся!",
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
            OpenExamination();
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
            CreateExamination();
        }

        #endregion AddExamination

        #region OpenDiagnosis command

        private ICommand _openDiagnosisCommand;

        public ICommand OpenDiagnosisCommand => _openDiagnosisCommand
            ??= new LambdaCommand(OnOpenDiagnosisCommandExecuted, CanOpenDiagnosisCommandExecute);

        private bool CanOpenDiagnosisCommandExecute() => true;

        private void OnOpenDiagnosisCommandExecuted()
        {
            OpenDiagnosis();
        }

        #endregion OpenDiagnosis

        #region OpenMoveWindow command

        private ICommand _openMoveWindowCommand;

        public ICommand OpenMoveWindowCommand => _openMoveWindowCommand
            ??= new LambdaCommand(OnOpenMoveWindowCommandExecuted, CanOpenMoveWindowCommandExecute);

        private bool CanOpenMoveWindowCommandExecute() => true;

        private void OnOpenMoveWindowCommandExecuted()
        {
            OpenMoveWindow();
        }

        #endregion OpenMoveWindow


        #endregion Commands

        /*Commands------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Commands methods------------------*/

        private void OpenMoveWindow()
        {
            _windowService.OpenMoveWindow();
        }

        private void OpenDiagnosis()
        {
            _windowService.OpenDiagnosisWindow(CurrentHospitalization);
        }

        private void OpenCheckup()
        {
            _windowService.OpenExistingCheckupWindow(Checkups[CheckUpsDataGridSelectedIndex]);
        }

        private void CreateCheckup()
        {
            var previousCheckup = Checkups.Count > 0 ? Checkups.Last() : null;
            _windowService.OpenNewCheckupWindow(CurrentHospitalization.Id, _authService.CurrentUser.Id, previousCheckup);
            try
            {
                UpdateData();
            }
            catch (Exception e)
            {
                _messageService.ShowError($"Ошибка загрузки данных: {e.Message}", "Ошибка");
                CloseView();
            }
        }

        private void OpenExamination()
        {
            _windowService.OpenExistingExamination(Examinations.ElementAt(SelectedExaminationIndex));
        }

        private void CreateExamination()
        {
            _windowService.OpenNewExaminationWindow(CurrentHospitalization.Id);
            try
            {
                UpdateData();
            }
            catch (Exception e)
            {
                _messageService.ShowError($"Ошибка загрузки данных: {e.Message}", "Ошибка");
                CloseView();
            }
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
                    CurrentAnamnesisVitae, AvailableChambers.ElementAt(SelectedChamber), Treatments);
            }

            if (saved)
                CloseView();
            else
                MessageBox.Show(
                    "Не удалось сохранить данные. Не все поля заполнены. В случае проблем обратитесь к сотрудникам отдела IT",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /*Commands methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Private methods------------------*/

        /// <summary>
        /// Initialize data for modelview work
        /// </summary>
        private void InitData()
        {
            // If new patient appears - his id always 0
            _isNewPatient = CurrentPatient.Id == 0;

            //Setting up the Address
            CurrentPatient.Address ??= new Address(); //TODO: CurrentAddress is useless now

            //Setting up current hospitalization
            CurrentHospitalization = _isNewPatient
                ? new Hospitalization()
                : _patientsService.GetCurrentHospitalization(CurrentPatient.Id);

            //Setting up current anamnesis vitae
            CurrentAnamnesisVitae = _isNewPatient
                ? new AnamnesisVitae()
                : _patientsService.GetAnamnesisVitae(CurrentHospitalization.Id);
        }

        /// <summary>
        /// Update data that can be changed during work
        /// </summary>
        private void UpdateData()
        {
            //Setting up Treatments
            CurrentHospitalization.Treatments ??= new List<Treatment>();
            Treatments = new ObservableCollection<Treatment>(CurrentHospitalization.Treatments);

            //Load chambers for patient
            AvailableChambers = _patientsService.GetDoctorsChambers(_authService.CurrentUser.Id, _patientGender);

            //Setting up checkups
            var checkups = _isNewPatient ? null : _checkupService.GetPatientCheckups(CurrentHospitalization.Id);
            Checkups = checkups is null
                ? new ObservableCollection<Checkup>()
                : new ObservableCollection<Checkup>(checkups);

            //Setting up Examinations
            var examinations = _isNewPatient ? null : _examinationsService.GetExaminations(CurrentHospitalization.Id);
            Examinations = examinations is null
                ? new ObservableCollection<Examination>()
                : new ObservableCollection<Examination>(examinations);

        }

        /// <summary>
        /// Initialize view
        /// </summary>
        private void InitView()
        {

            //Hide useless view elements on new patient creation
            OldPatientElementsVisibility = _isNewPatient ? Visibility.Hidden : Visibility.Visible;

            //Getting all cards for "card" tab combobox
            MedCardsCollection = _patientsService.GetAllMedCards(); //TODO: can be made only on creation

            //Make medcard combobox to select current patient or nothing on new patient
            SelectedMedCardIndex = _isNewPatient ? -1 : MedCardsCollection.FirstIndexOf(CurrentPatient);

            //Set medcard combobox readonly if not creating new patient
            IsMedCardsComboBoxReadOnly = !_isNewPatient;

            //Med card view header title
            MedCardHeader = _isNewPatient ? "Новый пациент" : CurrentPatient.ToString();
        }

        /*Private methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Public methods------------------*/

        /// <summary>
        /// Initialize modelView
        /// </summary>
        public void PopUp(
            DoctorsViewModel doctorsViewModel,
            MedCard patient)
        {
            _doctorsViewModel = doctorsViewModel;
            CurrentPatient = patient;

            try
            {
                InitData();
                InitView();
                UpdateData();
            }
            catch (Exception e)
            {
                _messageService.ShowError($"Ошибка загрузки данных: {e.Message}", "Ошибка");
                CloseView();
            }
        }

        /*Public methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Ctor------------------*/

        public PatientViewModel(
            IMessageService messageService, 
            IWindowService windowService,
            IAuthService authService,
            ICheckupService checkupService, 
            IPatientsService patientsService,
            IExaminationsService examinationsService)
        {
            _messageService = messageService;
            _windowService = windowService;
            _authService = authService;
            _checkupService = checkupService;
            _patientsService = patientsService;
            _examinationsService = examinationsService;
        }
        /*Ctor------------------------------------------------------------------------------*/
    }
}
