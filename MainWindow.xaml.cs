using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace todobar
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window, IComponentConnector
    {
        private static string folder = "E:\\data\\localDB\\todo";
        private static readonly double TimerInterval = 60000.0;
        private static bool transparent = false;
        private static bool workTimerEnabled = false;
        private static bool restTimerEnabled = false;
        private static int restCounter = 15;
        private static int workCounter = 0;

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.reload();
            this.startTimer(MainWindow.TimerInterval);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval"></param>
        private void startTimer(double interval)
        {
            Timer timer = new Timer(interval);
            timer.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
            timer.Start();
            this.processTimers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private TextBox createbox()
        {
            TextBox b = new TextBox();
            b.Height = b.Width = 100.0;
            b.TextWrapping = TextWrapping.Wrap;
            b.Background = (Brush)Brushes.DarkGray;
            b.Height = b.Width = 100.0;
            b.BorderBrush = (Brush)Brushes.Green;
            return b;
        }


        protected void TextBoxOnMouseWheel(string fullpath, TextBox b, object sender, MouseWheelEventArgs e)
        {
            if (!b.IsFocused)
                return;
            bool flag = e.Delta > 0;

            Brush background = b.Background;

            if (Brushes.DarkGray == background)
            {
                b.Background = flag ? (Brush)Brushes.Red : (Brush)Brushes.Green;
            }

            if (Brushes.Green == background)
            {
                b.Background = flag ? (Brush)Brushes.DarkGray : (Brush)Brushes.Yellow;
            }

            if (Brushes.Yellow == background)
            {
                b.Background = flag ? (Brush)Brushes.Green : (Brush)Brushes.Red;
            }

            if (Brushes.Red == background)
            {
                b.Background = flag ? (Brush)Brushes.Yellow : (Brush)Brushes.DarkGray;
            }



            SaveInDB(GetDataFromTextBox(fullpath, b));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        string ColorToString(Brush b)
        {
            if (Brushes.Green == b)
                return "Green";

            if (Brushes.DarkGray == b)
                return "DarkGray";

            if (Brushes.Yellow == b)
                return "Yellow";

            if (Brushes.Red == b)
                return "Red";

            return "DarkGray";
        }

        Brush StringToColor(string name)
        {
            if (name == "Green")
                return (Brush)Brushes.Green;

            if (name == "DarkGray")
                return (Brush)Brushes.DarkGray;

            if (name == "Yellow")
                return (Brush)Brushes.Yellow;

            if (name == "Red")
                return (Brush)Brushes.Red;

            return (Brush)Brushes.DarkGray;
        }

        void OnTextEdited(string path, TextBox b)
        {
            b.ToolTip = b.Text;
            SaveInDB(GetDataFromTextBox(path, b));
        }

        Data GetDataFromTextBox(string path, TextBox b)
        {
            Data d = new Data();
            d.UniqueId = path;
            d.Text = b.Text;
            d.ColorName = ColorToString(b.Background);

            return d;
        }



        private void reload()
        {
            this.wrapPanel.Children.Clear();
            if (!Directory.Exists(MainWindow.folder))
            {
                MainWindow.folder = Directory.GetCurrentDirectory() + "\\db";
                Directory.CreateDirectory(MainWindow.folder);
            }
            foreach (FileInfo fileInfo in ((IEnumerable<FileInfo>)new DirectoryInfo(MainWindow.folder).GetFiles("*.*", SearchOption.AllDirectories)).OrderBy<FileInfo, DateTime>((Func<FileInfo, DateTime>)(t => t.CreationTime)).ToList<FileInfo>())
            {
                FileInfo item = fileInfo;
                string str = File.ReadAllText(item.FullName);
                var data = readFromDb(item.FullName);
                if (data == null || data.Text.Length == 0)
                {
                    File.Delete(item.FullName);
                }
                else
                {
                    TextBox b = this.createbox();
                    b.Background = StringToColor(data.ColorName);
                    TextChangedEventHandler changedEventHandler = (TextChangedEventHandler)((s, a) => OnTextEdited(item.FullName, b));
                    b.MouseWheel += (MouseWheelEventHandler)((s, e) => this.TextBoxOnMouseWheel(item.FullName, b, s, e));
                    b.Text = data.Text;
                    b.ToolTip = data.Text;
                    b.TextChanged += changedEventHandler;
                    this.wrapPanel.Children.Add((UIElement)b);
                }
            }
        }

        private void toggleTransperency()
        {
            if (!MainWindow.transparent)
            {
                MainWindow.transparent = true;
                this.Opacity = 0.1;
            }
            else
            {
                MainWindow.transparent = false;
                this.Opacity = 1.0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateNewBox()
        {
            TextBox b = this.createbox();
            string myUniqueFileName = string.Format("{0}.txt", (object)Guid.NewGuid());
            myUniqueFileName = MainWindow.folder + "\\" + myUniqueFileName;
            File.WriteAllText(myUniqueFileName, "");
            TextChangedEventHandler changedEventHandler = (TextChangedEventHandler)((s, a) => OnTextEdited(myUniqueFileName, b));
            b.MouseWheel += (MouseWheelEventHandler)((s, e) => this.TextBoxOnMouseWheel(myUniqueFileName, b, s, e));
            b.TextChanged += changedEventHandler;
            this.wrapPanel.Children.Add((UIElement)b);
            b.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void SaveInDB(Data data)
        {
            IDatabase databse = new DB_Xml("");
            databse.save(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Data readFromDb(string path)
        {
            IDatabase databse = new DB_Xml(path);
            return databse.read(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.toggleTransperency();
            else if (e.Key == Key.F5)
            {
                this.reload();
            }
            else
            {
                if (e.Key != Key.Return)
                    return;
                this.CreateNewBox();
            }
        }

        private void WorkTimer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.workTimerEnabled = !MainWindow.workTimerEnabled;
            if (!MainWindow.workTimerEnabled)
            {
                MainWindow.workCounter = 0;
                this.WorkTimer.Content = (object)"";
            }
            else
                this.WorkTimer.Content = (object)MainWindow.workCounter.ToString();
        }

        private void RestTimer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.restTimerEnabled = !MainWindow.restTimerEnabled;
            if (!MainWindow.restTimerEnabled)
            {
                MainWindow.restCounter = 0;
                this.RestTimer.Content = (object)"";
            }
            else
            {
                MainWindow.restCounter = 15;
                Application.Current.Dispatcher.Invoke((Action)(() =>
               {
                   this.WorkTimer.Foreground = (Brush)new SolidColorBrush(MainWindow.restCounter > 1 ? Colors.Green : Colors.Red);
                   this.RestTimer.Content = (object)MainWindow.restCounter.ToString();
               }));
            }
        }

        private void processTimers()
        {
            if (MainWindow.restTimerEnabled)
            {
                --MainWindow.restCounter;
                Application.Current.Dispatcher.Invoke((Action)(() =>
               {
                   this.RestTimer.Foreground = (Brush)new SolidColorBrush(MainWindow.restCounter > 1 ? Colors.Green : Colors.Red);
                   this.RestTimer.Content = (object)MainWindow.restCounter.ToString();
               }));
            }
            if (!MainWindow.workTimerEnabled)
                return;
            ++MainWindow.workCounter;
            Application.Current.Dispatcher.Invoke((Action)(() =>
           {
               this.WorkTimer.Foreground = (Brush)new SolidColorBrush(MainWindow.workCounter < 60 ? Colors.Green : Colors.Red);
               this.WorkTimer.Content = (object)MainWindow.workCounter.ToString();
           }));
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.processTimers();
        }

        //[DebuggerNonUserCode]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    switch (connectionId)
        //    {
        //        case 1:
        //            ((UIElement)target).KeyDown += new KeyEventHandler(this.Window_KeyDown);
        //            break;
        //        case 2:
        //            this.wrapPanel = (WrapPanel)target;
        //            break;
        //        case 3:
        //            this.RestTimer = (Button)target;
        //            this.RestTimer.Click += new RoutedEventHandler(this.RestTimer_Click);
        //            break;
        //        case 4:
        //            this.WorkTimer = (Button)target;
        //            this.WorkTimer.Click += new RoutedEventHandler(this.WorkTimer_Click);
        //            break;
        //        default:
        //            this._contentLoaded = true;
        //            break;
        //    }
        //}
    }
}
