## An observable implementation of [XpCollection](https://documentation.devexpress.com/CoreLibraries/2031/DevExpress-ORM-Tool/Feature-Center/Data-Representation/XPCollection) and [XPPageSelector](https://documentation.devexpress.com/CoreLibraries/DevExpress.Xpo.XPPageSelector.class).

![bit xpo observables](https://user-images.githubusercontent.com/22223689/46484582-e5e49580-c7ae-11e8-89b4-233583ab9f78.png)

After 15 years, DevExpress has finally made XPO available free-of-charge. If you’re not familiar with XPO, you can learn more about [its feature set here](https://www.devexpress.com/Products/NET/ORM/). If you’ve used XPO in the past or are familiar with capabilities, you will love this.

A we already know a Xamarin ListView is populated with data using the ItemsSource property, which can accept any collection implementing IEnumerable but if we want the ListView to automatically update as items are added, removed or changed in the underlying list, you'll need to use an [ObservableCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.7.2). Here is where XpoObservableCollection becomes the best friend for all the XPO fans out there.

XpoObservableCollection inherit from a XPCollection so to use, it is exactly as you would use an XPCollection, the only difference is that the XpoObservableCollection refresh the state of ListViews on Xamarin Forms.

XamarinXpoPageSelector takes it a step further by internally implementing XPPageSelector and presenting the XpoObservableCollection as a pageable collection. With this in mind, on the constructor of the XamarinXpoPageSelector  you need to pass the following parameters:

```c#
SortingCollection sorting = new SortingCollection();
sorting.Add(new SortProperty("Your Property", SortingDirection.Ascending));
XPCollection <Your Class> Collection = new XPCollection <YourClass>(UnitOfWork);
Collection.Sorting = sorting;

XamarinXpoPageSelector <YourClass> selector = new XamarinXpoPageSelector <YourClass> (Collection,10, XpoObservablePageSelectorBehavior.AppendPage);
       
this.listView.ItemsSource = selector.ObservableData;

```
Collection = An instance of XPCollection.

10 = Page Size by default.

XpoObservablePageSelectorBehavior = AppendPage or SinglePage.

Use Append in case you want to to add the results of the new page to the collection or Single page to clear the last page results before show the new page.

And that's it. The same awesome ObservableRangeCollection [(from MVVM Helpers)](https://github.com/jamesmontemagno/mvvm-helpers) that adds important methods such as: **AddRange, RemoveRange, Replace, and ReplaceRange**, it is now available in XPO. 

https://www.nuget.org/packages/BIT.Xpo.Observables/

Until next time. Xpo out!
