namespace Delta.WPF
{
    readonly public partial struct GridLength
    {
        readonly System.Windows.GridLength value;

        public GridLength(System.Windows.GridLength value) => this.value = value;

        public static implicit operator System.Windows.GridLength(GridLength value) => value.value;
        public static implicit operator GridLength(System.Windows.GridLength value) => new (value);

        public static implicit operator GridLength(double value) => new System.Windows.GridLength (value);
    }
}
