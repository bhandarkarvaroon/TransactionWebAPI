using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using TransactionWebApi.Models;

namespace TransactionWebApi.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        TransactionWebApi.Api.Controllers.TransactionController transactionWebApiController = null;

        public TransactionController()
        {
            transactionWebApiController = new TransactionWebApi.Api.Controllers.TransactionController();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportToCSV()
        {
            List<Transaction> transactions = transactionWebApiController.GetAllTransactions();

            StringBuilder sb = new StringBuilder();

            sb.Append("Trans Id," + "External Trans Id," + "Transaction Type," + "CashAmount," + "NAV," + "NAV Date," + "Fund Id," + "Account Id," + "Status," + "\n");

            foreach (Transaction transaction in transactions)
            {
                sb.Append(transaction.TransactionId + "," + transaction.ExternalTransactionId + "," + Enum.GetName(typeof(TransactionType), transaction.TransactionType) + "," + transaction.CashAmount + "," + transaction.NAV + "," + transaction.NAVDate + "," + transaction.FundId + "," + transaction.AccountId + "," + (transaction.TransactionStatus.HasValue && transaction.TransactionStatus.Value ? "Active" : "Inactive") + "\n");
            }
            return File(new System.Text.UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "Report123.csv");
        }

        public ActionResult ExportToExcel()
        {
            List<Transaction> transactions = transactionWebApiController.GetAllTransactions();

            IWorkbook workbook = new HSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Transaction List");

            IRow row1 = sheet1.CreateRow(0);

            ICell cell;
            cell = row1.CreateCell(0);
            cell.SetCellValue("Trans Id");
            cell = row1.CreateCell(1);
            cell.SetCellValue("External Trans Id");
            cell = row1.CreateCell(2);
            cell.SetCellValue("Transaction Type");
            cell = row1.CreateCell(3);
            cell.SetCellValue("Cash Amount");
            cell = row1.CreateCell(4);
            cell.SetCellValue("NAV");
            cell = row1.CreateCell(5);
            cell.SetCellValue("NAV Date");
            cell = row1.CreateCell(6);
            cell.SetCellValue("Fund Id");
            cell = row1.CreateCell(7);
            cell.SetCellValue("Account Id");
            cell = row1.CreateCell(8);
            cell.SetCellValue("Status");

            //IRow row2 = sheet1.CreateRow(1);
            //ICell cell3, cell4;
            //cell3 = row2.CreateCell(0);
            //cell3.SetCellValue("101");

            //cell4 = row2.CreateCell(1);
            //cell4.SetCellValue("E101");

            int i = 1;
            foreach (Transaction transaction in transactions)
            {
                IRow row = sheet1.CreateRow(i);

                cell = row.CreateCell(0);
                cell.SetCellValue(transaction.TransactionId.ToString());
                cell = row.CreateCell(1);
                cell.SetCellValue(transaction.ExternalTransactionId.ToString());
                cell = row.CreateCell(2);
                cell.SetCellValue(Enum.GetName(typeof(TransactionType), transaction.TransactionType).ToString());
                cell = row.CreateCell(3);
                cell.SetCellValue(transaction.CashAmount.ToString());
                cell = row.CreateCell(4);
                cell.SetCellValue(transaction.NAV.ToString());
                cell = row.CreateCell(5);
                cell.SetCellValue(transaction.NAVDate.ToString());
                cell = row.CreateCell(6);
                cell.SetCellValue(transaction.FundId.ToString());
                cell = row.CreateCell(7);
                cell.SetCellValue(transaction.AccountId.ToString());
                cell = row.CreateCell(8);
                cell.SetCellValue((transaction.TransactionStatus.HasValue && transaction.TransactionStatus.Value ? "Active" : "Inactive").ToString());

                i++;
            }


            byte[] fileContents = null;
            using (var memoryStream = new MemoryStream())
            {
                workbook.Write(memoryStream);
                fileContents = memoryStream.ToArray();
            }

            return File(fileContents, System.Net.Mime.MediaTypeNames.Application.Octet, "Transaction_Details.xls");
        }
    }
}