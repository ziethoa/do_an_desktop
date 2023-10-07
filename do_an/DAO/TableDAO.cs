﻿using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance 
        {
            get { if(instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 80;
        public static int TableHeight = 100;

        private TableDAO() { }

        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> TableList = new List<TableDTO>();

            DataTable data = Dataprovider.Instance.ExecuteQuery("USP_GetTableList");
             foreach(DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                TableList.Add(table);

            }

            return TableList;
        }
    }
}
