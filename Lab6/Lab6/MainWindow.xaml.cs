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

    

    public partial class MainWindow : Window
    {
        //ConcurrentQueue<ChairClass> chairList = new ConcurrentQueue<ChairClass>();
        //ConcurrentQueue<AgentClass> employeeList = new ConcurrentQueue<AgentClass>();
        //ShelfClass shelf = new ShelfClass();
        
        
        Random rnd = new Random();


        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateBar()
        {
            //Creates all employees and put em in to employe list
            
            //Creates all chairs and put em it to chairlist
            for (int i = 0; i < 9; i++)
            {
                //chairList.Enqueue(new ChairClass((ushort)i));
            }
            
            //Creates all em jugs
            for (int i = 0; i < 8; i++)
            {
                //shelf.ItemList.Enqueue(new BeerJugClass((ushort)i));
            }
            
        }
        public void StartSimulation()
        {
            BouncerClass bouncer = new BouncerClass(Adding);
            Task.Run(() => bouncer.BouncerControler());
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
            else if (witchList == 2) //ChairQueue
            {

            }
            else if(witchList == 3) //Washing Glass
            {

            }
        }
    }
}
