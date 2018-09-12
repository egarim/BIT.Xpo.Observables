using DevExpress.Xpo;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BIT.Xpo.Observables
{
    public class XamarinXpoPageSelector<T>:INotifyPropertyChanged
    {
        private readonly XPPageSelector Selector;
        ObservableRangeCollection<T> _ObservableData = new ObservableRangeCollection<T>();
        readonly XpoObservablePageSelectorBehavior _Behavior;
        public XamarinXpoPageSelector(XPCollection<T> collection,int PageSize, XpoObservablePageSelectorBehavior Behavior)
        {
            this.Selector = new XPPageSelector(collection);
            this.Selector.PageSize = PageSize;
            _Behavior = Behavior;
            this.Selector.CurrentPage = 1;
        }
      
        public int CurrentPage
        {
            get { return this.Selector.CurrentPage; }
            set
            {
                if (this.Selector.CurrentPage == value)
                    return;
                this.Selector.CurrentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
                ProcessData();
            }
        }
        
        public ObservableRangeCollection<T> ObservableData { get => _ObservableData; set => _ObservableData = value; }

        public XpoObservablePageSelectorBehavior Behavior => _Behavior;

        public event PropertyChangedEventHandler PropertyChanged;

        private void ProcessData()
        {

            
            IEnumerable<T> InvokeData = ((IListSource)this.Selector).GetList().Cast<T>();
            if (this.Behavior== XpoObservablePageSelectorBehavior.AppendPage)
            _ObservableData.AddRange(InvokeData);
            else
            {
                _ObservableData.Clear();
                _ObservableData.AddRange(InvokeData);
            }
        }

    }
}
