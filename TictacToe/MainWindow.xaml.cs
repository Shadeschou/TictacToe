using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TictacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private variables
        private KrydsEllerBolle[] resultater;
        private bool isPlayer1turn;
        private bool HasEnded;
        private GameSystems gameSystems;
        
        public GameSystems GameSystems
        {
            get { return gameSystems; }
            set { gameSystems = value; }
        }

        public Player newPlayer1;
        public Player NewPlayer1
        {
            get { return newPlayer1; }
            set { newPlayer1 = value; }
        }
        
        public Player newPlayer2;

        public Player NewPlayer2
        {
            get { return newPlayer2; }
            set { newPlayer2 = value; }
        }

        #endregion

        #region Constructor
        public MainWindow()
        {
            gameSystems = new GameSystems();
            newPlayer1 = new Player();
            newPlayer2 = new Player();
            InitializeComponent();
            NewGame();
            
        }

        #endregion
        #region game controls
        private void NewGame()
        {
            resultater = new KrydsEllerBolle[9];
            for (int i = 0; i < resultater.Length; i++)
            {
                resultater[i] = KrydsEllerBolle.intet;
            }
            isPlayer1turn = true;
            fieldsContainer.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                Button.Content = string.Empty;
                Button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#373737"));
                Button.Foreground = Brushes.Blue;
            });

            HasEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HasEnded)
            {
                NewGame();
                return;
            }
            Button button = (Button)sender;
            int index = Grid.GetColumn(button) + (Grid.GetRow(button) * 3);
            if (resultater[index] != KrydsEllerBolle.intet)
            {
                return;
            }
            resultater[index] = isPlayer1turn ? KrydsEllerBolle.kryds : KrydsEllerBolle.Bolle;
            button.Content = isPlayer1turn ? "X" : "O";
            gameSystems.CurrentTurn = isPlayer1turn ? newPlayer1.Name : newPlayer2.Name;
            if (!isPlayer1turn)
            {
                button.Foreground = Brushes.Purple;
            }
            isPlayer1turn ^= true;

            checkforWinner();
        }
        #endregion
        #region helper methods
        private void checkforWinner()
        {
            if (resultater[0] != KrydsEllerBolle.intet && (resultater[0] & resultater[1] & resultater[2]) == resultater[0])
            {
                GameOver(Button0_0,Button1_0,Button2_0);
            } else if (resultater[3] != KrydsEllerBolle.intet && (resultater[3] & resultater[4] & resultater[5]) == resultater[3])
            {
                GameOver(Button0_1,Button1_1,Button2_1);
            } else if (resultater[6] != KrydsEllerBolle.intet && (resultater[6] & resultater[7] & resultater[8]) == resultater[6])
            {
                GameOver(Button0_2,Button1_2, Button2_2);
            } else if (resultater[0] != KrydsEllerBolle.intet && (resultater[0] & resultater[3] & resultater[6]) == resultater[0])
            {
                GameOver(Button0_0,Button0_1,Button0_2);
            } else if(resultater[1] != KrydsEllerBolle.intet && (resultater[1] & resultater[4] & resultater[7]) == resultater[1])
            {
                GameOver(Button1_0,Button1_1,Button1_2);
            } else if (resultater[2] != KrydsEllerBolle.intet && (resultater[2] & resultater[5] & resultater[8]) == resultater[2])
            {
                GameOver(Button2_0, Button2_1, Button2_2);
            } else if (resultater[0] != KrydsEllerBolle.intet && (resultater[0] & resultater[4] & resultater[8]) == resultater[0])
            {
                GameOver(Button0_0, Button1_1, Button2_2);
            } else if (resultater[2] != KrydsEllerBolle.intet && (resultater[2] & resultater[4] & resultater[6]) == resultater[2])
            {
                GameOver(Button2_0, Button1_1, Button0_2);
            } else if (!resultater.Any(f => f == KrydsEllerBolle.intet))
                {
                    HasEnded = true;
                    fieldsContainer.Children.Cast<Button>().ToList().ForEach(button =>
                    {
                        button.Background = Brushes.Orange;

                    });
                    MessageBox.Show("DRAW!");

                }
        }



        private void GameOver(Button button1, Button button2, Button button3)
        {
            HasEnded = true;
            button1.Background = button2.Background = button3.Background = Brushes.Green;
            if (isPlayer1turn)
            {
                MessageBox.Show("WINNER WINNER CHICKEN DINNER " + newPlayer2.Name + " has won");
            }
            else
            {
                MessageBox.Show("WINNER WINNER CHICKEN DINNER " + newPlayer1.Name + " has won");
            }
            
        }
        #endregion
    }
}
