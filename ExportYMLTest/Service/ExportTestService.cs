using ExportYMLTest.YMLTest;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ExportYMLTest.Service;

public interface IExportTestService
{
    /// <summary>
    /// 匯出測試檔案 (CamelCase)
    /// </summary>
    /// <returns>測試檔案</returns>
    void ExportByCamelCase();

    /// <summary>
    /// 匯出測試檔案 (PascalCase)
    /// </summary>
    /// <returns>測試檔案</returns>
    void ExportByPascalCase();

    /// <summary>
    /// 匯出測試檔案 (Underscored)
    /// </summary>
    /// <returns>測試檔案</returns>
    void ExportByUnderscored();

    /// <summary>
    /// 匯出測試檔案 (原始陣列)
    /// </summary>
    /// <returns>測試檔案</returns>
    void ExportByOriginList();
}

public sealed class ExportTestService : IExportTestService
{
    /// <inheritdoc />
    public void ExportByCamelCase()
    {
        var filePath = "D:\\YMLExport";
        var fileName = "CamelCaseTest" + ".yml";
        var item = GenerateYaml();

        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var result = serializer.Serialize(item);
        WriteYMLToFile(filePath + "\\" + fileName, result);
    }

    /// <inheritdoc />
    public void ExportByPascalCase()
    {
        var filePath = "D:\\YMLExport";
        var fileName = "PascalCaseTest" + ".yml";
        var item = GenerateYaml();

        var serializer = new SerializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();
        var result = serializer.Serialize(item);
        WriteYMLToFile(filePath + "\\" + fileName, result);
    }

    /// <inheritdoc />
    public void ExportByUnderscored()
    {
        var filePath = "D:\\YMLExport";
        var fileName = "UnderscoredTest" + ".yml";
        var item = GenerateYaml();

        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        var result = serializer.Serialize(item);
        WriteYMLToFile(filePath + "\\" + fileName, result);
    }

    /// <inheritdoc />
    private Item GenerateYaml()
    {
        var yListFlow = new YamlSequenceNode();
        yListFlow.Style = SequenceStyle.Flow;
        yListFlow.Add("度數");

        var xListFlow = new YamlSequenceNode();
        xListFlow.Style = SequenceStyle.Flow;
        xListFlow.Add("溫度1");
        xListFlow.Add("照度1");
        xListFlow.Add("溫度2");
        xListFlow.Add("照度2");

        return new Item
        {
            Dataset = new Dataset
            {
                Directory = "demo",
                Filename = "exportTest.csv",
                YTargets = yListFlow,
                XFeatures = xListFlow
            },
            FeatureSelect = new FeatureSelect
            {
                Method = "BestSubsetSelection",
            },
            Model = new Model
            {
                Name = "LinearRegression",
            },
            Response = new Response
            {
                Api = "http://server-container:8000/api/PredictiveModel/Callback"
            }
        };
    }

    private void WriteYMLToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    /// <inheritdoc />
    public void ExportByOriginList()
    {
        var filePath = "D:\\YMLExport";
        var fileName = "OriginList" + ".yml";

        var yList = new string[] { "度數" };
        var xList = new string[] { "溫度1", "照度1", "溫度2", "照度2" };

        var item =  new OriginListItem
        {
            Dataset = new OriginListDataset
            {
                Directory = "demo",
                Filename = "exportTest.csv",
                YTargets = yList,
                XFeatures = xList
            },
            FeatureSelect = new FeatureSelect
            {
                Method = "BestSubsetSelection",
            },
            Model = new Model
            {
                Name = "LinearRegression",
            },
            Response = new Response
            {
                Api = "http://server-container:8000/api/PredictiveModel/Callback"
            }
        };

        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        var result = serializer.Serialize(item);
        WriteYMLToFile(filePath + "\\" + fileName, result);
    }
}
