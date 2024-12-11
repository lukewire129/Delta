using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Delta.WPF
{
    public partial class Scroll : ContentControl, IScroll, IContent
    {
        public Scroll(IElement element) : base ("ScrollViewer")
        {
            this.Content (element);
        }
        public Scroll(object o) : base ("ScrollViewer")
        {
            this.Content (o);
        }
    }

    public partial class Button : ContentControl, IText
    {
        public Button() : base ("Button") { }
        public Button(object o) : base ("Button")
        {
            this.Content (o);
        }
        public Button(IElement element) : base ("Button")
        {
            this.Content (element);
        }
        public Button(object o, RoutedEventHandler handler) : base ("Button")
        {
            this.Content (o);
            this.AddEvent ("Click", handler);
        }
        public Button(IElement element, RoutedEventHandler handler) : base ("Button")
        {
            this.Content (element);
            this.AddEvent ("Click", handler);
        }
    }
    public partial class VStack : Panel, IVisual
    {
        public VStack() : base ("StackPanel")
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Vertical);
        }
        public VStack(params IElement[] node) : base ("StackPanel", node)
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Vertical);
        }
    }

    public partial class HStack : Panel, IVisual
    {
        public HStack() : base ("StackPanel")
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Horizontal);
        }
        public HStack(params IElement[] node) : base ("StackPanel", node)
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Horizontal);
        }
    }

    public partial class Text : Visual, IText
    {
        public Text() : base ("TextBlock") { }
        public Text(string o) : base ("TextBlock")
        {
            this.SetProperty ("Text", o);
        }
    }

    public partial class Input : Visual, IText, IInput
    {
        public Input() : base ("TextBox")
        {
            this.SetProperty ("VerticalContentAlignment", System.Windows.VerticalAlignment.Center);
        }
    }

    public partial class Radio : ContentControl, IText, IRadio, ICheck
    {
        public Radio() : base ("RadioButton")
        {
        }
        public Radio(object o) : base ("RadioButton")
        {
            this.Content (o);
        }
        public Radio(IElement element) : base ("RadioButton")
        {
            this.Content (element);
        }

        public IElement Group(string groupName)
        {
            return this.SetProperty ("GroupName", groupName);
        }
    }

    public partial class Check : ContentControl, IText, ICheck
    {
        public Check() : base ("CheckBox")
        {
        }
        public Check(object o) : base ("CheckBox")
        {
            this.Content (o);
        }
        public Check(IElement element) : base ("CheckBox")
        {
            this.Content (element);
        }
    }

    public partial class Img : Visual, IImage
    {
        public Img() : base ("Image")
        {
        }

        public Img(string path) : base ("Image")
        {
            this.Source (path);
        }
        public IElement Source(string sourcePath)
        {
            var bitmap = SetImageSource (sourcePath);
            if (bitmap == null)
                return this;
            return this.SetProperty ("Source", bitmap);
        }

        private static BitmapImage SetImageSource(string path)
        {
            try
            {
                Uri imageUri;

                // 경로가 절대경로인지 상대경로인지 판단
                if (Path.IsPathRooted (path)) // 절대경로
                {
                    if (!File.Exists (path)) // 파일 존재 확인
                    {
                        throw new Exception ("존재하지 않는 경로의 파일입니다.");
                    }
                    imageUri = new Uri (path, UriKind.Absolute);
                }
                else // 상대경로
                {
                    // Pack URI로 처리 (애플리케이션 리소스 기준)
                    string packUri = $"pack://application:,,,/{path}";

                    // 상대 경로를 로컬 파일 기준으로 해석할 경우:
                    // string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    // if (!File.Exists(relativePath)) { ... }

                    imageUri = new Uri (packUri, UriKind.RelativeOrAbsolute);
                }

                // BitmapImage로 설정
                var bitmap = new BitmapImage ();
                bitmap.BeginInit ();
                bitmap.UriSource = imageUri;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit ();

                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show ($"이미지를 로드하는 중 오류가 발생했습니다: {ex.Message}");
            }

            return null;
        }
    }
}
