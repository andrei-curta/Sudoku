using Caliburn.Micro;
using Sudoku.Models;
using Sudoku.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace Sudoku.ViewModels
{
    class SudokuBoardViewModel : Conductor<object>
    {
        public ObservableCollection<ObservableCollection<CellModel>> Elements { get; set; }
        private int _size;
        private IWindowManager windowManager;
        private BoardModel board;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int delay = 50;
        private DateTime deadline;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int secondsRemaining = (deadline - DateTime.Now).Seconds;
            if (secondsRemaining == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.IsEnabled = false;
                MessageBox.Show("Time has expired!");
                CheckBoard();
                delay = 20;
            }
            else
            {
                //label1.Content = secondsRemaining.ToString();
            }
        }

        private void StartTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //se seteaza momentul in care trebuie sa se opreaqsca timer-ul
            //se adauga la data curenta un numar de secunde egal cu delay-ul
            //mai exact, peste 20 de secunde, trebuie sa se opreasca timer-ul
            //se pot adauga si minute, ore, etc... la data curenta
            deadline = DateTime.Now.AddSeconds(delay);
            dispatcherTimer.Start();
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public void LoadBoardToScreen()
        {
           
            for (int i = 0; i < _size; i++)
            {
                Elements.Add(new ObservableCollection<CellModel>());
                for (int j = 0; j < _size; j++)
                {
                    Elements[i].Add( new CellModel(i, j, board.BoardToBeFilled[i * _size + j]));
                   // MessageBox.Show(boardString[i * _size + j].ToString());
                }
            }
        }

        public void LoadFromFile(string path)
        {
            if (!System.IO.File.Exists(path))
                MessageBox.Show("nu e");
            using (StreamReader file = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                if (file.EndOfStream)
                    return;

                string line = file.ReadLine();
                board.BoardFilledCorrectly = line.Trim();

                line = file.ReadLine();
                board.BoardToBeFilled = line.Trim();

                file.Dispose();
            }
        }

        public void LoadSavedGame(string path)
        {
            if (!System.IO.File.Exists(path))
                MessageBox.Show("nu e");
            using (StreamReader file = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                if (file.EndOfStream)
                    return;

                string line = file.ReadLine();
                _size = Int32.Parse(line);

                line = file.ReadLine();
                delay = Int32.Parse(line);

                line = file.ReadLine();
                board.BoardFilledCorrectly = line.Trim();

                line = file.ReadLine();
                board.BoardToBeFilled = line.Trim();

                file.Dispose();
            }
        }

        private string getBoardString()
        {
            string boardString = "";
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    boardString += Elements[i][j].Value;
                }
            }
            return boardString;
        }

        public bool isBoardSolvedCorrectly()
        {
            
            if (getBoardString() == board.BoardFilledCorrectly)
                return true;
            return false;
        }

        public SudokuBoardViewModel(IWindowManager windowManager, int boardSize)
        {
            _size = boardSize;
            Elements = new ObservableCollection<ObservableCollection<CellModel>>();
            board = new BoardModel();
            var path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\..\\Data\\Boards\\" + _size + "x" + _size + "\\1.txt";
            LoadFromFile(path);
            LoadBoardToScreen();
            StartTimer();
        }

        public SudokuBoardViewModel(IWindowManager windowManager)
        {
            Elements = new ObservableCollection<ObservableCollection<CellModel>>();
            board = new BoardModel();
            var path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\..\\Data\\Users\\" + UsersListModel.CurrentUser.Username + "\\savedGame.txt";

            LoadSavedGame(path);
            LoadBoardToScreen();
            StartTimer();
        }

        public void CheckBoard()
        {
            if (isBoardSolvedCorrectly())
                MessageBox.Show("Ai castigat!");
            else
                MessageBox.Show("Mai incearca!");
        }

        public void SaveGame()
        {
            string[] lines = {_size.ToString(), delay.ToString(), board.BoardFilledCorrectly, getBoardString()};
            var path = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\..\\Data\\Users\\" + UsersListModel.CurrentUser.Username + "\\savedGame.txt";
            System.IO.File.WriteAllLines(path, lines); 

        }
    }
}
