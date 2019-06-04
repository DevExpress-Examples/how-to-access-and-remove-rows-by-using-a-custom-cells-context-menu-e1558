
# How to access and remove rows by using a custom cell's context menu.


This example shows how to access and remove rows by using a custom context menu for cells. 

To implement such a context menu, add corresponding [BarItems](https://documentation.devexpress.com/WPF/6646/Controls-and-Libraries/Ribbon-Bars-and-Menu/Common-Features/The-List-of-Bar-Items-and-Links) to TableView's [RowCellMenuCustomizations](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.RowCellMenuCustomizations.property) collection: 

````xaml
<dxg:TableView.RowCellMenuCustomizations>
    <dxb:BarButtonItem Content="Delete" ... />
    <dxb:BarButtonItem Content="Copy Cell Data" .../>
</dxg:TableView.RowCellMenuCustomizations>
````

You can enable and disable such items based on property values in underlying data items. DataContexts in these items contain an object of the **GridCellMenuInfo** data type. This object's **Row.Row** property contains your data item instance. Therefore, you can bind to this data item's properties using the ***Row.Row.[Property_Name]*** path.  

In this example, the *Delete* item is enabled only for rows whose *CanBeDeleted* property is True: 

````xaml
<dxb:BarButtonItem Name="deleteRowItem" Content="Delete"
                    IsEnabled="{Binding Row.Row.CanBeDeleted}"
                    ItemClick="deleteRowItem_ItemClick"/>
````
