using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Band_Database_API.Models
{
    public class BandDetails
    {
        //Music band id
        public int Id { get; set; }
        //Music band name 
        public string Band_Name { get; set; }
        //Producer name
        public string Producer_Name { get; set; }
        //Album name
        public string Album_Name { get; set; }
        //Release date of the album
        [DataType(DataType.Date)]
        public DateTime Album_ReleaseDate { get; set; }
    }
}
