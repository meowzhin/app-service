using FwksLabs.Libs.Core.Configuration.Settings;

namespace FwksLabs.ResumeService.Core.Configuration.Settings;

//public record AppSettings
//{
//    public SecuritySettings Security { get; set; } = new();
//    public PersistenceSettings Persistence { get; set; } = new();
//    public static int[] ApiVersions => [1, 2];
//}

public record AppSettings(
    InfoSettings Info,
    AuthoritySettings Authority
);