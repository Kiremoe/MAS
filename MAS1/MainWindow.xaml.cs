using MAS2.GamePieces;
using MAS2.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAS2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Zone> _allZones = new List<Zone>();
        private List<Zone> _selectedZones = new List<Zone>();
        private List<Enemy> _selectedEnemies = new List<Enemy>();
        private List<NPC> _selectedNPCs = new List<NPC>();
        private List<Player> _selectedPlayers = new List<Player>();
        private GameMaster _gameMaster;

        public MainWindow()
        {
            GeneralFunctions.InitailSetup();
            InitializeComponent();
            _gameMaster = GeneralFunctions.GetGameMaster();
            _allZones = GeneralFunctions.GetZones();
            ZoneListBox.ItemsSource = _allZones;
            EnemyListBox.ItemsSource = new List<Enemy>();
            NPCListBox.ItemsSource = new List<NPC>();
            PlayerListBox.ItemsSource = new List<Player>();
            
        }

        private void ZoneListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedZones.Clear();
            foreach (object element in ZoneListBox.SelectedItems)
            {
                _selectedZones.Add((Zone)element);
            }
            EnemyListBox.ItemsSource = GeneralFunctions.GetEnemies(_selectedZones);
            NPCListBox.ItemsSource = GeneralFunctions.GetNPCs(_selectedZones);
            PlayerListBox.ItemsSource = GeneralFunctions.GetPlayers(_selectedZones);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _selectedZones.Clear();
            foreach (object element in ZoneListBox.SelectedItems)
            {
                _selectedZones.Add((Zone)element);
            }

            foreach (object element in EnemyListBox.SelectedItems)
            {
                _selectedEnemies.Add((Enemy)element);
            }

            foreach (object element in NPCListBox.SelectedItems)
            {
                _selectedNPCs.Add((NPC)element);
            }

            foreach (object element in PlayerListBox.SelectedItems)
            {
                _selectedPlayers.Add((Player)element);
            }
            GeneralFunctions.Submit(_gameMaster,_selectedZones, _selectedPlayers, _selectedEnemies, _selectedNPCs);
            MessageBox.Show("Done");
            Application.Current.Shutdown();
        }
    }
}
