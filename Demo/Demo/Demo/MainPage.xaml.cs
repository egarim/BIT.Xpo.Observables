using BIT.Xpo.Observables;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.NextPage.Clicked += NextPage_Clicked;

            uoW = XpoHelper.CreateUnitOfWork();


            SortingCollection sorting = new SortingCollection();
            sorting.Add(new SortProperty("Description", DevExpress.Xpo.DB.SortingDirection.Ascending));
            XPCollection<Item> Collection = new XPCollection<Item>(uoW);
            Collection.Sorting = sorting;

            selector = new XamarinXpoPageSelector<Item>(Collection,10, XpoObservablePageSelectorBehavior.AppendPage);
            //selector.CurrentPage = 0;


            //XpoObservableCollection<Item> Observabl = new XpoObservableCollection<Item>(uoW);
            //((INotifyCollectionChanged)Observabl).CollectionChanged += MainPage_CollectionChanged;
            //Device.StartTimer(TimeSpan.FromSeconds(4), () =>
            //{
            //    // Do something
            //    PersistentClasses1 newObject = new PersistentClasses1(uoW);
            //    newObject.Number = 500;
            //    Observabl.Add(newObject);
            //    return false; // True = Repeat again, False = Stop the timer
            //});


            this.listView.ItemsSource = selector.ObservableData;
            //this.listView.ItemsSource = selector.ObservableData;
        }

        private void MainPage_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine(string.Format("{0}:{1}", "e.Action", e.Action.ToString()));
        }

        ObservableCollection<Item> Data;
        XamarinXpoPageSelector<Item> selector;




        int count = 1;

        UnitOfWork uoW;
        private void NextPage_Clicked(object sender, EventArgs e)
        {
            this.listView.BeginRefresh();
            if (count == selector.CurrentPage)
                return;

            selector.CurrentPage= count;
            this.listView.EndRefresh();
            count = count + 1;


        }
    }
}
