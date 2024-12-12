using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Delta.WPF
{
    public abstract partial class Component
    {
        public static Img Img()
        {
            return new Img ();
        }
        public static Img Img(string sourcePath)
        {
            return new Img (sourcePath);
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
    }

    public static partial class ImgVisualExtention
    {
        public static T Source<T>(this T node, string sourcePath) where T : IImage
        {
            var bitmap = SetImageSource (sourcePath);
            if (bitmap == null)
                return node;
            node.SetProperty ("Source", bitmap);

            return node;
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
