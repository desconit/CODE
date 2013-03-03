using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

public class Tables
{
    public const string Users = "Users";
    public const string ExistingData = "ExistingData";
    public const string CurrencyConversions = "CurrencyConversions";
    public const string CurrencySymbols = "CurrencySymbols";
    public const string Suppliers = "Suppliers";
    public const string Items = "Items";
    public const string SupplierOrderTypes = "SupplierOrderTypes";
    public const string DeliveryMonths = "DeliveryMonths";
    public const string OrderMonths = "OrderMonths";
    public const string PricingOptions = "PricingOptions";
   
    public const string POs = "POs";
    public const string PODetails = "PODetails";
    public const string Customers = "Customers";
    public const string SOs = "SOs";
    public const string SODetails = "SODetails";
    public const string AppSettings = "AppSettings";

    ////////////////NEW///////////////////
    public const string Employees = "Employees";
    public const string Branches = "Branches";
    public const string Roles = "Roles";
    public const string OrgRoles = "OrgRoles";
    public const string EmployeeRoles = "EmployeeRoles";
    public const string Attachments = "Attachments";
    public const string Processes = "Processes";
    public const string ProcessTypes = "ProcessTypes";
    public const string MeasureUnits = "MeasureUnits";
    public const string MeasureClassifications = "MeasureClassifications";
    public const string Measures = "Measures";
    public const string ReviewFrequencies = "ReviewFrequencies";
    public const string Polarities = "Polarities";
    public const string MeasureDetails = "MeasureDetails";
    public const string TimeDimensions = "TimeDimensions";
    public const string HeadquaterSettings = "HeadquaterSettings";
    public const string Months = "Months";
    public const string Goals = "Goals";
    public const string AttachmentTypes = "AttachmentTypes";
    public const string DataSources = "DataSources";
    public const string EmployeeResponsibles = "EmployeeResponsibles";
    public const string BaselineSources = "BaselineSources";
    public const string MeasureCodes = "MeasureCodes";
    public const string ProcessClassificationRanks = "ProcessClassificationRanks";
    public const string ProcessBranchRanks = "ProcessBranchRanks";
    public const string ProcessTypeBranchRanks = "ProcessTypeBranchRanks";
    public const string BranchRanks = "BranchRanks";
    ////////////////////////////////////

    public const string Companies = "Companies";
    public const string Countries = "Countries";
    public const string Counties = "Counties";
    public const string Industries = "Industries";
    public const string TimeSheetFrequencies = "TimeSheetFrequencies";
    public const string Statuses = "Statuses";
    public const string CompanyBackOffices = "CompanyBackOffices";
    public const string PersonBackOffices = "PersonBackOffices";
    public const string Persons = "Persons";
    public const string Genders = "Genders";
    public const string MartialStatuses = "MartialStatuses";
    public const string ContactTypes = "ContactTypes";
    public const string Trades = "Trades";
    public const string JobTitles = "JobTitles";
    public const string WorkTypes = "WorkTypes";

    public const string PaymentMethods = "PaymentMethods";
    public const string PaymentTypes = "PaymentTypes";
    public const string Groups = "Groups";
    public const string GroupRights = "GroupRights";
    public const string UserGroups = "UserGroups";
    public const string Notes = "Notes";
    public const string NotePriorities = "NotePriorities";
    public const string DiaryActions = "DiaryActions";
    public const string Requirements = "Requirements";
    public const string JobStatuses = "JobStatuses";
    public const string RateTypes = "RateTypes";
    public const string RequirementTypes = "RequirementTypes";
    public const string CompanySites = "CompanySites";
    public const string RateFrequencies = "RateFrequencies";
    public const string Contracts = "Contracts";
    public const string ShortlistContacts = "ShortlistContacts";
    public const string Tickets = "Tickets";
    public const string ContactTickets = "ContactTickets";
    public const string TicketTypes = "TicketTypes";
    public const string RequirementTickets = "RequirementTickets";
    public const string PersonTrades = "PersonTrades";
    public const string AppErrors = "AppErrors";
    public const string Placements = "Placements";
    public const string Consultant = "Consultant";

