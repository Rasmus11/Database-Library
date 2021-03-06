﻿using System;
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
using System.Windows.Shapes;

namespace Database_Libary
{
    /// <summary>
    /// Interaction logic for removeWarning.xaml
    /// </summary>
    public partial class removeWarning : Window
    {
        MySQL mysql = new MySQL();
        customMethods methods = new customMethods();

        int id = 0;
        string text = "";
        string title = "";
        string number = "";
        string secondTitle = "";
        string platform = "";

        public removeWarning(int id_game, string title_game, string number_game, string secondTitle_game, string platform_game)
        {
            InitializeComponent();

            if (number_game == "" && secondTitle_game == "")
            {
                text = title_game;
            }
            else if (number_game != "" && secondTitle_game == "")
            {
                text = title_game + " " + number_game;
            }
            else if (number_game == "" && secondTitle_game != "")
            {
                text = title_game + " - " + secondTitle_game;
            }
            else if (number_game != "" && secondTitle_game != "")
            {
                text = title_game + " " + number_game + " - " + secondTitle_game;
            }

            game.Content = text + " - " + platform_game;
            cancel.Focus();

            id = id_game;
            title = title_game;
            number = number_game;
            secondTitle = secondTitle_game;
            platform = platform_game;

            id_game = 0;
            title_game = "";
            number_game = "";
            secondTitle_game = "";
            platform_game = "";
        }

        private void removeGame_Click(object sender, RoutedEventArgs e)
        {
            if (methods.checkString(number, secondTitle))
            {
                MySQL.result_string = text;

                if (mysql.removeGame(id))
                {
                    this.Close();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
