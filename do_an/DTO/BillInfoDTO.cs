﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class BillInfoDTO
    {
        public BillInfoDTO(int id, int idbill, int idfood, int iddrink, int count)
        {
            this.ID = id;
            this.IDBill = idbill;
            this.IDFood = idfood;
            this.IDDrink = iddrink;
            this.Count = count;
        }

        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["idbill"];
            this.IDFood = (int)row["idfood"];
            this.IDDrink = (int)row["iddrink"];
            this.Count = (int)row["count"];
        }

        private int iD;
        private int iDBill;
        private int iDFood;
        private int iDDrink;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int IDDrink { get => iDDrink; set => iDDrink = value; }
        public int Count { get => count; set => count = value; }
    }
}