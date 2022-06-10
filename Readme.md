<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128647820/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1558)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Display a Context Menu for Data Cells

This example shows how to define a cell's context menu. The context menu allows users to delete a row or copy its data to the clipboard.

![image](https://user-images.githubusercontent.com/65009440/173060803-2d949b04-11fb-455c-a5ad-41a17b3d3657.png)

To specify a context menu, add [BarItems](https://docs.devexpress.com/WPF/6646/controls-and-libraries/ribbon-bars-and-menu/common-concepts/the-list-of-bar-items-and-links) to the TableView's [RowCellMenuCustomizations](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.RowCellMenuCustomizations) collection. The menu item's **DataContext** property is set to an object of the **GridCellMenuInfo** type. That allows you to use the `Row.Row.[Property_Name]` path to access data source properties.  

In this example, the **Delete** button is enabled only for rows whose **CanBeDeleted** property is `true`: 

```xaml
<dxb:BarButtonItem Name="deleteRowItem" Content="Delete"
                   IsEnabled="{Binding Row.Row.CanBeDeleted}"
                   ItemClick="OnDeleteRow"/>
```
