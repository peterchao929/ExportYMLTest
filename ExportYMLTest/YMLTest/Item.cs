using System.Data;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace ExportYMLTest.YMLTest;

/// <summary>
/// 匯出樣板
/// </summary>
public class Item
{
    public Dataset Dataset { get; set; } = new Dataset();

    public FeatureSelect FeatureSelect { get; set; } = new FeatureSelect();

    public Model Model { get; set; } = new Model();

    public Response Response { get; set; } = new Response();

    [YamlIgnore]
    public string? IgnoreTest { get; set; }
}

public class Dataset
{
    public string Directory { get; set; } = string.Empty;

    // [YamlMember(ScalarStyle = ScalarStyle.SingleQuoted)]
    public string Filename { get; set; } = string.Empty;
    
    public YamlSequenceNode YTargets { get; set; } = new YamlSequenceNode();

    public YamlSequenceNode XFeatures { get; set; } = new YamlSequenceNode();
}

public class FeatureSelect
{
    public string Method { get; set; } = string.Empty;
}

public class Model
{
    public string Name { get; set; } = string.Empty;
}

public class Response
{
    public string Api { get; set; } = string.Empty;
}
