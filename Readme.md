<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128647820/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1558)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

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
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-access-and-remove-rows-by-using-a-custom-cells-context-menu-e1558&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-access-and-remove-rows-by-using-a-custom-cells-context-menu-e1558&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
