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
    /// 匯出測試檔案
    /// </summary>
    /// <returns>測試檔案</returns>
    void Export();
}

public sealed class ExportTestService : IExportTestService
{
    /// <inheritdoc />
    public void Export()
    {
        var filePath = "D:\\YMLExport";
        var fileName = "exportTest" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".yml";

        var yList = new string[] { "度數" };

        var yListFlow = new YamlSequenceNode();
        yListFlow.Style = SequenceStyle.Flow;
        yListFlow.Add("度數");

        var xList = new string[] { "溫度1", "照度1", "溫度2", "照度2" };

        var xListFlow = new YamlSequenceNode();
        xListFlow.Style = SequenceStyle.Flow;
        xListFlow.Add("溫度1");
        xListFlow.Add("照度1");
        xListFlow.Add("溫度2");
        xListFlow.Add("照度2");
        var a = xListFlow.ToList();

        var item = new Item
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

        var result = SerializeToYML(item);
        WriteYMLToFile(filePath + "\\" + fileName, result);
    }

    private string SerializeToYML(Item item)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        return serializer.Serialize(item);
    }

    private void WriteYMLToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }
}
