using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
using System.Threading.Tasks;

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
            employeeList.Enqueue(new ServicePersonelClass((ushort)1));
            //employeeList.Enqueue(new BartenderClass((ushort)1));
            //employeeList.Enqueue(new BouncerClass((ushort)1));
            //Creates all chairs and put em it to chairlist
            for (int i = 0; i < 9; i++)
            {
                chairList.Enqueue(new ChairClass((ushort)i));
            }
            
            //Creates all em jugs
            for (int i = 0; i < 8; i++)
            {
                shelf.ItemList.Enqueue(new BeerJugClass((ushort)i));
            }
            
        }
        public void StartSimulation()
        {
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

        private void RadioButton_Patrons_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Patrons_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
