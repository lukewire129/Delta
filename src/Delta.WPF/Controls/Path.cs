using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Delta.WPF
{
    public interface IPath : IVisual
    {

    }
    public abstract partial class Component
    {
        public static Path Path(string path)
        {
            return new Path (path);
        }
    }



    public partial class Path : Shape, IPath, IShape
    {
        public Path(string path) : base ("Path")
        {
            this.Data (path);
        }

    }
    public static partial class PathVisualExtention
    {
        public static T Data<T>(this T node, string pathData) where T : IPath
        {
            Geometry geometry = Geometry.Parse (pathData);
            node.SetProperty ("Data", geometry);
            return node;
        }
    }
}
