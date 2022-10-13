using System;
using System.ComponentModel.DataAnnotations;
using CENTROS.Core.DA.Interfaces;
using CRB.DA.Interfaces;

namespace centros_ref_book.Models.Configuration
{
    public class BaseServiceOptions : IBaseServiceOptions
    {
        public string MainDBConnectionName { get; set; } = "mainDB";
        public bool IsConnectionsEncoded { get; set; } = false;
        public TimeSpan DelayForShutdown { get; set; } = TimeSpan.FromSeconds(10);
        public int MaxErrorsAllowed { get; set; } = 5;
        public bool StopRequestProcessingWhenMaxErrorsReached { get; } = false;
        public DBEngineEnum UseDBEngine { get; set; } = DBEngineEnum.PostgreSQL;
    }
    
    public enum DBEngineEnum
    {
        /// <summary>
        /// PostgeSQL
        /// </summary>
        [Display(Name = "SQLServer")]
        SQLServer = 0,
        /// <summary>
        /// PostgeSQL
        /// </summary>
        [Display(Name = "PostgreSQL")]
        PostgreSQL = 1,
    }
}