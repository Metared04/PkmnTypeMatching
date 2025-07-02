using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Pkmn.Models;
using WpfPkmn.Views;

namespace WpfPkmn.ViewModels
{
    public class MainViewModel /*: INotifyPropertyChanged*/
    {
        /*
        public ObservableCollection<OptionItem> TypeOptions1 { get; set; }
        public ObservableCollection<OptionItem> TypeOptions2 { get; set; }
        private RelayCommand _validateCommand;
        private RelayCommand _testCommand;
        //private RelayCommand _openShowTeamsWeaknessesCommand;

        private OptionItem _selectedTypeOption1;
        public OptionItem SelectedTypeOption1
        {
            get => _selectedTypeOption1;
            set
            {
                _selectedTypeOption1 = value;
                OnPropertyChanged();
                _validateCommand.RaiseCanExecuteChanged();
            }
        }

        private OptionItem _selectedTypeOption2;
        public OptionItem SelectedTypeOption2
        {
            get => _selectedTypeOption2;
            set
            {
                _selectedTypeOption2 = value;
                OnPropertyChanged();
                _validateCommand.RaiseCanExecuteChanged();
            }
        }
        public ICommand ValidateCommand { get; }
        public ICommand TestCommand { get; }
        //public ICommand OpenShowTeamsWeaknessesCommand { get; }

        public MainViewModel()
        {
            TypeOptions1 = new ObservableCollection<OptionItem>
            {
                new OptionItem { Label = "Insecte", Type = new BugType() },
                new OptionItem { Label = "Ténèbres", Type = new DarkType() },
                new OptionItem { Label = "Dragon", Type = new DragonType() },
                new OptionItem { Label = "Electrik", Type = new ElectricType() },
                new OptionItem { Label = "Fée", Type = new FairyType() },
                new OptionItem { Label = "Combat", Type = new FightingType() },
                new OptionItem { Label = "Feu", Type = new FireType() },
                new OptionItem { Label = "Vol", Type = new FlyingType() },
                new OptionItem { Label = "Spectre", Type = new GhostType() },
                new OptionItem { Label = "Plante", Type = new GrassType() },
                new OptionItem { Label = "Sol", Type = new GroundType() },
                new OptionItem { Label = "Glace", Type = new IceType() },
                new OptionItem { Label = "Normal", Type = new NormalType() },
                new OptionItem { Label = "Poison", Type = new PoisonType() },
                new OptionItem { Label = "Psy", Type = new PsychicType() },
                new OptionItem { Label = "Roche", Type = new RockType() },
                new OptionItem { Label = "Acier", Type = new SteelType() },
                new OptionItem { Label = "Eau", Type = new WaterType() },
            };

            TypeOptions2 = new ObservableCollection<OptionItem>
            {
                new OptionItem { Label = "Insecte", Type = new BugType() },
                new OptionItem { Label = "Ténèbres", Type = new DarkType() },
                new OptionItem { Label = "Dragon", Type = new DragonType() },
                new OptionItem { Label = "Electrik", Type = new ElectricType() },
                new OptionItem { Label = "Fée", Type = new FairyType() },
                new OptionItem { Label = "Combat", Type = new FightingType() },
                new OptionItem { Label = "Feu", Type = new FireType() },
                new OptionItem { Label = "Vol", Type = new FlyingType() },
                new OptionItem { Label = "Spectre", Type = new GhostType() },
                new OptionItem { Label = "Plante", Type = new GrassType() },
                new OptionItem { Label = "Sol", Type = new GroundType() },
                new OptionItem { Label = "Glace", Type = new IceType() },
                new OptionItem { Label = "Normal", Type = new NormalType() },
                new OptionItem { Label = "Poison", Type = new PoisonType() },
                new OptionItem { Label = "Psy", Type = new PsychicType() },
                new OptionItem { Label = "Roche", Type = new RockType() },
                new OptionItem { Label = "Acier", Type = new SteelType() },
                new OptionItem { Label = "Eau", Type = new WaterType() },
            };
            _validateCommand = new RelayCommand(Validate/*, () => SelectedTypeOption1 != null && SelectedTypeOption2 != null);
            ValidateCommand = _validateCommand;
            _testCommand = new RelayCommand(Test);
            TestCommand = _testCommand;
            //_openShowTeamsWeaknessesCommand = new RelayCommand(OpenShowWeaknesses);
            //OpenShowTeamsWeaknessesCommand = _openShowTeamsWeaknessesCommand;
        }

        private void OpenShowWeaknesses()
        {
            MessageBox.Show("Je dois changer de fenetre");
            var window = new ShowWeaknessesView();
            window.Show();
        }

        private void Validate()
        {
            //MessageBox.Show($"Type sélectionné : {SelectedTypeOption1} et {SelectedTypeOption2}");
            string label1 = SelectedTypeOption1?.Label ?? "(non sélectionné)";
            string label2 = SelectedTypeOption2?.Label ?? "(non sélectionné)";
            //MessageBox.Show($"Type sélectionné : {SelectedTypeOption1.Label} et {SelectedTypeOption2.Label}");
            MessageBox.Show($"Type sélectionné : {label1} et {label2}");

        }

        private void Test()
        {
            MessageBox.Show($"test : {SelectedTypeOption1.Label} et {SelectedTypeOption2.Label}");
        }

        private void ExecuteValidate(object parameter)
        {
            // Pour tester, on affiche la sélection dans la console
            System.Diagnostics.Debug.WriteLine($"Option sélectionnée : {SelectedTypeOption1}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public class OptionItem
        {
            public string Label { get; set; }
            public PkmnType Type { get; set; }
        }
    */
    }
}
