using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Models
{
    public class Request
    {
        // ID 
        public int Id { get; set; }
        // Make
        [Required]
        [Display(Name = "Make")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Make { get; set; }
        // Model
        [Required]
        [Display(Name = "Model")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Model { get; set; }
        // Year 
        [Required]
        [Display(Name = "Year")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string Year { get; set; }
        // VIN
        [Required]
        [Display(Name = "VIN")]
        [MaxLength(50, ErrorMessage = "Exceeded the maximum record length")]
        public string VIN { get; set; }
        // OrderAmount
        [Display(Name = "OrderAmount")]
        [MaxLength(200, ErrorMessage = "Exceeded the maximum record length")]
        public string OrderAmount { get; set; }
        // Status
        [Display(Name = "Status")]
        public int Status { get; set; }


    
        public int? ClientId { get; set; }

        public Client Client { get; set; }


        public int LifecycleId { get; set; }

        public Lifecycle Lifecycle { get; set; }
    }

    public class Lifecycle
    {
        // ID 
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Opened { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Closed { get; set; }
    }


    public enum RequestStatus
    {
        Open = 1,
        Distributed = 2,
        Proccesing = 3,
        Checking = 4,
        Closed = 5
    }
}