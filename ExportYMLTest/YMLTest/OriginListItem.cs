using System.Data;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace ExportYMLTest.YMLTest;

/// <summary>
/// 匯出樣板 (原始清單)
/// </summary>
public class OriginListItem
{
    public OriginListDataset Dataset { get; set; } = new OriginListDataset();

    public FeatureSelect FeatureSelect { get; set; } = new FeatureSelect();

    public Model Model { get; set; } = new Model();

    public Response Response { get; set; } = new Response();

    [YamlIgnore]
    public string? IgnoreTest { get; set; }
}

public class OriginListDataset
{
    public string Directory { get; set; } = string.Empty;

    // [YamlMember(ScalarStyle = ScalarStyle.SingleQuoted)]
    public string Filename { get; set; } = string.Empty;
    
    public IList<string> YTargets { get; set; } = new List<string>();

    public IList<string> XFeatures { get; set; } = new List<string>();
}
