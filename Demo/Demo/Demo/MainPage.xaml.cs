using BIT.Xpo.Observables;
using DevExpress.Xpo;
using System;
using Xamarin.Forms;

namespace Demo
{
    public partial class MainPage : ContentPage
    {
  
        XamarinXpoPageSelector<Item> selector;
        int count = 0;
        UnitOfWork uoW;
        public MainPage()
        {
            InitializeComponent();
                                  
            this.NextPage.Clicked += NextPage_Clicked;
            this.PreviousPage.Clicked += PreviousPage_Clicked;
            this.ChangeBehavior.Clicked += ChangeBehavior_Clicked; 
            uoW = XpoHelper.CreateUnitOfWork();


            SortingCollection sorting = new SortingCollection();
            sorting.Add(new SortProperty("Index", DevExpress.Xpo.DB.SortingDirection.Ascending));
            XPCollection<Item> Collection = new XPCollection<Item>(uoW);
            Collection.Sorting = sorting;

            selector = new XamarinXpoPageSelector<Item>(Collection,10, XpoObservablePageSelectorBehavior.SinglePage);
            
            this.listView.ItemsSource = selector.ObservableData;           

            //var pagecount = selector.Selector.PageCount;

           // FirstPage();

        }

        void FirstPage()
        {
            this.listView.BeginRefresh();
            //selector.CurrentPage = 1;
            //selector.CurrentPage = 0;
            this.listView.EndRefresh();
        }

        private void ChangeBehavior_Clicked(object sender, EventArgs e)
        {
            if(selector.Behavior == XpoObservablePageSelectorBehavior.AppendPage)
            {
                selector.Behavior = XpoObservablePageSelectorBehavior.SinglePage;
                this.DisplayAlert("Behavior", "XpoObservablePageSelectorBehavior.SinglePage", "OK");
            }
            else
            {
                selector.Behavior = XpoObservablePageSelectorBehavior.AppendPage;
                this.DisplayAlert("Behavior", "XpoObservablePageSelectorBehavior.AppendPage", "OK");
            }
        }

        private void PreviousPage_Clicked(object sender, EventArgs e)
        {
            
            if (selector.CurrentPage == 0) return;
            this.listView.BeginRefresh();
            selector.CurrentPage--;            
            this.listView.EndRefresh();           
        }

        private void NextPage_Clicked(object sender, EventArgs e)
        {
            if (selector.CurrentPage == selector.Selector.PageCount - 1) return;
            this.listView.BeginRefresh();            
            selector.CurrentPage++;
            this.listView.EndRefresh();
          

        }

       
    }
}
