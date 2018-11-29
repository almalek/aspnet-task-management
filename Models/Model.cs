using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codex.Models
{
    public class CodexContext : DbContext
    {
        public CodexContext(DbContextOptions<CodexContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public List<Task> Tasks { get; set; }
    }

    public class Task
    {
        public int TaskId { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Details is required")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }

        [Display(Name = "Due Date")]
        [Required(ErrorMessage = "Due Date is required")]
        public  DateTime DueDate { get; set; }

        public int EmployeeForeignKey { get; set; }

        [ForeignKey("EmployeeForeignKey")]
        public Employee Employee { get; set; }
    }

}