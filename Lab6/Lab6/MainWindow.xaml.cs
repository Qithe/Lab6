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
    

    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        Stopwatch Time = new Stopwatch();
        int scenario;
        bool haveLodedUi = false;

        public MainWindow()
        {
            InitializeComponent();
            haveLodedUi = true;
        }

        public void CreateBar()
        {
            //Creates all chairs and put em it to chairlist
            ChairClass.GenerateChairs();
            //Creates all em jugs
            ShelfClass.GenerateShelf();
        }

        public void StartSimulation()
        {
            if(scenario == 2)
            {
                ShelfClass.ShelfSize = 20;
                ChairClass.NumbOfChairs = 3;
                TextBox_ChairsInBar.Text = $"{ChairClass.NumbOfChairs}";
            }
            else if(scenario == 3)
            {
                ShelfClass.ShelfSize = 5;
                ChairClass.NumbOfChairs = 20;
                TextBox_ChairsInBar.Text = $"{ChairClass.NumbOfChairs}";
            }
            else if(scenario == 4)
            {
                PatronClass.PatronSpeed = 2;
            }
            else if(scenario == 5)
            {
                ServicePersonelClass.ServiceSpeed = 2;
            }
            else if(scenario == 6)
            {
                AgentClass.OpenTime = 300;
                TextBox_TimeBarIsOpen.Text = $"{AgentClass.OpenTime}";
            }
            else if(scenario == 7)
            {
                BouncerClass.couplesNight = true;
            }
            else if(scenario == 8)
            {
                BouncerClass.groupNight = true;
                BouncerClass.BouncerSpeed = 2;
            }
            CreateBar();
            Time.Start();
            BouncerClass bouncer = new BouncerClass(Adding, ChangeQueue);
            BartenderClass bartender = new BartenderClass(Adding, ChangeQueue);
            ServicePersonelClass waitress = new ServicePersonelClass(Adding, ChangeQueue);

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
            else if(witchList == 7) //Pick up jugs
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
            else if(witchList == 8) //Bartender go home
            {
                Dispatcher.Invoke(() => ListBox_Bartender.Items.Insert(0, $"{now}. The {element} went home"));
            }
        }

        private void Slider_TimeModifyer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (haveLodedUi)
            {
                int modifier = (int)Slider_TimeModifyer.Value;
                AgentClass.sek = 1000 / modifier;
                Lable_TimeModifyer.Content = modifier + ".0x";
            }
        }

        private void ComboBox_ScenarioSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scenario = ComboBox_SenarioSelection.SelectedIndex;
            if (haveLodedUi)
            {
                switch (scenario)
                {
                    case (0):
                        Textbox_SenarioDescription.Text = "Standardvärden på allt";
                        break;
                    case (1):
                        Textbox_SenarioDescription.Text = "Det finns 20 glas, men bara 3 stolar";
                        break;
                    case (2):
                        Textbox_SenarioDescription.Text = "Det finns 20 stolar, men bara 5 glas";
                        break;
                    case (3):
                        Textbox_SenarioDescription.Text = "Gästerna stannar dubbelt så länge";
                        break;
                    case (4):
                        Textbox_SenarioDescription.Text = "Servitrisen plockar glas och diskar dubbelt så fort";
                        break;
                    case (5):
                        Textbox_SenarioDescription.Text = "Baren är öppen i 5 minuter (5*60 = 300 sekunder)";
                        break;
                    case (6):
                        Textbox_SenarioDescription.Text = "Couples night - inkastaren släpper in två gäster varje gång i stället för en";
                        break;
                    case (7):
                        Textbox_SenarioDescription.Text = "Det tar dubbelt så lång tid mellan det att inkastaren släpper in gäster, men efter de första 20 sekunderna släpper hen in en busslast på 15 gäster på samma gång som en engångshändelse";
                        break;
                }
            }
        }

        public void ChangeQueue(int queueSize, int wichLabel)
        {
            if(wichLabel == 1)
            {
                Dispatcher.Invoke(() => Label_AllPatrionsInBar.Content = $"Total amount of Patrons in bar: {queueSize}");
            }
            else if(wichLabel == 2)
            {
                Dispatcher.Invoke(() => Label_PatronsInEntrenceQueue.Content = $"Patrons in entrance queue: {queueSize}");
            }
            else if(wichLabel == 3)
            {
                Dispatcher.Invoke(() => Label_PatronsInBarQueue.Content = $"Patrons waiting for a beer: {queueSize}");
            }
            else if(wichLabel == 4)
            {
                Dispatcher.Invoke(() => Label_PatronsInChairQueue.Content = $"Patrons waiting for a free chair: {queueSize}");
            }
            else if(wichLabel == 5)
            {
                Dispatcher.Invoke(() => Lable_ServedPatrions.Content = $"Served patrons: {queueSize}");
            }
        }
    }
}
