using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public delegate void AgentPauser(List<AgentClass> agentList, bool paused);
    

    public partial class MainWindow : Window
    {
        ConcurrentQueue<ChairClass> chairList = new ConcurrentQueue<ChairClass>();
        ConcurrentQueue<AgentClass> employeeList = new ConcurrentQueue<AgentClass>();
        ShelfClass shelf = new ShelfClass();
        ChairClass chairs = new ChairClass();
        Random rnd = new Random();
        public Stopwatch Time = new Stopwatch();
        int scenario;
        AgentPauser agentPauser = new AgentPauser(AgentStateChanger);

        bool haveLodedUi = false;

        public MainWindow()
        {
            InitializeComponent();
            haveLodedUi = true;


        }

        public static void AgentStateChanger(List<AgentClass> agentList, bool paused)
        {
            foreach (AgentClass A in agentList)
            {
                if (paused)
                {
                    //PUT DAT MOFO TO SLEEP
                }
                else if (!paused)
                {
                    //WAKE EM UP!
                }
            }
            
        }

        public void CreateBar()
        {
            //Creates all chairs and put em it to chairlist
            chairs.GenerateChairs();
            //Creates all em jugs
            shelf.GenerateShelf();
        }

        public void StartSimulation()
        {
            if (scenario == 1)
            {

            }
            else if(scenario == 2)
            {
                ShelfClass.ShelfSize = 20;
                ChairClass.NumbOfChairs = 3;
            }
            else if(scenario == 3)
            {
                ShelfClass.ShelfSize = 5;
                ChairClass.NumbOfChairs = 20;
            }
            else if(scenario == 4)
            {
                
            }
            else if(scenario == 5)
            {

            }
            else if(scenario == 6)
            {
                AgentClass.OpenTime = 300;
            }
            else if(scenario == 7)
            {
                BouncerClass.couplesNight = true;
            }
            else if(scenario == 8)
            {

            }
            CreateBar();
            Time.Start();
            BouncerClass bouncer = new BouncerClass(Adding);
            BartenderClass bartender = new BartenderClass(Adding);
            ServicePersonelClass waitress = new ServicePersonelClass(Adding);

            Task.Run(() => bouncer.BouncerControler());
            Task.Run(() => bartender.BartenderController());
            Task.Run(() => waitress.ServicePersonelController());
        }

        private void Button_StartStopDay_Click(object sender, RoutedEventArgs e)
        {
            Slider_TimeModifyer.IsEnabled ^= true;
            StartSimulation();
        }

        

        public void Adding(string element, int witchList)
        {
            int now = (int)Time.Elapsed.TotalSeconds;
            if(witchList == 0) //OutsideQueue
            {
                if(ListBox_Patrons.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_Patrons.Items.Add($"{now}. {element} arrived outside the bar"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{now}. {element} arrived outside the bar"));
                } 
            }
            else if (witchList == 1) //BarQueue
            {
                if(ListBox_Bouncers.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_Bouncers.Items.Add($"{now}. Bouncer let in {element}"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_Bouncers.Items.Insert(0, $"{now}. Bouncer let in {element}"));
                }
                
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{now}. {element} went into the bar"));
            }
            else if (witchList == 2) //Drinking
            {
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{now}. {element} sat down to drink"));
            }
            else if(witchList == 3) //Washing Glass
            {
                Dispatcher.Invoke(() => ListBox_ServicePersonel.Items.Insert(0, $"{now}. The waitress washed jug nr {element}"));
            }
            else if(witchList == 4) //Close the bar
            {
                Dispatcher.Invoke(() => ListBox_Bouncers.Items.Insert(0, $"{now}. {element} closed the bar"));
            }
            else if(witchList == 5) //Go home
            {
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{now}. {element} went home"));
            }
            else if(witchList == 6) //Serve Drink
            {
                if(ListBox_Bartender.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_Bartender.Items.Add($"{now}. Bartender served {element} a beer"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_Bartender.Items.Insert(0, $"{now}. bartender served {element} a beer"));
                }
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{now}. {element} got a beer"));
                
            }
            else if(witchList == 7)
            {
                if(ListBox_ServicePersonel.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_ServicePersonel.Items.Add($"{now}. The waitress picked up {element} jugs"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_ServicePersonel.Items.Insert(0, $"{now}. The waitress picked up {element} jugs"));
                }
            }
        }

        private void Button_RestartDay_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Slider_TimeModifyer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (haveLodedUi != false)
            {
                int modifier = (int)Slider_TimeModifyer.Value;
                AgentClass.sek = 1000 / modifier;
                Lable_TimeModifyer.Content = modifier + ".0x";
            }
            
            
        }

        private void ComboBox_ScenarioSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scenario = ComboBox_SenarioSelection.SelectedIndex;
        }
    }
}
