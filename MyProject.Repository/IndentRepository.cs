﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class IndentRepository : RepositoryBase<IndentDetails>, IIndentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public IndentRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IndentDetails AddIndent(IndentDetails indentDetails, List<IndentProducts> indentProducts)
        {
            try
            {
                indentDetails.OrderNo = GetOrderId();
                indentDetails.CreatedDate = DateTime.Now;
                _repositoryContext.IndentDetails.Add(indentDetails);
                var id = GetIndentId();
                foreach (IndentProducts indentProduct in indentProducts)
                {
                    indentProduct.IndentId = id;
                }
                _repositoryContext.IndentProducts.AddRange(indentProducts);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IndentDetails Update(IndentDetails indentDetails)
        {
            try
            {
                _repositoryContext.IndentDetails.Update(indentDetails);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string GetOrderId()
        {
            string orderNo = _repositoryContext.IndentDetails.OrderByDescending(a => a.Id).Select(a => a.OrderNo).FirstOrDefault();
            if (orderNo == null)
            {
                orderNo = "IndNo-1";
            }
            else
            {
                orderNo = "IndNo-" + (Convert.ToInt32(orderNo.Split('-')[1].Trim()) + 1);
            }
            return orderNo;
        }

        public int GetIndentId()
        {
            int id = _repositoryContext.IndentDetails.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            return id;
        }
        public Tuple<IndentDetails, byte[]> GetIndent(int indentID)
        {
            IndentDetails indentDetails= _repositoryContext.IndentDetails.Where(a=>a.Id== indentID).FirstOrDefault();
           var bytes= getByte(_repositoryContext.GlobalConfigurations.Where(a => a.Key == "QRPath").FirstOrDefault().Value + indentDetails.QrId);
          return(Tuple.Create(indentDetails,bytes));
        }
        public List<IndentDetails> GetIndentByDateRange(DateTime fromDate, DateTime toDate)
        {
           return _repositoryContext.IndentDetails.Where(a => a.CreatedDate>= fromDate && a.CreatedDate<= toDate).ToList();
        }
        private byte[]  getByte(string path)
        {
            Image img = Image.FromFile(path);
            return (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
        }
        public byte[] GenerateQRCode(string indentId,string merchantId,string driverId)
        {
            Tuple<IndentDetails, byte[]> indentDetails = GetIndent(int.Parse(indentId));
            //if (string.IsNullOrWhiteSpace(indentDetails.OrderNo)|| string.IsNullOrWhiteSpace(indentDetails.DriverNo)||)
            //{

            //}
            string encodeString = Base64Encode(indentId+"|"+ merchantId+"|"+ driverId);
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(encodeString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            byte[] array = BitmapToBytesCode(qrCodeImage);
            File.WriteAllBytes(_repositoryContext.GlobalConfigurations.Where(a => a.Key == "QRPath").FirstOrDefault().Value + indentId+ merchantId+ driverId+".png", array);
            indentDetails.Item1.QrId = indentId + merchantId + driverId + ".png";
            _repositoryContext.IndentDetails.Update(indentDetails.Item1);
            _repositoryContext.SaveChanges();
            return array;
        }

        private Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
