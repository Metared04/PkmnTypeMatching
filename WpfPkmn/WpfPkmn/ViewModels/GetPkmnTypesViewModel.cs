﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Pkmn.Models;
using static WpfPkmn.ViewModels.MainViewModel;

namespace WpfPkmn.ViewModels
{
    public class GetPkmnTypesViewModel : ViewModelBase
    {
        //Champs
        private OptionItem _selectedFirstType;
        private OptionItem _selectedSecondType;

        public ObservableCollection<OptionItem> FirstType { get; set; }
        public ObservableCollection<OptionItem> SecondType { get; set; }

        public ObservableCollection<TypeDisplayItem> ResistingTypes { get; set; }
        public ObservableCollection<TypeDisplayItem> NotResistingTypes { get; set; }

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

        //Commandes
        public ICommand ExecuteDisplayFirstType { get; }
        public ICommand ExecuteDisplayPkmnResistances { get; }

        //Constructeur
        public GetPkmnTypesViewModel()
        {
            FirstType = new ObservableCollection<OptionItem>();
            SecondType = new ObservableCollection<OptionItem>();
            ResistingTypes = new ObservableCollection<TypeDisplayItem>();
            NotResistingTypes = new ObservableCollection<TypeDisplayItem>();
            ExecuteDisplayFirstType = new ViewModelCommand(ExecuteDisplayFirstTypeAction, CanExecuteDisplayFirstTypeAction);
            ExecuteDisplayPkmnResistances = new ViewModelCommand(ExecuteDisplayPkmnResistancesAction, CanExecuteDisplayPkmnResistancesAction);
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

        private static List<PkmnType> GetAllTypes()
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
            return new List<PkmnType>
            {
                insecte, tenebre, dragon, electrik,
                fee, combat, feu, vol,
                spectre, glace, normal, poison,
                psy, roche, acier, eau,
                plante, sol
            };
        }

        //Bouton affichage des types choisit.
        private bool CanExecuteDisplayFirstTypeAction(object obj)
        {
            return SelectedFirstType != null;
        }

        private void ExecuteDisplayFirstTypeAction(object obj)
        {
            if(SelectedSecondType == null)
            {
                MessageBox.Show($"Type choisit : {SelectedFirstType.Label}");
            }
            else if(SelectedFirstType == null)
            {
                SelectedFirstType = SelectedSecondType;
                MessageBox.Show($"Type choisit : {SelectedFirstType.Label}");
            } else
            {
                MessageBox.Show($"Double type choisit : {SelectedFirstType.Label} - {SelectedSecondType.Label}");
            }
        }

        //Bouton affichage du type du pkmn choisit
        private bool CanExecuteDisplayPkmnResistancesAction(object obj)
        {
            return (SelectedFirstType != null);
        }

        private void ExecuteDisplayPkmnResistancesAction(object obj)
        {
            ResistingTypes.Clear();
            NotResistingTypes.Clear();
            Pokemon myPkmn;
            
            if (SelectedSecondType == null || SelectedSecondType.Label == "Aucun")
            {
                myPkmn = new Pokemon(SelectedFirstType.Value);
                MessageBox.Show("Pkmn monotype");
            }
            else if (SelectedFirstType.Value == SelectedSecondType.Value)
            {
                myPkmn = new Pokemon(SelectedFirstType.Value);
                MessageBox.Show("Pkmn monotype");
                //var myPkmn = new Pokemon(SelectedFirstType.Value);
                //var res = ShowSimpleResistanceOnly(myPkmn);
            } else
            {
                myPkmn = new Pokemon(SelectedFirstType.Value, SelectedSecondType.Value);
                MessageBox.Show("Pkmn double type");
                //var myPkmn = new Pokemon(SelectedFirstType.Value, SelectedSecondType.Value);
                //var res = ShowSimpleResistanceOnly(myPkmn);
            }

            var resistances = GetSimpleResistances(myPkmn);
            var weaknesses = GetSimpleWeaknesses(myPkmn);

            foreach (var resistance in resistances)
            {
                ResistingTypes.Add(new TypeDisplayItem 
                { 
                    Name = $"{resistance.PkmnTypeName}" 
                });
            }
            foreach (var weakness in weaknesses)
            {
                NotResistingTypes.Add(new TypeDisplayItem
                {
                    Name = $"{weakness.PkmnTypeName}"
                });
            }
            
            //MessageBox.Show($"Type de la variable : {SelectedFirstType.Label.GetType()} - {SelectedSecondType.Label.GetType()}");
        }

