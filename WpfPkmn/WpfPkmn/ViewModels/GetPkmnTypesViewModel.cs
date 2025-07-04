using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Pkmn.Models;
using WpfPkmn.Views;
using static WpfPkmn.ViewModels.MainViewModel;

namespace WpfPkmn.ViewModels
{
    public class GetPkmnTypesViewModel : ViewModelBase
    {
        //Champs
        private OptionItem _selectedFirstType;
        private OptionItem _selectedSecondType;
        private int _account;
        private RelayCommand _openShowTeamsWeaknessesCommand;

        public ObservableCollection<OptionItem> FirstType { get; set; }
        public ObservableCollection<OptionItem> SecondType { get; set; }

        public ObservableCollection<TypeDisplayItem> FirstTypeWeakTypes { get; set; }
        public ObservableCollection<TypeDisplayItem> FirstTypeResistingTypes { get; set; }
        public ObservableCollection<TypeDisplayItem> DefensiveWeakTypesList { get; set; }
        public ObservableCollection<TypeDisplayItem> DefensiveResistingTypesList { get; set; }
        public ObservableCollection<TypeDisplayItem> ResistingDoubleTypes { get; set; }
        public ObservableCollection<TypeDisplayItem> WeakDoubleTypes { get; set; }

        //Proprietes
        public OptionItem SelectedFirstType
        {
            get => _selectedFirstType;
            set
            {
                _selectedFirstType = value;
                OnPropertyChanged(nameof(SelectedFirstType));
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

        public int Account
        {
            get => _account;
            set
            {
                if (_account != value)
                {
                    _account = value;
                    OnPropertyChanged(nameof(Account));
                }
            }
        }

        //Commandes
        public ICommand ExecuteDisplayFirstType { get; }
        public ICommand ExecuteDisplayPkmnResistances { get; }
        public ICommand OpenShowTeamsWeaknessesCommand { get; }

        //Constructeur
        public GetPkmnTypesViewModel()
        {
            FirstType = new ObservableCollection<OptionItem>();
            SecondType = new ObservableCollection<OptionItem>();
            DefensiveWeakTypesList = new ObservableCollection<TypeDisplayItem>();
            DefensiveResistingTypesList = new ObservableCollection<TypeDisplayItem>();
            ResistingDoubleTypes = new ObservableCollection<TypeDisplayItem>();
            WeakDoubleTypes = new ObservableCollection<TypeDisplayItem>();
            FirstTypeWeakTypes = new ObservableCollection<TypeDisplayItem>();
            FirstTypeResistingTypes = new ObservableCollection<TypeDisplayItem>();
            Account = 0;
            ExecuteDisplayFirstType = new ViewModelCommand(ExecuteDisplayFirstTypeAction, CanExecuteDisplayFirstTypeAction);
            ExecuteDisplayPkmnResistances = new ViewModelCommand(ExecuteDisplayPkmnResistancesAction, CanExecuteDisplayPkmnResistancesAction);
            _openShowTeamsWeaknessesCommand = new RelayCommand(OpenShowWeaknesses);
            OpenShowTeamsWeaknessesCommand = _openShowTeamsWeaknessesCommand;
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
            FirstTypeWeakTypes.Clear();
            FirstTypeResistingTypes.Clear();
            /*
            if (SelectedSecondType == null)
            {
                //MessageBox.Show($"Type choisit : {SelectedFirstType.Label}");
                Pokemon pkmn1 = new Pokemon(SelectedFirstType.Value);
                var weaksForTypeOne = GetFirstTypeEffictivityVsAllType(pkmn1);
                var resistanceForTypeOne = GetFirstTypeNoneffictivityVsAllType(pkmn1);
                foreach (var weak in weaksForTypeOne)
                {
                    FirstTypeWeakTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{weak.PkmnTypeName}"
                    });
                }
                foreach (var resistance in resistanceForTypeOne)
                {
                    FirstTypeResistingTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{resistance.PkmnTypeName}"
                    });
                }
            }
            else if(SelectedFirstType == null)
            {
                SelectedFirstType = SelectedSecondType;
                //MessageBox.Show($"Type choisit : {SelectedFirstType.Label}");
                Pokemon pkmn1 = new Pokemon(SelectedFirstType.Value);
                var weaksForTypeOne = GetFirstTypeEffictivityVsAllType(pkmn1);
                var resistanceForTypeOne = GetFirstTypeNoneffictivityVsAllType(pkmn1);
                foreach (var weak in weaksForTypeOne)
                {
                    FirstTypeWeakTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{weak.PkmnTypeName}"
                    });
                }
                foreach (var resistance in resistanceForTypeOne)
                {
                    FirstTypeResistingTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{resistance.PkmnTypeName}"
                    });
                }
            } else
            {
                //MessageBox.Show($"Double type choisit : {SelectedFirstType.Label} - {SelectedSecondType.Label}");
                Pokemon pkmn1 = new Pokemon(SelectedFirstType.Value);
                Pokemon pkmn2 = new Pokemon(SelectedSecondType.Value);
                var weaksForTypeOne = GetFirstTypeEffictivityVsAllType(pkmn1);
                var weaksForTypeTwo = GetFirstTypeEffictivityVsAllType(pkmn2);
                var resistanceForTypeOne = GetFirstTypeNoneffictivityVsAllType(pkmn1);
                var resistanceForTypeTwo = GetFirstTypeNoneffictivityVsAllType(pkmn2);
                //var resistanceForTypeOne = FiltrerTypeFaiblesEtResistant(weaksForTypeTwo, GetFirstTypeNoneffictivityVsAllType(pkmn1));
                //var resistanceForTypeTwo = FiltrerTypeFaiblesEtResistant(weaksForTypeOne, GetFirstTypeNoneffictivityVsAllType(pkmn2));
                foreach (var weak in weaksForTypeOne)
                {
                    FirstTypeWeakTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{weak.PkmnTypeName}"
                    });
                }
                foreach (var weak in weaksForTypeTwo)
                {
                    FirstTypeWeakTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{weak.PkmnTypeName}"
                    });
                }
                foreach (var resistance in resistanceForTypeOne)
                {
                    FirstTypeResistingTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{resistance.PkmnTypeName}"
                    });
                }
                foreach (var resistance in resistanceForTypeTwo)
                {
                    FirstTypeResistingTypes.Add(new TypeDisplayItem
                    {
                        Name = $"{resistance.PkmnTypeName}"
                    });
                }
                
            }*/
        }
        
        public static List<PkmnType> GetAllPkmnOffensiveTypeEffictivityVsAllType(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<PkmnType> allWeakTypes = new List<PkmnType>();
            var firstType = onePkmn.Type1;
            var secondType = onePkmn.Type2;
            if(secondType == null)
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    double effectivenessScoreVsOneType = firstType.GetEffectivenessAgainst(allTypes[i]);
                    if (effectivenessScoreVsOneType > 1)
                    {
                        allWeakTypes.Add(allTypes[i]);
                    }
                }
            } else
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    double effectivenessScoreVsOneType = firstType.GetEffectivenessAgainst(allTypes[i]);
                    if (effectivenessScoreVsOneType > 1)
                    {
                        allWeakTypes.Add(allTypes[i]);
                    }
                }
                for (int i = 0; i < allTypes.Count; i++)
                {
                    double effectivenessScoreVsOneType = secondType.GetEffectivenessAgainst(allTypes[i]);
                    if (effectivenessScoreVsOneType > 1)
                    {
                        allWeakTypes.Add(allTypes[i]);
                    }
                }
            }

