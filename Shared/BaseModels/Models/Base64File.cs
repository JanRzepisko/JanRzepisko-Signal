using Shared.PublicEnums;

namespace Shared.BaseModels.Models;

public class Base64File
{
    public string Base64 { get; set; }
    public FileType FileType { get; set; }
}