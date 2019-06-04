using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DXGrid_CreateCellContextMenu {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.ItemsSource = new AccountList().GetData();
        }

        #region #RowCellMenuCustomization
        private void copyCellDataItem_ItemClick(object sender, ItemClickEventArgs e) {
            GridCellMenuInfo menuInfo = view.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null) {
                string text = "" +
                    grid.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column as GridColumn).ToString();
                Clipboard.SetText(text);
            }
        }

        private void deleteRowItem_ItemClick(object sender, ItemClickEventArgs e) {
            GridCellMenuInfo menuInfo = view.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
                view.DeleteRow(menuInfo.Row.RowHandle.Value);
        }
        #endregion #RowCellMenuCustomization
    }

    #region Account classes
    public class AccountList {
        public List<Account> GetData() {
            return CreateAccounts();
        }
        private List<Account> CreateAccounts() {
            List<Account> list = new List<Account>();
            list.Add(new Account() { UserName = "Nick White",
                CanBeDeleted = false,
                RegistrationDate = DateTime.Today });
            list.Add(new Account() { UserName = "Jack Rodman",
                CanBeDeleted = true,
                RegistrationDate = new DateTime(2009, 5, 10) });
            list.Add(new Account() { UserName = "Sandra Sherry",
                CanBeDeleted = false,
                RegistrationDate = new DateTime(2008, 12, 22) });
            list.Add(new Account() { UserName = "Sabrina Vilk", 
                CanBeDeleted = true,
                RegistrationDate = DateTime.Today });
            list.Add(new Account() { UserName = "Mike Pearson",
                CanBeDeleted = true,
                RegistrationDate = new DateTime(2008, 10, 18) });
            return list;
        }
    }

    public class Account {
        public string UserName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool CanBeDeleted { get; set; }
    }
    #endregion
}
