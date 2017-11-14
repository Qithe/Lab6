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
            //Creates all employees and put em in to employe list
            //employeeList.Enqueue(new ServicePersonelClass(Adding));
            //employeeList.Enqueue(new BartenderClass((ushort)1));
            //employeeList.Enqueue(new BouncerClass((ushort)1));
            //Creates all chairs and put em it to chairlist
            chairs.GenerateChairs();

            //Creates all em jugs
            shelf.GenerateShelf();
            
        }
        public void StartSimulation()
        {
            CreateBar();
            BouncerClass bouncer = new BouncerClass(Adding);
            BartenderClass bartender = new BartenderClass(Adding);
            ServicePersonelClass waitress = new ServicePersonelClass(Adding);

            Task.Run(() => bouncer.BouncerControler());
            Task.Run(() => bartender.BartenderController());
            Task.Run(() => waitress.ServicePersonelController());
        }

        private void Button_StartStopDay_Click(object sender, RoutedEventArgs e)
        {
            StartSimulation();
        }

        

        public void Adding(int time, string element, int witchList)
        {
            if(witchList == 0) //OutsideQueue
            {
                if(ListBox_Patrons.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_Patrons.Items.Add($"{time}. {element} arrived outside the bar"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{time}. {element} arrived outside the bar"));
                } 
            }
            else if (witchList == 1) //BarQueue
            {
                if(ListBox_Bouncers.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_Bouncers.Items.Add($"{time}. Bouncer let in {element}"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_Bouncers.Items.Insert(0, $"{time}. Bouncer let in {element}"));
                }
                
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{time}. {element} went into the bar"));
            }
            else if (witchList == 2) //Drinking
            {
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{time}. {element} sat down to drink"));
            }
            else if(witchList == 3) //Washing Glass
            {
                if(ListBox_ServicePersonel.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_ServicePersonel.Items.Add($"{time}. The waitress washed jug nr {element}"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_ServicePersonel.Items.Insert(0, $"{time}. The waitress washed jug nr {element}"));
                }
            }
            else if(witchList == 4) //Close the bar
            {
                Dispatcher.Invoke(() => ListBox_Bouncers.Items.Insert(0, $"{time}. {element} closed the bar"));
            }
            else if(witchList == 5) //Go home
            {
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{time}. {element} went home"));
            }
            else if(witchList == 6) //Serve Drink
            {
                if(ListBox_Bartender.Items.Count == 0)
                {
                    Dispatcher.Invoke(() => ListBox_Bartender.Items.Add($"{time}. Bartender served {element} a beer"));
                }
                else
                {
                    Dispatcher.Invoke(() => ListBox_Bartender.Items.Insert(0, $"{time}. bartender served {element} a beer"));
                }
                Dispatcher.Invoke(() => ListBox_Patrons.Items.Insert(0, $"{time}. {element} got a beer"));
                
            }
            //Action startSP = ServicePersonelController;
        }

        private void Button_RestartDay_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Slider_TimeModifyer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (haveLodedUi != false)
            {
                double modifier = Slider_TimeModifyer.Value;
                Lable_TimeModifyer.Content = modifier + ".0x";
            }
            
            
        }

        private void Button_StartStopDay_Click(object sender, RoutedEventArgs e)
        {
            Slider_TimeModifyer.IsEnabled ^= true;
        }
    }
}
