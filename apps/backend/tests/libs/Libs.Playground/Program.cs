#pragma warning disable S1481 // Unused local variables should be removed
#pragma warning disable S1075 // Absolute Paths
#pragma warning disable S3903 // Namespace

using System.Text.Json;
using Npgsql;

try
{

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

internal record EntityStub(Guid Id);