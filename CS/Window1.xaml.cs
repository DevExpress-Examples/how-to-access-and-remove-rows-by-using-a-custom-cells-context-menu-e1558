using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DXGrid_CreateCellContextMenu {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.ItemsSource = AccountList.GetData();
        }
        void OnCopyRow(object sender, ItemClickEventArgs e) {
            if (view.GridMenu.MenuInfo is GridCellMenuInfo menuInfo && menuInfo.Row != null) {
                grid.CopyCurrentItemToClipboard();
            }
        }
        void OnDeleteRow(object sender, ItemClickEventArgs e) {
            if (view.GridMenu.MenuInfo is GridCellMenuInfo menuInfo && menuInfo.Row != null)
                view.DeleteRow(menuInfo.Row.RowHandle.Value);
        }
    }

    public class AccountList {
        public static ObservableCollection<Account> GetData() {
            ObservableCollection<Account> list = new ObservableCollection<Account>();
            list.Add(new Account() { 
                UserName = "Nick White",
                CanBeDeleted = false,
                RegistrationDate = DateTime.Today 
            });
            list.Add(new Account() { 
                UserName = "Jack Rodman",
                CanBeDeleted = true,
                RegistrationDate = new DateTime(2009, 5, 10) 
            });
            list.Add(new Account() { 
                UserName = "Sandra Sherry",
                CanBeDeleted = false,
                RegistrationDate = new DateTime(2008, 12, 22) 
            });
            list.Add(new Account() { 
                UserName = "Sabrina Vilk", 
                CanBeDeleted = true,
                RegistrationDate = DateTime.Today 
            });
            list.Add(new Account() { 
                UserName = "Mike Pearson",
                CanBeDeleted = true,
                RegistrationDate = new DateTime(2008, 10, 18) 
            });
            return list;
        }
    }
    public class Account {
        public string UserName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}