        //Autres methodes
        public static List<PkmnType> GetSimpleResistances(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<PkmnType> simpleResistancesList = new List<PkmnType>();

            if(onePkmn.Type2 == null)
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    Pokemon pkmnTest = new Pokemon(allTypes[i]);
                    double effictiveness = pkmnTest.GetEffectiveness(onePkmn.Type1);
                    if(effictiveness < 1)
                    {
                        simpleResistancesList.Add(allTypes[i]);
                    } 
                    //MessageBox.Show($"Efficacite de {onePkmn.Type1.PkmnTypeName} sur {allTypes[i].PkmnTypeName} = {effictiveness}");
                    // Donne l'efficacite d'un type sur 1 pkmn
                }
            } else
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    Pokemon pkmnTest = new Pokemon(allTypes[i]);
                    double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                    double effictiveness2 = pkmnTest.GetEffectiveness(onePkmn.Type2);
                    double effictiveness;
                    if (effictiveness1 >= effictiveness2)
                    {
                        effictiveness = effictiveness1;
                    } else if(effictiveness1 < effictiveness2)
                    {
                        effictiveness = effictiveness2;
                    } else
                    {
                        effictiveness = effictiveness1;
                        MessageBox.Show($"Valeur 1 : {effictiveness1}, Valeur 2 : {effictiveness2}, Resultat : {effictiveness}");
                    }
                    if (effictiveness < 1)
                    {
                        simpleResistancesList.Add(allTypes[i]);
                    }
                    //MessageBox.Show($"Efficacite de {onePkmn.Type1.PkmnTypeName} / {onePkmn.Type2.PkmnTypeName} sur {allTypes[i].PkmnTypeName} = {effictiveness1}");
                    // Donne l'efficacite d'un type sur 1 pkmn
                }
            }

                return simpleResistancesList;
        }
        public static List<PkmnType> GetSimpleWeaknesses(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<PkmnType> simpleResistancesList = new List<PkmnType>();

            if (onePkmn.Type2 == null)
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    Pokemon pkmnTest = new Pokemon(allTypes[i]);
                    double effictiveness = pkmnTest.GetEffectiveness(onePkmn.Type1);
                    if (effictiveness > 1)
                    {
                        simpleResistancesList.Add(allTypes[i]);
                    }
                    //MessageBox.Show($"Efficacite de {onePkmn.Type1.PkmnTypeName} sur {allTypes[i].PkmnTypeName} = {effictiveness}");
                    // Donne l'efficacite d'un type sur 1 pkmn
                }
            }
            else
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    Pokemon pkmnTest = new Pokemon(allTypes[i]);
                    double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                    double effictiveness2 = pkmnTest.GetEffectiveness(onePkmn.Type2);
                    double effictiveness;
                    if (effictiveness1 == 0)
                    {
                        effictiveness = effictiveness2;
                    }
                    else if (effictiveness2 == 0)
                    {
                        effictiveness = effictiveness1;
                    }
                    else
                    {
                        effictiveness = effictiveness1 * effictiveness2;
                    }
                    if (effictiveness > 1)
                    {
                        simpleResistancesList.Add(allTypes[i]);
                    }
                    //MessageBox.Show($"Efficacite de {onePkmn.Type1.PkmnTypeName} / {onePkmn.Type2.PkmnTypeName} sur {allTypes[i].PkmnTypeName} = {effictiveness1}");
                    // Donne l'efficacite d'un type sur 1 pkmn
                }
            }

            return simpleResistancesList;
        }
        public class TypeDisplayItem
        {
            public string Name { get; set; }
        }
        /*
        public static List<PkmnType> ShowSimpleResistanceOnly(Pokemon onePkmn)
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
            List<PkmnType> resistanceList = new List<PkmnType>();
            Console.WriteLine($"Type a tester : {onePkmn.Type1.PkmnTypeName}");
            for (int i = 0; i < tab.Length; i++)
            {
                var type = tab[i];
                double weakness = onePkmn.Type1.GetEffectivenessAgainst(type);
                if (weakness == 0.5)
                {
                    resistanceList.Add(type);
                    //Console.WriteLine($"resistance spoted : {type.PkmnTypeName}");
                    MessageBox.Show($"resistance spoted : {type.PkmnTypeName}");
                }
            }

            return resistanceList;
        }

        public static List<PkmnType> ShowImmunityOnly(Pokemon onePkmn)
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
            List<PkmnType> immunityList = new List<PkmnType>();
            Console.WriteLine($"Type a tester : {onePkmn.Type1.PkmnTypeName}");
            for (int i = 0; i < tab.Length; i++)
            {
                var type = tab[i];
                double weakness = onePkmn.Type1.GetEffectivenessAgainst(type);
                if (weakness == 0.0)
                {
                    immunityList.Add(type);
                    MessageBox.Show($"Immunite spoted : {type.PkmnTypeName}");
                }
            }

            return immunityList;
        }

        public PkmnType[] GetAllTypeResistance(List<PkmnType> allResistance, List<PkmnType> allImmunity)
        {
            List<PkmnType> allResistancesList = new List<PkmnType>();
            if(allResistance != null)
            {
                for (int i = 0; i < allResistance.Count; i++)
                {
                    allResistancesList.Add(allResistance[i]);
                }
            }
            if (allImmunity != null)
            {
                for (int i = 0; i < allImmunity.Count; i++)
                {
                    allResistancesList.Add(allImmunity[i]);
                }
            }
            PkmnType[] tabTypes = allResistancesList.ToArray();
            return tabTypes;
        }
        */
    }
}
