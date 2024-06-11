using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gateway;

// Parents' Requests Interface
public class Parent
{
    [Key]
    public int ParentID { get; set; }
    public string ParentName { get; set; }
    public string? EmailAddress { get; set; }
}

public class Child
{
    [Key]
    public int ChildID { get; set; }
    public string ChildName { get; set; }
    public string? EmailAddress { get; set; }
}

public class BookingRequest
{
    [Key]
    public int RequestID { get; set; }
    public int ParentID { get; set; }
    public int ChildID { get; set; }
    public int PsychologistID { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime PreferredDateTime { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }

    public Parent Parent { get; set; }
    public Child Child { get; set; }
    public Psychologist Psychologist { get; set; }
}

// Psychologists' Dashboard
public class Psychologist
{
    [Key]
    public int PsychologistID { get; set; }
    public string PsychologistName { get; set; }
    public string? EmailAddress { get; set; }
}

// Permission Slip
public class PermissionSlip
{
    [Key]
    public int PermissionSlipID { get; set; }

    // Other properties
    public int ChildID { get; set; }
    public int ParentID { get; set; }
    public int PsychologistID { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime EventDate { get; set; }
    public string EventDescription { get; set; }
    public string Status { get; set; }
    public DateTime? ApprovalDate { get; set; } // Nullable DateTime
    public string Notes { get; set; }

    // Navigation properties
    public Child Child { get; set; }
    public Parent Parent { get; set; }
    public Psychologist Psychologist { get; set; }
}