            return allWeakTypes.Distinct().ToList();
        }
        public static List<PkmnType> GetAllPkmnOffensiveTypeNoneEffictivityVsAllType(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<PkmnType> allWeakTypes = new List<PkmnType>();
            var firstType = onePkmn.Type1;
            var secondType = onePkmn.Type2;

            if (secondType == null)
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    double effectivenessScoreVsOneType = firstType.GetEffectivenessAgainst(allTypes[i]);
                    if (effectivenessScoreVsOneType < 1)
                    {
                        allWeakTypes.Add(allTypes[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < allTypes.Count; i++)
                {
                    double effectivenessScoreVsTypeOne = firstType.GetEffectivenessAgainst(allTypes[i]);
                    double effectivenessScoreVsTypeTwo = secondType.GetEffectivenessAgainst(allTypes[i]);
                    if (effectivenessScoreVsTypeOne < 1 && effectivenessScoreVsTypeTwo < 1)
                    {
                        allWeakTypes.Add(allTypes[i]);
                    }
                }
            }

            return allWeakTypes;
        }
        public static List<PkmnType> GetFirstTypeNoneffictivityVsAllType(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<PkmnType> allWeakTypes = new List<PkmnType>();
            var firstType = onePkmn.Type1;

            for (int i = 0; i < allTypes.Count; i++)
            {
                double effectivenessScoreVsOneType = firstType.GetEffectivenessAgainst(allTypes[i]);
                if (effectivenessScoreVsOneType < 1)
                {
                    allWeakTypes.Add(allTypes[i]);
                }
            }

            return allWeakTypes;
        }

        //Bouton qui affiche les simples types qui sont faibles et resistants a un type/double type donné
        private bool CanExecuteDisplayPkmnResistancesAction(object obj)
        {
            return (SelectedFirstType != null);
        }

        private void ExecuteDisplayPkmnResistancesAction(object obj)
        {
            DefensiveWeakTypesList.Clear();
            DefensiveResistingTypesList.Clear();
            ResistingDoubleTypes.Clear();
            WeakDoubleTypes.Clear();
            Account = 0;

            Pokemon myPkmn;

            if (SelectedSecondType == null || SelectedSecondType.Label == "Aucun")
            {
                myPkmn = new Pokemon(SelectedFirstType.Value);
            }
            else if (SelectedFirstType.Value == SelectedSecondType.Value)
            {
                myPkmn = new Pokemon(SelectedFirstType.Value);
            } else
            {
                myPkmn = new Pokemon(SelectedFirstType.Value, SelectedSecondType.Value);
            }
            var allWeaksForPkmn = GetAllPkmnOffensiveTypeEffictivityVsAllType(myPkmn);
            var allResistanceForPkmn = GetAllPkmnOffensiveTypeNoneEffictivityVsAllType(myPkmn);
            var allDoubleResistingTypes = GetAllResistingDoubleTypes(myPkmn);
            var allDoubleWeakTypes = GetAllWeakDoubleTypes(myPkmn);

            foreach (var weakness in allWeaksForPkmn)
            {
                DefensiveWeakTypesList.Add(new TypeDisplayItem
                {
                    Name = $"{weakness.PkmnTypeName}"
                });
            }
            if(allResistanceForPkmn.Count > 0)
            {
                foreach (var resistance in allResistanceForPkmn)
                {
                    DefensiveResistingTypesList.Add(new TypeDisplayItem
                    {
                        Name = $"{resistance.PkmnTypeName}"
                    });
                }
            } else
            {
                DefensiveResistingTypesList.Add(new TypeDisplayItem
                {
                    Name = $"Rien"
                });
            }
            /*
            foreach (var resistance in allResistanceForPkmn)
            {
                DefensiveResistingTypesList.Add(new TypeDisplayItem
                {
                    Name = $"{resistance.PkmnTypeName}"
                });
            }
            */
            foreach (var doubleResistingType in allDoubleResistingTypes)
            {
                ResistingDoubleTypes.Add(new TypeDisplayItem
                {
                    Name = $"{doubleResistingType.Type1.PkmnTypeName} / {doubleResistingType.Type2.PkmnTypeName}"
                });
            }
            foreach(var doubleWeaknessType in allDoubleWeakTypes)
            {
                WeakDoubleTypes.Add(new TypeDisplayItem
                {
                    Name = $"{doubleWeaknessType.Type1.PkmnTypeName} / {doubleWeaknessType.Type2.PkmnTypeName}"
                });
            }

            /*
            Account = doubleResistingTypes.Count;
            */
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
            //Pokemon sousPkmn = new Pokemon(onePkmn.Type1);

            if (onePkmn.Type2 == null)
            {
                //var weaksForTypeOne = GetFirstTypeEffictivityVsAllType(onePkmn.Type1);
                /*
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
                */
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
        public static List<Pokemon> GetAllResistingDoubleTypes(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<Pokemon> allDoubleTypeResistancesList = new List<Pokemon>();
            Pokemon pkmnTest;
            //MessageBox.Show($"Test : {allTypes[13].PkmnTypeName}, {allTypes[17].PkmnTypeName}");
            for (int i = 0; i < allTypes.Count; i++)
            {
                for (int j = i + 1; j < allTypes.Count; j++)
                {
                    if(allTypes[i] != allTypes[j])
                    {
                        pkmnTest = new Pokemon(allTypes[i], allTypes[j]);
                        if (onePkmn.Type2 != null)
                        {
                            double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                            double effictiveness2 = pkmnTest.GetEffectiveness(onePkmn.Type2);
                            //MessageBox.Show($"Resultat de {onePkmn.Type1.PkmnTypeName} / {onePkmn.Type2.PkmnTypeName} : {effictiveness1}, {effictiveness2}");
                            if (effictiveness1 < 1 && effictiveness2 < 1)
                            {
                                allDoubleTypeResistancesList.Add(pkmnTest);
                            }
                        } else
                        {
                            double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                            if (effictiveness1 < 1)
                            {
                                allDoubleTypeResistancesList.Add(pkmnTest);
                            }
                        }
                    }
                }
            }
            
            /*
            if(onePkmn.Type2 != null)
            {
                double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                double effictiveness2 = pkmnTest.GetEffectiveness(onePkmn.Type2);
                MessageBox.Show($"Resultat de {onePkmn.Type1.PkmnTypeName} / {onePkmn.Type2.PkmnTypeName} : {effictiveness1}, {effictiveness2}");
                if(effictiveness1 < 1 && effictiveness2 < 1 )
                {
                    allDoubleTypeResistancesList.Add(pkmnTest);
                }
            }*/


            return allDoubleTypeResistancesList;
        }
        public static List<Pokemon> GetAllWeakDoubleTypes(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<Pokemon> allDoubleTypeWeaknessesList = new List<Pokemon>();
            Pokemon pkmnTest;
            //MessageBox.Show($"Test : {allTypes[13].PkmnTypeName}, {allTypes[17].PkmnTypeName}");
            for (int i = 0; i < allTypes.Count; i++)
            {
                for (int j = i + 1; j < allTypes.Count; j++)
                {
                    if (allTypes[i] != allTypes[j])
                    {
                        pkmnTest = new Pokemon(allTypes[i], allTypes[j]);
                        if (onePkmn.Type2 != null)
                        {
                            double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                            double effictiveness2 = pkmnTest.GetEffectiveness(onePkmn.Type2);
                            //MessageBox.Show($"{onePkmn.Type1.PkmnTypeName} contre {allTypes[i].PkmnTypeName}/{allTypes[j].PkmnTypeName} = {effictiveness1} et {onePkmn.Type2.PkmnTypeName} contre {allTypes[i].PkmnTypeName}/{allTypes[j].PkmnTypeName} = {effictiveness2}");
                            if (effictiveness1 > 1 || effictiveness2 > 1)
                            {
                                allDoubleTypeWeaknessesList.Add(pkmnTest);
                            }
                        } else
                        {
                            double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                            if (effictiveness1 > 1)
                            {
                                allDoubleTypeWeaknessesList.Add(pkmnTest);
                            }
                        }
                    }
                }
            }

            /*
            if(onePkmn.Type2 != null)
            {
                double effictiveness1 = pkmnTest.GetEffectiveness(onePkmn.Type1);
                double effictiveness2 = pkmnTest.GetEffectiveness(onePkmn.Type2);
                MessageBox.Show($"Resultat de {onePkmn.Type1.PkmnTypeName} / {onePkmn.Type2.PkmnTypeName} : {effictiveness1}, {effictiveness2}");
                if(effictiveness1 < 1 && effictiveness2 < 1 )
                {
                    allDoubleTypeResistancesList.Add(pkmnTest);
                }
            }*/


            return allDoubleTypeWeaknessesList;
        }
        public class TypeDisplayItem
        {
            public string Name { get; set; }
        }
        private void OpenShowWeaknesses()
        {
            var window = new ShowWeaknessesView();
            window.Show();
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
        public static List<Pokemon> FilterDuplicate(List<Pokemon> allDoubleTypes)
        {
            var filteredList = new List<Pokemon>(allDoubleTypes);
            for (int i = 0; i < allDoubleTypes.Count; i++)
            {
                for (int j = filteredList.Count - 1; j >= 0; j--)
                {
                    if (allDoubleTypes[i].Type1 == filteredList[j].Type2)
                    {
                        filteredList.RemoveAt(j);
                    }
                }
            }

            return filteredList;
        }
        public static List<PkmnType> GetFirstTypeEffictivityVsAllType(Pokemon onePkmn)
        {
            var allTypes = GetAllTypes();
            List<PkmnType> allWeakTypes = new List<PkmnType>();
            var firstType = onePkmn.Type1;

            for (int i = 0; i < allTypes.Count; i++)
            {
                double effectivenessScoreVsOneType = firstType.GetEffectivenessAgainst(allTypes[i]);
                if(effectivenessScoreVsOneType > 1)
                {
                    allWeakTypes.Add(allTypes[i]);
                }
            }

            return allWeakTypes;
        }
        public static List<PkmnType> FiltrerTypeFaiblesEtResistant(List<PkmnType> weaknessList, List<PkmnType> resistanceList)
        {
            //MessageBox.Show("On rentre ?");
            List<PkmnType> allFiltredResistingTypeList = new List<PkmnType>();
            int foundType = 0;
            
            if (resistanceList == null || weaknessList == null)
            {
                //MessageBox.Show("Vide ?");
                return allFiltredResistingTypeList;
            }
            else
            {
                MessageBox.Show($"{resistanceList.Count}");
                for (int i = 0; i < resistanceList.Count; i++)
                {
                    //MessageBox.Show($"{i}");
                    for(int j = 0; j < weaknessList.Count; j++)
                    {
                        if (resistanceList[i].PkmnTypeName == weaknessList[j].PkmnTypeName)
                        {
                            foundType = 1;
                        }
                        MessageBox.Show($"Type faible : {weaknessList[j].ToString}, Type resistant : {resistanceList[i].ToString} =>{foundType}");
                    }
                    /*
                    if(foundType == 0)
                    {
                        allFiltredResistingTypeList.Add(resistanceList[i]);
                    }
                    
                    foundType = 0;
                }
            }
            return allFiltredResistingTypeList;
        }
        */
    }
}
