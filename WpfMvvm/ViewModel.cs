using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using Prism.Events;
using System;

namespace WpfMvvm
{
    public class ViewModel : BindableBase
    {
        private Model _model;

        [DoubleValidation]
        public ReactiveProperty<string> X { get; }

        [DoubleValidation]
        public ReactiveProperty<string> Y { get; }

        public ReactiveCommand SendSum { get; }

        public ViewModel()
        {
            _model = new Model(0.0, 0.0);
            X = _model.ToReactivePropertyAsSynchronized(
                m => m.X,
                x => x.ToString(),
                s => double.Parse(s),
                ReactivePropertyMode.DistinctUntilChanged
                    | ReactivePropertyMode.RaiseLatestValueOnSubscribe,
                true)
                .SetValidateAttribute(() => X);
            Y = _model.ToReactivePropertyAsSynchronized(
                m => m.Y,
                y => y.ToString(),
                s => double.Parse(s),
                ReactivePropertyMode.DistinctUntilChanged
                    | ReactivePropertyMode.RaiseLatestValueOnSubscribe,
                true)
                .SetValidateAttribute(() => Y);
            SendSum = X.ObserveHasErrors.CombineLatest(
                Y.ObserveHasErrors, (x, y) => !x && !y)
                .ToReactiveCommand();
            SendSum.Subscribe(_ => Messenger.Instance.GetEvent<PubSubEvent<double>>().Publish(_model.Sum()));
        }
    }
}
