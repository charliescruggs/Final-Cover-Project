

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Xceed.Wpf.Toolkit;

namespace FinalCoverDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //@param filePath : Declared at the top so the user can change its value during run time tp pull up a new image
        private Uri filePath;

        //Creates a panel for the user to drag a file to upload
        private void FileDropStackPanel_Drop(object sender, DragEventArgs e)
        {

            /*
             * add check for more than one file passed
             */
            /*
             * add check for wrong file types
             */

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                string fileName = System.IO.Path.GetFileName(files[0]);

                filePath = new Uri(files[0]);

                ImagePreviewer.Source = new BitmapImage(filePath);

                FileNameLabel.Content = fileName;

            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialoug = new OpenFileDialog();
            bool? response = openFileDialoug.ShowDialog();

            if (response == true)
            {
                filePath = new Uri(openFileDialoug.FileName);

                ImagePreviewer.Source = new BitmapImage(filePath);

                FileNameLabel.Content = System.IO.Path.GetFileName(openFileDialoug.FileName);
            }
        }

        //Variables for canvas elements
        private Point startPoint;
        private Rectangle rectSelectArea;
        private Point translation;
        private bool isDragging;

        private void imgCamera_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(canvas1);
            
                if (e.ClickCount == 2 && e.OriginalSource is Rectangle)
                {
                    int index = canvas1.Children.IndexOf((UIElement)e.Source);
                    Rectangle temp = (Rectangle)e.OriginalSource;

                    Color colorPicked = (Color)colorPicker.SelectedColor;
                    SolidColorBrush brush = new SolidColorBrush(colorPicked);

                    temp.Stroke = brush;

                    canvas1.Children[index] = temp;
                }

                else if (e.ClickCount == 3 && e.OriginalSource is Rectangle)
                {
                    //code to remove a selected rectangle
                    int index = canvas1.Children.IndexOf((UIElement)e.Source);
                    canvas1.Children.RemoveAt(index);
                }

            

            // Initialize the rectangle.
            // Set border color and width
            rectSelectArea = new Rectangle
            {
                Stroke = Brushes.Yellow,
                StrokeThickness = 4
            };

            Canvas.SetLeft(rectSelectArea, startPoint.X);
            Canvas.SetTop(rectSelectArea, startPoint.X);
            canvas1.Children.Add(rectSelectArea);
        }

        private void imgCamera_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rectSelectArea = null;
        }

        private void imgCamera_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Source is Shape shape)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point p = e.GetPosition(canvas1);

                    if (!isDragging)
                    {
                        translation = new Point(p.X - Canvas.GetLeft(shape), p.Y - Canvas.GetTop(shape));
                        isDragging = true;
                    }

                    // Set the position of rectangle
                    var x1 = Math.Min(p.X, startPoint.X);
                    var y1 = Math.Min(p.Y, startPoint.Y);

                    // Set the dimenssion of the rectangle
                    var w1 = Math.Max(p.X, startPoint.X) - x1;
                    var h1 = Math.Max(p.Y, startPoint.Y) - y1;

                    rectSelectArea.Width = w1;
                    rectSelectArea.Height = h1;

                    Canvas.SetLeft(shape, p.X - translation.X);
                    Canvas.SetTop(shape, p.Y - translation.Y);

                    shape.CaptureMouse();
                    return;
                }
                else
                {
                    shape.ReleaseMouseCapture();
                    isDragging = false;
                }
            }

            if (e.LeftButton == MouseButtonState.Released || rectSelectArea == null)
            return;

            var pos = e.GetPosition(canvas1);

            // Set the position of rectangle
            var x = Math.Min(pos.X, startPoint.X);
            var y = Math.Min(pos.Y, startPoint.Y);

            // Set the dimenssion of the rectangle
            var w = Math.Max(pos.X, startPoint.X) - x;
            var h = Math.Max(pos.Y, startPoint.Y) - y;

            rectSelectArea.Width = w;
            rectSelectArea.Height = h;

            Canvas.SetLeft(rectSelectArea, x);
            Canvas.SetTop(rectSelectArea, y);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.RemoveRange(1, canvas1.Children.Count);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Rect rect = new Rect(canvas1.RenderSize);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
              (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas1);
            //endcode as PNG
            Microsoft.Win32.SaveFileDialog dl1 = new Microsoft.Win32.SaveFileDialog();
            dl1.FileName = "Sample Image";
            dl1.DefaultExt = ".png";
            dl1.Filter = "Image documents (.png)|*.png";
            Nullable<bool> result = dl1.ShowDialog();
            if (result == true)
            {
                string filename = dl1.FileName;
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();
                System.IO.File.WriteAllBytes(filename, ms.ToArray());
                Console.WriteLine("Done");
            }
        }
    }
}