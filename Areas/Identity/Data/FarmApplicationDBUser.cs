using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Elfie.Serialization;
using FarmApplication.Model;
using Microsoft.AspNetCore.Identity;

namespace FarmApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the  class
public class FarmApplicationDBUser : IdentityUser
{

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }


    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    // should allow for the tables to work together 
    //public List<Resources> Resources { get; set; }
    //public List<Equipment> Equipment { get; set; }
    //public List<Workers> Workers { get; set; }

    //public List<Field> Fields { get; set; }
}

