using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.DataLayer.Entities
{
    public class BaseEntity
    {
        [JsonIgnore]
        [Column(Order = 100)]
        public DateTime CreateDate { get; set; }

        [JsonIgnore]
        [Column(Order = 200)]
        public DateTime? UpdateDate { get; set; }
    }
}
