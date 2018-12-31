using Prism.Mvvm;

namespace WpfMvvm
{
    public class Model : BindableBase
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }
            set { SetProperty(ref _x, value); }
        }

        public double Y
        {
            get { return _y; }
            set { SetProperty(ref _y, value); }
        }

        public Model(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double Sum()
        {
            return X + Y;
        }
    }
}
