XpoObservableCollection<T>  inherit from a XPCollection so to use it just us it as you would use an XPCollection, the only difference is that this XpoObservableCollection<T> refresh the state of ListViews on Xamarin forms

XamarinXpoPageSelector<T> internally implements XPPageSelector. On the constructor you need to pass the following parameters

XPCollection<T> collection = the XpCollection for paging 
int PageSize = the size of the page
XpoObservablePageSelectorBehavior = the behavior this can be Append to add the results of the new page to the collection or single page to clear the last page results before show the new page

