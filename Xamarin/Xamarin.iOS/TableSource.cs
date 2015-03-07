using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Xamarin.iOS
{
    public class TableSource : UITableViewSource
    {
        List<string> tableItems;
        string cellIdentifier = "TableCell";
        public TableSource(List<string> items)
        {
            tableItems = items;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            cell.TextLabel.Text = tableItems[indexPath.Row];
            return cell;
        }
    }
}