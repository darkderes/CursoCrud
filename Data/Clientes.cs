using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CursoCrud.Data
{
    public class Clientes
    {
         public int Id { get; set;} 
         [Required(ErrorMessage = "Obligatorio")]
         public string Cliente { get;set;}  

    }  


}