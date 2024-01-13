using Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Module
{
    public int ModuleId { get; set; }
    public string ModuleName { get; set; }
    public string ModuleDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<Domain.Entities.Group> Groups { get; set; } = new List<Domain.Entities.Group>();
}
