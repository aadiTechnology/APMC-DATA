﻿using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IEntryGateDetailsRepository : IRepositoryBase<IndentDetails>
    {
        Task<IEnumerable<IndentDetails>> IndentDetailsById(int id);
        Task<IEnumerable<IndentDetails>> GetAllNotScannedIndent();
        ParkingCharges AddEntryCheckInDetails(IndentDetails indentDetails, List<ParkingCharges> parkingCharges);
    }
}
