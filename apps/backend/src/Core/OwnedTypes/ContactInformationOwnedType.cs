namespace FwksLabs.ResumeService.Core.OwnedTypes;

public record ContactInformationOwnedType(ICollection<string> Phones, ICollection<string> Emails);
