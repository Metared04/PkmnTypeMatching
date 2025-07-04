using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Pkmn.Models;
using WpfPkmn.Views;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace WpfPkmn.ViewModels
{
    public class GetWeaknessesViewModel : ViewModelBase
    {
        //Champs

        private OptionItem _selectedFirstType;
        private OptionItem _selectedSecondType;

        public ObservableCollection<OptionItem> FirstType { get; set; }
        public ObservableCollection<OptionItem> SecondType { get; set; }

        //Proprietes
        public OptionItem SelectedFirstType
        {
            get => _selectedFirstType;
            set
            {
                _selectedFirstType = value;
                OnPropertyChanged(nameof(SelectedFirstType));
                // Déclencher la réévaluation des commandes
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public OptionItem SelectedSecondType
        {
            get => _selectedSecondType;
            set
            {
                _selectedSecondType = value;
                OnPropertyChanged(nameof(SelectedSecondType));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        //Constructeurs
        public GetWeaknessesViewModel() 
        {
            FirstType = new ObservableCollection<OptionItem>();
            SecondType = new ObservableCollection<OptionItem>();
            LoadPkmnType();
        }
        
        private void LoadPkmnType()
        {
            var insecte = new BugType();
            var tenebre = new DarkType();
            var dragon = new DragonType();
            var electrik = new ElectricType();
            var fee = new FairyType();
            var combat = new FightingType();
            var feu = new FireType();
            var vol = new FlyingType();
            var spectre = new GhostType();
            var glace = new IceType();
            var normal = new NormalType();
            var poison = new PoisonType();
            var psy = new PsychicType();
            var roche = new RockType();
            var acier = new SteelType();
            var eau = new WaterType();
            var plante = new GrassType();
            var sol = new GroundType();

            PkmnType[] tab = { insecte, tenebre, dragon, electrik, fee, combat, feu, vol, spectre, glace, normal, poison, psy, roche, acier, eau, plante, sol };
            List<PkmnType> list = new List<PkmnType>();

            foreach (var type in tab)
            {
                FirstType.Add(new OptionItem(type.PkmnTypeName, type));
            }

            SecondType.Add(new OptionItem("Aucun", null));

            foreach (var type in tab)
            {
                SecondType.Add(new OptionItem(type.PkmnTypeName, type));
            }
        }
    }
}