    public const string ConsultantHistory = "ConsultantHistory";
}



public class ConsultantHistory
{
	public const string ID = "ID";
	public const string CompaniesID = "CompaniesID";
	public const string PersonsID = "PersonsID";
	public const string ConsultantStartDate = "ConsultantStartDate";
	public const string ConsultantEndDate = "ConsultantEndDate";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Placements
{
	public const string PlacementId = "PlacementId";
	public const string PersonId = "PersonId";
	public const string RequirementId = "RequirementId";
	public const string StartDate = "StartDate";
	public const string IsDeleted = "IsDeleted";
	public const string IsCanceled = "IsCanceled";
	public const string StandardRate = "StandardRate";
	public const string OvertimeRate = "OvertimeRate";
	public const string WeekendRate = "WeekendRate";
	public const string StandardRateCharge = "StandardRateCharge";
	public const string OvertimeRateCharge = "OvertimeRateCharge";
	public const string WeekendRateCharge = "WeekendRateCharge";
	public const string EndDate = "EndDate";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedOn = "LastModifiedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string Rollover = "Rollover";
}


public class AppErrors
{
	public const string ID = "ID";
	public const string UserName = "UserName";
	public const string MachineName = "MachineName";
	public const string InnerException = "InnerException";
	public const string ErrorMessage = "ErrorMessage";
	public const string Source = "Source";
	public const string TargetSite = "TargetSite";
	public const string StackTrace = "StackTrace";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class PersonTrades
{
	public const string ID = "ID";
	public const string PersonsID = "PersonsID";
	public const string TradesID = "TradesID";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class RequirementTickets
{
	public const string ID = "ID";
	public const string RequirementsID = "RequirementsID";
	public const string TicketsID = "TicketsID";
	public const string Comments = "Comments";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class TicketTypes
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class ContactTickets
{
	public const string ID = "ID";
    public const string PersonsID = "PersonsID";
	public const string TicketsID = "TicketsID";
	public const string Comments = "Comments";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Tickets
{
	public const string ID = "ID";
    public const string TicketTypesID = "TicketTypesID ";
	public const string Code = "Code";
	public const string Name = "Name";
	public const string Description = "Description";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class ShortlistContacts
{
	public const string ID = "ID";
	public const string RequirementsID = "RequirementsID";
	public const string PersonsID = "PersonsID";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Contracts
{
    public const string ID = "ID";
    public const string RequirementsID = "RequirementsID";
    public const string RateTypesID = "RateTypesID";
    public const string RateFrequenciesID = "RateFrequenciesID";
    public const string PayRate = "PayRate";
    public const string ChargeRate = "ChargeRate";
    public const string Note = "Note";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class RateFrequencies
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isForContact = "isForContact";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class CompanySites
{
	public const string ID = "ID";
	public const string CompaniesID = "CompaniesID";
	public const string CountiesID = "CountiesID";
	public const string CountriesID = "CountriesID";
	public const string Name = "Name";
	public const string Address1 = "Address1";
	public const string Address2 = "Address2";
	public const string City = "City";
	public const string Postcode = "Postcode";
	public const string Tel = "Tel";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class RequirementTypes
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class RateTypes
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class JobStatuses
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Requirements
{
    public const string Trades = "JobTitlesID";
    public const string ID = "ID";
    public const string PersonsID = "PersonsID";
    public const string CompaniesID = "CompaniesID";
    public const string JobStatusesID = "JobStatusesID";
    public const string SitesID = "SitesID";
    public const string RequirementTypesID = "RequirementTypesID";
    public const string Reference = "Reference";
    public const string NoRequired = "NoRequired";
    public const string Comments = "Comments";
    public const string HoursPerDay = "HoursPerDay";
    public const string DaysPerWeek = "DaysPerWeek";
    public const string DurationInWeeks = "DurationInWeeks";
    public const string EarliestStart = "EarliestStart";
    public const string DisplayJobOnWeb = "DisplayJobOnWeb";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
    public const string MustBringText = "MustBringText";
    public const string JobName = "JobName";
    public const string ConsultantID = "ConsultantID";
}


public class DiaryActions
{
    public const string ID = "ID";
    public const string UserId = "UserId";
    public const string ScreensID = "ScreensID";
    public const string RecordID = "RecordID";
    public const string Resource = "Resource";
    public const string ResourceID = "ResourceID";
    public const string Status = "Status";
    public const string Subject = "Subject";
    public const string Description = "Description";
    public const string Label = "Label";
    public const string StartTime = "StartTime";
    public const string EndTime = "EndTime";
    public const string Location = "Location";
    public const string AllDay = "AllDay";
    public const string EventType = "EventType";
    public const string RecurrenceInfo = "RecurrenceInfo";
    public const string ReminderInfo = "ReminderInfo";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class NotePriorities
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Notes
{
	public const string ID = "ID";
	public const string NotePrioritiesID = "NotePrioritiesID";
	public const string ScreensID = "ScreensID";
	public const string RecordID = "RecordID";
	public const string Note = "Note";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class UserGroups
{
	public const string ID = "ID";
	public const string PersonsID = "PersonsID";
	public const string GroupsID = "GroupsID";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class GroupRights
{
	public const string ID = "ID";
	public const string SystemObjectDetailsID = "SystemObjectDetailsID";
	public const string GroupsID = "GroupsID";
	public const string CanAccess = "CanAccess";
	public const string CanAdd = "CanAdd";
	public const string CanView = "CanView";
	public const string CanDelete = "CanDelete";
	public const string CanUpdate = "CanUpdate";
	public const string CanExecute = "CanExecute";
	public const string CanPrint = "CanPrint";
	public const string CanFull = "CanFull";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Groups
{
	public const string ID = "ID";
	public const string Code = "Code";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string SystemGroup = "SystemGroup";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class AttachmentTypes
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isForContact = "isForContact";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Attachments
{
    public const string ID = "ID";
    public const string AttachmentTypesID = "AttachmentTypesID";
    public const string ScreensID = "ScreensID";
    public const string RecordID = "RecordID";
    public const string AttPath = "AttPath";
    public const string AttType = "AttType";
    public const string Attachment = "Attachment";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class PaymentMethods
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class PaymentTypes
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class WorkTypes
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class JobTitles
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Trades
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class ContactTypes
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class MartialStatuses
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Genders
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class Persons
{
    public const string ID = "ID";
    public const string ConatactTypesID = "ConatactTypesID";
    public const string JobTitlesID = "JobTitlesID";
    public const string CompaniesID = "CompaniesID";
    public const string TradesID = "TradesID";
    public const string MartialStatusesID = "MartialStatusesID";
    public const string GendersID = "GendersID";
    public const string WorkTypesID = "WorkTypesID";
    public const string StatusesID = "StatusesID";
    public const string InternalRolesID = "InternalRolesID";
    public const string CountiesID = "CountiesID";
    public const string CountriesID = "CountriesID";
    public const string FirstName = "FirstName";
    public const string LastName = "LastName";
    public const string FullName = "FullName";
    public const string DOB = "DOB";
    public const string Comments = "Comments";
    public const string isStaff = "isStaff";
    public const string Address1 = "Address1";
    public const string Address2 = "Address2";
    public const string City = "City";
    public const string Postcode = "Postcode";
    public const string HomeTel = "HomeTel";
    public const string HomeFax = "HomeFax";
    public const string PersonalEmail = "PersonalEmail";
    public const string PersonalMobile = "PersonalMobile";
    public const string WorkTel = "WorkTel";
    public const string WorkFax = "WorkFax";
    public const string WorkEmail = "WorkEmail";
    public const string WorkMobile = "WorkMobile";
    public const string Password = "Password";
    public const string isActive = "isActive";
    public const string isPassport = "isPassport";
    public const string isProofOfAddress = "isProofOfAddress";
    public const string isBirthCertificate = "isBirthCertificate";
    public const string isCV = "isCV";
    public const string isPayDetails = "isPayDetails";
    public const string isVisa = "isVisa";
    public const string isDrivingLicence = "isDrivingLicence";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
    public const string UTR = "UTR";
    public const string NI = "NI";
    public const string isDriving = "isDriving";
}

public class PersonBackOffices
{
    public const string ID = "ID";
    public const string PersonsID = "PersonsID";
    public const string StatusesID = "StatusesID";
    public const string PayTypesID = "PayTypesID";
    public const string PaymentMethodsID = "PaymentMethodsID";
    public const string CompanyName = "CompanyName";
    public const string CompanyRegNo = "CompanyRegNo";
    public const string Comments = "Comments";
    public const string VATNumber = "VATNumber";
    public const string NationalInsuranceNo = "NationalInsuranceNo";
    public const string TaxCode = "TaxCode";
    public const string Address1 = "Address1";
    public const string Address2 = "Address2";
    public const string City = "City";
    public const string Postcode = "Postcode";
    public const string CountiesID = "CountiesID";
    public const string CountriesID = "CountriesID";
    
    public const string Tel = "Tel";
    public const string Fax = "Fax";
    public const string Email = "Email";
    public const string Website = "Website";
    public const string CrAddress1 = "CrAddress1";
    public const string CrAddress2 = "CrAddress2";
    public const string CrCity = "CrCity";
    public const string CrPostcode = "CrPostcode";
    public const string CrCountiesID = "CrCountiesID";
    public const string CrCountriesID = "CrCountriesID";
    public const string CrTel = "CrTel";
    public const string CrFax = "CrFax";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class CompanyBackOffices
{
	public const string ID = "ID";
	public const string CompaniesID = "CompaniesID";
	public const string IndustriesID = "IndustriesID";
	public const string StatusesID = "StatusesID";
	public const string CountiesID = "CountiesID";
	public const string CountriesID = "CountriesID";
	public const string NoOfEmployees = "NoOfEmployees";
	public const string TurnOver = "TurnOver";
	public const string CompanyName = "CompanyName";
	public const string Comments = "Comments";
	public const string Address1 = "Address1";
	public const string Address2 = "Address2";
	public const string City = "City";
	public const string Postcode = "Postcode";
	public const string Tel = "Tel";
	public const string Fax = "Fax";
	public const string Email = "Email";
	public const string Website = "Website";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class Statuses
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isForContact = "isForContact";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class TimeSheetFrequencies
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Industries
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Counties
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}


public class Countries
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class Companies
{
	public const string ID = "ID";
	public const string HeadquatersID = "HeadquatersID";
	public const string IndustriesID = "IndustriesID";
	public const string SourcesID = "SourcesID";
	public const string TradesID = "TradesID";
	public const string DivisionsID = "DivisionsID";
	public const string SectorsID = "SectorsID";
	public const string CompanyStatusesID = "CompanyStatusesID";
	public const string TimeSheetFrequenciesID = "TimeSheetFrequenciesID";
	public const string CountiesID = "CountiesID";
	public const string CountriesID = "CountriesID";
	public const string CompanyName = "CompanyName";
	public const string CompanyRegNo = "CompanyRegNo";
	public const string VATNumber = "VATNumber";
	public const string AccountID = "AccountID";
	public const string isVATStatus = "isVATStatus";
	public const string PaymentTermDays = "PaymentTermDays";
	public const string Comments = "Comments";
	public const string Address1 = "Address1";
	public const string Address2 = "Address2";
	public const string City = "City";
	public const string Postcode = "Postcode";
	public const string Tel = "Tel";
	public const string Fax = "Fax";
	public const string Email = "Email";
	public const string Website = "Website";
	public const string isHeadQuater = "isHeadQuater";
    public const string isParentCompany = "isParentCompany";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
    public const string ConsultantID = "ConsultantID";
    public const string ConsultantStartDate = "ConsultantStartDate";
}

/// <summary>
/// end rsys
/// </summary>
public class BranchRanks
{
	public const string ID = "ID";
	public const string BranchesID = "BranchesID";
	public const string Rank = "Rank";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class ProcessTypeBranchRanks
{
	public const string ID = "ID";
	public const string BranchesID = "BranchesID";
	public const string ProcessTypesID = "ProcessTypesID";
	public const string Rank = "Rank";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class ProcessBranchRanks
{
	public const string ID = "ID";
	public const string BranchesID = "BranchesID";
	public const string ProcessesID = "ProcessesID";
	public const string Rank = "Rank";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class ProcessClassificationRanks
{
    public const string ID = "ID";
    public const string BranchesID = "BranchesID";
    public const string ProcessesID = "ProcessesID";
    public const string MeasureClassificationsID = "MeasureClassificationsID";
    public const string Rank = "Rank";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class MeasureCodes
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string SeqNo = "SeqNo";
    public const string BranchesID = "BranchesID";
	public const string ProcessesID = "ProcessesID";
	public const string MeasureClassificationsID = "MeasureClassificationsID";
	public const string Rank = "Rank";
	public const string Description = "Description";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class BaselineSources
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class EmployeeResponsibles
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class DataSources
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Goals
{
	public const string ID = "ID";
	public const string Name = "Name";
    public const string Prefix = "Prefix";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Months
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string Number = "Number";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class HeadquaterSettings
{
	public const string ID = "ID";
	public const string BranchesID = "BranchesID";
	public const string FiscalStartMonthsID = "FiscalStartMonthsID";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class TimeDimensions
{
	public const string ID = "ID";
	public const string Date = "Date";
	public const string Year = "Year";
	public const string Quarter = "Quarter";
	public const string MonthNumberOfYear = "MonthNumberOfYear";
	public const string MonthNumberOfQuarter = "MonthNumberOfQuarter";
	public const string WeekNumberOfYear = "WeekNumberOfYear";
	public const string WeekNumberOfQuarter = "WeekNumberOfQuarter";
	public const string WeekNumberOfMonth = "WeekNumberOfMonth";
	public const string DayNumberOfYear = "DayNumberOfYear";
	public const string DayNumberOfQuarter = "DayNumberOfQuarter";
	public const string DayNumberOfMonth = "DayNumberOfMonth";
	public const string DayNumberOfWeek = "DayNumberOfWeek";
	public const string MonthName = "MonthName";
	public const string MonthNameAbbreviation = "MonthNameAbbreviation";
	public const string DayName = "DayName";
	public const string DayNameAbbreviation = "DayNameAbbreviation";
	public const string YYYYMMDD = "YYYYMMDD";
	
}

public class Polarities
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class ReviewFrequencies
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class MeasureDetails
{
    public const string ID = "ID";
    public const string MeasuresID = "MeasuresID";
    public const string Year = "Year";
    public const string Quater = "Quater";
    public const string Month = "Month";
    public const string Week = "Week";
    public const string Day = "Day";
    public const string Period = "Period";
    public const string Target = "Target";
    public const string Baseline = "Baseline";
    public const string Actual = "Actual";
    public const string Difference = "Difference";
    public const string WeekToDateDiff = "WeekToDateDiff";
    public const string MonthToDateDiff = "MonthToDateDiff";
    public const string QuaterToDateDiff = "QuaterToDateDiff";
    public const string YearToDateDiff = "YearToDateDiff";
    public const string DayToDateIndicator = "DayToDateIndicator";
    public const string WeekToDateIndicator = "WeekToDateIndicator";
    public const string QuaterToDateIndicator = "QuaterToDateIndicator";
    public const string MonthToDateIndicator = "MonthToDateIndicator";
    public const string YearToDateIndicator = "YearToDateIndicator";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Measures
{
    public const string ID = "ID";
    public const string MeasureCodesID = "MeasureCodesID";
    public const string MeasureUnitsID = "MeasureUnitsID";
    public const string ReviewFrequenciesID = "ReviewFrequenciesID";
    public const string ProcessesID = "ProcessesID";
    public const string SecProcessesID = "SecProcessesID";
    public const string PolaritiesID = "PolaritiesID";
    public const string ClassificationsID = "ClassificationsID";
    public const string GoalsID = "GoalsID";
    public const string Rank = "Rank";
    public const string Code = "Code";
    public const string Description = "Description";
    public const string Year = "Year";
    public const string SeqNo = "SeqNo";
    public const string DataSourcesID = "DataSourcesID";
    public const string BaselineSourcesID = "BaselineSourcesID";
    public const string EmployeeResponsiblesID = "EmployeeResponsiblesID";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class MeasureClassifications
{
    public const string ID = "ID";
    public const string Name = "Name";
    public const string Prefix = "Prefix";
    public const string isActive = "isActive";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class MeasureUnits
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class ProcessTypes
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Processes
{
	public const string ID = "ID";
	public const string ProcessTypesID = "ProcessTypesID";
	public const string Name = "Name";
    public const string Prefix = "Prefix";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class CompanyRecords
{
    public const string ID = "ID";
    public const string CompanyID = "CompanyID";
    public const string BranchesID = "BranchesID";
    public const string RecordID = "RecordID";
    public const string TableName = "TableName";
    public const string Attachment = "Attachment";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}


public class EmployeeRoles
{
	public const string ID = "ID";
	public const string EmployeesID = "EmployeesID";
	public const string RolesID = "RolesID";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}
public class OrgRoles
{
    public const string ID = "ID";
    public const string ParentRolesID = "ParentRolesID";
    public const string ChildRolesID = "ChildRolesID";
    public const string CreatedBy = "CreatedBy";
    public const string CreatedOn = "CreatedOn";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Roles
{
	public const string ID = "ID";
	public const string Name = "Name";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class Branches
{
	public const string ID = "ID";
	public const string HeadquatersID = "HeadquatersID";
	public const string Name = "Name";
	public const string isHeadQuater = "isHeadQuater";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Employees
{
	public const string ID = "ID";
	public const string BranchesID = "BranchesID";
	public const string FirstName = "FirstName";
	public const string LastName = "LastName";
	public const string Email = "Email";
	public const string Password = "Password";
	public const string isAppUser = "isAppUser";
	public const string isActive = "isActive";
	public const string CreatedBy = "CreatedBy";
	public const string CreatedOn = "CreatedOn";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class AppSettings
{
	public const string ID = "ID";
	public const string SagePath = "SagePath";
    public const string SageUser = "SageUser";
    public const string SagePwd = "SagePwd";
    public const string Version = "Version";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}


public class SODetails
{
    public const string ID = "ID";
    public const string SOsID = "SOsID";
    public const string ItemsID = "ItemsID";
    public const string ItemName = "ItemName";
    public const string SuppliersID = "SuppliersID";
    public const string SupplierCurrency = "SupplierCurrency";
    public const string Qty = "Qty";
    public const string ExRate = "ExRate";
    public const string SupplierPrice = "SupplierPrice";
    public const string DiscountPerc = "DiscountPerc";
    public const string ImportDuty = "ImportDuty";
    public const string AddCustomChargesPerc = "AddCustomChargesPerc";
    public const string PackandCarriagePerc = "PackandCarriagePerc";
    public const string PerformaceMarginPerc = "PerformaceMarginPerc";
    public const string DealerMarginPerc = "DealerMarginPerc";
    public const string DealerDiscPerc = "DealerDiscPerc";
    public const string isPriceSensitive = "isPriceSensitive";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}


public class Customers
{
	public const string ID = "ID";
	public const string CurrencySymbolsID = "CurrencySymbolsID";
	public const string Code = "Code";
	public const string Name = "Name";
    public const string DealerMarginPerc = "DealerMarginPerc";
	public const string isActive = "isActive";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class SOs
{
    public const string ID = "ID";
    public const string CustomersID = "CustomersID";
    public const string Code = "Code";
    public const string ExRate = "ExRate";
    public const string Date = "Date";
    public const string isExported = "isExported";
    public const string OrderNo = "OrderNo";
    public const string Contact = "Contact";
    public const string Notes1 = "Notes1";
    public const string Notes2 = "Notes2";
    public const string Comments = "Comments";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class PoDetails
{
    public const string ID = "ID";
    public const string POsID = "POsID";
    public const string ItemsID = "ItemsID";
    public const string isDiscountApp = "isDiscountApp";
    public const string PricingOptionsID = "PricingOptionsID";
    public const string Qty = "Qty";
    public const string SupplierPrice = "SupplierPrice";
    public const string ExRate = "ExRate";
    public const string DiscountPerc = "DiscountPerc";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class POs
{
    public const string ID = "ID";
    public const string SuppliersID = "SuppliersID";
    public const string CurrencySymbolsID = "CurrencySymbolsID";
    public const string SupplierOrderTypesID = "SupplierOrderTypesID";
    public const string Code = "Code";
    public const string Date = "Date";
    public const string Comments = "Comments";
    public const string isExported = "isExported";
    public const string ExRate = "ExRate";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}


public class PricingOptions
{
	public const string ID = "ID";
	public const string SupplierOrderTypesID = "SupplierOrderTypesID";
	public const string Code = "Code";
	public const string InvStartValue = "InvStartValue";
	public const string InvEndValue = "InvEndValue";
	public const string Discount = "Discount";
	public const string isActive = "isActive";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class DeliveryMonths
{
	public const string ID = "ID";
    public const string PricingOptionsID = "PricingOptionsID";
	public const string MonthsID = "MonthsID";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class OrderMonths
{
    public const string ID = "ID";
    public const string PricingOptionsID = "PricingOptionsID";
    public const string MonthsID = "MonthsID";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class SupplierOrderTypes
{
    public const string ID = "ID";
    public const string SuppliersID = "SuppliersID";
    public const string OrderType = "OrderType";
    public const string MinOrderAmt = "MinOrderAmt";
    public const string isActive = "isActive";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class Items
{
    public const string ID = "ID";
    public const string SuppliersID = "SuppliersID";
    public const string StockTypesID = "StockTypesID";
    public const string Code = "Code";
    public const string Name = "Name";
    public const string UM = "UM";
    public const string isDiscountApp = "isDiscountApp";
    public const string Price = "Price";
    public const string isPriceSensitive = "isPriceSensitive";
    public const string PriceForPriceSensitive = "PriceForPriceSensitive";
    public const string isActive = "isActive";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}
public class ExistingData
{
    public const string ID = "ID";
    public const string Code = "Code";
    public const string Name = "Name";
}
public class Users
{
    public const string ID = "ID";
    public const string FirstName = "FirstName";
    public const string LastName = "LastName";
    public const string Phone = "Phone";
    public const string Mobile = "Mobile";
    public const string Email = "Email";
    public const string Login = "Login";
    public const string Password = "Password";
    public const string isAdmin = "isAdmin";
    public const string isActive = "isActive";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}


public class CurrencySymbols
{
    public const string ID = "ID";
    public const string Code = "Code";
    public const string Name = "Name";
    public const string Symbol = "Symbol";
    public const string isDefault = "isDefault";
    public const string isActive = "isActive";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}

public class CurrencyConversions
{
	public const string ID = "ID";
    public const string CurrencySymbolsID = "CurrencySymbolsID";
	public const string ConversionRate = "ConversionRate";
	public const string Date = "Date";
	public const string CreatedOn = "CreatedOn";
	public const string CreatedBy = "CreatedBy";
	public const string LastModifiedBy = "LastModifiedBy";
	public const string LastModifiedOn = "LastModifiedOn";
}

public class Suppliers
{
    public const string ID = "ID";
    public const string Code = "Code";
    public const string Name = "Name";
    public const string CurrencySymbolsID = "CurrencySymbolsID";
    public const string Prefix = "Prefix";
    public const string Discount = "Discount";
    public const string PerformacePerc = "PerformacePerc";
    public const string MinOrderAmt = "MinOrderAmt";
    public const string CustPackCarr = "CustPackCarr";
    public const string SalesOrderDiscPerc = "SalesOrderDiscPerc";
    public const string DealerMarginPerc = "DealerMarginPerc";
    public const string ImportDuty = "ImportDuty";
    public const string isActive = "isActive";
    public const string CreatedOn = "CreatedOn";
    public const string CreatedBy = "CreatedBy";
    public const string LastModifiedBy = "LastModifiedBy";
    public const string LastModifiedOn = "LastModifiedOn";
}


