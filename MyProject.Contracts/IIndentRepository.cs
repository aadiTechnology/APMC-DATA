﻿using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IIndentRepository : IRepositoryBase<IndentDetails>
    {
        IndentDetails AddIndent(IndentDetails indentDetails, List<IndentProducts> indentProducts);
        IndentDetails Update(IndentDetails indentDetails);
        string GetOrderId();
        public byte[] GenerateQRCode(string indentId, string merchantId, string driverId);
        public Tuple<IndentDetails, byte[]> GetIndent(int indentId);
        public List<IndentDetails> GetIndentByDateRange(DateTime fromDate, DateTime toDate);
    }
}
